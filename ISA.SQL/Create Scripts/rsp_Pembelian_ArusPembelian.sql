USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Pembelian_ArusPembelian]    Script Date: 04/21/2011 10:06:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==============================================================
-- Author:		Stephanie
-- Create date: 21 Apr 2011
-- Description:	Pembelian > Laporan > Pembelian > Arus Pembelian
-- E.g.	: [dbo].[rsp_Pembelian_ArusPembelian] 
--			@fromDate = '2007/05/10', @toDate = '2007/05/20',
--			@mode = 'B', @searchArg = 'BOLT'
-- ==============================================================
CREATE PROCEDURE [dbo].[rsp_Pembelian_ArusPembelian] 
	-- Add the parameters for the stored procedure here
	 @fromDate datetime,
	 @toDate datetime,
	 @mode varchar(1), -- 'N' = Nota, 'B' = Barang
	 @barangID varchar(23) = NULL,
	 @searchArg varchar(73) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
		
    -- Insert statements for procedure here
	
	/* Arus Pembelian berdasarkan Nota */
	IF @mode = 'N' 
	BEGIN
		SELECT
			h.NoNota,
			h.TglNota,
			d.BarangID,
			s.NamaStok AS NamaBarang,
			s.SatSolo AS Satuan,
			d.QtyNota
		FROM dbo.NotaPembelian h
			INNER JOIN dbo.NotaPembelianDetail d ON h.RowID = d.HeaderID
			LEFT OUTER JOIN dbo.Stok s ON d.BarangID = s.BarangID			
		WHERE
			h.TglSuratJalan BETWEEN @fromDate AND @toDate 
			AND 
			(
				d.barangID = @barangID
					OR
				(
					@barangID IS NULL
						AND
					(
						s.NamaStok LIKE '%'+@searchArg+'%'
							OR
						@searchArg IS NULL
					)
				)
			)
		ORDER BY h.TglNota, s.NamaStok
	END 

	/* Arus Pembelian berdasarkan Barang */
	ELSE
	BEGIN
		DECLARE @barang TABLE 
		(
			BarangID varchar(23), 
			NamaBarang varchar(73),
			Satuan varchar(3), 
			QtyNota int
		)
		
		INSERT INTO @barang
		SELECT 
			d.BarangID,
			s.NamaStok AS NamaBarang,
			s.SatSolo AS Satuan,
			SUM(d.QtyNota)	AS QtyNota
		FROM dbo.NotaPembelian h
			INNER JOIN dbo.NotaPembelianDetail d ON h.RowID = d.HeaderID
			LEFT OUTER JOIN dbo.Stok s ON d.BarangID = s.BarangID
		WHERE
			h.TglSuratJalan BETWEEN @fromDate AND @toDate
			AND 
			(
				d.barangID = @barangID
					OR
				(
					@barangID IS NULL
						AND
					(
						s.NamaStok LIKE '%'+@searchArg+'%'
							OR
						@searchArg IS NULL
					)
				)
			)	
		GROUP BY d.BarangID, s.NamaStok, s.SatSolo
		ORDER BY s.NamaStok	
		
		SELECT
			nota.NoNota,
			nota.TglNota,
			barang.BarangID,
			barang.NamaBarang,
			barang.Satuan,
			barang.QtyNota
		FROM @barang barang
			OUTER APPLY
			(
				SELECT TOP 1
					a.TglNota,
					a.NoNota
				FROM dbo.NotaPembelian a
					INNER JOIN dbo.NotaPembelianDetail b ON a.RowID = b.HeaderID
				WHERE 
					(a.TglSuratJalan BETWEEN @fromDate AND @toDate)
					AND
					b.BarangID = barang.BarangID
				ORDER BY a.TglSuratJalan
			) nota			
	END
		
	
END
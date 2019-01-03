USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Pembelian_ArusPembelianDanPenjualan]    Script Date: 04/20/2011 09:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===================================================
-- Author:		Stephanie
-- Create date: 20 Apr 2011
-- Description:	Pembelian > Laporan > Pembelian 
--				> Arus Pembelian dan Penjualan
-- ===================================================
CREATE PROCEDURE [dbo].[rsp_Pembelian_ArusPembDanPenj] 
	-- Add the parameters for the stored procedure here
	 @fromSJPembDate datetime,
	 @toSJPembDate datetime,
	 @fromSJPenjDate datetime,
	 @toSJPenjDate datetime,
	 @barangID varchar(23) = NULL,
	 @searchArgs varchar(73) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
		
    -- Insert statements for procedure here
	DECLARE @tabelPB TABLE
	(BarangID varchar(23), QtyBeli int)

	DECLARE @tabelPJ TABLE
	(BarangID varchar(23), QtyJual int)

	/* Ambil data pembelian */
	INSERT INTO @tabelPB
	SELECT 
		b.BarangID,
		SUM(b.QtyNota) AS QtyBeli
	FROM dbo.NotaPembelian a
	LEFT OUTER JOIN dbo.NotaPembelianDetail b ON a.RowID = b.HeaderID
	LEFT OUTER JOIN dbo.Stok s ON b.BarangID = s.BarangID
	WHERE
		a.TglSuratJalan BETWEEN @fromSJPembDate AND @toSJPembDate
			AND
		(
			b.BarangID = @barangID
				OR
			(
				@barangID IS NULL 
				AND
				(s.NamaStok LIKE '%'+@searchArgs+'%' OR @searchArgs IS NULL)
			)
		)
	GROUP BY b.BarangID

	/* Ambil data penjualan */
	INSERT INTO @tabelPJ
	SELECT 
		c.BarangID,
		SUM(b.QtySuratJalan) AS QtyJual
	FROM dbo.NotaPenjualan a
	LEFT OUTER JOIN dbo.NotaPenjualanDetail b ON a.RowID = b.HeaderID
	LEFT OUTER JOIN dbo.OrderPenjualanDetail c ON b.DODetailID = c.RowID
	LEFT OUTER JOIN dbo.Stok s ON c.BarangID = s.BarangID
	WHERE
		a.TglSuratJalan BETWEEN @fromSJPenjDate AND @toSJPenjDate
			AND
		(
			c.BarangID = @barangID
				OR
			(
				@barangID IS NULL 
				AND
				(s.NamaStok LIKE '%'+@searchArgs+'%' OR @searchArgs IS NULL)
			)
		)
	GROUP BY c.BarangID


	/* Query data report */
	SELECT 
		PB.BarangID,
		s.NamaStok AS NamaBarang,
		s.SatSolo AS Satuan,
		PB.QtyBeli,
		PJ.QtyJual,
		(PB.QtyBeli - PJ.QtyJual) AS Selisih,
		((PJ.QtyJual/PB.QtyBeli) * 100) AS Persen
	FROM  @tabelPB PB
	LEFT OUTER JOIN dbo.Stok s ON PB.BarangID = s.BarangID
	LEFT OUTER JOIN @tabelPJ PJ ON PB.BarangID = PJ.BarangID
	ORDER BY s.NamaStok
	
				
END

USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_NotaPembelianDetail_LIST_ForReturHistori]    Script Date: 04/15/2011 08:25:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ====================================================
-- Author:		Stephanie
-- Create date: 14 Apr 11
-- Description:	List data on table NotaPembelianDetail
--				Untuk Pembuatan Retur Pembelian Histori
-- ====================================================
CREATE PROCEDURE [dbo].[usp_NotaPembelianDetail_LIST_ForReturHistori] 
	-- Add the parameters for the stored procedure here
	@barangID varchar(23) = NULL,
	@tglKeluar datetime =  NULL,
	@pemasok varchar(19)= NULL,
	@notaBeliDetailID uniqueidentifier = NULL -- Di input hanya bila edit tanpa ganti barang	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    -- Insert statements for procedure here

	SELECT TOP 1
		x.RowID,
		x.RecordID,
		x.NoNota,
		x.TglNota,
		x.TglTerima,
		x.Pemasok,
		x.NamaBarang,
		x.Satuan,
		(CASE WHEN x.Koreksi IS NULL
			THEN x.HrgBeliNet + ((x.HrgBeliNet * x.PPN)/100)
			ELSE x.HrgBeliNet END) AS HrgBeliNet,
		x.QtyTerima,
		x.QtyRetur,
		(x.QtyTerima - x.QtyRetur) AS QtySisa
	FROM
	(
		SELECT 
			d.RowID,
			d.RecordID,
			h.NoNota,
			h.TglNota,
			h.TglTerima,
			h.Pemasok,
			s.NamaStok AS NamaBarang,
			s.SatSolo AS Satuan,
			(CASE WHEN k.RowID is NULL 
				THEN dbo.fnHitungNet3Disc((dbo.fnGetHargaBeli(d.BarangID, h.TglNota, NULL)),
					d.Disc1, d.Disc2, d.Disc3, '') - d.Pot
				ELSE k.HrgBeliBaru END) AS HrgBeliNet,
			(CASE WHEN k.RowID is NULL
				THEN d.QtySuratJalan ELSE k.QtyNotaBaru END) AS QtyTerima,
			ISNULL((SELECT SUM(ISNULL(r.QtyGudang,0)) FROM dbo.ReturPembelianDetail r
				WHERE r.NotaBeliDetailID = d.RowID), 0) AS QtyRetur,
			d.PPN,
			k.RowID AS Koreksi
		FROM dbo.NotaPembelianDetail d
			LEFT OUTER JOIN dbo.NotaPembelian h ON d.HeaderID = h.RowID
			LEFT OUTER JOIN dbo.Stok s ON d.BarangID = s.BarangID
			LEFT OUTER JOIN dbo.KoreksiPembelian k ON d.RowID= k.NotaBeliDetailID

		WHERE
			(d.RowID = @notaBeliDetailID)
			OR
			(
				@notaBeliDetailID IS NULL
				AND
				d.BarangID = @barangID
				AND 
				h.Pemasok = @pemasok	
				AND
				h.TglTerima < @tglKeluar
				AND
				(	-- Bila ada koreksi ambil yang terbaru saja		
					k.RowID IS NULL
						OR	
					k.RowID = dbo.fnGetKoreksi(d.RowID, 'NPB', @tglKeluar)
				)					
			)
	) AS x
	
	WHERE 
		(x.RowID = @notaBeliDetailID)
		OR
		( (@notaBeliDetailID IS NULL) AND ((x.QtyTerima - x.QtyRetur) > 0) )

	ORDER BY x.TglNota, SUBSTRING(x.recordID, 4, 16) DESC        
		    
END
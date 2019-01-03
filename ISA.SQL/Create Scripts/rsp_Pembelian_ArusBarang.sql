USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Pembelian_ArusBarang]    Script Date: 04/20/2011 16:15:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =========================================================== 
-- Author:		Stephanie
-- Create date: 19 Apr 2011
-- Description:	Pembelian > Laporan > Pembelian > Arus Barang
-- =========================================================== 
CREATE PROCEDURE [dbo].[rsp_Pembelian_ArusBarang] 
	-- Add the parameters for the stored procedure here
	 @tglTerima datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
		
    -- Insert statements for procedure here
	
	SELECT
		d.BarangID,
		s.NamaStok AS NamaBarang,
		s.SatSolo AS Satuan,
		SUM(ISNULL(d.QtyNota,0)) AS QtyNota, 
		SUM( ISNULL(
			(d.QtyNota  *
			dbo.fnHitungNet3Disc(
				(d.QtyNota * dbo.fnGetHargaBeli(d.BarangID, h.TglNota, NULL)),
				d.Disc1, d.Disc2, d.Disc3, d.DiscFormula))
			,0)) AS NilaiBeli
	FROM dbo.NotaPembelian h
		INNER JOIN dbo.NotaPembelianDetail d ON h.RowID = d.HeaderID
		LEFT OUTER JOIN dbo.Stok s ON d.BarangID = s.BarangID
	
	WHERE
		h.TglTerima = @tglTerima

	GROUP BY d.BarangID, s.NamaStok, s.SatSolo

	ORDER BY s.NamaStok
	

END

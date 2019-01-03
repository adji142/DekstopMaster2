USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_CetakNotaReturJual]    Script Date: 03/24/2011 09:39:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- Author:		Stephanie
-- Create date: 24 Mar 2011
-- Description:	Penjualan > Nota Retur > Cetak Nota Retur
-- ============================================================
ALTER PROCEDURE [dbo].[rsp_CetakNotaReturJual] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    -- Insert statements for procedure here
	SELECT
		a.NoMPR,
		a.NoNotaRetur,
		a.TglMPR,
		a.TglNotaRetur,		
		LEFT(a.Penerima, 17) AS Penerima,
		f.NamaToko,
		LEFT(f.Alamat, 73) AS Alamat,
		f.Daerah,
		f.Kota,
		f.WilID,
		e.NamaStok AS NamaBarang,
		c.NoNota AS NotaAsal,
		d.NamaSales,
		b.QtyGudang,
		c.HrgJual,
		ISNULL(dbo.fnHitungNet3Disc((b.QtyGudang * c.HrgJual), c.Disc1, c.Disc2, c.Disc3, c.DiscFormula)
			- (b.QtyGudang * c.Pot), 0)	
			AS JmlHrg,
		g.Keterangan AS Kategori
	FROM dbo.ReturPenjualan a 
		LEFT OUTER JOIN dbo.ReturPenjualanDetail b ON a.ReturID = b.ReturID
		LEFT OUTER JOIN dbo.vwNotaPenjualanDetail c ON b.NotaJualDetailID = c.RowID
		LEFT OUTER JOIN dbo.Sales d ON c.KodeSales = d.SalesID 
		LEFT OUTER JOIN dbo.Stok e ON c.BarangID = e.BarangID
		LEFT OUTER JOIN dbo.Toko f ON a.KodeToko = f.KodeToko
		LEFT OUTER JOIN dbo.Kategori g ON b.Kategori = g.Kategori
	WHERE 
		a.RowID = @rowID

	UNION ALL

	SELECT
		a.NoMPR,
		a.NoNotaRetur,
		a.TglMPR,
		a.TglNotaRetur,
		LEFT(a.Penerima, 17) AS Penerima,
		e.NamaToko,
		LEFT(e.Alamat, 73) AS Alamat,
		e.Daerah,
		e.Kota,
		e.WilID,
		d.NamaStok AS NamaBarang,
		b.NotaAsal,
		c.NamaSales,
		b.QtyGudang,
		b.HrgJual,
		(b.QtyGudang * b.HrgJual) - (b.QtyGudang * b.Pot) AS JmlHrg,
		f.Keterangan AS Kategori
	FROM dbo.ReturPenjualan a
		LEFT OUTER JOIN dbo.ReturPenjualanTarikanDetail b ON a.ReturID = b.ReturID
		LEFT OUTER JOIN dbo.Sales c ON b.KodeSales = c.SalesID 
		LEFT OUTER JOIN dbo.Stok d ON b.BarangID = d.BarangID 
		LEFT OUTER JOIN dbo.Toko e ON a.KodeToko = e.KodeToko
		LEFT OUTER JOIN dbo.Kategori f ON b.Kategori = f.Kategori
	WHERE 
		a.RowID = @rowID

	ORDER BY NamaBarang ASC


	/* Update setelah cetak NotaRetur */

	UPDATE ISAdb.dbo.ReturPenjualan
	SET NPrint = 2
	WHERE RowID = RowID	
				
END

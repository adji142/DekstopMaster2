USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_CetakNotaKoreksiJual]    Script Date: 04/01/2011 15:48:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- Author:		Stephanie
-- Create date: 01 Apr 11
-- Description:	PJ3 > Transaksi > Cetak Nota Koreksi Penjualan
-- ============================================================
CREATE PROCEDURE [dbo].[rsp_CetakNotaKoreksiJual] 
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
		t.NamaToko,
		t.Alamat,
		t.Kota,
		a.NoNota,
		a.TglNota,
		/* Data nota */
		s.NamaStok AS NamaBarang,
		b.QtyNota,
		s.SatSolo AS Satuan,
		d.HrgJual,
		(b.QtyNota * d.HrgJual) AS JmlHrg,
		d.Disc1,
		d.Disc2,
		d.Disc3,
		((b.QtyNota * d.Pot) 
			+ ((b.QtyNota * d.HrgJual)
			- dbo.fnHitungNet3Disc((b.QtyNota * d.HrgJual), d.Disc1, d.Disc2, d.Disc3, d.DiscFormula)))
			AS Disc,
		/* Data koreksi */
		c.QtyNotaBaru,
		c.HrgJualBaru,
		(c.QtyNotaBaru * c.HrgJualBaru) AS JmlHrgKoreksi,
		((c.QtyNotaBaru * d.Pot) 
			+ ((c.QtyNotaBaru * c.HrgJualBaru)
			- dbo.fnHitungNet3Disc((c.QtyNotaBaru * c.HrgJualBaru), d.Disc1, d.Disc2, d.Disc3, d.DiscFormula)))
			AS DiscKoreksi
	FROM dbo.NotaPenjualan a
		LEFT OUTER JOIN dbo.NotaPenjualanDetail b ON a.RowID = b.HeaderID
		LEFT OUTER JOIN dbo.KoreksiPenjualan c ON b.RowID = c.NotaJualDetailID
		LEFT OUTER JOIN dbo.OrderPenjualanDetail d ON b.DODetailID = d.RowID
		LEFT OUTER JOIN dbo.OrderPenjualan e ON a.DOID = e.RowID
		LEFT OUTER JOIN dbo.Toko t ON e.KodeToko = t.KodeToko
		LEFT OUTER JOIN dbo.Stok s ON d.BarangID = s.BarangID
	WHERE 
		a.RowID = @rowID
		AND c.RowID IS NOT NULL

END
 
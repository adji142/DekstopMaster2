USE [ISAdb]
GO
/****** Object:  View [dbo].[vwReturPenjualanDetail]    Script Date: 04/01/2011 13:53:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwReturPenjualanDetail] 
AS 
SELECT 
	a.RowID, 
	a.HeaderID, 
	a.NotaJualDetailID, 
	a.RecordID,
	a.ReturID, 
	a.NotaJualDetailRecID, 
	c.NoNota AS NotaAsal, 
	c.TglNota,
	c.TglTerima, -- Tgl terima toko dari nota penjualan
	a.KodeRetur, 
	c.BarangID,
	e.NamaStok,
	e.SatSolo AS Satuan,
	c.KodeSales,
	d.NamaSales,
	b.KodeToko, 
	a.QtyMemo, 
	a.QtyTarik, 
	ISNULL(a.QtyTerima, 0) AS QtyTerima, 
	a.QtyGudang, 
	a.QtyTolak, 
	c.Pot,
	c.HrgJual,
	a.Catatan1, 
	a.Catatan2, 
	b.TglGudang,
	a.SyncFlag, 
	a.Kategori, 
	a.KodeGudang, 
	a.NoACC, 
	a.LastUpdatedBy, 
	a.LastUpdatedTime,
	c.Disc1,
	c.Disc2,
	c.Disc3,
	c.DiscFormula,
	b.Cabang1,
	c.Expedisi,
	c.QtySuratJalan,
	ISNULL((SELECT SUM(ISNULL(r.QtyGudang, 0)) FROM dbo.ReturPenjualanDetail r (NOLOCK) 
		WHERE r.NotaJualDetailID = a.NotaJualDetailID), 0) As QtyRetur,
	ISNULL(dbo.fnHitungNet3Disc((a.QtyTerima * c.HrgJual), c.Disc1, c.Disc2, c.Disc3, c.DiscFormula) 
		- (a.QtyTerima * c.Pot) , 0) AS HrgNetto, -- Perhitungan HrgNet untuk RJ3
	ISNULL(dbo.fnHitungNet3Disc((a.QtyTarik * c.HrgJual), c.Disc1, c.Disc2, c.Disc3, c.DiscFormula) 
		- (a.QtyTarik * c.Pot) , 0) AS HrgNetto1, -- Perhitungan HrgNet untuk MPR
	ISNULL(dbo.fnHitungNet3Disc((a.QtyGudang * c.HrgJual), c.Disc1, c.Disc2, c.Disc3, c.DiscFormula) 
		- (a.QtyGudang * c.Pot) , 0) AS HrgNetto2, -- Perhitungan HrgNet untuk NotaRetur
	0 AS HrgNetto3
FROM dbo.ReturPenjualanDetail a (NOLOCK) 
	LEFT OUTER JOIN dbo.ReturPenjualan b (NOLOCK) ON a.ReturID = b.ReturID
	LEFT OUTER JOIN dbo.vwNotaPenjualanDetail c (NOLOCK) ON a.NotaJualDetailID = c.RowID
	LEFT OUTER JOIN dbo.Sales d (NOLOCK) ON c.KodeSales = d.SalesID 
	LEFT OUTER JOIN dbo.Stok e (NOLOCK) ON c.BarangID = e.BarangID 

UNION ALL

SELECT 
	a.RowID, 
	a.HeaderID, 
	NULL AS NotaJualDetailID, 
	a.RecordID,
	a.ReturID, 
	NULL AS NotaJDetailRecID, 
	a.NotaAsal, 
	NULL AS TglNota,
	NULL AS TglTerima,
	a.KodeRetur, 
	a.BarangID,
	d.NamaStok,
	d.SatSolo AS Satuan,
	a.KodeSales,
	c.NamaSales,
	b.KodeToko, 
	a.QtyMemo, 
	a.QtyTarik, 
	ISNULL(a.QtyTerima, 0) AS QtyTerima, 
	a.QtyGudang, 
	a.QtyTolak, 
	a.Pot,
	a.HrgJual,
	a.Catatan1, 
	a.Catatan2, 
	b.TglGudang,
	a.SyncFlag, 
	a.Kategori, 
	a.KodeGudang, 
	a.NoACC, 
	a.LastUpdatedBy, 
	a.LastUpdatedTime,
	0 AS Disc1,
	0 AS Disc2,
	0 AS Disc3,
	'' AS DiscFormula,
	b.Cabang1,
	NULL AS Expedisi,
	0 AS QtySuratJalan,
	0 As QtyRetur,
	ISNULL( ((a.QtyTerima * a.HrgJual) - (a.QtyTerima * a.Pot)) , 0) 
		AS HrgNetto, -- Perhitungan HrgNet untuk RJ3
	ISNULL( ((a.QtyTarik * a.HrgJual) - (a.QtyTarik * a.Pot)) , 0) 
		AS HrgNetto1, -- Perhitungan HrgNet untuk MPR
	ISNULL( ((a.QtyGudang * a.HrgJual) - (a.QtyGudang * a.Pot)) , 0) 
		AS HrgNetto2, -- Perhitungan HrgNet untuk NotaRetur
	0 AS HrgNetto3
FROM dbo.ReturPenjualanTarikanDetail a (NOLOCK) 
	LEFT OUTER JOIN dbo.ReturPenjualan b (NOLOCK) ON a.ReturID = b.ReturID
	LEFT OUTER JOIN dbo.Sales c (NOLOCK) ON a.KodeSales = c.SalesID 
	LEFT OUTER JOIN dbo.Stok d (NOLOCK) ON a.BarangID = d.BarangID 




USE [ISAdb]
GO
/****** Object:  View [dbo].[vwStokGudang]    Script Date: 03/28/2011 14:48:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwStokGudang] 
AS 
SELECT
	g.BarangID,
	g.KodeGudang,
	g.TglAwal,
	ISNULL (g.QtyAwal, 0) AS QtyAwal,
	ISNULL((SELECT SUM(ISNULL(n.QtySuratJalan, 0)) 
		FROM dbo.OrderPenjualandetail o(NOLOCK) 
		LEFT OUTER JOIN dbo.NotaPenjualanDetail n(NOLOCK) ON o.RowID = n.DoDetailID
		WHERE g.BarangID = o.BarangID), 0) AS QtyJual,
	0 AS QtyBeli,
	ISNULL((SELECT SUM(ISNULL(r.QtyGudang, 0))
		FROM dbo.OrderPenjualanDetail o(NOLOCK) 
		LEFT OUTER JOIN dbo.NotaPenjualanDetail n(NOLOCK) ON o.RowID = n.DODetailID
		LEFT OUTER JOIN dbo.ReturPenjualanDetail r(NOLOCK) ON n.RowID = r.NotaJualDetailID
		WHERE g.BarangID = o.BarangID), 0) AS QtyRetJual,
	0 AS QtyRetBeli,
	ISNULL((SELECT SUM(ISNULL(o.QtyDO, 0)) 
		FROM dbo.OrderPenjualanDetail o(NOLOCK)
		LEFT OUTER JOIN dbo.NotaPenjualanDetail n(NOLOCK) ON o.RowID = n.DODetailID
		WHERE g.BarangID = o.BarangID AND n.RowID IS NULL), 0) AS QtyOrderJual,
	0 AS QtyOrderBeli,
	ISNULL((SELECT SUM(ISNULL(m.QtyMutasi, 0))
		FROM dbo.MutasiDetail m(NOLOCK) LEFT OUTER JOIN dbo.Mutasi n(NOLOCK) ON m.HeaderID=n.RowID WHERE  (n.TglMutasi >=g.TglAwal) AND (g.BarangID = m.KodeBarang) AND (m.Gudang=g.KodeGudang)), 
	0) AS QtyMutasi,
	ISNULL((SELECT SUM(ISNULL(k.QtyNotaKoreksi, 0)) 
		FROM dbo.OrderPenjualanDetail o(NOLOCK)
		LEFT OUTER JOIN dbo.NotaPenjualanDetail n(NOLOCK) ON o.RowID = n.DODetailID
		LEFT OUTER JOIN dbo.KoreksiPenjualan k(NOLOCK) ON n.RowID = k.NotaJualDetailID
		WHERE g.BarangID = o.BarangID), 0) AS QtyKorJual,
	0 AS QtyKorRetJual,
	0 AS QtyKorBeli,
	0 AS QtyKorRetBeli,
	ISNULL((SELECT SUM(ISNULL(o.QtyOpname,0)-ISNULL(o.QtyComp,0))
			FROM dbo.SelisihDetail o (NOLOCK) WHERE g.BarangID = o.KodeBarang  ),
	0)AS QtySelisih,
	ISNULL((SELECT SUM(ISNULL(z.QtyKirim,0))
						FROM dbo.AntarGudangDetail z (NOLOCK) LEFT OUTER JOIN dbo.AntarGudang w (NOLOCK) ON z.HeaderID=w.RowID
						WHERE 
							(w.TglKirim >= g.TglAwal) 
						AND (z.KodeBarang = g.BarangID)
						AND (w.DrGudang = g.KodeGudang)),
	0)AS QtyAntarGudangKirim,

	ISNULL((SELECT SUM(ISNULL(x.QtyTerima,0)) 
			 FROM dbo.AntarGudangDetail x (NOLOCK) LEFT OUTER JOIN dbo.AntarGudang (NOLOCK) y ON x.HeaderID=y.RowID
			 WHERE 
					(y.TglTerima >= g.TglAwal) 
				AND (x.KodeBarang = g.BarangID)
				AND (y.KeGudang = g.KodeGudang)),
	0)AS QtyAntarGudangTerima
FROM dbo.StokGudang g 
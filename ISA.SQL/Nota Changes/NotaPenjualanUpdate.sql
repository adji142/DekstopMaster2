 UPDATE NotaPenjualan
 SET
	Cabang1 = b.Cabang1,
	Cabang2 = b.Cabang2,
	Cabang3 = b.Cabang3,
	KodeToko = b.KodeToko,
	KodeSales = b.KodeSales,
	HariKirim = b.HariKirim,
	HariSales = b.HariSales
FROM NotaPenjualan a
INNER JOIN OrderPenjualan b ON a.DOID = b.RowID

GO

UPDATE NotaPenjualan
SET
	Cabang1 = ISNULL(Cabang1,0),
	Cabang2 = ISNULL(Cabang2,0),
	Cabang3 = ISNULL(Cabang3,0),
	KodeToko = ISNULL(KodeToko,0),
	KodeSales = ISNULL(KodeSales,0),
	HariKirim = ISNULL(HariKirim,0),
	HariSales = ISNULL(HariSales,0)
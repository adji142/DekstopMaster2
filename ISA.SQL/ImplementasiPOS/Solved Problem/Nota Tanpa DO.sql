﻿ INSERT INTO dbo.OrderPenjualan
(
	RowID, 
	HtrID, 
	Cabang1, 
	Cabang2, 
	Cabang3, 
	NoRequest, 
	TglRequest, 
	NoDO, 
	TglDO, 
	NoACCPusat, 
	ACCPiutangID, 
	NoACCPiutang, 
	TglACCPiutang, 
	RpACCPiutang, 
	RpPlafonToko, 
	RpPiutangTerakhir, 
	RpGiroTolakTerakhir, 
	RpOverdue, 
	StatusBatal, 
	KodeToko, 
	KodeSales, 
	StsToko, 
	AlamatKirim, 
	Kota, 
	DiscFormula, 
	Disc1, Disc2, 
	Disc3, 
	isClosed, 
	Catatan1, 
	Catatan2, 
	Catatan3, 
	Catatan4, 
	Catatan5, 
	NoDOBO, 
	TglReorder, 
	StatusBO, 
	SyncFlag, 
	LinkID, 
	TransactionType, 
	Expedisi, 
	Shift, 
	HariKredit, 
	HariKirim, 
	HariSales, 
	NPrint, 
	SumTglSuratJalan, 
	SumRpJual, 
	SumRpNet, 
	SumRpNet3, 
	SumQtyDO, 
	SumQtySJ, 
	LastUpdatedBy, 
	LastUpdatedTime
)

select 
	NEWID() AS RowID, 
	x.HtrID HtrID, 
	x.Cabang1 AS Cabang1, 
	x.Cabang2 AS Cabang2, 
	x.Cabang3 AS Cabang3, 
	'' AS NoRequest, 
	'' AS TglRequest, 
	'' AS NoDO, 
	'' AS TglDO, 
	'' AS NoACCPusat, 
	'' AS ACCPiutangID, 
	'' AS NoACCPiutang, 
	'' AS TglACCPiutang, 
	0 AS RpACCPiutang, 
	0 AS RpPlafonToko, 
	0 AS RpPiutangTerakhir, 
	0 AS RpGiroTolakTerakhir, 
	0 AS RpOverdue, 
	0 AS StatusBatal, 
	x.KodeToko AS KodeToko, 
	x.KodeSales KodeSales, 
	'' AS StsToko, 
	x.AlamatKirim AS AlamatKirim, 
	x.Kota AS Kota, 
	'' AS DiscFormula, 
	0 AS Disc1, 
	0 AS Disc2, 
	0 AS Disc3, 
	1 AS isClosed, 
	x.Catatan1 AS Catatan1, 
	x.Catatan2 AS Catatan2, 
	x.Catatan3 AS Catatan3, 
	x.Catatan4 AS Catatan4, 
	x.Catatan5 AS Catatan5 , 
	'' AS NoDOBO, 
	NULL AS TglReorder, 
	'' AS StatusBO, 
	1 AS SyncFlag, 
	'1' AS LinkID, 
	x.TransactionType TransactionType, 
	'' AS Expedisi, 
	'1' AS Shift, 
	x.HariKredit AS HariKredit, 
	x.HariKirim AS HariKirim, 
	x.HariSales AS HariSales, 
	1 AS NPrint, 
	0 AS SumTglSuratJalan, 
	0 AS SumRpJual, 
	0 AS SumRpNet, 
	0 AS SumRpNet3, 
	0 AS SumQtyDO, 
	0 AS SumQtySJ, 
	'IMPORT' AS LastUpdatedBy, 
	GETDATE() AS LastUpdatedTime
from isadb.dbo.Notapenjualan x
where
htrid not in
(
	select htrid from isadb_jkt.dbo.orderpenjualan
)
and htrid not in
(
	select htrid from isadb.dbo.orderpenjualan
)
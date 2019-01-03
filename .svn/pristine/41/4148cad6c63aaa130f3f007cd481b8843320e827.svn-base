USE ISAdb 
GO
DELETE FROM ISAdb.dbo.TokoToSales 
GO
INSERT INTO ISAdb.dbo.TokoToSales 
(
	RecordID, 
	KodeToko, 
	KodeSales, 
	PiutangBerjalan, 
	PiutangJatuhTempo, 
	SyncFlag
)
SELECT 
	RTRIM(idrec), 
	RTRIM(kd_toko), 
	RTRIM(kd_sales),
	piutang_b,
	piutang_j, 
	(CASE id_match WHEN '1' THEN 1 ELSE 0 END)
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM tk2sales')

GO

--SELECT * FROM TokoToSales 
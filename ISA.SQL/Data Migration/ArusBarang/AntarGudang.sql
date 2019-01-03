USE ISAdb

GO
DELETE FROM ISAdb.dbo.AntarGudang

GO

INSERT INTO dbo.AntarGudang
(
	RowID,
	RecordID,
	DrGudang,
	KeGudang,
	TglKirim,
	TglTerima,
	NoAG,
	Pengirim,
	Penerima,
	DrCheck1,
	DrCheck2,
	KeCheck1,
	KeCheck2,
	Catatan,
	expedisi,
	NoKendaraan,
	NamaSopir,
	KirimTerimaID,
	SyncFlag,
	LastUpdatedBy,
	LastUpdatedTime
)

SELECT 
	NEWID(),
	RTRIM(idhkrmagud),
	RTRIM(dr_gud),
	RTRIM(ke_gud),
	CONVERT(datetime , CASE LEFT(tgl_krm,2) WHEN '  ' THEN NULL ELSE RTRIM(tgl_krm) END ),
	CONVERT(datetime , CASE LEFT(tgl_trm,2) WHEN '  ' THEN NULL ELSE RTRIM(tgl_trm) END ),
	RTRIM(no_ag),
	RTRIM(pengirim),
	RTRIM(penerima),
	RTRIM(drcheck1),
	RTRIM(drcheck2),
	RTRIM(kecheck1),
	RTRIM(kecheck2),
	RTRIM(catatan)	,
	RTRIM([exp]),
	RTRIM(no_kend),
	RTRIM(nm_sopir),
	RTRIM(id_krmtrm),
	RTRIM(id_match),
	'Admin',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM Hkrmagud')

GO
UPDATE dbo.AntarGudang
SET 
TglTerima =NULL
WHERE YEAR(TglTerima)='1899'
GO
--SELECT * FROM   dbo.AntarGudang  
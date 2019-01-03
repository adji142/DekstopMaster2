USE ISAdb

GO
DELETE FROM ISAdb.dbo.Selisih

GO

INSERT INTO dbo.Selisih
(
	RowID,
	RecordID,
	KodeGudang,
	TglSelisih,
	NoSelisih,
	Cabang,
	Keterangan,
	Pemeriksa1,
	Pemeriksa2,
	SyncFlag,
	LastUpdatedBy,
	LastUpdatedTime
)

SELECT 
	NEWID(),
	RTRIM(idhselisih),
	RTRIM(kd_gdg),
	CONVERT(datetime , CASE LEFT(tgl,2) WHEN '  ' THEN NULL ELSE RTRIM(tgl) END ),
	RTRIM(no_slsh),
	RTRIM(cab),
	RTRIM(ket),
	RTRIM(pmrks1),
	RTRIM(pmrks2),
	RTRIM(id_match),
	'DELTA CRB',
	GETDATE()

FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM HSelisih')
GO
--SELECT * FROM   dbo.Selisih  
 
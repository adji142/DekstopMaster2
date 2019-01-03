USE ISAdb
GO
DELETE FROM ISAdb.dbo.OpnameDetail3
GO

INSERT INTO dbo.OpnameDetail3
(
	RowID,
	HeaderID,
	RecordID,
	TransactionID,
	KodeGudang,
	TglOpname,
	NoForm,
	Baik,
	Cacat,
	Rusak,
	Pengguna,
	SyncFlag,
	flag,
	LastUpdatedBy,
	LastUpdatedTime
)

SELECT   
	NewID(),
	NULL,
	RTRIM(idtr),
	RTRIM(id_stok),
	RTRIM(kd_gdg),
	CONVERT(datetime , CASE LEFT(tgl_opnm,2) WHEN '  ' THEN NULL ELSE RTRIM(tgl_opnm) END ),
	RTRIM(no_form),
	ISNULL(baik,0),
	ISNULL(cacat,0),
	ISNULL(rusak,0),
	RTRIM([user]),
	id_match,
	flag,
	'DELTA CRB',
	GETDATE()
	
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM Data3')
GO
UPDATE	dbo.opnameDetail3
SET HeaderID=b.RowID
FROM  OpnameDetail3 a LEFT OUTER JOIN Opname b on a.TransactionID = b.RecordID
GO
--SELECT * FROM OpnameDetail3  
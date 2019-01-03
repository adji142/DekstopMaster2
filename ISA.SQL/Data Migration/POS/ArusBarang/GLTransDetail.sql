USE ISAdb

GO
DELETE FROM ISAdb.dbo.GLTransDetail

GO

INSERT INTO dbo.GLTransDetail
(
	RowID, 
	NoPerkiraan, 
	Uraian, 
	Mdl, 
	RecordID, 
	KodeTransaksi, 
	GLTransRecID, 
	StatusPasif, 
	KodeCabang, 
	LastUpdatedBy, 
	LastUpdatedTime
)

SELECT 
	NEWID(), 
	RTRIM(no_perk), 
	RTRIM(uraian), 
	RTRIM(mdl), 
	RTRIM(idrec), 
	RTRIM(kodetrn), 
	RTRIM(idgltrans), 
	lpasif, 
	RTRIM(kd_cab), 
	'DELTA CRB', 
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM gltrans')

GO

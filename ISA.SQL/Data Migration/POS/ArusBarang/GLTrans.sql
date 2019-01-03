USE ISAdb

GO
DELETE FROM ISAdb.dbo.GLTrans

GO

INSERT INTO dbo.GLTrans
(
	RowID, 
	Kode, 
	Uraian, 
	RecordID, 
	Ref, 
	LastUpdatedBy, 
	LastUpdatedTime
)

SELECT 
	NEWID(), 
	RTRIM(kode), 
	RTRIM(uraian), 
	RTRIM(idrec), 
	RTRIM(ref), 
	'DELTA CRB', 
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM dgltrans')

GO

 USE ISAFinance 
GO
DELETE FROM dbo.GLTransDetail
GO

INSERT INTO dbo.GLTransDetail
(
	RowID, 
	RecordID, 
	Kode, 
	Uraian, 
	Ref, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	idrec,
	kode,	
	Uraian,
	ref,
	'DELTA CRB',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM DGLTrans')

GO

  USE ISAFinance 
GO
DELETE FROM dbo.GLTransSubDetail
GO

INSERT INTO dbo.GLTransSubDetail
(
	RowID, 
	RecordID, 
	GLTransRecID, 
	NoPerkiraan, 
	Uraian, 
	Mdl, 
	KodeTrn, 
	Pasif, 
	KodeCabang,
	LastUpdatedBy,
	LastUpdatedTime
)
SELECT 
	NEWID(),
	idrec,
	idgltrans,
	no_perk,
	uraian,
	mdl,
	kodetrn,
	lpasif,
	kd_cab,
	'DELTA CRB',
	GETDATE()
	
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM GLTrans')

GO

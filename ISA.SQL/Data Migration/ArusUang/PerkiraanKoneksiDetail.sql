USE ISAFinance 
GO
DELETE FROM dbo.PerkiraanKoneksiDetail
GO

INSERT INTO dbo.PerkiraanKoneksiDetail
(
	RowID, 
	HeaderID,
	RecordID, 
	HRecordID, 
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
	NULL,
	RTRIM(idrec),
	RTRIM((idgltrans)),
	RTRIM(no_perk),
	RTRIM(uraian),
	RTRIM(mdl),
	RTRIM(kodetrn),
	lpasif,
	RTRIM(kd_cab),
	'Import',
	GETDATE()
	
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM GLTrans')

GO

UPDATE dbo.PerkiraanKoneksiDetail
SET
	HeaderID = (SELECT TOP 1 RowID FROM dbo.PerkiraanKoneksi b WHERE b.RecordID = a.HRecordID )
FROM dbo.PerkiraanKoneksiDetail a

GO

 
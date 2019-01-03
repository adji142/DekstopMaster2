USE ISAFinance 
GO
DELETE FROM dbo.PerkiraanKoneksi
GO
INSERT INTO dbo.PerkiraanKoneksi
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
	RTRIM(idrec),
	RTRIM(kode),
	RTRIM(uraian),
	RTRIM(ref),
	'Import',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM DGLTRANS')

GO

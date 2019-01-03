 USE ISAFinance 
GO
DELETE FROM dbo.Perkiraan 
GO
INSERT INTO dbo.Perkiraan
(
	--RecordID, 
	Ref, 
	NoPerkiraan, 
	Level, 
	NamaPerkiraan, 
	SyncFlag, 
	Pasif, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	--IdRec,
	Ref,
	RTRIM(No_Perk),
	5,
	Uraian,
	Id_Match,
	LPasif,
	'Import',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_GL\'; ' '; ' ', 'SELECT * FROM No_Perk')


update dbo.Perkiraan
set Level = 4
where NoPerkiraan LIKE '%000'



update dbo.Perkiraan
set Level = 3
where NoPerkiraan LIKE '%00000'

update dbo.Perkiraan
set Level = 2
where NoPerkiraan LIKE '%0000000'

update dbo.Perkiraan
set Level = 1
where NoPerkiraan LIKE '%00000000'


GO


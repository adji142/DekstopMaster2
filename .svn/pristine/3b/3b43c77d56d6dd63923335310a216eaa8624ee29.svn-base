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
	'DELTA CRB',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM DGLTRANS')

GO

UPDATE DBO.PerkiraanKoneksi
SET 
RowID = b.RowID

FROM DBO.PerkiraanKoneksi a INNER JOIN ISAFinance_JKT.DBO.PerkiraanKoneksi b ON a.RecordID =  b.RecordID


GO 

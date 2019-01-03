USE ISAFinance 
GO
DELETE FROM dbo.JournalDetail 
GO
INSERT INTO dbo.JournalDetail
(
	RowID, 
	HeaderID, 
	RecordID, 
	HRecordID, 
	NoPerkiraan, 
	Uraian, 
	Debet, 
	Kredit, 
	DK, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	NULL,
	idrec,
	idtrans,
	no_perk,
	uraian,
	debet,
	kredit,
	dk,
	'Import',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_GL\'; ' '; ' ', 'SELECT * FROM Journals')

GO

UPDATE dbo.JournalDetail
SET 
HeaderID = ISNULL((SELECT TOP 1 RowID FROM dbo.Journal x WHERE x.RecordID = a.HRecordID  ),NULL)
FROM dbo.JournalDetail a

GO



UPDATE dbo.JournalDetail
SET RefRowID = ISNULL((SELECT TOP 1 x.GiroID FROM Giro x WHERE LEFT(x.GiroRecID,22)  = LEFT(a.RecordID,22)),NewID())
FROM dbo.JournalDetail a
INNER JOIN dbo.Journal b ON a.HeaderID = b.RowID 
AND b.Src IN ('VPG','VTG')

GO

UPDATE dbo.JournalDetail
SET RefRowID = ISNULL((SELECT TOP 1 x.GiroID FROM Giro x WHERE LEFT(x.GiroRecID,22)  = LEFT(a.RecordID,22) and x.TglGiro= b.Tanggal ),NEWID())
FROM dbo.JournalDetail a
INNER JOIN dbo.Journal b ON a.HeaderID = b.RowID 
AND b.Src IN ('VPG')

GO

UPDATE dbo.JournalDetail
SET RefRowID = ISNULL((SELECT TOP 1 x.GiroID FROM Giro x WHERE LEFT(x.GiroRecID,22)  = LEFT(a.RecordID,22) and x.TglTitip= b.Tanggal ),NEWID())
FROM dbo.JournalDetail a
INNER JOIN dbo.Journal b ON a.HeaderID = b.RowID 
AND b.Src IN ('VTG')

GO

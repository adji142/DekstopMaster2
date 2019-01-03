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
	'DELTA CRB',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_GL\'; ' '; ' ', 'SELECT * FROM Journals')

GO
UPDATE DBO.JournalDetail
SET 
RowID = b.RowID,
HeaderID = b.HeaderID,
RefRowID = b.RefRowID

FROM DBO.JournalDetail a INNER JOIN ISAFinance_JKT.DBO.JournalDetail b ON a.RecordID =  b.RecordID


GO 
UPDATE dbo.JournalDetail
SET 
HeaderID = ISNULL((SELECT TOP 1 RowID FROM dbo.Journal x WHERE x.RecordID = a.HRecordID  ),NEWID())
FROM dbo.JournalDetail a

GO



UPDATE dbo.JournalDetail
SET RowID = ISNULL((SELECT TOP 1 x.GiroID FROM Giro x WHERE LEFT(x.GiroRecID,22)  = LEFT(a.RecordID,22)),NewID())
FROM dbo.JournalDetail a
INNER JOIN dbo.Journal b ON a.HeaderID = b.RowID 
AND b.Src IN ('VPG','VTG')

GO

UPDATE dbo.JournalDetail
SET RowID = ISNULL((SELECT TOP 1 x.GiroID FROM Giro x WHERE LEFT(x.GiroRecID,22)  = LEFT(a.RecordID,22) and x.TglGiro= b.Tanggal ),NEWID())
FROM dbo.JournalDetail a
INNER JOIN dbo.Journal b ON a.HeaderID = b.RowID 
AND b.Src IN ('VPG')

GO

UPDATE dbo.JournalDetail
SET RowID = ISNULL((SELECT TOP 1 x.GiroID FROM Giro x WHERE LEFT(x.GiroRecID,22)  = LEFT(a.RecordID,22) and x.TglTitip= b.Tanggal ),NEWID())
FROM dbo.JournalDetail a
INNER JOIN dbo.Journal b ON a.HeaderID = b.RowID 
AND b.Src IN ('VTG')

GO

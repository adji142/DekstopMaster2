USE ISAFinance
GO
DELETE FROM dbo.SubJournal

GO
INSERT INTO dbo.SubJournal
(
	RowID, 
	RecordID, 
	JournalDetailID, 
	JournalDetailRecID, 
	PartnerID, 
	Keterangan,  
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	IdSub,
	NEWID(),
	DStamp,
	Idpart,
	Gr_part,
	'DELTA CRB',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_GL\'; ' '; ' ', 'SELECT * FROM HSubj')

GO
UPDATE dbo.SubJournal
SET
	RowID = b.RowID	
FROM dbo.SubJournal a
INNER JOIN ISAFinance_JKT.dbo.SubJournal b ON  a.RecordID = b.RecordID
 
GO 
UPDATE dbo.SubJournal
SET
	JournalDetailID = (SELECT TOP 1 RowID FROM dbo.JournalDetail x WHERE x.RecordID = a.JournalDetailRecID)
FROM dbo.SubJournal a

GO
 
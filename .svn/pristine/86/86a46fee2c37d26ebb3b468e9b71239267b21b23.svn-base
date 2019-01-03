USE ISAFinance_JKT
GO


INSERT INTO DBO.SubJournal
(
RowID, RecordID, JournalDetailID, JournalDetailRecID, PartnerID, Keterangan, LastUpdatedBy, LastUpdatedTime
)
SELECT RowID, 
RecordID, 
(SELECT TOP 1 RowID FROM DBO.JournalDetail x WHERE x.RecordID = a.JournalDetailRecID) AS JournalDetailID, 
JournalDetailRecID, PartnerID, Keterangan, LastUpdatedBy, LastUpdatedTime 
FROM ISAFinance.DBO.SubJournal a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.SubJournal)

GO 
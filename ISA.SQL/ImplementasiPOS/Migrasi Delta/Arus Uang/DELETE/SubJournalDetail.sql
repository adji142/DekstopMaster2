USE ISAFinance_JKT
GO

DELETE FROM DBO.SubJournalDetail 
WHERE RecordID NOT IN (SELECT RecordID FROM ISAFinance.DBO.SubJournalDetail)


GO


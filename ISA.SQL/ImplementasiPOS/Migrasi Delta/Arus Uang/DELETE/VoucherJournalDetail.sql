USE ISAFinance_JKT
GO

DELETE FROM DBO.VoucherJournalDetail 
WHERE RecordID NOT IN (SELECT RecordID FROM ISAFinance.DBO.VoucherJournalDetail)


GO


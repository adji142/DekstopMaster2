USE ISAFinance_JKT
GO

DELETE FROM DBO.TagihanDetail 
WHERE RecordID NOT IN (SELECT RecordID FROM ISAFinance.DBO.TagihanDetail)


GO


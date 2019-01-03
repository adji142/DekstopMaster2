USE ISAFinance_JKT
GO

DELETE FROM DBO.IndenDetail 
WHERE RecordID NOT IN (SELECT RecordID FROM ISAFinance.DBO.IndenDetail)

GO


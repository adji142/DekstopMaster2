USE ISAFinance_JKT
GO

DELETE FROM DBO.IndenSuperDetail 
WHERE RecordID NOT IN (SELECT RecordID FROM ISAFinance.DBO.IndenSuperDetail)

GO


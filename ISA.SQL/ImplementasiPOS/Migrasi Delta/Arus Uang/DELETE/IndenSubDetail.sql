USE ISAFinance_JKT
GO

DELETE FROM DBO.IndenSubDetail 
WHERE RecordID NOT IN (SELECT RecordID FROM ISAFinance.DBO.IndenSubDetail)

GO


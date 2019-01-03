USE ISAFinance_JKT
GO

DELETE FROM DBO.BuktiDetail 
WHERE RecordID NOT IN (SELECT RecordID FROM ISAFinance.DBO.BuktiDetail)

GO


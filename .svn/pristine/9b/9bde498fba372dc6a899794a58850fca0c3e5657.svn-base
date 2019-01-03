USE ISAFinance_JKT
GO

DELETE FROM DBO.GiroInternal 
WHERE GiroRecID NOT IN (SELECT GiroRecID FROM ISAFinance.DBO.GiroInternal)

GO


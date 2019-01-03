USE ISAFinance_JKT
GO
DELETE FROM ISAFinance_JKT.dbo.DataBank
GO
INSERT INTO ISAFinance_JKT.dbo.DataBank
SELECT * FROM ISAFinance.dbo.DataBank
USE ISAFinance_JKT
GO
DELETE FROM ISAFinance_JKT.dbo.AccountToko
GO
INSERT INTO ISAFinance_JKT.dbo.AccountToko
SELECT * FROM ISAFinance.dbo.AccountToko
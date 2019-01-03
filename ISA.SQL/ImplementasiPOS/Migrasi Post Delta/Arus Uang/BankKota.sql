USE ISAFinance_JKT
GO
DELETE FROM ISAFinance_JKT.dbo.BankKota
GO
INSERT INTO ISAFinance_JKT.dbo.BankKota
SELECT * FROM ISAFinance.dbo.BankKota
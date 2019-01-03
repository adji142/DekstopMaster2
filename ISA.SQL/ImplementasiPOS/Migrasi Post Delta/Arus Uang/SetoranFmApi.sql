USE ISAFinance_JKT
GO
DELETE FROM ISAFinance_JKT.dbo.SetoranFmApi
GO
INSERT INTO ISAFinance_JKT.dbo.SetoranFmApi
SELECT * FROM ISAFinance.dbo.SetoranFmApi
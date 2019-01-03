USE ISAFinance_JKT
GO
DELETE FROM ISAFinance_JKT.dbo.TransaksiBank
GO
INSERT INTO ISAFinance_JKT.dbo.TransaksiBank
SELECT * FROM ISAFinance.dbo.TransaksiBank
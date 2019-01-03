USE ISAFinance_JKT
GO
DELETE FROM ISAFinance_JKT.dbo.KartuPiutangLunas
GO
INSERT INTO ISAFinance_JKT.dbo.KartuPiutangLunas
SELECT * FROM ISAFinance.dbo.KartuPiutangLunas
USE ISAFinance_JKT
GO
DELETE FROM ISAFinance_JKT.dbo.SaldoTransferOtomatis
GO
INSERT INTO ISAFinance_JKT.dbo.SaldoTransferOtomatis
SELECT * FROM ISAFinance.dbo.SaldoTransferOtomatis
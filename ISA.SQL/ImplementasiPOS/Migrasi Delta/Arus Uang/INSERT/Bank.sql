USE ISAFinance_JKT
GO



INSERT INTO DBO.Bank
SELECT * FROM ISAFinance.DBO.Bank WHERE BankID NOT IN (SELECT BankID FROM DBO.Bank)
GO

USE ISAFinance_JKT
GO

update ISAFinance_JKT.dbo.Bank
set 
	saldo = b.Saldo,
	SaldoAwal = b.SaldoAwal,
	SaldoAkhir = b.SaldoAkhir,
	Limit = b.Limit
from ISAFinance_JKT.dbo.Bank a
inner join ISAFinance.dbo.Bank b on a.BankID = b.BankID



GO
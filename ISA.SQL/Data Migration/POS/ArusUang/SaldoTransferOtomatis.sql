USE ISAFinance
GO
TRUNCATE TABLE dbo.SaldoTransferOtomatis
GO
INSERT INTO dbo.SaldoTransferOtomatis
SELECT	NEWID(),
		a.*
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM SaldoTo') a

GO

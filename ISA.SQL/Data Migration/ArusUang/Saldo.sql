USE ISAFinance;
GO
TRUNCATE TABLE dbo.Saldo


GO

 INSERT INTO dbo.Saldo(RowID, Bulan, Tahun,rr, RpAwal, RpAkhir, LastUpdatedBy, LastUpdatedTime)
SELECT NEWID(),* , 'Import',GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM SALDO')
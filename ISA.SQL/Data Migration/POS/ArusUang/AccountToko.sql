USE ISAFinance 
GO
DELETE FROM dbo.AccountToko
GO
INSERT INTO dbo.AccountToko
(
	RowID, 
	KodeToko, 
	NoAccount, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),	
	RTRIM(kd_toko), 
	RTRIM(no_account), 	
	'DELTA CRB',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM ACCToko')

GO

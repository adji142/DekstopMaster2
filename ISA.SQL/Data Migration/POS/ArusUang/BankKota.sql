USE ISAFinance 
GO
DELETE FROM dbo.BankKota
GO
INSERT INTO dbo.BankKota
(
	RowID, 
	NamaBank, 
	Lokasi, 
	SyncFlag, 
	LastUpdatdBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),	
	RTRIM(namaBank), 
	RTRIM(lokasi), 	
	id_match,
	'DELTA CRB',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM BankKota')

GO

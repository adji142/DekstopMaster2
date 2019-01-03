 USE ISAdb 
GO
DELETE FROM ISAdb.dbo.Checker
GO
INSERT INTO ISAdb.dbo.Checker
(
	CheckerID, 
	FirstName, 
	LastName, 
	Alamat, 
	Kota, 
	Masuk, 
	Keluar,
	LastUpdatedBy,
	LastUpdatedTime
)
SELECT 
	idcheck, 
	nama_f, 
	nama_l, 
	alamat,
	kota,
	masuk, 
	keluar,
	'DELTA CRB',
	getdate()  
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM checker')

GO

--SELECT * FROM Checker
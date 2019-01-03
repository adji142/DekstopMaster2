USE ISAdb 
GO
DELETE FROM ISAdb.dbo.PT
GO
INSERT INTO ISAdb.dbo.PT 
(
	Nama, 
	Alamat, 
	TransactionType, 
	NPWP, 
	TglPKP, 
	InitCabang
)
SELECT 
	RTRIM(nama), 
	RTRIM(alamat), 
	RTRIM(id_tr),
	RTRIM(npwp),
	tglpkp , 
	RTRIM(initcab)  
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM pt')

GO

--SELECT * FROM PT
 
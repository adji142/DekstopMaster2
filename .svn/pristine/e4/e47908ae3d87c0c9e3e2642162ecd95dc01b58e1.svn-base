 USE ISAdb 
GO
DELETE FROM ISAdb.dbo.Gudang 
GO
INSERT INTO ISAdb.dbo.Gudang
(
	GudangID, 
	KodeCabang, 
	NamaGudang, 
	Alamat1, 
	Alamat2, 
	Alamat3, 
	Telp, 
	Fax, 
	Modem, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	RTRIM(kd_gdg),
	RTRIM(kd_cab),
	RTRIM(nm_gudang),
	RTRIM(alamat1),
	RTRIM(alamat2),
	RTRIM(alamat3),
	RTRIM(telp),
	RTRIM(fax),
	RTRIM(modem),
	'Admin',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ','select * from gudang')

GO

--SELECT * FROM Gudang 
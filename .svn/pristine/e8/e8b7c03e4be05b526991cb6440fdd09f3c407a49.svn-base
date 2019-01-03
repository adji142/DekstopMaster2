USE ISAdb 
GO
DELETE FROM ISAdb.dbo.Cabang 
GO
INSERT INTO ISAdb.dbo.Cabang 
(
	CabangID, 
	Nama, 
	TelModem, 
	Alamat1, 
	Alamat2, 
	Kota,
	LastUpdatedBy
)
SELECT 
	RTRIM(idcab), 
	RTRIM(Nama), 
	RTRIM(TelModem),
	RTRIM(Alamat1),
	RTRIM(Alamat2) , 
	RTRIM(Kota),
	'DELTA CRB'
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM cabang')

GO

--SELECT * FROM Cabang 
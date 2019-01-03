USE ISAdb 
GO
DELETE FROM ISAdb.dbo.Expedisi 
GO
INSERT INTO ISAdb.dbo.Expedisi 
(
	KodeExpedisi, 
	NamaExpedisi, 
	Alamat, 
	Telp, 
	KotaTujuan, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	RTRIM(kode), 
	RTRIM(nm_exp), 
	RTRIM(alamat),
	RTRIM(telepon),
	RTRIM(kota_tj), 
	RTRIM(id_match),  
	'DELTA CRB',
	GETDATE()
	FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM expedisi')

GO

--SELECT * FROM Expedisi 
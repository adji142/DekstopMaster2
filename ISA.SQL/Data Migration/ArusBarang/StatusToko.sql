USE ISAdb 
GO
DELETE FROM ISAdb.dbo.StatusToko
GO
INSERT INTO ISAdb.dbo.StatusToko
(
	RowID, 
	CabangID, 
	KodeToko, 
	TglAktif, 
	Status, 
	RecordID, 
	Keterangan, 
	SyncFlag, 
	KStatus, 
	Roda, 
	WilID, 
	TglPasif, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(), 
	RTRIM(c1), 
	RTRIM(kd_toko), 
	tmt, 
	RTRIM(sts), 
	RTRIM(idrec), 
	RTRIM(ket), 
	RTRIM(id_match), 
	RTRIM(ksts), 
	RTRIM(rd), 
	RTRIM(idwil), 
	tmt_pasif,
	'Admin', 
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM ststoko')

GO
UPDATE dbo.StatusToko
SET TglPasif = NULL
WHERE TglPasif = '1899/12/30'

GO
--SELECT * FROM StatusToko 
USE ISAdb 
GO
DELETE FROM ISAdb.dbo.PerolehanBonusSales
GO
INSERT INTO ISAdb.dbo.PerolehanBonusSales 
(
	RowID,
	RecordID, 
	KodeSales, 
	Periode, 
	Tanggal, 
	NoACC, 
	TglACC, 
	RpBonus, 
	RpACC, 
	nPrint, 
	LinkID, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	RTRIM(idrec),
	RTRIM(kd_sales), 
	RTRIM(periode), 
	tanggal, 
	RTRIM(no_acc), 
	tgl_acc, 
	rp_bonus, 
	rp_acc, 
	nprint, 
	id_link, 
	id_match,
	'DELTA CRB',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM dpbonus') 

GO
UPDATE dbo.PerolehanBonusSales
SET TglACC = NULL
WHERE TglACC = '1899/12/30'

GO
SELECT * FROM dbo.PerolehanBonusSales  
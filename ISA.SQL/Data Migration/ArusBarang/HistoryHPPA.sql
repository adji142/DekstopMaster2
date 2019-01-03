USE ISAdb 

GO
DELETE FROM ISAdb.dbo.HistoryHPPA

GO
INSERT INTO ISAdb.dbo.HistoryHPPA
(
	RowID, 
	HistoryID, 
	BarangID, 
	TglAktif, 
	HPP, 
	Satuan, 
	Keterangan, 
	SyncFlag, 
	HPPAverage,
	LastUpdatedBy, 
	LastUpdatedTime 
)
SELECT 
	NEWID(),
	RTRIM(a.id_hist),
	ISNULL(s.BarangID,''),
	a.tmt,
	a.hpp,
	RTRIM(a.satuan),
	RTRIM(a.keterangan),
	a.id_match,
	a.hpp_ave,
	'Admin',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM his_hppa') a
LEFT OUTER JOIN dbo.Stok s ON RTRIM(a.id_stok) = s.RecordID

GO
--SELECT * FROM HistoryHPPA
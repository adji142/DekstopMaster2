USE ISAdb 

GO
DELETE FROM ISAdb.dbo.HistoryHPP

GO
INSERT INTO ISAdb.dbo.HistoryHPP
(
	RowID, 
	HistoryID, 
	BarangID, 
	TglAktif, 
	HPP, 
	Satuan, 
	Keterangan, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime 
)
SELECT 
	NEWID(),
	RTRIM(a.id_hist),
	isnull(s.BarangID,''),
	a.tmt,
	a.hpp,
	RTRIM(a.satuan),
	RTRIM(a.keterangan),
	a.id_match,
	'Admin',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM hist_hpp') a
LEFT OUTER JOIN dbo.Stok s ON RTRIM(a.id_stok) = s.RecordID

GO
--SELECT * FROM HistoryHPP
 USE ISAdb 
GO
DELETE FROM ISAdb.dbo.KoreksiReturPenjualan
GO
INSERT INTO ISAdb.dbo.KoreksiReturPenjualan
(
	RowID, 
	RecordID,  
	ReturJualDetailRecID, 
	TglKoreksi, 
	NoKoreksi, 
	BarangID,
	QtyNotaBaru, 
	HrgJualBaru, 
	Catatan, 
	KodeToko, 
	Sumber, 
	LinkID,  
	HrgJualKoreksi, 
	QtyNotaKoreksi, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(), 
	RTRIM(id_koreksi),
	RTRIM(id_detail), 
	tglkoreksi, 
	RTRIM(no_koreksi), 
	RTRIM(id_brg), 
	j_nota, 
	h_jual, 
	RTRIM(catatan), 
	RTRIM(kd_toko), 
	RTRIM(sumber), 
	RTRIM(dt_link), 
	h_koreksi, 
	n_koreksi, 
	id_match, 
	'Admin', 
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM kortrans')
WHERE RTRIM(sumber) = 'NRJ'

GO
UPDATE dbo.KoreksiReturPenjualan
SET 
	ReturJualDetailID = b.RowID
FROM dbo.KoreksiReturPenjualan a 
LEFT OUTER JOIN dbo.ReturPenjualanDetail b ON a.ReturJualDetailRecID = b.RecordID 
WHERE b.RowID IS NOT NULL

GO
UPDATE dbo.KoreksiReturPenjualan
SET 
	ReturJualDetailID = b.RowID
FROM dbo.KoreksiReturPenjualan a 
LEFT OUTER JOIN dbo.ReturPenjualanTarikanDetail b ON a.ReturJualDetailRecID = b.RecordID 
WHERE b.RowID IS NOT NULL

GO
--SELECT * FROM KoreksiReturPenjualan 
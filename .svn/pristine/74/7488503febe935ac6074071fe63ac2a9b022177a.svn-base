USE ISAdb 
GO
DELETE FROM ISAdb.dbo.KoreksiPenjualan
GO
INSERT INTO ISAdb.dbo.KoreksiPenjualan
(
	RowID, 
	RecordID,  
	NotaJualDetailRecID, 
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
WHERE RTRIM(sumber) = 'NPJ'

GO
UPDATE dbo.KoreksiPenjualan
SET 
	NotaJualDetailID = b.RowID
FROM dbo.KoreksiPenjualan a 
LEFT OUTER JOIN dbo.NotaPenjualanDetail b ON a.NotaJualDetailRecID = b.RecordID 

GO
--SELECT * FROM KoreksiPenjualan 
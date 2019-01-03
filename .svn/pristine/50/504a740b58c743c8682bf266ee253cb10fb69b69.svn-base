USE ISAdb 
GO
DELETE FROM ISAdb.dbo.KoreksiPembelian
GO
INSERT INTO ISAdb.dbo.KoreksiPembelian
(
	RowID, 
	RecordID,  
	NotaBeliDetailRecID, 
	TglKoreksi, 
	NoKoreksi,
	BarangID, 
	QtyNotaBaru, 
	HrgBeliBaru, 
	Catatan, 
	Pemasok, 
	Sumber, 
	LinkID, 
	HrgBeliKoreksi, 
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
WHERE RTRIM(sumber) = 'NPB'

GO
UPDATE dbo.KoreksiPembelian
SET 
	NotaBeliDetailID = b.RowID
FROM dbo.KoreksiPembelian a 
LEFT OUTER JOIN dbo.NotaPembelianDetail b ON a.NotaBeliDetailRecID = b.RecordID 

GO
--SELECT * FROM KoreksiPembelian  
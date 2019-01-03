USE ISAdb 
GO
DELETE FROM ISAdb.dbo.KoreksiReturPembelian
GO
INSERT INTO ISAdb.dbo.KoreksiReturPembelian
(
	RowID, 
	RecordID,  
	ReturBeliDetailRecID, 
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
WHERE RTRIM(sumber) = 'NRB'

GO
UPDATE dbo.KoreksiReturPembelian
SET 
	ReturBeliDetailID = b.RowID
FROM dbo.KoreksiReturPembelian a 
LEFT OUTER JOIN dbo.vwReturPembelianDetail b ON a.ReturBeliDetailRecID = b.RecordID 

GO
--SELECT * FROM KoreksiReturPembelian  
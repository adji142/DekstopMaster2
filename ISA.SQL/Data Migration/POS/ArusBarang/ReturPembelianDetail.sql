USE ISAdb 
GO
DELETE FROM ISAdb.dbo.ReturPembelianDetail
GO
INSERT INTO ISAdb.dbo.ReturPembelianDetail
(
	RowID, 
	HeaderID, 
	NotaBeliDetailID, 
	RecordID, 
	ReturID, 
	NotaBeliDetailRecID, 
	KodeRetur,
	BarangID,
	QtyGudang, 
	QtyTerima, 
	HrgBeli, 
	HrgNet, 
	HrgPokok, 
	HPPSolo, 
	Catatan, 
	TglKeluar, 
	KodeGudang,
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	h.RowID,
	n.RowID,
	RTRIM(r.idrec),
	RTRIM(r.idretur),
	RTRIM(r.iddtr),
	'1', -- Dipaksa satu karena ada kode retur yang kosong
	id_brg,
	r.q_gudang,
	r.q_terima,
	r.h_beli,
	r.h_net,
	r.h_pokok,
	r.hpp_solo,
	RTRIM(r.catatan),
	r.tgl_keluar,
	RTRIM(r.kd_gdg),
	0,
	'DELTA CRB',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM dreturb') r
LEFT OUTER JOIN dbo.ReturPembelian h ON RTRIM(r.idretur) = h.ReturID
LEFT OUTER JOIN dbo.NotaPembelianDetail n ON RTRIM(r.iddtr) = n.RecordID

/* Hanya untuk retur 'Histori' yaitu retur-retur yang ada nota belinya */
WHERE 
	(RTRIM(r.kdretur) = '1' OR (RTRIM(r.kdretur) = ''))
	AND 
	RTRIM(r.iddtr) <> ''
	AND
	n.RowID IS NOT NULL

GO

UPDATE DBO.ReturPembelianDetail
SET RowID = b.RowID,
HeaderID = b.HeaderID,
NotaBeliDetailID = b.NotaBeliDetailID


FROM DBO.ReturPembelianDetail a INNER JOIN ISAdb_JKT.DBO.ReturPembelianDetail b ON a.RecordID = b.RecordID

GO 
--SELECT * FROM ReturPembelianDetail  
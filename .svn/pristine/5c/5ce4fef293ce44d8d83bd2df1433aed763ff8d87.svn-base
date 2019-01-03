USE ISAdb 
GO
DELETE FROM ISAdb.dbo.ReturPembelianManualDetail
GO
INSERT INTO ISAdb.dbo.ReturPembelianManualDetail
(
	RowID, 
	HeaderID, 
	RecordID, 
	ReturID, 
	BarangID,
	KodeRetur,
	QtyGudang, 
	QtyTerima, 
	HrgBeli, 
	HrgNet, 
	HrgPokok, 
	HPPSolo, 
	Catatan, 
	TglKeluar, 
	KodeGudang, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	h.RowID,
	RTRIM(r.idrec),
	RTRIM(r.idretur),
	RTRIM(r.id_brg),
	'2',	-- Dipaksa dua karena ada kode retur yang kosong 
			-- dan ada yang '1' tapi tidak ada nota
	r.q_gudang,
	r.q_terima,
	r.h_beli,
	r.h_net,
	r.h_pokok,
	r.hpp_solo,
	RTRIM(r.catatan),
	r.tgl_keluar,
	RTRIM(r.kd_gdg),
	'DELTA CRB',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM dreturb') r
LEFT OUTER JOIN dbo.ReturPembelian h ON RTRIM(r.idretur) = h.ReturID
LEFT OUTER JOIN dbo.NotaPembelianDetail n ON RTRIM(r.iddtr) = n.RecordID

/* Hanya untuk retur 'Manual' yaitu retur-retur yang tidak dari notanya beli */
WHERE 
	((RTRIM(r.iddtr) = '') 
	OR 
	(n.RowID IS NULL) )
	AND
	(RTRIM(r.id_brg) <> '') -- Karena tidak ada nota retur beli manual harus ada barang-nya

GO

UPDATE DBO.ReturPembelianManualDetail
SET RowID = b.RowID,
HeaderID = b.HeaderID


FROM DBO.ReturPembelianManualDetail a INNER JOIN ISAdb_JKT.DBO.ReturPembelianManualDetail b ON a.RecordID = b.RecordID

GO 
--SELECT * FROM ReturPembelianManualDetail  
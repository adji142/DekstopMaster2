-- last edited by ferry, add script to handle null value [Row ID] to be inserted.
USE ISAdb 
GO
DELETE FROM ISAdb.dbo.OrderPembelianDetail
GO
INSERT INTO ISAdb.dbo.OrderPembelianDetail
(
	RowID, 
	HeaderID, 
	RecordID, 
	HeaderRecID, 
	BarangID, 
	QtyDO, 
	QtyBO, 
	QtyTambahan, 
	QtyJual, 
	QtyAkhir, 
	Keterangan, 
	KodeGudang, 
	Catatan, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	b.RowID,
	RTRIM(a.idrec),
	RTRIM(a.idheader),
	RTRIM(a.id_brg),
	a.j_do,
	a.j_bo,
	a.j_plus,
	a.q_jual,
	a.q_akhir,
	RTRIM(a.ket),
	RTRIM(a.kd_gdg),
	RTRIM(a.catatan),
	a.id_match,
	'Admin',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM dosheet') a
LEFT OUTER JOIN dbo.OrderPembelian b ON RTRIM(a.idheader) = b.RecordID
where B.RowID IS NOT NULL

GO
--SELECT * FROM OrderPembelianDetail 
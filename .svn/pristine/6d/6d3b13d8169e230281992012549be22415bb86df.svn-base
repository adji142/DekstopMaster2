USE ISAdb 
GO
DELETE FROM ISAdb.dbo.Collector
GO
INSERT INTO ISAdb.dbo.Collector
(
	CollectorID, 
	Kode, 
	Nama, 
	TglLahir, 
	Alamat, 
	Target, 
	BatasOD, 
	TglMasuk, 
	TglKeluar, 
	SyncFlag, 
	BarangA, 
	BarangB, 
	BarangC, 
	BarangE, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	RTRIM(id_colect), 
	RTRIM(kd_colec), 
	RTRIM(nm_colec),
	tgl_lahir, 
	RTRIM(alamat),
	target,
	batas_od,
	tgl_masuk, 
	tgl_keluar,
	id_match,
	RTRIM(barang_a),
	RTRIM(barang_b),
	RTRIM(barang_c),
	RTRIM(barang_e),
	'DELTA CRB',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM colector')


UPDATE dbo.Collector 
SET
	TglLahir = null 
WHERE 
	TglLahir='1899/12/30' 
UPDATE dbo.Collector 
SET
	TglMasuk= null 
WHERE 
	TglMasuk='1899/12/30' 
	UPDATE dbo.Collector 
SET
	TglKeluar = null 
WHERE 
	TglKeluar='1899/12/30' 
GO

--SELECT * FROM Collector 
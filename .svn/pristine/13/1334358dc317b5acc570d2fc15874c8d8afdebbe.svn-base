USE ISAdb 

GO
DELETE FROM ISAdb.dbo.StokGudang 

GO
INSERT INTO ISAdb.dbo.StokGudang
(
	BarangID, 
	KodeGudang, 
	TglAwal, 
	QtyAwal, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	RTRIM(id_brg),
	RTRIM(kd_gdg),
	CONVERT(datetime , CASE LEFT(tgl_awal,2) WHEN '  ' THEN NULL ELSE RTRIM(tgl_awal) END ),
	q_awal,
	'Admin',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM stok2gd')

GO
--SELECT * FROM StokGudang  
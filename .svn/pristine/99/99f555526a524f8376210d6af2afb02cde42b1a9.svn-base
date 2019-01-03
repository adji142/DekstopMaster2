USE ISAdb 
GO
DELETE FROM ISAdb.dbo.Sales
GO
INSERT INTO ISAdb.dbo.Sales
(
		RowID, 
		SalesID, 
		NamaSales,
		RecID, 
		--TglLahir, 
		Alamat, 
		Target, 
		BatasOD, 
		TglMasuk, 
		TglKeluar,
		KodeGudang, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
)
SELECT 
	(newid()),
	RTRIM(kd_sales),
	RTRIM(nm_sales),
	RTRIM(idrec),
	--tgl_lahir,
	RTRIM(alamat),
	target,
	batas_od,
	convert(datetime,tgl_masuk),
	convert(datetime,tgl_keluar),
	RTRIM(NamaToko),
	id_match,
	'Admin',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM sales')

GO

UPDATE sales SET tglkeluar = NULL WHERE tglkeluar = '18991230'
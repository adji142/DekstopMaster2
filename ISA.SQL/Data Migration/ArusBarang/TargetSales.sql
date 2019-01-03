USE ISAdb 
GO
DELETE FROM ISAdb.dbo.TargetSales
GO
INSERT INTO ISAdb.dbo.TargetSales
(
		RowID, 
		RecordID, 
		TglTarget, 
		KodeSales, 
		KodeToko, 
		Nota_B, 
		Nota_E, 
		NToko, 
		NItem, 
		Biaya, 
		TglPasif, 
		LastUpdatedBy, 
		LastUpdatedTime

)
SELECT 
	(newid()),
	RTRIM(idrec),
	RTRIM(tgl_tg),
	RTRIM(kd_sales),
	RTRIM(kd_toko),
	RTRIM(nota_b),
	RTRIM(nota_e),
	toko,
	item,
	biaya,
	tgl_pasif,
	'Admin',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM tg_sales')

GO

--SELECT * FROM TargetSales  
USE ISAdb
GO
DELETE FROM dbo.StandarStok
GO
SELECT
	NEWID() AS RowID,
	RTRIM(id_brg) AS KodeBarang,
	tmt AS TglMT,
	ratajual AS AVGJual,
	variabel AS Var1,
	var2 AS Var2
	
INTO dbo.StandarStok_Temp
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM stdstok')
GO
INSERT INTO dbo.StandarStok
( 
	RowID,
	KodeBarang,
	TglMT,
	AVGJual,
	Var1,
	var2,
	LastUpdatedBy,
	LastUpdatedTime
)
SELECT
	RowID,
	KodeBarang,
	TglMT,
	AVGJual,
	CONVERT(float,Var1)AS Var1,
	CONVERT(float,Var2) AS Var2,
	'Admin',
	GETDATE()
FROM dbo.StandarStok_Temp
GO
DROP TABLE dbo.StandarStok_Temp
GO
--SELECT * FROM StandarStok
GO
	





 
USE ISAdb
GO

DELETE FROM dbo.HistoryBMK2
GO

SELECT
	RTRIM(id_hist) AS id_hist, 
	RTRIM(id_stok) AS id_stok, 
	tmt,
	tmt_pasif,  
	hjual_std,
	qmin_b, 
	hjual_b, 
	qmin_m, 
	hjual_m, 
	qmin_k, 
	hjual_k, 
	RTRIM(ket) AS ket, 
	id_match
INTO #TEMP
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', '
SELECT
	id_hist, 
	id_stok, 
	DTOC (tmt) AS tmt,
	DTOC (tmt_pasif) AS tmt_pasif,
	hjual_std,
	qmin_b, 
	hjual_b, 
	qmin_m, 
	hjual_m, 
	qmin_k, 
	hjual_k, 
	ket, 
	id_match
FROM his_bmk2')


INSERT INTO dbo.HistoryBMK2
(
	[RowID]
	,[HistoryID]
	,[StokID]
	,[BarangID]
	,[TglAktif]
	,[TglPasif]
	,[HrgJualStd]
	,[QtyMinB]
	,[HrgJualB]
	,[QtyMinM]
	,[HrgJualM]
	,[QtyMinK]
	,[HrgJualK]
	,[Keterangan]
	,[SyncFlag]
	,[LastUpdatedBy]
	,[LastUpdatedTime]
)
SELECT 
	NEWID(),
	RTRIM(id_hist), 
	RTRIM(id_stok),
	RTRIM(id_stok), 
	CAST((CASE WHEN tmt = '  /  /  ' THEN NULL
					   WHEN RIGHT(tmt,4) < 1900 THEN NULL
					  ELSE tmt 
					  END) AS DATETIME) AS tmt,
   CAST((CASE WHEN tmt_pasif = '  /  /  ' THEN NULL
					   WHEN RIGHT(tmt_pasif,4) < 1900 THEN NULL
					  ELSE tmt_pasif 
					  END) AS DATETIME) AS tmt_pasif,
	hjual_std,
	qmin_b, 
	hjual_b, 
	qmin_m, 
	hjual_m, 
	qmin_k, 
	hjual_k, 
	RTRIM(ket), 
	id_match, 
	'Admin',
	GETDATE()
FROM #TEMP
WHERE
RIGHT(tmt,4) <> '0200' 

DROP TABLE #TEMP


 
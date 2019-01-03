USE ISAdb
GO

DELETE FROM dbo.HistoryBMK
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
	id_match, 
	RTRIM(sts_laba) AS sts_laba
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
	id_match, 
	sts_laba
FROM hist_bmk')


INSERT INTO dbo.HistoryBMK
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
	,[StatusLaba]
	,[LastUpdatedBy]
	,[LastUpdatedTime]
)
SELECT 
	NEWID(),
	RTRIM(t.id_hist), 
	RTRIM(t.id_stok),
	ISNULL(s.BarangID, ''), 
	CAST((CASE WHEN t.tmt = '  /  /  ' THEN NULL
					   WHEN RIGHT(t.tmt,4) < 1900 THEN NULL
					  ELSE t.tmt 
					  END) AS DATETIME) AS tmt,
    CAST((CASE WHEN t.tmt_pasif = '  /  /  ' THEN NULL
					   WHEN RIGHT(t.tmt_pasif,4) < 1900 THEN NULL
					  ELSE t.tmt_pasif 
					  END) AS DATETIME) AS tmt_pasif,
	t.hjual_std,
	t.qmin_b, 
	t.hjual_b, 
	t.qmin_m, 
	t.hjual_m, 
	t.qmin_k, 
	t.hjual_k, 
	RTRIM(t.ket), 
	t.id_match, 
	RTRIM(t.sts_laba),
	'DELTA CRB',
	GETDATE()
FROM #TEMP t
LEFT OUTER JOIN dbo.Stok s ON RTRIM(t.id_stok) = s.RecordID
WHERE
RIGHT(t.tmt,4) <> '0200' 

DROP TABLE #TEMP

/* Tambahan BarangID krn mostly link ke dbo.Stok pakai BarangID */
-- GO
-- UPDATE dbo.HistoryBMK
-- SET BarangID = s.BarangID
-- FROM dbo.HistoryBMK bmk
-- LEFT OUTER JOIN dbo.Stok s ON bmk.StokID = s.RecordID

GO
--SELECT * FROM HistoryBMK 



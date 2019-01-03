USE ISAdb
GO
DELETE FROM ISAdb.dbo.TPPC
GO
SELECT
	idhppc,
	kd_toko,
	rp_lunas,
	q_lunas,
	rp_belum,
	q_belum,
	rp_ambil,
	q_ambil,
	idrec,
	namatoko,
	tgl_do
INTO #TEMP_TPPC
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', '
SELECT 
	RTRIM(idhppc) as idhppc,
	RTRIM(kd_toko) as kd_toko,
	rp_lunas,
	q_lunas,
	rp_belum,
	q_belum,
	rp_ambil,
	q_ambil,
	RTRIM(idrec) as idrec,
	RTRIM(namatoko) as namatoko,
	DTOC(tgl_do) AS tgl_do
FROM tppc') as tppc


INSERT INTO ISAdb.dbo.TPPC
(
	HPPCRecID, 
	KodeToko, 
	RpLunas, 
	QtyLunas, 
	RpBelum, 
	QtyBelum, 
	RpAmbil, 
	QtyAmbil, 
	RecordID, 
	NamaToko, 
	TglDO
) 
SELECT
	RTRIM(idhppc),
	RTRIM(kd_toko),
	rp_lunas,
	q_lunas,
	rp_belum,
	q_belum,
	rp_ambil,
	q_ambil,
	RTRIM(idrec),
	RTRIM(namatoko),
	CAST((CASE WHEN tgl_do = '  /  /  ' THEN '' ELSE tgl_do END) AS DATETIME) AS tgl_do
FROM #TEMP_TPPC

GO

DROP TABLE #TEMP_TPPC
GO

--SELECT * FROM TPPC
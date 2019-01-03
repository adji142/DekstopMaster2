USE ISAdb
GO
-- Field bertipe tanggal harus diubah ke tipe char dulu

DELETE FROM ISAdb.dbo.Inden
GO

SELECT
	RTRIM(idtr) AS idtr,
	RTRIM(idrec) AS idrec,
	rp_cash,
	rp_giro,
	rp_trf,
	cash,
	trf,
	giro,
	tgl_trf,
	RTRIM(idbank) AS idbank,
	RTRIM(namabank) AS namabank,
	RTRIM(lokasi) AS lokasi,
	chbg,
	RTRIM(nomor) AS nomor,
	tgl_giro,
	tgl_jt,
	RTRIM(ket) AS ket,
	id_match,
	RTRIM(no_acc) AS no_acc,
	rp_crd,
	rp_dbt,
	crd,
	dbt
INTO #TEMP
FROM 
(SELECT * FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', '
SELECT
	RTRIM(idtr) AS idtr,
	RTRIM(idrec) AS idrec,
	rp_cash,
	rp_giro,
	rp_trf,
	cash,
	trf,
	giro,
	dtoc(tgl_trf) as tgl_trf,
	RTRIM(idbank) AS idbank,
	RTRIM(namabank) AS namabank,
	RTRIM(lokasi) AS lokasi,
	chbg,
	RTRIM(nomor) AS nomor,
	dtoc(tgl_giro) as tgl_giro,
	dtoc(tgl_jt) as tgl_jt,
	RTRIM(ket) AS ket,
	id_match,
	RTRIM(no_acc) AS no_acc,
	rp_crd,
	rp_dbt,
	crd,
	dbt
FROM dinden')) AS X

INSERT INTO ISAdb.dbo.Inden
(
	RowID
	,RecordID
	,RpCash
	,RpGiro
	,RpTrf
	,Cash
	,Tarif
	,Giro
	,TglTrf
	,BankID
	,NamaBank
	,Lokasi
	,Chbg
	,Nomor
	,TglGiro
	,TglJt
	,Ket
	,SyncFlag
	,NoAcc
	,RpCrd
	,RpDbt
	,Crd
	,Dbt
)
SELECT 
	idtr,
	idrec,
	rp_cash,
	rp_giro,
	rp_trf,
	cash,
	trf,
	giro,
	CAST((CASE WHEN tgl_trf = '  /  /  ' THEN NULL
					   WHEN RIGHT(tgl_trf,4) < 1900 THEN NULL
					  ELSE tgl_trf 
					  END) AS DATETIME) AS tgl_trf,
	idbank,
	namabank,
	lokasi,
	chbg,
	nomor,
	CAST((CASE WHEN tgl_giro = '  /  /  ' THEN NULL
					   WHEN RIGHT(tgl_giro,4) < 1900 THEN NULL
					  ELSE tgl_giro 
					  END) AS DATETIME) AS tgl_giro,
	CAST((CASE WHEN tgl_jt = '  /  /  ' THEN NULL
					   WHEN RIGHT(tgl_jt,4) < 1900 THEN NULL
					  ELSE tgl_jt 
					  END) AS DATETIME) AS tgl_jt,
	ket,
	id_match,
	no_acc,
	rp_crd,
	rp_dbt,
	crd,
	dbt
FROM #TEMP
WHERE (cast(right(tgl_giro,4) as int) >= 1900 or tgl_giro = '  /  /  ') and 
(cast(right(tgl_jt,4) as int) >= 1900 or tgl_jt = '  /  /  ')

DROP TABLE #TEMP


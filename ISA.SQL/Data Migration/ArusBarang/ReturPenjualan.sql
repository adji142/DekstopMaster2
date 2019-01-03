USE ISAdb 
GO
DELETE FROM ISAdb.dbo.ReturPenjualan
GO
INSERT INTO ISAdb.dbo.ReturPenjualan
(
	RowID, 
	Cabang1, 
	Cabang2, 
	ReturID, 
	NoMPR, 
	NoNotaRetur, 
	NoTolak, 
	TglMPR, 
	TglNotaRetur, 
	TglTolak, 
	KodeToko,
	Pengambilan, 
	TglPengambilan, 
	TglGudang, 
	BagPenjualan, 
	Penerima, 
	LinkID, 
	SyncFlag, 
	isClosed, 
	NPrint, 
	TglRQRetur, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(), 
	RTRIM(cab1), 
	RTRIM(cab2), 
	RTRIM(idretur), 
	RTRIM(no_memo), 
	RTRIM(no_ret), 
	RTRIM(no_tolak), 
	CAST((CASE WHEN tgl_memo = '  /  /  ' THEN NULL
			   WHEN RIGHT(tgl_memo,4) < 1900 THEN NULL
					ELSE tgl_memo 
			    END) AS DATETIME) AS tgl_memo,
	CAST((CASE WHEN tgl_ret = '  /  /  ' THEN NULL
			   WHEN RIGHT(tgl_ret,4) < 1900 THEN NULL
					ELSE tgl_ret 
			    END) AS DATETIME) AS tgl_ret,
	CAST((CASE WHEN tgl_tolak = '  /  /  ' THEN NULL
			   WHEN RIGHT(tgl_tolak,4) < 1900 THEN NULL
					ELSE tgl_tolak 
			    END) AS DATETIME) AS tgl_tolak, 
	RTRIM(kd_toko),
	RTRIM(pngmbln), 
	CAST((CASE WHEN tgl_pngmb = '  /  /  ' THEN NULL
			   WHEN RIGHT(tgl_pngmb,4) < 1900 THEN NULL
					ELSE tgl_pngmb 
			    END) AS DATETIME) AS tgl_pngmb,
	CAST((CASE WHEN tgl_gudang = '  /  /  ' THEN NULL
			   WHEN RIGHT(tgl_gudang,4) < 1900 THEN NULL
					ELSE tgl_gudang 
			    END) AS DATETIME) AS tgl_gudang,
	RTRIM(bag_penj), 
	RTRIM(penerima), 
	RTRIM(dt_link), 
	id_match, 
	laudit, 
	nprint, 
	CAST((CASE WHEN tgl_rqret = '  /  /  ' THEN NULL
			   WHEN RIGHT(tgl_rqret,4) < 1900 THEN NULL
					ELSE tgl_rqret 
			    END) AS DATETIME) AS tgl_rqret,
	'Admin', 
	GETDATE()	
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 
'SELECT 
	cab1,
	cab2,
	idretur, 
	no_memo, 
	no_ret, 
	no_tolak, 
	DTOC(tgl_memo) AS tgl_memo, 
	DTOC(tgl_ret) AS tgl_ret, 
	DTOC(tgl_tolak) AS tgl_tolak, 
	kd_toko, 
	pngmbln, 
	DTOC(tgl_pngmb) AS tgl_pngmb, 
	DTOC(tgl_gudang) AS tgl_gudang, 
	bag_penj, 
	penerima, 
	dt_link, 
	id_match, 
	laudit, 
	nprint, 
	DTOC(tgl_rqret) AS tgl_rqret
FROM hreturj')

GO

--SELECT * FROM ReturPenjualan 
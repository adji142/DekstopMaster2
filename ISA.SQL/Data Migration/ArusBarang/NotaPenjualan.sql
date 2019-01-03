/*
 * Note:
 * Di database fox pro rubah tipe dari 'datetime' jadi character(10)
 * untuk field2 tersebut:
 * - tgl_nota
 * - tgl_sj
 * - tgl_trm
 * - tgl_strm
 * Di migration script (ini), akan di ubah kembali ke'datetime'
 */



USE ISAdb 

GO
--DELETE FROM ISAdb.dbo.NotaPenjualan
DELETE ISAdb.DBO.NotaPenjualan

GO

INSERT INTO ISAdb.dbo.NotaPenjualan
(
	RowID, 
	HtrID, 
	RecordID, 
	DOID,
	NoNota, 
	TglNota, 
	NoSuratJalan, 
	TglSuratJalan, 
	TglTerima, 
	TglSerahTerimaChecker,
	TglExpedisi,
	Cabang1,
	Cabang2,
	Cabang3,
	KodeSales,
	KodeToko,
	AlamatKirim, 
	Kota, 
	isClosed, 
	Catatan1,  
	Catatan2, 
	Catatan3, 
	Catatan4, 
	Catatan5, 
	SyncFlag, 
	LinkID, 
	NPrint, 
	TransactionType,
	HariKredit,
	HariKirim,
	HariSales,
	Checker1, 
	Checker2, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(), 
	RTRIM(a.idhtr), 
	RTRIM(a.idtr), 
	b.RowID,
	RTRIM(a.no_nota), 
	CONVERT(datetime , CASE LEFT(a.tgl_nota,2) WHEN '  ' THEN NULL ELSE RTRIM(a.tgl_nota) END ), 
	RTRIM(a.no_sj), 
	CONVERT(datetime , CASE LEFT(a.tgl_sj,2) WHEN '  ' THEN NULL ELSE RTRIM(a.tgl_sj) END ), 
	CAST((CASE WHEN tgl_trm = '  /  /  ' THEN NULL
					   WHEN RIGHT(tgl_trm,4) < 1900 THEN NULL
					  ELSE RTRIM(tgl_trm) 
					  END) AS DATETIME) AS tgl_trm,
	CAST((CASE WHEN tgl_strm = '  /  /  ' THEN NULL
					   WHEN RIGHT(tgl_strm,4) < 1900 THEN NULL
					  ELSE RTRIM(tgl_strm) 
					  END) AS DATETIME) AS tgl_strm,
	--CONVERT(datetime , CASE LEFT(a.tgl_trm,2) WHEN '  ' THEN NULL ELSE RTRIM(a.tgl_trm) END ), 
	--CONVERT(datetime , CASE LEFT(a.tgl_strm,2) WHEN '  ' THEN NULL ELSE RTRIM(a.tgl_strm) END ), 
	CAST((CASE WHEN a.tgl_reord = '  /  /  ' THEN NULL
					   WHEN RIGHT(a.tgl_reord,4) < 1900 THEN NULL
					  ELSE RTRIM(a.tgl_reord) 
					  END) AS DATETIME) AS tgl_reord,
	--a.tgl_reord,
	RTRIM(a.cab1),
	RTRIM(a.cab2),
	RTRIM(a.cab3),
	RTRIM(a.kd_sales),
	RTRIM(a.kd_toko),
	RTRIM(a.al_kirim), 
	RTRIM(a.kota), 
	a.laudit, 
	RTRIM(a.catatan1), 
	RTRIM(a.catatan2), 
	RTRIM(a.catatan3), 
	RTRIM(a.catatan4), 
	RTRIM(a.catatan5), 
	a.id_match, 
	a.id_link, 
	a.nprint, 
	RTRIM(a.id_tr),
	hr_krdt,
	hari_krm,
	hari_sls,
	RTRIM(a.checker_1), 
	RTRIM(a.checker_2), 
	'Admin', 
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT 
 idhtr,
 idtr,
 no_nota,
 DTOC(tgl_nota) tgl_nota,
 no_sj,
 DTOC(tgl_sj) tgl_sj,
 DTOC(tgl_trm) tgl_trm,
 DTOC(tgl_strm) tgl_strm,
 DTOC(tgl_reord) tgl_reord,
 cab1,cab2,cab3,
 kd_sales,
 kd_toko,
 al_kirim,
 kota,
 laudit,
 catatan1,
 catatan2,
 catatan3,
 catatan4,
 catatan5,
 id_match,
 nprint,
 id_tr,
 hr_krdt,
 hari_krm,
 hari_sls,
 checker_1,
 checker_2,
 id_link
 FROM htransj') a LEFT OUTER JOIN dbo.OrderPenjualan b
ON a.idhtr = b.HtrID


GO
--SELECT * FROM NotaPenjualan
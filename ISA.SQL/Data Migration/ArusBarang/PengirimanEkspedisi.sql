-- last editted by ferry
USE ISAdb 
GO
--DELETE FROM ISAdb.dbo.PengirimanEkspedisi
delete ISAdb.dbo.PengirimanEkspedisi
GO
INSERT INTO ISAdb.dbo.PengirimanEkspedisi
(
	RowID, 
	TrID, 
	NoKirim, 
	TglKirim, 
	TglKembali, 
	Tujuan, 
	Sopir, 
	Kernet, 
	NoPolisi, 
	KasBon, 
	BBMltr, 
	BBMRp, 
	UMSopir, 
	UMKernet, 
	Parkir, 
	Tol, 
	Kuli, 
	Lain, 
	KetLain, 
	Tarikan,
	NPrint,
	JamKirim,
	JamKembali,
	KMBerangkat,
	KMKirim,
	IzinMasuk,
	Timbangan,
	InTepatWaktu,
	InPengiriman,
	LastUpdatedBy, 
	LastUpdatedTime
)
 
SELECT 
	newid(), 
	RTRIM(idtr), 
	RTRIM(no_kirim), 
	CAST((CASE WHEN tgl_kirim1 = '  /  /  ' THEN NULL
	WHEN RIGHT(tgl_kirim1,4) < 1900 THEN NULL
	ELSE tgl_kirim1 
	END) AS DATETIME) AS tgl_kirim1,
	CAST((CASE WHEN tgl_kbl1 = '  /  /  ' THEN NULL
	WHEN RIGHT(tgl_kbl1,4) < 1900 THEN NULL
	ELSE tgl_kbl1 
	  END) AS DATETIME) AS tgl_kbl1,
	--CONVERT(datetime , CASE LEFT(tgl_kirim,2) WHEN '  ' THEN NULL ELSE RTRIM(tgl_kirim) END ),
	--CONVERT(datetime , CASE LEFT(tgl_kbl,2) WHEN '  ' THEN NULL ELSE RTRIM(tgl_kbl) END ),  
	RTRIM(tujuan), 
	RTRIM(supir), 
	RTRIM(kernet), 
	RTRIM(no_pol), 
	kasbon, 
	bbm_llr, 
	bbm_rp, 
	um_sopir, 
	um_kernet, 
	parkir, 
	tol, 
	kuli, 
	lain, 
	RTRIM(ket_lain),
	j_tarikan,
	nprint, 
	RTRIM(jam_kirim),
	RTRIM(jam_kbl),
	km_brkt,
	km_kbl,
	izin_msk,
	timbangan,
	in_tpt_wtk,
	in_pgrm,
	'Admin',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT DTOC(tgl_kirim) tgl_kirim1,DTOC(tgl_kbl) AS tgl_kbl1, * FROM Hxpdckp')
 


--UPDATE dbo.PengirimanEkspedisi
--SET
--	TglKirim = null
--WHERE 
--	TglKirim='1899/12/30' 
--
--UPDATE dbo.PengirimanEkspedisi 
--SET
--	TglKembali= null
--WHERE 
--	TglKembali='1899/12/30' 

GO

--SELECT * FROM PengirimanEkspedisi
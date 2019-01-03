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
	CAST((CASE WHEN tgl_kirim = '  /  /  ' THEN NULL
	WHEN RIGHT(tgl_kirim,4) < 1900 THEN NULL
	ELSE tgl_kirim 
	END) AS DATETIME) AS tgl_kirim,
	CAST((CASE WHEN tgl_kbl = '  /  /  ' THEN NULL
	WHEN RIGHT(tgl_kbl,4) < 1900 THEN NULL
	ELSE tgl_kbl 
	  END) AS DATETIME) AS tgl_kbl,
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
	'DELTA CRB',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', '
SELECT 
idtr,
no_kirim,
DTOC(tgl_kirim) tgl_kirim,
DTOC(tgl_kbl) AS tgl_kbl,
tujuan,
supir,
kernet,
no_pol,
kasbon, 
bbm_llr, 
bbm_rp, 
um_sopir, 
um_kernet, 
parkir, 
tol, 
kuli, 
lain, 
ket_lain,
j_tarikan,
nprint, 
jam_kirim,
jam_kbl,
km_brkt,
km_kbl,
izin_msk,
timbangan,
in_tpt_wtk,
in_pgrm
FROM Hxpdckp')

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

UPDATE DBO.PengirimanEkspedisi
SET RowID = b.RowID

FROM DBO.PengirimanEkspedisi a INNER JOIN ISAdb_JKT.DBO.PengirimanEkspedisi b ON a.TrID = b.TrID



GO 

--SELECT * FROM PengirimanEkspedisi
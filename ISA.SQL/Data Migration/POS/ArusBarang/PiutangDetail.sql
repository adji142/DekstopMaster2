USE ISAdb 
GO
DELETE FROM ISAdb.dbo.PiutangDetail
GO
INSERT INTO ISAdb.dbo.PiutangDetail
(
	RecordID, 
	KPID, 
	TglTransaksi, 
	KodeTransaksi, 
	Debet, 
	Kredit, 
	TglJTGiro, 
	Uraian, 
	KodeToko, 
	WilID, 
	SyncFlag, 
	NoBuktiKasMasuk, 
	NoGiro, 
	Bank, 
	NoACC, 
	isClosed, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	RTRIM(idrec),
	RTRIM(id_kp),
	CAST((CASE WHEN tgl_tr = '  /  /  ' THEN NULL
					   WHEN RIGHT(tgl_tr,4) < 1900 THEN NULL
					  ELSE tgl_tr 
					  END) AS DATETIME) AS tgl_tr,
	RTRIM(kd_trans),
	debet,
	kredit,
	CAST((CASE WHEN cbg_jt = '  /  /  ' THEN NULL
					   WHEN RIGHT(cbg_jt,4) < 1900 THEN NULL
					  ELSE cbg_jt 
					  END) AS DATETIME) AS cbg_jt,
	RTRIM(uraian),
	RTRIM(kd_toko),
	RTRIM(idwil),
	id_match,
	RTRIM(no_bkm),
	RTRIM(no_bg),
	RTRIM(bank),
	RTRIM(no_acc),
	laudit,
	'DELTA CRB',
	GETDATE()	
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT 
 idrec,
 id_kp,
 DTOC(tgl_tr) as tgl_tr,
 kd_trans,
 debet,
 kredit,
 DTOC(cbg_jt) as cbg_jt,
 uraian,
 kd_toko,
 idwil,
 id_match,
 no_bkm,
 no_bg,
 bank, 
 no_acc,
 laudit
 FROM dpiutang')

GO
--SELECT * FROM PiutangDetail 
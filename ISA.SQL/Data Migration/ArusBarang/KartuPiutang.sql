USE ISAdb 
GO
DELETE FROM ISAdb.dbo.KartuPiutang
GO
INSERT INTO ISAdb.dbo.KartuPiutang 
(
	KPID, 
	KodeToko, 
	KodeSales, 
	TglTransaksi, 
	NoTransaksi, 
	JangkaWaktu, 
	TglJatuhTempo, 
	Uraian, 
	RpJual, 
	RpKredit, 
	RpSisa, 
	TransactionType, 
	SyncFlag, 
	HariKirim, 
	HariSales, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	RTRIM(id_kp),
	RTRIM(kd_toko),
	RTRIM(kd_sales),
	tgl_tr,
	RTRIM(no_tr),
	jk_waktu,
	tgl_jt,
	RTRIM(uraian),
	rp_jual,
	rp_kredit,
	rp_sisa,
	RTRIM(id_tr),
	id_match,
	hari_krm,
	hari_sls,
	'Admin',
	GETDATE()	
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM kpiutang')

GO
--SELECT * FROM KartuPiutang 
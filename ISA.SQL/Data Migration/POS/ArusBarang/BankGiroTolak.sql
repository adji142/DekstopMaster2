 USE ISAdb 
GO
DELETE FROM ISAdb.dbo.BankGiroTolak
GO
INSERT INTO ISAdb.dbo.BankGiroTolak
(
	RecID, 
	KodeToko, 
	KPID, 
	Alasan, 
	TglGiro, 
	CabangJatuhTempo, 
	Uraian, 
	Debet, 
	Dibayar, 
	KodeSales, 
	SyncFlag, 
	NoBkm, 
	NoBg, 
	Bank, 
	NoACCPiutang, 
	lAudit, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	RTRIM(idrec), 
	RTRIM(kd_toko), 
	RTRIM(idkp),
	RTRIM(alasan),
	tgl_giro,
	cbg_jt,
	RTRIM(uraian),
	debet,
	dibayar,
	RTRIM(kd_sales),
	id_match,
	RTRIM(no_bkm),
	RTRIM(no_bg),
	RTRIM(bank),
	RTRIM(no_acc),
	laudit,
	'DELTA CRB',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM hbgtolak')

GO

--SELECT * FROM BankGiroTolak
USE ISAdb 
GO
DELETE FROM ISAdb.dbo.BankGiroTolakDetail
GO

SELECT idrec,
	Tgl_byr,
	Kd_bayar,
	Kredit,
	Cbg_jt,
	Uraian,
	Dstamp,
	No_bkm,
	No_bg,
	Bank,
	No_acc,
	id_match
INTO #TEMP	
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', '
SELECT  
	idrec,
	Tgl_byr,
	Kd_bayar,
	Kredit,
	DTOC(Cbg_jt) as Cbg_jt,
	Uraian,
	Dstamp,
	No_bkm,
	No_bg,
	Bank,
	No_acc,
	id_match
 FROM dbgtolak')


INSERT INTO ISAdb.dbo.BankGiroTolakDetail
(
	RecID, 
	TglBayar, 
	KodeBayar, 
	Kredit, 
	CabangJatuhTempo, 
	Uraian, 
	DStamp, 
	NoBkm, 
	NoBg, 
	Bank, 
	NoACCPiutang, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	RTRIM(idrec), 
	CONVERT(datetime , CASE LEFT(tgl_byr,2) WHEN '  ' THEN NULL ELSE RTRIM(tgl_byr) END ),
	RTRIM(kd_bayar),
	kredit,	
	CAST((CASE WHEN Cbg_jt = '  /  /  ' THEN NULL
					   WHEN RIGHT(Cbg_jt,4) < 1900 THEN NULL
					  ELSE Cbg_jt 
					  END) AS DATETIME) AS Cbg_jt,RTRIM(uraian),
	RTRIM(dstamp),
	RTRIM(no_bkm),
	RTRIM(no_bg),
	RTRIM(bank),
	RTRIM(no_acc),
	id_match,
	'Admin',
	GETDATE()
FROM #TEMP
	

GO

--SELECT * FROM BankGiroTolakDetail 
-- last edited by ferry
USE ISAdb 
GO
DELETE FROM ISAdb.DBO.RekapKoli
--DELETE FROM ISAdb.dbo.RekapKoli 
GO

INSERT INTO ISAdb.dbo.RekapKoli
(
	RowID, 
	RecordID, 
	TglSuratJalan, 
	NoSuratJalan, 
	KodeToko, 
	TglKeluar, 
	--KodeExpedisi1, 
	--KodeExpedisi2, 
	--KodeExpedisi3, 
	KodeExp1,
	KodeExp2,
	KodeExp3,
	Shift, 
	--ByExpedisi1, 
	--ByExpedisi2, 
	--ByExpedisi3, 
	BiayaExp1,
	BiayaExp2,
	BiayaExp3,
	NPrint, 
	KP, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
	  
SELECT 
	NEWID(),
	RTRIM(idtr), 
	CAST((CASE WHEN tgl_sj = '  /  /  ' THEN NULL
					   WHEN RIGHT(tgl_sj,4) < 1900 THEN NULL
					  ELSE tgl_sj 
					  END) AS DATETIME) AS tgl_sj,
	--CONVERT(datetime , CASE LEFT(tgl_sj ,2) WHEN '  ' THEN NULL ELSE RTRIM(tgl_sj) END ),
	RTRIM(no_sj),
	RTRIM(kd_toko),
	CAST((CASE WHEN tgl_klr = '  /  /  ' THEN NULL
					   WHEN RIGHT(tgl_klr,4) < 1900 THEN NULL
					  ELSE tgl_klr 
					  END) AS DATETIME) AS tgl_klr,
	
	--CONVERT(datetime , CASE LEFT(tgl_klr ,2) WHEN '  ' THEN NULL ELSE RTRIM(tgl_klr) END ),
	RTRIM(kd_exp),
	RTRIM(kd_exp2),
	RTRIM(kd_exp3),
	shift,
	by_exp,
	by_exp2,
	by_exp3,
	nprint,
	kp,
	id_match,
	'DELTA CRB',
	GETDATE()	  
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT 
idtr,
DTOC(tgl_sj) as tgl_sj,
no_sj,
kd_toko,
DTOC(tgl_klr) as tgl_klr,
kd_exp,
kd_exp2,
kd_exp3,
shift,
by_exp,
by_exp2,
by_exp3,
nprint,
kp,
id_match
FROM hxpdc')

GO
UPDATE DBO.RekapKoli
SET RowID = b.RowID
FROM DBO.RekapKoli a INNER JOIN ISAdb_JKT.DBO.RekapKoli b ON a.RecordID = b.RecordID

GO 
--SELECT * FROM RekapKoli 

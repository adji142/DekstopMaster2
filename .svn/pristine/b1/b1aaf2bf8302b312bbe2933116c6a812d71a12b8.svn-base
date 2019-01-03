 USE ISAFinance 
GO
DELETE FROM dbo.GiroTolak
GO

INSERT INTO dbo.GiroTolak
(
	RowID, 
	RecordID, 
	KartuPiutangID, 
	KPID, 
	KodeToko, 
	Status,
	Alasan, 
	TglGiro, 
	CbgJt, 
	Uraian, 
	Debet, 	 
	KodeSales, 
	SyncFlag, 
	NoBKM, 
	NoBG, 
	Bank, 
	NoACC, 
	Audit, 
	KetTagih, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	idrec,
	NULL,
	idkp,
	kd_toko,
	'OPEN',
	Alasan,
	Tgl_Giro,
	Cbg_jt,
	Uraian,
	Debet,	
	KD_sales,
	id_match,
	no_bkm,
	no_bg,
	Bank,
	no_acc,
	laudit,
	ket_tagih,	
	'DELTA CRB',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM HBGTolak')

GO

 UPDATE DBO.GiroTolak
SET 
RowID = b.RowID,
KartuPiutangID = b.KartuPiutangID

FROM DBO.GiroTolak a INNER JOIN ISAFinance_JKT.DBO.GiroTolak b ON a.RecordID =  b.RecordID


GO 
UPDATE dbo.GiroTolak
SET
KartuPiutangID = (SELECT TOP 1 RowID FROM KartuPiutang b WHERE b.KPID = a.KPID)
FROM dbo.GiroTolak a
GO


 
UPDATE DBO.GiroTolak
SET RowID = b.RowID
FROM DBO.GiroTolak a INNER JOIN DBO.IndenSubDetail b ON  a.RecordID = LEFT(b.RecordID,19)


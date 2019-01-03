USE ISAFinance 
GO
DELETE FROM dbo.KartuPiutangDetail
GO
INSERT INTO dbo.KartuPiutangDetail
(
	RowID,
	RecordID, 
	KPID, 
	TglTransaksi, 
	KodeTransaksi, 
	Debet, 
	Kredit, 
	TglJTGiro, 
	Uraian, 
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
	NEWID(),
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
 FROM DPIUTANG')

GO

UPDATE DBO.KartuPiutangDetail
SET 
RowID = b.RowID,
HeaderID = b.HeaderID

FROM DBO.KartuPiutangDetail a INNER JOIN ISAFinance_JKT.DBO.KartuPiutangDetail b ON a.RecordID =  b.RecordID


GO 
UPDATE dbo.KartuPiutangDetail
SET
	HeaderID = b.RowID
FROM dbo.KartuPiutangDetail a
INNER JOIN dbo.KartuPiutang b ON a.KPID = b.KPID

GO

UPDATE dbo.KartuPiutangDetail
SET
	RowID = b.RowID
FROM dbo.KartuPiutangDetail a
INNER JOIN dbo.IndenSuperDetail b ON a.RecordID = b.RecordID 
WHERE
KodeTransaksi  IN ('BGC', 'KAS', 'TRN')


UPDATE DBO.KartuPiutang
SET TglLink = b.TglTransaksi
FROM DBO.KartuPiutang a INNER JOIN DBO.KartuPiutangDetail b ON a.RowID = b.HeaderID
WHERE b.KodeTransaksi = 'PJT' OR b.KodeTransaksi = 'PJK'
GO
 
 
UPDATE KartuPiutang
	SET STATUS = CASE WHEN x.Debet = x.Kredit THEN 'CLOSE' ELSE 'OPEN' END
FROM dbo.KartuPiutang a
OUTER APPLY
	( 
			
	SELECT ISNULL(SUM( CASE WHEN (CHARINDEX(b.KodeTransaksi,'PJK | PJT')>0)  
          THEN  b.Debet  
          ELSE 0  
        END),0) AS Debet,  
      ISNULL( SUM(( CASE WHEN (CHARINDEX(b.KodeTransaksi,'PJK | PJT')>0) THEN  0   
          ELSE (-1 *b.Debet)+b.Kredit  
        END)) ,0)AS Kredit
    FROM dbo.KartuPiutangDetail b   WITH (NOLOCK)     
    WHERE b.HeaderID = a.RowID 
    AND (b.KodeTransaksi='PJK' OR b.KodeTransaksi='PJT')
	) x
GO
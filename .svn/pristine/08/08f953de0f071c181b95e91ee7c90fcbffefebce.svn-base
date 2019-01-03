 USE ISAFinance 
GO
DELETE FROM dbo.TagihanDetail
GO
INSERT INTO dbo.TagihanDetail
(
	RowID, 
	HeaderID, 
	RecordID, 
	HRecordID, 
	KPID, 
	KPRecID,
	Flag,
	TglInden, 
	RpNota, 
	RpBayar, 
	RpTagih, 	
	Keterangan,
	KodeTagih, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	NULL,
	idrec,
	id_reg,
	NULL,
	idkp,
	flag,
	tgl_tagih,
	rp_nota,
	rp_bayar,
	rp_tagih,	
	ket,
	'',
	'DELTA CRB',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM DTagihan')

GO

UPDATE DBO.TagihanDetail
SET 
RowID = b.RowID,
HeaderID = b.HeaderID,
KPID = b.KPID

FROM DBO.TagihanDetail a INNER JOIN ISAFinance_JKT.DBO.TagihanDetail b ON a.RecordID =  b.RecordID


GO 
UPDATE dbo.TagihanDetail
SET
HeaderID = (SELECT TOP 1 RowID FROM dbo.Tagihan b WHERE b.RecordID = a.HRecordID)
FROM dbo.TagihanDetail a

GO

UPDATE dbo.TagihanDetail
SET
KPID = (SELECT TOP 1 RowID FROM dbo.KartuPiutang b WHERE b.KPID = a.KPRecID)
FROM dbo.TagihanDetail a


GO



UPDATE dbo.TagihanDetail 
		SET KodeTagih='K'
		FROM dbo.TagihanDetail a
		INNER JOIN dbo.KartuPiutang k ON a.KPID=k.RowID

GO




UPDATE dbo.TagihanDetail
SET
KPID = (SELECT TOP 1 RowID FROM dbo.GiroTolak b WHERE b.RecordID = a.KPRecID)
FROM dbo.TagihanDetail a
WHERE LEN(a.KPRecID) = 19
GO

UPDATE dbo.TagihanDetail 
		SET KodeTagih='G'
		FROM dbo.TagihanDetail a
		INNER JOIN dbo.GiroTolak k ON a.KPID=k.RowID
WHERE LEN(a.KPRecID) = 19
GO 

update tagihandetail set tglinden=null
where tglinden='1899-12-30 00:00:00.000'


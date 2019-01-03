USE ISAFinance
GO
DELETE FROM ISAFinance.dbo.IndenSuperDetail
GO
INSERT INTO ISAFinance.dbo.IndenSuperDetail
(
	RowID, 
	HeaderID, 
	RecordID, 
	HRecordID, 
	TagihDetailID, 
	TagihDetailRecID, 
	KPID, 
	KPrecID,
	Src, 
	TglBPP, 
	NoReg, 
	Ref, 
	NoBukti, 
	TglInden, 
	TglJatuhTempo, 
	Kode, 
	Sub, 
	NoPerk, 
	RpInden, 
	RpNota, 
	RpTagih, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT
	NEWID(),
	NULL,	
	RTRIM(iddrec),
	RTRIM(id_coltoko),
	NULL,
	RTRIM(idrec),
	NULL,
	RTRIM(id_kp),
	'',
	CASE WHEN YEAR(tgl_bpp) < 1900 THEN NULL ELSE tgl_bpp END AS tgl_bpp ,
	RTRIM(no_reg),
	RTRIM(ref),
	RTRIM(no_bukti),
	tgl_ind,	
	tgl_jt,	
	RTRIM(kode),
	RTRIM(sub),
	RTRIM(no_perk),
	rp_ind,
	rp_nota,
	rp_tagih,
	id_match,
	'DELTA CRB',
	GETDATE()	
	FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM ddinden')

GO
UPDATE DBO.IndenSuperDetail
SET 
RowID = b.RowID,
HeaderID = b.HeaderID,
IndenID = b.IndenID,
IndenDetailID = b.IndenDetailID,
TagihDetailID = b.TagihDetailID,
KPID = b.KPID

FROM DBO.IndenSuperDetail a INNER JOIN ISAFinance_JKT.DBO.IndenSuperDetail b ON a.RecordID =  b.RecordID


GO 
UPDATE dbo.IndenSuperDetail
SET HeaderID = (SELECT TOP 1 RowID FROM dbo.IndenSubDetail b WHERE b.RecordID = a.HRecordID)
FROM dbo.IndenSuperDetail a
GO

UPDATE dbo.IndenSuperDetail
SET KPID = (SELECT TOP 1 RowID FROM dbo.KartuPiutang b WHERE b.KPID = a.KPRecID)
FROM dbo.IndenSuperDetail a
WHERE (LEN(a.KPRECID))>19
 GO
UPDATE INDENSUPERDETAIL
SET KPID=B.ROWID
FROM INDENSUPERDETAIL A INNER JOIN GIROTOLAK B
ON A.KPRECID=B.RECORDID
WHERE (LEN(A.KPRECID))=19

GO




UPDATE dbo.IndenSuperDetail
SET IndenID = (SELECT TOP 1 a.RowID 
					FROM 
						dbo.Inden a
						INNER JOIN dbo.IndenDetail b ON a.RowID = b.HeaderID
						INNER JOIN dbo.IndenSubDetail c ON b.RowID = c.HeaderID
					WHERE c.RowID  = d.HeaderID)
FROM dbo.IndenSuperDetail d
GO

UPDATE dbo.IndenSuperDetail
SET IndenDetailID = (SELECT TOP 1 b.RowID 
					FROM 
						dbo.IndenDetail b 
						INNER JOIN dbo.IndenSubDetail c ON b.RowID = c.HeaderID
					WHERE c.RowID  = d.HeaderID)
FROM dbo.IndenSuperDetail d


GO

UPDATE DBO.IndenSuperDetail 
SET Src = CASE WHEN (LEN(KPrecID)) = 19 THEN 'GT' WHEN (LEN(KPrecID)) >= 19 THEN 'KP' ELSE 'NP' END
GO

UPDATE DBO.IndenSuperDetail
SET TagihDetailID = (SELECT TOP 1 RowID FROM DBO.TagihanDetail t WHERE t.RecordID = isd.TagihDetailRecID)
FROM DBO.IndenSuperDetail isd
GO
USE ISAFinance_JKT
GO



INSERT INTO DBO.IndenSuperDetail
(
RowID, HeaderID, IndenID, IndenDetailID, RecordID, HRecordID, TagihDetailID, TagihDetailRecID, KPID, KPrecID, Src, TglBPP, NoReg, Ref, NoBukti, TglInden, TglJatuhTempo, Kode, Sub, NoPerk, RpInden, RpNota, RpTagih, SyncFlag, LastUpdatedBy, LastUpdatedTime
)
SELECT 
a.RowID, 
(SELECT TOP 1 RowID  FROM DBO.IndenSubDetail x WHERE x.RecordID = a.HRecordID) HeaderID, 
b.IndenID, 
b.IndenDetailID, 
a.RecordID, HRecordID, 
CASE WHEN a.TagihDetailRecID = c.RecordID THEN c.RowID ELSE a.TagihDetailID END AS TagihDetailID, 
TagihDetailRecID, 
CASE WHEN d.KPID = a.KPRecID AND (LEN(a.KPRECID))>19 THEN d.RowID 
WHEN e.RecordID = a.KPrecID AND (LEN(a.KPRECID))>19 THEN e.RowID
ELSE a.KPID END AS KPID, 
KPrecID, Src, TglBPP, NoReg, Ref, NoBukti, TglInden, TglJatuhTempo, Kode, Sub, NoPerk, RpInden, RpNota, RpTagih, SyncFlag, LastUpdatedBy, LastUpdatedTime
FROM ISAFinance.DBO.IndenSuperDetail a
OUTER APPLY
			(
			 SELECT TOP 1 x.RowID AS IndenID,y.RowID AS IndenDetailID FROM DBO.Inden x INNER JOIN DBO.IndenDetail y ON x.RowID = y.HeaderID
			 INNER JOIN DBO.IndenSubDetail z ON z.RowID = a.HeaderID
			)b
OUTER APPLY
			(
			 SELECT TOP 1 RowID,RecordID  FROM DBO.TagihanDetail x
			 WHERE a.TagihDetailRecID = x.RecordID
			
			)c
OUTER APPLY
			(
			 SELECT TOP 1 RowID,KPID   FROM DBO.KartuPiutang x
			 WHERE x.KPID = a.KPRecID
			 AND (LEN(a.KPRECID))>19
			)d
OUTER APPLY
			(
			 SELECT TOP 1  RowID,RecordID  FROM DBO.GiroTolak x
			 WHERE x.RecordID = a.KPrecID
			 AND (LEN(a.KPRECID))>19
			
			
			)e			

WHERE a.RecordID NOT IN (SELECT RecordID FROM DBO.IndenSuperDetail)
GO 
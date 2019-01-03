USE ISAFinance_JKT
GO



INSERT INTO DBO.TagihanDetail
(
RowID, HeaderID, RecordID, HRecordID, KPID, KPRecID, Flag, TglInden, RpNota, RpBayar, RpTagih, Keterangan, KodeTagih, LastUpdatedBy, LastUpdatedTime
)
SELECT a.RowID, 
(SELECT TOP 1 RowID  FROM DBO.Tagihan x WHERE x.RecordID = a.HRecordID ) AS HeaderID, 
a.RecordID, HRecordID, 
CASE WHEN b.KPID = a.KPRecID THEN b.RowID
WHEN c.RecordID = a.KPRecID AND LEN(a.KPRecID) = 19 THEN c.RowID END AS KPID, 
KPRecID, Flag, TglInden, RpNota, RpBayar, RpTagih, Keterangan, KodeTagih, LastUpdatedBy, LastUpdatedTime 
FROM ISAFinance.DBO.TagihanDetail a
OUTER APPLY
			(
			 SELECT TOP 1 RowID,KPID FROM DBO.KartuPiutang x WHERE x.KPID = a.KPRecID
			)b
OUTER APPLY
			(
			 SELECT TOP 1 RowID,RecordID   FROM DBO.GiroTolak x WHERE x.RecordID = a.KPRecID
			 AND LEN(a.KPRecID) = 19
			)c
			
WHERE a.RecordID NOT IN (SELECT RecordID FROM DBO.TagihanDetail)

GO 
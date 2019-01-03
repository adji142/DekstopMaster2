USE ISAFinance_JKT
GO


INSERT INTO DBO.GiroTolak
(
RowID, RecordID, KartuPiutangID, KPID, KodeToko, Status, Alasan, TglGiro, CbgJt, Uraian, Debet, KodeSales, SyncFlag, NoBKM, NoBG, Bank, NoACC, Audit, KetTagih, LastUpdatedBy, LastUpdatedTime
)
SELECT 
CASE WHEN a.RecordID = LEFT(c.RecordID,19) THEN c.RowID ELSE a.RowID END AS RowID, 
a.RecordID, 
CASE WHEN b.KPID = a.KPID THEN b.RowID ELSE a.KartuPiutangID END AS KartuPiutangID, 
a.KPID, KodeToko, Status, Alasan, TglGiro, CbgJt, Uraian, Debet, KodeSales, SyncFlag, NoBKM, NoBG, Bank, NoACC, Audit, KetTagih, LastUpdatedBy, LastUpdatedTime

FROM ISAFinance.DBO.GiroTolak a
OUTER APPLY
			(
			 SELECT TOP 1 KPID,RowID  FROM DBO.KartuPiutang x
			 WHERE x.KPID = a.KPID
			
			)b
OUTER APPLY
			(
			 SELECT TOP 1 RecordID,RowID   FROM DBO.IndenSubDetail x
			 WHERE a.RecordID = LEFT(x.RecordID,19)
						
			)c
WHERE a.RecordID NOT IN (SELECT RecordID FROM DBO.GiroTolak)
GO 
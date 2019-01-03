USE ISAFinance_JKT
GO



INSERT INTO DBO.GiroTolakDetail
(
RowID, HeaderID, RecordID, HRecordID, TglBayar, KodeBayar, Kredit, CbgJt, Uraian, NoBKM, NoBG, Bank, NoACC, SyncFlag, LastUpdatedBy, LastUpdatedTime
)
SELECT 
CASE WHEN a.recordid = substring(b.recordid,4,19) THEN b.RowID ELSE  a.RowID END AS RowID, 
(SELECT TOP 1 RowID FROM DBO.GiroTolak x WHERE x.RecordID = a.HRecordID) AS HeaderID, 
a.RecordID, HRecordID, TglBayar, KodeBayar, Kredit, CbgJt, Uraian, NoBKM, NoBG, Bank, NoACC, SyncFlag, LastUpdatedBy, LastUpdatedTime
FROM ISAFinance.DBO.GiroTolakDetail a

OUTER APPLY
			(
			 SELECT TOP 1 RecordID,RowID FROM DBO.IndenSuperDetail x
			 WHERE a.recordid = substring(x.recordid,4,19)
			
			)b
WHERE (a.HRecordID+a.RecordID) NOT IN (SELECT (HRecordID+RecordID) FROM DBO.GiroTolakDetail)
GO
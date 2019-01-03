USE ISAFinance_JKT
GO



INSERT INTO DBO.DKN
(
RowID, RecordID, Tanggal, NoDKN, DK, Cabang, CD, Src, RefTipe, RefNoBukti, RefRowID, SyncFlag, NPrint, LastUpdatedBy, LastUpdatedTime
)
SELECT  a.RowID, 
a.RecordID, 
Tanggal, NoDKN, DK, Cabang, CD, Src, RefTipe, RefNoBukti, 
CASE WHEN SUBSTRING(a.RecordID,1,22) = SUBSTRING(b.RecordID,1,22) THEN b.RowID
WHEN SUBSTRING(a.RecordID,1,22) = SUBSTRING(c.RecordID,1,22) AND c.MK = 'K' THEN c.RowID
WHEN SUBSTRING(a.RecordID,1,22) = SUBSTRING(d.RecordID,1,22) AND d.MK = 'M'	 THEN d.RowID
END	AS RefRowID, 
SyncFlag, NPrint, LastUpdatedBy, LastUpdatedTime
FROM ISAFinance.DBO.DKN a
OUTER APPLY
			(
			 SELECT TOP 1 RecordID,RowID FROM DBO.VoucherJournal x 
			 WHERE SUBSTRING(a.RecordID,1,22) = SUBSTRING(x.RecordID,1,22)
			
			)b
OUTER APPLY
			(
			 SELECT TOP 1  RecordID,RowID,MK   FROM DBO.Bukti x
			 WHERE SUBSTRING(a.RecordID,1,22) = SUBSTRING(x.RecordID,1,22)
			 AND x.MK = 'K'
			
			)c
OUTER APPLY
			(
			 SELECT TOP 1  RecordID,RowID,MK   FROM DBO.Bukti x
			 WHERE SUBSTRING(a.RecordID,1,22) = SUBSTRING(x.RecordID,1,22)
			 AND x.MK = 'M'			
			)d

WHERE a.RecordID NOT IN (SELECT RecordID FROM DBO.DKN)
GO
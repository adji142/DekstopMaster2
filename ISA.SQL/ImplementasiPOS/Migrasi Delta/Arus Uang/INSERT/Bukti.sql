USE ISAFinance_JKT
GO


INSERT INTO DBO.Bukti
(
RowID, RecordID, MK, JenisBukti, Src, SrcID, NoBukti, TglBukti, Kepada, Pembukuan, NoACC, Kasir, Penerima, NPrint, SyncFlag, LastUpdatedBy, LastUpdatedTime
)
SELECT  a.RowID, 
a.RecordID, MK, JenisBukti, Src, 
CASE WHEN  a.RecordID = rtrim(b.RecordID)+'I' THEN b.RowID
WHEN SUBSTRING(a.RecordID,1,22) = SUBSTRING(c.RecordID,1,22) THEN c.RowID
WHEN SUBSTRING(a.RecordID,1,22) = SUBSTRING(d.RecordID,1,22) AND SUBSTRING(a.RecordID,23,1)='B' THEN d.RowID
WHEN SUBSTRING(a.RecordID,1,22) = SUBSTRING(e.KPID,1,22)AND SUBSTRING(a.RecordID,23,1) = 'T' AND LEFT(e.TransactionType,1) = 'T' THEN e.RowID
WHEN a.RecordID = SUBSTRING(f.RecordID,1,22) + 'S' AND f.Tipe = 'TT' THEN f.RowID
END AS SrcID, 
NoBukti, TglBukti, Kepada, Pembukuan, NoACC, Kasir, Penerima, NPrint, SyncFlag, LastUpdatedBy, LastUpdatedTime
FROM ISAFinance.DBO.Bukti a
OUTER APPLY
			(
			  SELECT TOP 1 RowID,RecordID FROM DBO.inden x
			  WHERE a.RecordID = rtrim(x.RecordID)+'I'
			)b
OUTER APPLY
			(
			  SELECT TOP 1  RecordID,RowID FROM DBO.KasBon x
			  WHERE SUBSTRING(a.RecordID,1,22) = SUBSTRING(x.RecordID,1,22)
			)c
OUTER APPLY
			(
			  SELECT TOP 1 RecordID,RowID  FROM DBO.BankDetail x
			  WHERE SUBSTRING(a.RecordID,1,22) = SUBSTRING(x.RecordID,1,22)
			  AND SUBSTRING(a.RecordID,23,1)='B'
			
			)d
OUTER APPLY
			(
			  SELECT TOP 1 TransactionType,KPID, RowID   FROM DBO.KartuPiutang x
			  WHERE SUBSTRING(a.RecordID,1,22) = SUBSTRING(x.KPID,1,22)
			  AND SUBSTRING(a.RecordID,23,1) = 'T' AND LEFT(x.TransactionType,1) = 'T'
			
			)e
OUTER APPLY
			(
			 SELECT  TOP  1 RecordID,RowID,Tipe    FROM DBO.VoucherJournal x
			 WHERE a.RecordID = SUBSTRING(x.RecordID,1,22) + 'S'
			 AND x.Tipe = 'TT'
			
			)f


WHERE a.RecordID NOT IN (SELECT RecordID FROM DBO.Bukti)
GO 
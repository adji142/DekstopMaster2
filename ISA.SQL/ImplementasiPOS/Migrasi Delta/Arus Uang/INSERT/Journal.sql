USE ISAFinance_JKT
GO


INSERT INTO DBO.Journal
(
RowID, RecordID, Tanggal, NoReff, Uraian, Src, KodeGudang, SyncFlag, LastUpdatedBy, LastUpdatedTime, RefRowID
)
SELECT 
CASE WHEN b.RecordID = a.RecordID AND a.Src IN ('BKK','BKM') THEN b.RowID 
WHEN c.RecordID = a.RecordID AND a.Src = 'BBB' THEN c.RowID
WHEN d.RecordID = a.RecordID AND a.Src = 'BBM' THEN d.RowID
WHEN e.VoucherRecID = a.RecordID AND a.Src = 'VPG' THEN e.VoucherID
WHEN f.TitipRecID = a.RecordID AND a.Src = 'VTG' THEN f.TitipID
WHEN g.RecordID = a.RecordID AND a.Src = 'VJU' THEN g.RowID
ELSE a.RowID
END AS RowID, 
a.RecordID, Tanggal, NoReff, Uraian, Src, KodeGudang, SyncFlag, LastUpdatedBy, LastUpdatedTime, RefRowID 
FROM ISAFinance.DBO.Journal a
OUTER APPLY
			(
			 SELECT TOP 1  RecordID,RowID FROM DBO.Bukti x
			 WHERE x.RecordID = a.RecordID
			)b
OUTER APPLY
			(
			 SELECT TOP 1 RecordID,RowID  FROM DBO.BankDetail x
			 WHERE x.RecordID = a.RecordID
			
			)c
OUTER APPLY
			(
			 SELECT TOP 1 RecordID,RowID  FROM DBO.BBM x
			 WHERE x.RecordID = a.RecordID
			)d
OUTER APPLY
			(
			 SELECT TOP 1  VoucherRecID,VoucherID FROM DBO.Giro x
			 WHERE x.VoucherRecID = a.RecordID
			
			)e
OUTER APPLY
			(
			 SELECT TOP 1 TitipRecID,TitipID  FROM DBO.Giro x
			 WHERE x.TitipRecID = a.RecordID
			
			)f
OUTER APPLY
			(
			 SELECT TOP 1 RecordID,RowID  FROM DBO.VoucherJournal x
			 WHERE x.RecordID = a.RecordID
			
			)g

WHERE a.RecordID NOT IN (SELECT RecordID FROM DBO.Journal)
GO 
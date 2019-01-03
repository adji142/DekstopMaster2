USE ISAFinance_JKT
GO



INSERT INTO DBO.DKNDetail
(
RowID, HeaderID, RecordID, HRecordID, RefRowID, NoPerkiraan, Uraian, Jumlah, Tolak, Dari, Alasan, LastUpdatedBy, LastUpdatedTime
)
SELECT a.RowID, 
(SELECT  TOP 1 RowID FROM DBO.DKN x WHERE x.RecordID = a.HRecordID ) AS HeaderID, 
a.RecordID, HRecordID, 
CASE WHEN SUBSTRING(a.RecordID,1,22) = SUBSTRING(b.RecordID,1,22) THEN b.RowID
WHEN SUBSTRING(a.RecordID,1,22) = SUBSTRING(c.RecordID,1,22) THEN c.RowID
END AS RefRowID, 
NoPerkiraan, Uraian, Jumlah, Tolak, Dari, Alasan, LastUpdatedBy, LastUpdatedTime
FROM ISAFinance.DBO.DKNDetail a
OUTER APPLY
			(
			 SELECT TOP 1 RecordID,RowID  FROM DBO.BuktiDetail x
			 WHERE SUBSTRING(a.RecordID,1,22) = SUBSTRING(x.RecordID,1,22)
			
			)b
OUTER APPLY
			(
			
			 SELECT TOP 1 RecordID,RowID   FROM DBO.VoucherJournalDetail x
			 WHERE SUBSTRING(a.RecordID,1,22) = SUBSTRING(x.RecordID,1,22)
			
			)c
WHERE a.RecordID NOT IN (SELECT RecordID FROM DBO.DKNDetail)
GO 
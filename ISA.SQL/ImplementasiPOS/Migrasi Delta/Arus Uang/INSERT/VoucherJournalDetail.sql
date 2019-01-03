USE ISAFinance_JKT
GO



INSERT INTO DBO.VoucherJournalDetail
(
RowID, HeaderID, RecordID, HRecordID, Kode, Sub, VoucherType, VoucherNo, NoPerkiraan, Keterangan, Debet, Kredit, SyncFlag, LastUpdatedBy, LastUpdatedTime
)
SELECT 
CASE WHEN b.RecordID = a.RecordID THEN b.RowID ELSE a.RowID END AS RowID, 
(SELECT TOP 1 RowID  FROM DBO.VoucherJournal x WHERE x.RecordID = a.HRecordID) AS HeaderID, 
a.RecordID, HRecordID, Kode, Sub, VoucherType, VoucherNo, NoPerkiraan, Keterangan, Debet, Kredit, SyncFlag, LastUpdatedBy, LastUpdatedTime
FROM ISAFinance.DBO.VoucherJournalDetail a
OUTER APPLY
			(
			 SELECT TOP 1 RowID,RecordID   FROM DBO.IndenDetail x
			 WHERE x.RecordID = a.RecordID
			)b
WHERE a.RecordID NOT IN (SELECT RecordID FROM DBO.VoucherJournalDetail)

GO 
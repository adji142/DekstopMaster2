USE ISAFinance_JKT
GO



INSERT INTO DBO.VoucherJournal
(
RowID, RecordID, RefRowID, Tipe, TglVoucher, NoVoucher, Uraian1, Uraian2, Uraian3, Dibuat, Dibukukan, Mengetahui, BankID, NamaBank, NPrint, SyncFlag, LastUpdatedBy, LastUpdatedTime
)
SELECT 
a.RowID, a.RecordID, 
CASE WHEN SUBSTRING(a.RecordID,1,22)=SUBSTRING(b.RecordID,1,22) THEN b.RowID
WHEN SUBSTRING(a.RecordID,1,22) = SUBSTRING(c.RecordID,1,22) THEN c.RowID END AS RefRowID, 
Tipe, TglVoucher, NoVoucher, Uraian1, Uraian2, Uraian3, Dibuat, Dibukukan, Mengetahui, BankID, NamaBank, NPrint, SyncFlag, LastUpdatedBy, LastUpdatedTime
FROM ISAFinance.DBO.VoucherJournal a
OUTER APPLY
			(
			 SELECT TOP 1 RowID,RecordID  FROm DBO.Inden x
			 WHERE SUBSTRING(a.RecordID,1,22)=SUBSTRING(x.RecordID,1,22)
			
			)b
OUTER APPLY
			(
			 SELECT TOP 1 RowID,RecordID FROm DBO.KasBon x
			 WHERE SUBSTRING(a.RecordID,1,22) = SUBSTRING(x.RecordID,1,22)
			
			)c

WHERE a.RecordID NOT IN (SELECT RecordID FROM DBO.VoucherJournal)

GO 
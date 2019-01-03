USE ISAFinance_JKT
GO



INSERT INTO DBO.IndenDetail
(
RowID, HeaderID, RecordID, HRecordID, TglTrf, BankID, NamaBank, Lokasi, CHBG, Nomor, TglGiro, TglJt, Ket, NoAcc, RpCash, RpGiro, RpTrf, RpCrd, RpDbt, SyncFlag, LastUpdatedBy, LastUpdatedTime
)
SELECT RowID, 
(SELECT TOP 1 RowID  FROM DBO.Inden x WHERE x.RecordID = a.HRecordID) AS HeaderID, 
RecordID, HRecordID, TglTrf, BankID, NamaBank, Lokasi, CHBG, Nomor, TglGiro, TglJt, Ket, NoAcc, RpCash, RpGiro, RpTrf, RpCrd, RpDbt, SyncFlag, LastUpdatedBy, LastUpdatedTime

FROM ISAFinance.DBO.IndenDetail a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.IndenDetail)
GO 
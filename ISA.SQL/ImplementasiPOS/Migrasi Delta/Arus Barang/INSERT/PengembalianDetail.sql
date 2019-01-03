USE ISAdb_JKT
GO



INSERT INTO DBO.PengembalianDetail
(
RowID, HeaderID, PeminjamanID, RecordID, TransactionID, IDPinjam, NoPinjam, QtyKembali, Catatan, SyncFlag, LastUpdatedBy, LastUpdatedTime
)
SELECT RowID, 
(SELECT TOP 1 RowID FROM DBO.Pengembalian x WHERE x.RecordID = a.TransactionID) AS HeaderID, 
PeminjamanID, RecordID, TransactionID, IDPinjam, NoPinjam, QtyKembali, Catatan, SyncFlag, LastUpdatedBy, LastUpdatedTime
FROM ISAdb.DBO.PengembalianDetail a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.PengembalianDetail)

GO
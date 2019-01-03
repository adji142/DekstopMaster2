USE ISAdb_JKT
GO



INSERT INTO DBO.PeminjamanDetail
(
RowID, HeaderID, TransactionID, RecordID, KodeBarang, QtyMemo, QtyKeluarGudang, Catatan, SyncFlag, LastUpdatedTime, LastUpdatedBy
)
SELECT RowID, 
(SELECT TOP 1 RowID FROM DBO.PeminjamanDetail x WHERE x.RecordID = a.TransactionID) AS HeaderID, 
TransactionID, RecordID, KodeBarang, QtyMemo, QtyKeluarGudang, Catatan, SyncFlag, LastUpdatedTime, LastUpdatedBy 
FROM ISAdb.DBO.PeminjamanDetail a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.PeminjamanDetail)

GO 
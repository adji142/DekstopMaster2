USE ISAdb_JKT
GO


INSERT INTO DBO.SelisihDetail
(
RowID, HeaderID, RecordID, TransactionID, KodeBarang, QtyComp, QtyOpname, Catatan, SyncFlag, LastUpdatedTime, LastUpdatedBy
)
SELECT RowID, 
(SELECT TOP 1 RowID FROM DBO.Selisih x WHERE x.RecordID = a.TransactionID) AS HeaderID, 
RecordID, TransactionID, KodeBarang, QtyComp, QtyOpname, Catatan, SyncFlag, LastUpdatedTime, LastUpdatedBy 
FROM ISAdb.DBO.SelisihDetail a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.SelisihDetail)

GO
USE ISAdb_JKT
GO



INSERT INTO DBO.AntarGudangDetail
(
RowID, HeaderID, RecordID, TransactionID, KodeBarang, QtyKirim, QtyTerima, Catatan, Ongkos, SyncFlag, QtyDO, LastUpdatedTime, LastUpdatedBy
)

SELECT RowID, 
(SELECT TOP 1 RowID FROM DBO.AntarGudang x WHERE x.RecordID = a.TransactionID) AS HeaderID, 
RecordID, TransactionID, KodeBarang, QtyKirim, QtyTerima, Catatan, Ongkos, SyncFlag, QtyDO, LastUpdatedTime, LastUpdatedBy
FROM ISAdb.DBO.AntarGudangDetail a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.AntarGudangDetail)

GO
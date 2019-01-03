USE ISAdb_JKT
GO


INSERT INTO DBO.OrderPembelianDetail
(
RowID, HeaderID, RecordID, HeaderRecID, BarangID, QtyDO, QtyBO, QtyTambahan, QtyJual, QtyAkhir, Keterangan, KodeGudang, Catatan, SyncFlag, LastUpdatedBy, LastUpdatedTime
)
SELECT RowID, 
(SELECT TOP 1 RowID FROM DBO.OrderPembelian x WHERE x.RecordID = a.HeaderRecID) AS HeaderID, 
RecordID, HeaderRecID, BarangID, QtyDO, QtyBO, QtyTambahan, QtyJual, QtyAkhir, Keterangan, KodeGudang, Catatan, SyncFlag, LastUpdatedBy, LastUpdatedTime
FROM ISAdb.DBO.OrderPembelianDetail a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.OrderPembelianDetail)

GO 
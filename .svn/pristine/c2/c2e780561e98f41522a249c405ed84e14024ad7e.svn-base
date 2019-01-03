USE ISAdb_JKT
GO



INSERT INTO DBO.ReturPenjualanTarikanDetail
(
RowID, HeaderID, RecordID, ReturID, NotaAsal, KodeRetur, BarangID, KodeSales, QtyMemo, QtyTarik, QtyTerima, QtyGudang, QtyTolak, HrgJual, Pot, Catatan1, Catatan2, SyncFlag, Kategori, KodeGudang, NoACC, LastUpdatedBy, LastUpdatedTime
)
SELECT RowID, 
(SELECT TOP 1 RowID FROM DBO.ReturPenjualan x WHERE x.ReturID = a.ReturID) AS HeaderID, 
RecordID, ReturID, NotaAsal, KodeRetur, BarangID, KodeSales, QtyMemo, QtyTarik, QtyTerima, QtyGudang, QtyTolak, HrgJual, Pot, Catatan1, Catatan2, SyncFlag, Kategori, KodeGudang, NoACC, LastUpdatedBy, LastUpdatedTime
FROM ISAdb.DBO.ReturPenjualanTarikanDetail a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.ReturPenjualanTarikanDetail)

GO 
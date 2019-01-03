USE ISAdb_JKT
GO


INSERT INTO DBO.ReturPembelianManualDetail
(
RowID, HeaderID, RecordID, ReturID, BarangID, KodeRetur, QtyGudang, QtyTerima, HrgBeli, HrgNet, HrgPokok, HPPSolo, Catatan, TglKeluar, KodeGudang, SyncFlag, LastUpdatedBy, LastUpdatedTime
)
SELECT RowID, 
(SELECT TOP 1 RowID FROM DBO.ReturPembelian x WHERE x.ReturID = a.ReturID) AS HeaderID, 
RecordID, ReturID, BarangID, KodeRetur, QtyGudang, QtyTerima, HrgBeli, HrgNet, HrgPokok, HPPSolo, Catatan, TglKeluar, KodeGudang, SyncFlag, LastUpdatedBy, LastUpdatedTime 
FROM ISAdb.DBO.ReturPembelianManualDetail a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.ReturPembelianManualDetail)

GO
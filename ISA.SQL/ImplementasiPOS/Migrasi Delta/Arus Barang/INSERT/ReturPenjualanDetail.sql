USE ISAdb_JKT
GO



INSERT INTO DBO.ReturPenjualanDetail
(
RowID, HeaderID, NotaJualDetailID, RecordID, ReturID, NotaJualDetailRecID, KodeRetur, BarangID, QtyMemo, QtyTarik, QtyTerima, QtyGudang, QtyTolak, HrgJual, Catatan1, Catatan2, SyncFlag, Kategori, KodeGudang, NoACC, LastUpdatedBy, LastUpdatedTime
)
SELECT RowID, 
(SELECT TOP 1 RowID FROM DBO.ReturPenjualan x WHERE x.ReturID = a.ReturID ) AS HeaderID, 
(SELECT TOP 1 RowID FROM DBO.NotaPenjualanDetail y WHERE y.RecordID = a.NotaJualDetailRecID) AS NotaJualDetailID, 
RecordID, ReturID, NotaJualDetailRecID, KodeRetur, BarangID, QtyMemo, QtyTarik, QtyTerima, QtyGudang, QtyTolak, HrgJual, Catatan1, Catatan2, SyncFlag, Kategori, KodeGudang, NoACC, LastUpdatedBy, LastUpdatedTime

FROM ISAdb.DBO.ReturPenjualanDetail a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.ReturPenjualanDetail)

GO
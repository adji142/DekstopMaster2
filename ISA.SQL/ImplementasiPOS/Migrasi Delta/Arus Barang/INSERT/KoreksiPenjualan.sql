USE ISAdb_JKT
GO



INSERT INTO DBO.KoreksiPenjualan
(
RowID, RecordID, NotaJualDetailID, NotaJualDetailRecID, TglKoreksi, NoKoreksi, BarangID, QtyNotaBaru, HrgJualBaru, Catatan, KodeToko, Sumber, LinkID, HrgJualKoreksi, QtyNotaKoreksi, SyncFlag, LastUpdatedBy, LastUpdatedTime
)
SELECT RowID, RecordID, 
(SELECT TOP 1 RowID FROM DBO.NotaPenjualanDetail x WHERE x.RecordID = a.NotaJualDetailRecID) AS NotaJualDetailID, 
NotaJualDetailRecID, TglKoreksi, NoKoreksi, BarangID, QtyNotaBaru, HrgJualBaru, Catatan, KodeToko, Sumber, LinkID, HrgJualKoreksi, QtyNotaKoreksi, SyncFlag, LastUpdatedBy, LastUpdatedTime
FROM ISAdb.DBO.KoreksiPenjualan a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.KoreksiPenjualan)

GO
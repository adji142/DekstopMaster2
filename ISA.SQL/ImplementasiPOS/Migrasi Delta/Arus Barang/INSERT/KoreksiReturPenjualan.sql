USE ISAdb_JKT
GO



INSERT INTO DBO.KoreksiReturPenjualan
(
RowID, RecordID, ReturJualDetailID, ReturJualDetailRecID, TglKoreksi, NoKoreksi, BarangID, QtyNotaBaru, HrgJualBaru, Catatan, KodeToko, Sumber, LinkID, HrgJualKoreksi, QtyNotaKoreksi, SyncFlag, LastUpdatedBy, LastUpdatedTime
)
SELECT 
a.RowID, a.RecordID, 
CASE WHEN a.RecordID = b.RecordID THEN b.RowID ELSE c.RowID END  AS ReturJualDetailID, 
ReturJualDetailRecID, TglKoreksi, NoKoreksi, BarangID, QtyNotaBaru, HrgJualBaru, Catatan, KodeToko, Sumber, LinkID, HrgJualKoreksi, QtyNotaKoreksi, SyncFlag, LastUpdatedBy, LastUpdatedTime
 
FROM ISAdb.DBO.KoreksiReturPenjualan a
OUTER APPLY
			(
			 SELECT TOP 1 RecordID,RowID FROM DBO.ReturPenjualanDetail x 
			 WHERE x.RecordID = a.ReturJualDetailRecID
			)b
OUTER APPLY
			(
			 SELECT TOP 1 RecordID,RowID  FROM DBO.ReturPenjualanTarikanDetail x
			 WHERE x.RecordID = a.ReturJualDetailRecID
			)c
WHERE a.RecordID NOT IN (SELECT RecordID FROM DBO.KoreksiReturPenjualan)

GO
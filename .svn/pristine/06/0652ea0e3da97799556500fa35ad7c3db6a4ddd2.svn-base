USE ISAdb_JKT
GO



INSERT INTO DBO.KoreksiReturPembelian
(
RowID, RecordID, ReturBeliDetailID, ReturBeliDetailRecID, TglKoreksi, NoKoreksi, BarangID, QtyNotaBaru, HrgBeliBaru, Catatan, Pemasok, Sumber, LinkID, HrgBeliKoreksi, QtyNotaKoreksi, SyncFlag, LastUpdatedBy, LastUpdatedTime
)

SELECT RowID, 
RecordID, 
(SELECT TOP 1 RowID FROM DBO.ReturPembelianDetail x WHERE x.RecordID = a.ReturBeliDetailRecID) AS ReturBeliDetailID, 
ReturBeliDetailRecID, TglKoreksi, NoKoreksi, BarangID, QtyNotaBaru, HrgBeliBaru, Catatan, Pemasok, Sumber, LinkID, HrgBeliKoreksi, QtyNotaKoreksi, SyncFlag, LastUpdatedBy, LastUpdatedTime
FROM ISAdb.DBO.KoreksiReturPembelian a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.KoreksiReturPembelian)

GO 
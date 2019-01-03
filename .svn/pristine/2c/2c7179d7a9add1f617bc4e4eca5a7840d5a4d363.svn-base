USE ISAdb_JKT
GO



INSERT INTO DBO.KoreksiPembelian
(
RowID, RecordID, NotaBeliDetailID, NotaBeliDetailRecID, TglKoreksi, NoKoreksi, BarangID, QtyNotaBaru, HrgBeliBaru, Catatan, Pemasok, Sumber, LinkID, HrgBeliKoreksi, QtyNotaKoreksi, SyncFlag, LastUpdatedBy, LastUpdatedTime
)

SELECT RowID, 
RecordID, 
(SELECT TOP 1 RowID FROM DBO.NotaPembelianDetail x WHERE x.RecordID = a.NotaBeliDetailRecID ) AS NotaBeliDetailID, 
NotaBeliDetailRecID, TglKoreksi, NoKoreksi, BarangID, QtyNotaBaru, HrgBeliBaru, Catatan, Pemasok, Sumber, LinkID, HrgBeliKoreksi, QtyNotaKoreksi, SyncFlag, LastUpdatedBy, LastUpdatedTime
FROM ISAdb.DBO.KoreksiPembelian a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.KoreksiPembelian)

GO
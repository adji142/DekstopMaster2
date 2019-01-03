USE ISAdb_JKT
GO



INSERT INTO DBO.MutasiDetail
(
RowID, HeaderID, MutasiID, RecordID, QtyMutasi, KodeBarang, Keterangan, Gudang, SyncFlag, LastUpdatedBy, LastUpdatedTime
)
SELECT RowID, 
(SELECT TOP 1 RowID FROM DBO.Mutasi x WHERE x.MutasiID = a.MutasiID)HeaderID, 
MutasiID, RecordID, QtyMutasi, KodeBarang, Keterangan, Gudang, SyncFlag, LastUpdatedBy, LastUpdatedTime
FROM ISAdb.DBO.MutasiDetail a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.MutasiDetail)

GO 
USE ISAdb_JKT
GO



INSERT INTO DBO.ReturPembelianDetail
(
RowID, HeaderID, NotaBeliDetailID, RecordID, ReturID, NotaBeliDetailRecID, KodeRetur, BarangID, QtyGudang, QtyTerima, HrgBeli, HrgNet, HrgPokok, HPPSolo, Catatan, TglKeluar, KodeGudang, SyncFlag, LastUpdatedBy, LastUpdatedTime
)
SELECT RowID, 
(SELECT TOP 1 RowID FROM DBO.ReturPembelian x WHERE x.ReturID = a.ReturID) AS HeaderID, 
(SELECT TOP 1 RowID FROM DBO.NotaPembelianDetail y WHERE y.RecordID = a.NotaBeliDetailRecID) AS NotaBeliDetailID, 
RecordID, ReturID, NotaBeliDetailRecID, KodeRetur, BarangID, QtyGudang, QtyTerima, HrgBeli, HrgNet, HrgPokok, HPPSolo, Catatan, TglKeluar, KodeGudang, SyncFlag, LastUpdatedBy, LastUpdatedTime

FROM ISAdb.DBO.ReturPembelianDetail a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.ReturPembelianDetail)

GO 
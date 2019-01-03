USE ISAdb_JKT
GO



INSERT INTO DBO.NotaPembelianDetail
(
RowID, HeaderID, RecordID, HeaderRecID, BarangID, QtyRequest, QtyDO, QtySuratJalan, QtyNota, Catatan, TglTerima, HrgBeli, HrgPokok, HPPSolo, Pot, Disc1, Disc2, Disc3, DiscFormula, PPN, KodeGudang, KoreksiID, SyncFlag, LastUpdatedBy, LastUpdatedTime
)

SELECT 
RowID, 
(SELECT TOP 1 RowID  FROM DBO.NotaPembelian x WHERE x.RecordID = a.HeaderRecID )HeaderID, 
RecordID, HeaderRecID, BarangID, QtyRequest, QtyDO, QtySuratJalan, QtyNota, Catatan, TglTerima, HrgBeli, HrgPokok, HPPSolo, Pot, Disc1, Disc2, Disc3, DiscFormula, PPN, KodeGudang, KoreksiID, SyncFlag, LastUpdatedBy, LastUpdatedTime
FROM ISAdb.DBO.NotaPembelianDetail a 
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.NotaPembelianDetail)

GO  
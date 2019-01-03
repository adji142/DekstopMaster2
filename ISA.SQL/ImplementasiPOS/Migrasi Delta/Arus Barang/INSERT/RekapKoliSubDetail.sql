USE ISAdb_JKT
GO



INSERT INTO DBO.RekapKoliSubDetail
(
RowID, HeaderID, RecordID, HtrID, Uraian, Jumlah, Satuan, Keterangan, SyncFlag, LastUpdatedBy, LastUpdatedTime
)
SELECT RowID, 
(SELECT TOP 1 RowID FROM DBO.RekapKoliDetail x WHERE x.RecordID = a.HtrID) AS HeaderID, 
RecordID, HtrID, Uraian, Jumlah, Satuan, Keterangan, SyncFlag, LastUpdatedBy, LastUpdatedTime
FROM ISAdb.DBO.RekapKoliSubDetail a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.RekapKoliSubDetail)

GO
USE ISAdb_JKT
GO



INSERT INTO DBO.RekapKoliDetail
(
RowID, HeaderID, NotaJualID, RecordID, HtrID, NotaJualRecID, NoNota, TunaiKredit, Nominal, Uraian, Keterangan, NoResi, SyncFlag, LastUpdatedBy, LastUpdatedTime
)
SELECT RowID, 
(SELECT TOP 1 RowID FROM DBO.RekapKoli x WHERE x.RecordID = a.HtrID ) AS HeaderID, 
(SELECT TOP 1 RowID FROM DBO.NotaPenjualan y WHERE y.RecordID = a.NotaJualRecID) AS NotaJualID, 
RecordID, HtrID, NotaJualRecID, NoNota, TunaiKredit, Nominal, Uraian, Keterangan, NoResi, SyncFlag, LastUpdatedBy, LastUpdatedTime
FROM ISAdb.DBO.RekapKoliDetail a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.RekapKoliDetail)

GO
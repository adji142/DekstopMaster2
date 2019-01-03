USE ISAdb_JKT
GO



INSERT INTO DBO.PengirimanEkspedisiDetail
(
RowID, HeaderID, TrID, RecordID, RekapKoliID, KetPending, LastUpdatedBy, LastUpdatedTime
)
SELECT RowID, 
(SELECT TOP 1 RowID FROM DBO.PengirimanEkspedisi x WHERE x.TrID = a.TrID) AS HeaderID, 
TrID, RecordID, 
RekapKoliID, 
KetPending, LastUpdatedBy, LastUpdatedTime
FROM ISAdb.DBO.PengirimanEkspedisiDetail a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.PengirimanEkspedisiDetail)

GO
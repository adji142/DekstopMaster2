USE ISAdb_JKT
GO

INSERT INTO DBO.OpnameDetail3
(
RowID, HeaderID, RecordID, TransactionID, KodeGudang, TglOpname, NoForm, Baik, Cacat, Rusak, Pengguna, SyncFlag, Flag, LastUpdatedBy, LastUpdatedTime
)
SELECT RowID, 
(SELECT TOP 1 RowID FROM DBO.Opname x WHERE x.RecordID = a.TransactionID) AS HeaderID, 
RecordID, TransactionID, KodeGudang, TglOpname, NoForm, Baik, Cacat, Rusak, Pengguna, SyncFlag, Flag, LastUpdatedBy, LastUpdatedTime
FROM ISAdb.DBO.OpnameDetail3 a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.OpnameDetail3)

GO
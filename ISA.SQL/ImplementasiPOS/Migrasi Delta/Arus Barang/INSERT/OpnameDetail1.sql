USE ISAdb_JKT
GO

INSERT INTO DBO.OpnameDetail1
(
RowID, HeaderID, RecordID, TransactionID, KodeGudang, TglOpname, NoForm, Baik, Cacat, Rusak, Pengguna, SyncFlag, Flag, LastUpdatedBy, LastUpdatedTime
)
SELECT RowID, 
(SELECT TOP 1 RowID FROM DBO.Opname x WHERE x.RecordID = a.TransactionID ) AS HeaderID, 
RecordID, TransactionID, KodeGudang, TglOpname, NoForm, Baik, Cacat, Rusak, Pengguna, SyncFlag, Flag, LastUpdatedBy, LastUpdatedTime

FROM ISAdb.DBO.OpnameDetail1 a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.OpnameDetail1)

GO 
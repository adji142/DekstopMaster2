USE ISAdb_JKT
GO

INSERT INTO DBO.BarangBonusDetail
(
RowId, HeaderId, TrId, RecordId, BarangId, Qty, SyncFlag, LastUpdatedBy, LastUpdatedTime
)

SELECT RowId, 
(SELECT TOP 1 RowID  FROM DBO.BarangBonus x WHERE x.TrID = a.TrId)  AS HeaderId, 
TrId, RecordId, BarangId, Qty, SyncFlag, LastUpdatedBy, LastUpdatedTime 
FROM ISAdb.DBO.BarangBonusDetail a
WHERE RecordId NOT IN (SELECT RecordId FROM DBO.BarangBonusDetail)

GO
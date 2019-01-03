USE ISAdb_JKT
GO



INSERT INTO DBO.BackOrder
(
RowID, DOID, RecordID, DOHtrID, RpNet, Sub, LastUpdatedBy, LastUpdatedTime
)

SELECT RowID, 
(SELECT TOP 1 RowID FROM DBO.OrderPenjualan x WHERE x.HtrID = a.DOHtrID) AS DOID, 
RecordID, DOHtrID, RpNet, Sub, LastUpdatedBy, LastUpdatedTime
FROM ISAdb.DBO.BackOrder a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.BackOrder)

GO 
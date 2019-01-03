USE ISAdb_JKT
GO


INSERT INTO DBO.OrderPenjualanDetail
(
RowID, HeaderID, RecordID, HtrID, BarangID, QtyRequest, QtyDO, HrgJual, Disc1, Disc2, Disc3, Pot, DiscFormula, NoDOBO, NoACC, Catatan, SyncFlag, NBOPrint, DOBeliDetailID, LastUpdatedBy, LastUpdatedTime
)

SELECT RowID, 
(SELECT TOP 1 RowID FROM DBO.OrderPenjualan x WHERE x.HtrID = a.HtrID) AS HeaderID, 
RecordID, HtrID, BarangID, QtyRequest, QtyDO, HrgJual, Disc1, Disc2, Disc3, Pot, DiscFormula, NoDOBO, NoACC, Catatan, SyncFlag, NBOPrint, DOBeliDetailID, LastUpdatedBy, LastUpdatedTime 
FROM ISAdb.DBO.OrderPenjualanDetail a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.OrderPenjualanDetail)

GO 
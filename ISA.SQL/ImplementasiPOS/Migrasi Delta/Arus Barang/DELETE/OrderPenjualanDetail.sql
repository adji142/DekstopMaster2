USE ISAdb_JKT
GO

DELETE FROM DBO.OrderPenjualanDetail 
WHERE RecordID NOT IN (SELECT RecordID FROM ISAdb.DBO.OrderPenjualanDetail)


GO


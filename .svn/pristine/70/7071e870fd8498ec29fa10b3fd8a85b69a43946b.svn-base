USE ISAdb_JKT
GO


INSERT INTO DBO.OrderPenjualanPos
SELECT * FROM ISAdb.DBO.OrderPenjualanPos WHERE HtrID NOT IN (SELECT HtrID FROM DBO.OrderPenjualanPos)

GO 
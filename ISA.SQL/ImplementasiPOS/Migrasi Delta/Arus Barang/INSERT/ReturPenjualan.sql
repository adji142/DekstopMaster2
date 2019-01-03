USE ISAdb_JKT
GO



INSERT INTO DBO.ReturPenjualan
SELECT * FROM ISAdb.DBO.ReturPenjualan WHERE ReturID NOT IN (SELECT ReturID FROM DBO.ReturPenjualan)

GO 
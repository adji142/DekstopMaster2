USE ISAdb_JKT
GO


INSERT INTO DBO.ReturPembelian
SELECT * FROM ISAdb.DBO.ReturPembelian WHERE ReturID NOT IN (SELECT ReturID FROM DBO.ReturPembelian)

GO 
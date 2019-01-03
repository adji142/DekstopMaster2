USE ISAdb_JKT
GO


INSERT INTO DBO.NotaPenjualan
SELECT * FROM ISAdb.DBO.NotaPenjualan WHERE RecordID NOT IN (SELECT RecordID FROM DBO.NotaPenjualan)

GO 
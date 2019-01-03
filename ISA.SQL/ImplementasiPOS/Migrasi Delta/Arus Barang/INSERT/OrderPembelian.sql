USE ISAdb_JKT
GO



INSERT INTO DBO.OrderPembelian
SELECT * FROM ISAdb.DBO.OrderPembelian WHERE RecordID NOT IN (SELECT RecordID FROM DBO.OrderPembelian)

GO 
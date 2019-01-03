USE ISAdb_JKT
GO


INSERT INTO DBO.Pengembalian
SELECT * FROM ISAdb.DBO.Pengembalian WHERE RecordID NOT IN (SELECT RecordID FROM DBO.Pengembalian)

GO
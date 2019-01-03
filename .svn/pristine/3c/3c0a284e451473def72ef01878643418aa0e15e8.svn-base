USE ISAdb_JKT
GO



INSERT INTO DBO.NotaPembelian
SELECT * FROM ISAdb.DBO.NotaPembelian WHERE RecordID NOT IN (SELECT RecordID FROM DBO.NotaPembelian)

GO 
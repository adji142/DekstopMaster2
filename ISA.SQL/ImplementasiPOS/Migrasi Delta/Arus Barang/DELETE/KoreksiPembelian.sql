USE ISAdb_JKT
GO

DELETE FROM DBO.KoreksiPembelian 
WHERE RecordID NOT IN (SELECT RecordID FROM ISAdb.DBO.KoreksiPembelian)


GO

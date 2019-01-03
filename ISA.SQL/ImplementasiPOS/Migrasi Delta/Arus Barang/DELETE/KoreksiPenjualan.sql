USE ISAdb_JKT
GO

DELETE FROM DBO.KoreksiPenjualan 
WHERE RecordID NOT IN (SELECT RecordID FROM ISAdb.DBO.KoreksiPenjualan)


GO


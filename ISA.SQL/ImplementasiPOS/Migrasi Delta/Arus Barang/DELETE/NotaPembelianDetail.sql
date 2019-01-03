USE ISAdb_JKT
GO

DELETE FROM DBO.NotaPembelianDetail 
WHERE RecordID NOT IN (SELECT RecordID FROM ISAdb.DBO.NotaPembelianDetail)


GO


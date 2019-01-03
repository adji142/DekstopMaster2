USE ISAdb_JKT
GO

DELETE FROM DBO.ReturPembelianManualDetail 
WHERE RecordID NOT IN (SELECT RecordID FROM ISAdb.DBO.ReturPembelianManualDetail)


GO


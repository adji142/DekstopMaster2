USE ISAdb_JKT
GO

DELETE FROM DBO.ReturPenjualanDetail 
WHERE RecordID NOT IN (SELECT RecordID FROM ISAdb.DBO.ReturPenjualanDetail)
GO
DELETE FROM DBO.ReturPenjualanTarikanDetail 
WHERE RecordID NOT IN (SELECT RecordID FROM ISAdb.DBO.ReturPenjualanTarikanDetail)



GO



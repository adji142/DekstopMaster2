USE ISAdb_JKT
GO

DELETE FROM DBO.OpnameHistory 
WHERE RTRIM(KodeGudang) + RecordID NOT IN (SELECT RTRIM(KodeGudang) + RecordID FROM ISAdb.DBO.OpnameHistory)


GO


USE ISAdb_JKT
GO


INSERT INTO DBO.OpnameHistory
SELECT * FROM ISAdb.DBO.OpnameHistory WHERE RTRIM(KodeGudang) + RecordID NOT IN (SELECT RTRIM(KodeGudang) + RecordID FROM DBO.OpnameHistory)

GO 
USE ISAdb_JKT
GO

DELETE FROM DBO.SelisihDetail 
WHERE RecordID NOT IN (SELECT RecordID FROM ISAdb.DBO.SelisihDetail)


GO
  
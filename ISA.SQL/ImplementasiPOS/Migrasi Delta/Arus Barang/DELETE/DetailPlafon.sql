USE ISAdb_JKT
GO

DELETE FROM DBO.DetailPlafon 
WHERE TransactionID NOT IN (SELECT TransactionID FROM ISAdb.DBO.DetailPlafon)


GO  
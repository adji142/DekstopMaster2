USE ISAdb_JKT
GO

INSERT INTO DBO.DetailPlafon
SELECT * FROM ISAdb.DBO.DetailPlafon WHERE TransactionID NOT IN (SELECT TransactionID FROM DBO.DetailPlafon)

GO  
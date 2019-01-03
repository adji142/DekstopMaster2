USE ISAdb_JKT
GO

DELETE FROM DBO.BarangBonusDetail 
WHERE RecordId NOT IN (SELECT RecordId FROM ISAdb.DBO.BarangBonusDetail)


GO  
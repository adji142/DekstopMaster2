USE ISAdb_JKT
GO
DELETE FROM ISAdb_JKT.dbo.TujuanExpedisi
GO
INSERT INTO dbo.TujuanExpedisi
SELECT * FROM ISAdb.dbo.TujuanExpedisi
GO
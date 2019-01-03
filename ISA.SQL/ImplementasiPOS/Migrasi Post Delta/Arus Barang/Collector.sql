USE ISAdb_JKT
GO
DELETE FROM ISAdb_JKT.dbo.Collector
GO
INSERT INTO dbo.Collector
SELECT * FROM ISAdb.dbo.Collector
GO
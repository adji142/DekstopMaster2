USE ISAdb_JKT
GO
DELETE FROM ISAdb_JKT.dbo.Expedisi
GO
INSERT INTO dbo.Expedisi
SELECT * FROM ISAdb.dbo.Expedisi
GO
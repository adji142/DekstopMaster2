USE ISAdb_JKT
GO
DELETE FROM ISAdb_JKT.dbo.OpnameDetail3
GO
INSERT INTO dbo.OpnameDetail3
SELECT * FROM ISAdb.dbo.OpnameDetail3
GO
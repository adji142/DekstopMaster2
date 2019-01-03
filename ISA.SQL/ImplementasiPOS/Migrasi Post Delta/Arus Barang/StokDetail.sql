USE ISAdb_JKT
GO
DELETE FROM ISAdb_JKT.dbo.StokDetail
GO
INSERT INTO dbo.StokDetail
SELECT * FROM ISAdb.dbo.StokDetail
GO
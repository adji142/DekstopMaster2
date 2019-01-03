USE ISAdb_JKT
GO
DELETE FROM ISAdb_JKT.dbo.Kategori
GO
INSERT INTO dbo.Kategori
SELECT * FROM ISAdb.dbo.Kategori 
GO
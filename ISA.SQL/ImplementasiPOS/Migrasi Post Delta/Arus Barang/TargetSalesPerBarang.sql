USE ISAdb_JKT
GO
DELETE FROM ISAdb_JKT.dbo.TargetSalesPerBarang
GO
INSERT INTO dbo.TargetSalesPerBarang
SELECT * FROM ISAdb.dbo.TargetSalesPerBarang 
GO
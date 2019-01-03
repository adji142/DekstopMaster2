USE ISAdb_JKT
GO
DELETE FROM ISAdb_JKT.dbo.TargetSalesPerBarangDetail
GO
INSERT INTO dbo.TargetSalesPerBarangDetail
SELECT * FROM ISAdb.dbo.TargetSalesPerBarangDetail 
GO
USE ISAdb_JKT
GO
DELETE FROM ISAdb_JKT.dbo.StaffPenjualan
GO
INSERT INTO dbo.StaffPenjualan
SELECT * FROM ISAdb.dbo.StaffPenjualan
GO
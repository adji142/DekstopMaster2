USE ISAdb_JKT
GO
DELETE FROM ISAdb_JKT.dbo.DPJPPC
GO
INSERT INTO dbo.DPJPPC
SELECT * FROM ISAdb.dbo.DPJPPC
GO
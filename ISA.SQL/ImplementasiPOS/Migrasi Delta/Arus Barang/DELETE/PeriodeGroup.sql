USE ISAdb_JKT
GO

DELETE FROM DBO.PeriodeGroup 
WHERE stokgroupid NOT IN (SELECT stokgroupid FROM ISAdb.DBO.PeriodeGroup)


GO
 
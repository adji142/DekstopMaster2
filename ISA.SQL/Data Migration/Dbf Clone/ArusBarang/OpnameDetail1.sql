USE ISA_dbf
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISA_dbf].[dbo].[Data1]') AND type in (N'U'))
DROP TABLE ISA_dbf.dbo.Data1
GO

SELECT *
INTO ISA_dbf.dbo.Data1
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT  * FROM Data1')c
GO


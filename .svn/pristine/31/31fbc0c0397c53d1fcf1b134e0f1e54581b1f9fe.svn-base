USE ISA_dbf
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISA_dbf].[dbo].[tagih]') AND type in (N'U'))
DROP TABLE ISA_dbf.dbo.tagih
GO

SELECT *
INTO ISA_dbf.dbo.tagih
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT  * FROM tagih')c
GO


USE ISA_dbf
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISA_dbf].[dbo].[DINDEN]') AND type in (N'U'))
DROP TABLE ISA_dbf.dbo.DINDEN
GO

SELECT *
INTO ISA_dbf.dbo.DINDEN
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT  * FROM DINDEN')c
GO


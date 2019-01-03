USE ISA_dbf
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISA_dbf].[dbo].[HPartner]') AND type in (N'U'))
DROP TABLE ISA_dbf.dbo.HPartner
GO

SELECT *
INTO ISA_dbf.dbo.HPartner
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT  * FROM HPartner')c
GO

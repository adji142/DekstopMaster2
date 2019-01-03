USE ISA_dbf
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISA_dbf].[dbo].[his_hppa]') AND type in (N'U'))
DROP TABLE ISA_dbf.dbo.his_hppa
GO

SELECT *
INTO ISA_dbf.dbo.his_hppa
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT  * FROM his_hppa')c
GO

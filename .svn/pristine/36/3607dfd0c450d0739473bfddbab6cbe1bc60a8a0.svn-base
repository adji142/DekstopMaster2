USE ISA_dbf
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISA_dbf].[dbo].[his_bmk2]') AND type in (N'U'))
DROP TABLE ISA_dbf.dbo.his_bmk2
GO

SELECT *
INTO ISA_dbf.dbo.his_bmk2
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT  * FROM his_bmk2')c
GO


 
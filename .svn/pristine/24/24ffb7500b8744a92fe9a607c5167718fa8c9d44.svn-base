USE ISA_dbf
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISA_dbf].[dbo].[hpotj]') AND type in (N'U'))
DROP TABLE ISA_dbf.dbo.hpotj
GO

SELECT *
INTO ISA_dbf.dbo.hpotj
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT  * FROM hpotj')c
GO


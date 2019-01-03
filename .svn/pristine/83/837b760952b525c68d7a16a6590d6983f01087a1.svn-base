USE ISA_dbf
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISA_dbf].[dbo].[hkasbon]') AND type in (N'U'))
DROP TABLE ISA_dbf.dbo.hkasbon
GO

SELECT *
INTO ISA_dbf.dbo.hkasbon
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT  * FROM hkasbon')c
GO


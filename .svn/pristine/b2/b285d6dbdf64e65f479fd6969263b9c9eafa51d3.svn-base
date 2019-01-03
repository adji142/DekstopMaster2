USE ISA_dbf
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISA_dbf].[dbo].[HBABON]') AND type in (N'U'))
DROP TABLE ISA_dbf.dbo.HBABON
GO

SELECT *
INTO ISA_dbf.dbo.HBABON
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT  * FROM HBABON')c
GO


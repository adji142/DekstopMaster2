USE ISA_dbf
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISA_dbf].[dbo].[STOKKAS]') AND type in (N'U'))
DROP TABLE ISA_dbf.dbo.STOKKAS
GO

SELECT *
INTO ISA_dbf.dbo.STOKKAS
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT  * FROM STOKKAS')c
GO


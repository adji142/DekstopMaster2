USE ISA_dbf
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISA_dbf].[dbo].[trsbank]') AND type in (N'U'))
DROP TABLE ISA_dbf.dbo.trsbank
GO

SELECT *
INTO ISA_dbf.dbo.trsbank
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT  * FROM trsbank')c
GO


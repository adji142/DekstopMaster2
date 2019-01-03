USE ISA_dbf
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISA_dbf].[dbo].[GLTrans]') AND type in (N'U'))
DROP TABLE ISA_dbf.dbo.GLTrans
GO

SELECT *
INTO ISA_dbf.dbo.GLTrans
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT  * FROM GLTrans')c
GO


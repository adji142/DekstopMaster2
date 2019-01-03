USE ISA_dbf
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISA_dbf].[dbo].[DGLTrans]') AND type in (N'U'))
DROP TABLE ISA_dbf.dbo.DGLTrans
GO

SELECT *
INTO ISA_dbf.dbo.DGLTrans
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT  * FROM DGLTrans')c
GO


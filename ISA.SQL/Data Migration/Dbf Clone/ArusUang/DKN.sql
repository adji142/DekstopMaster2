USE ISA_dbf
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISA_dbf].[dbo].[hdnota]') AND type in (N'U'))
DROP TABLE ISA_dbf.dbo.hdnota
GO

SELECT *
INTO ISA_dbf.dbo.hdnota
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT  * FROM hdnota')c
GO

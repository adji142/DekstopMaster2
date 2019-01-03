USE ISA_dbf
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISA_dbf].[dbo].[dpiutang]') AND type in (N'U'))
DROP TABLE ISA_dbf.dbo.dpiutang
GO

SELECT *
INTO ISA_dbf.dbo.dpiutang
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT  * FROM dpiutang')c
GO


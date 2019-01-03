USE ISA_dbf
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISA_dbf].[dbo].[stok2gd]') AND type in (N'U'))
DROP TABLE ISA_dbf.dbo.stok2gd
GO

SELECT *
INTO ISA_dbf.dbo.stok2gd
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT  * FROM stok2gd')c
GO


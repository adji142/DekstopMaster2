USE ISA_dbf
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISA_dbf].[dbo].[gr_stok]') AND type in (N'U'))
DROP TABLE ISA_dbf.dbo.gr_stok
GO

SELECT *
INTO ISA_dbf.dbo.gr_stok
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT  * FROM gr_stok')c
GO

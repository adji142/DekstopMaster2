USE ISA_dbf
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISA_dbf].[dbo].[kel_brg]') AND type in (N'U'))
DROP TABLE ISA_dbf.dbo.kel_brg
GO

SELECT *
INTO ISA_dbf.dbo.kel_brg
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT  * FROM kel_brg')c
GO


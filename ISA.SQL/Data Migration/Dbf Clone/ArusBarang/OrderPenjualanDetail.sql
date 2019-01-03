USE ISA_dbf
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISA_dbf].[dbo].[dhtransj]') AND type in (N'U'))
DROP TABLE ISA_dbf.dbo.dhtransj
GO

SELECT *
INTO ISA_dbf.dbo.dhtransj
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT  * FROM dhtransj')c
GO


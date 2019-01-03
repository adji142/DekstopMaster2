USE ISA_dbf
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISA_dbf].[dbo].[hhtransj]') AND type in (N'U'))
DROP TABLE ISA_dbf.dbo.hhtransj
GO

SELECT *
INTO ISA_dbf.dbo.hhtransj
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT  * FROM hhtransj')c
GO

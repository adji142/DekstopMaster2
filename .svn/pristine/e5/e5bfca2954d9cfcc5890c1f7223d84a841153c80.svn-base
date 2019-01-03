USE ISA_dbf
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISA_dbf].[dbo].[hist_bmk]') AND type in (N'U'))
DROP TABLE ISA_dbf.dbo.hist_bmk
GO

SELECT *
INTO ISA_dbf.dbo.hist_bmk
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT  * FROM hist_bmk')c
GO


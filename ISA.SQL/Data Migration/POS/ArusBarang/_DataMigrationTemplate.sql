 sp_configure 'show advanced options', 1
reconfigure 
GO

sp_configure 'Ad Hoc Distributed Queries', 1 
reconfigure 
GO

SELECT * FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM Cabang')

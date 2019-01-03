USE ISAdb 
GO
DELETE FROM ISAdb.dbo.TujuanExpedisi 
GO
INSERT INTO ISAdb.dbo.TujuanExpedisi
(
	Tujuan, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	RTRIM(tujuan),
	'Admin',
	GETDATE() 
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM tujuan')

GO


--SELECT * FROM TujuanExpedisi 
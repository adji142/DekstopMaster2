 USE ISAdb 
GO
DELETE FROM ISAdb.dbo.KodePos
GO
INSERT INTO ISAdb.dbo.KodePos
(
	KodePos, 
	Wilayah, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	RTRIM(kd_pos),
	RTRIM(wilayah),
	'Admin',
	GETDATE() 
	FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM kd_pos')


GO

--SELECT * FROM KodePos
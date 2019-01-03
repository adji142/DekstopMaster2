USE ISAdb 
GO
DELETE FROM ISAdb.dbo.PostKota 
GO
INSERT INTO ISAdb.dbo.PostKota
(
	RecordID, 
	PostRecID, 
	Kota, 
	Propinsi, 
	PostName
)
SELECT 
	RTRIM(idrec),
	RTRIM(idrec_post),
	RTRIM(kota),
	RTRIM(propinsi),
	RTRIM(post_name)
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM postkota')

GO

--SELECT * FROM PostKota 
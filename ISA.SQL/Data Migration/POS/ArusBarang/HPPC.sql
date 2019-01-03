USE ISAdb
GO
DELETE FROM ISAdb.dbo.HPPC
GO
INSERT INTO ISAdb.dbo.HPPC
(
	NamaProyek, 
	RecordID, 
	Promotor, 
	TMT, 
	TMT1, 
	SyncFlag, 
	LPasif
) 
SELECT
	RTRIM(nm_project),
	RTRIM(idrec),
	RTRIM(promotor),
	tmt,
	tmt1,
	id_match,
	lpasif
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM hppc')

GO
--SELECT * FROM HPPC 
USE ISAdb 
GO
DELETE FROM ISAdb.dbo.PenanggungjawabRak
GO
INSERT INTO ISAdb.dbo.PenanggungjawabRak
(
	TglTransaksi, 
	--Nama, 
	KodeRak, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	tmt, 
	--nama,
	kd_rak, 
	'DELTA CRB',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM penanggungjawabrak')

GO

--SELECT * FROM PenanggungjawabRak 
USE ISAdb 
GO
DELETE FROM ISAdb.dbo.StokGroup
GO
INSERT INTO ISAdb.dbo.StokGroup
(
	StokGroupID,	
	NamaGroup, 
	Formula, 
	Formula2
)
SELECT 
	RTRIM(id_grstok),
	RTRIM(nama_group),
	formula,
	formula2
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM gr_stok')

GO


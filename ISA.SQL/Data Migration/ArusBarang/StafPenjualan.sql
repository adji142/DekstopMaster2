-- last edited by ferry
USE ISAdb 
GO
DELETE FROM ISAdb.dbo.StaffPenjualan
GO
INSERT INTO ISAdb.dbo.StaffPenjualan
(
	RowID,
	Nama, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	newid(),
	nama,
	'Admin',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM pjstaff')

GO

--SELECT * FROM StaffPenjualan
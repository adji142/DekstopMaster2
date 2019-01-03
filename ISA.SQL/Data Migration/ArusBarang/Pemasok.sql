 USE ISAdb 
GO
DELETE FROM ISAdb.dbo.Pemasok
GO
INSERT INTO ISAdb.dbo.Pemasok
(
	PemasokID, 
	Nama, 
	Lengkap, 
	Alamat, 
	Kota, 
	Telp, 
	Fax, 
	Kontak, 
	Keterangan, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	idp, 
	nama, 
	lengkap,
	alamat,
	kota,
	telp,
	fax, 
	kontak,
	keterangan,
	id_match,
	'Admin',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM Pemasok')

GO

--SELECT * FROM Pemasok
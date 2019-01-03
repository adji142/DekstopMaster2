USE ISAdb 
GO
DELETE FROM ISAdb.dbo.Perusahaan
GO

INSERT INTO ISAdb.dbo.Perusahaan
(
	RowID,
	InitPerusahaan,
	Nama,
	Alamat,
	Kota,
	Propinsi,
	Negara,
	KodePos,
	Telp,
	Fax,
	Email,
	Website,
	NPWP,
	TglPKP,
	InitCabang,
	InitGudang, 
	LastUpdatedBy, 
	LastUpdatedTime,
	TipeLokasi
)
SELECT 
	NEWID(),
	RTRIM(initprs),
	RTRIM(nama),
	RTRIM(alamat),
	RTRIM(kota),
	RTRIM(propinsi),
	RTRIM(negara),
	RTRIM(kodepos),
	RTRIM(notelp),
	RTRIM(nofax),
	RTRIM(email),
	RTRIM(www),
	RTRIM(npwp),
	tglpkp,
	RTRIM(initcab),
	RTRIM(initgdg),
	'Admin',
	GETDATE(),
	''
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM perusahaan')
GO

--SELECT * FROM Perusahaan 
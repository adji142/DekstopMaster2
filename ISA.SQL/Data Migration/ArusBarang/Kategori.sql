USE ISAdb

GO
DELETE FROM ISAdb.dbo.Kategori

GO
INSERT INTO ISAdb.dbo.Kategori
(
	Kategori,
	Keterangan,
	Ket
)
SELECT 
	RTRIM(kategori),
	RTRIM(keterangan),
	RTRIM(ket)
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM kategori')

GO 
--SELECT * FROM Kategori 
USE ISAdb 
GO
DELETE FROM ISAdb.dbo.StokDetail
GO
INSERT INTO ISAdb.dbo.StokDetail
(
	StokGroupID, 
	RecordID, 
	TglAktif, 
	TglPasif, 
	TglFresh, 
	StokMin, 
	StokMax, 
	StokAkhir, 
	StokAkh, 
	BarangID, 
	Tempo
)
SELECT 
	RTRIM(id_grstok),
	RTRIM(idrec),
	tgl_aktif,
	tgl_pasif,
	tgl_fresh,
	stok_min,
	stok_max,
	stok_akhir,
	stok_akh,
	RTRIM(id_brg),
	tempo
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM dt_stok')

GO
UPDATE dbo.StokDetail
SET TglAktif = (CASE WHEN TglAktif = '1899/12/30' THEN NULL ELSE TglAktif END),
	TglPasif = (CASE WHEN TglPasif = '1899/12/30' THEN NULL ELSE TglPasif END),
	TglFresh = (CASE WHEN TglFresh = '1899/12/30' THEN NULL ELSE TglAktif END)

--GO
--SELECT * FROM dbo.StokDetail 
USE ISAdb 
GO
DELETE FROM ISAdb.dbo.Stok
GO
INSERT INTO ISAdb.dbo.Stok
(	
	RowID
	,BarangID
	,RecordID
	,Bundle
	,NamaStok
	,Kendaraan
	,NamaTertera
	,PartNo
	,Merek
	,Dibungkus
	,SumberDr
	,ProsesID
	,SatSolo
	,Material
	,SatJual
	,KodeRak
	,KodeRak1
	,KodeRak2
	,JB
	,StatusPasif
	,SyncFlag
	,PrediksiLamaKirim
	,HariRataRata
	,StokMin
	,StokMax
	,IsiKoli
	,LastUpdatedBy
	,LastUpdatedTime
)
SELECT 
	NEWID(),
	RTRIM(id_brg),
	RTRIM(idrec),
	RTRIM(bundel),
	RTRIM(nama_stok),
	RTRIM(kendaraan),
	RTRIM(nm_tertera),
	RTRIM(partno),
	RTRIM(merek),
	RTRIM(dibungkus),
	RTRIM(sumber_dr),
	RTRIM(idproses),
	RTRIM(sat_solo),
	RTRIM(material),
	RTRIM(sat_jual),
	RTRIM(kd_rak),
	RTRIM(kd_rak1),
	RTRIM(kd_rak2),
	RTRIM(jb),
	lpasif,
	id_match,
	q_ordb,
	q_opnm,
	stokmin,
	stokmax,
	isi_koli,
	'DELTA CRB',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM sasstok')

GO

--SELECT * FROM Stok 
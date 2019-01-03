USE ISAdb 
GO
DELETE FROM ISAdb.dbo.ACCBonusSales 
GO
INSERT INTO ISAdb.dbo.ACCBonusSales 
(
	RowID, 
	NotaID, 
	NotaRecID, 
	KodeGudang, 
	KodeSales, 
	KodeToko, 
	TglJatuhTempo, 
	RpSuratJalan, 
	RpSisa, 
	RpGiro, 
	RpRetur, 
	RpPotongan, 
	RpLain, 
	NoACC, 
	TglACC, 
	isChecked, 
	Keterangan, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(), 
	NULL, 
	RTRIM(a.idtr),  
	RTRIM(a.c1),
	RTRIM(a.kd_sales),
	RTRIM(a.kd_toko),
	a.tgl_jt,
	a.rp_sj,
	a.rp_sisa, 
	a.rp_giro, 
	a.rp_retur, 
	a.rp_potong, 
	a.lain_lain, 
	RTRIM(a.no_acc), 
	a.tgl_acc,
	a.lcek, 
	RTRIM(a.ket_nota),
	'Admin',  
	GETDATE()     
	 
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM haccbns') a


UPDATE DBO.ACCBonusSales 
SET NotaID = b.RowID
FROM DBO.ACCBonusSales a LEFT OUTER JOIN DBO.NotaPenjualan b ON a.NotaRecID = b.RecordID
WHERE a.Keterangan = 'J'


UPDATE DBO.ACCBonusSales 
SET NotaID = b.RowID
FROM DBO.ACCBonusSales a LEFT OUTER JOIN DBO.ReturPenjualan b ON a.NotaRecID = b.ReturID
WHERE a.Keterangan <> 'J'


GO
UPDATE dbo.ACCBonusSales
SET TglACC = NULL
WHERE TglACC = '1899/12/30'

--GO
--SELECT * FROM dbo.ACCBonusSales 
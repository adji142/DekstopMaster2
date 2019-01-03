USE ISAdb 
GO
DELETE FROM ISAdb.dbo.DetailPlafon
GO
INSERT INTO ISAdb.dbo.DetailPlafon
(
	TransactionID, 
	KodeToko, 
	Tanggal, 
	PlafonAwal, 
	Bayar, 
	Bgc, 
	Bgt,
	Lembar, 
	Hitung, 
	PlafonAkhir, 
	PlafonAjuan, 
	Ajuan, 
	PlafonACC, 
	ACC, 
	TglACC, 
	Keterangan, 
	PlafonHl, 
	PlafonB, 
	PlafonVt, 
	PlafonOc, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	RTRIM(id_tr), 
	RTRIM(kd_toko),
	tanggal,
	p_awal,
	bayar,
	bgc,
	bgt,
	lembar,
	hitung,
	p_akhir,
	p_ajuan,
	RTRIM(ajuan),
	plafon_acc,
	RTRIM(acc),
	tgl_acc,
	RTRIM(ket),
	plf_hl,
	plf_b,
	plf_vt,
	plf_oc,
	'Admin',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM dplafon')

GO

--SELECT * FROM DetailPlafon 
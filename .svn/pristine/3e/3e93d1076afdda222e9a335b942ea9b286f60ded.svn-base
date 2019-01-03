 USE ISAdb 
GO
DELETE FROM ISAdb.dbo.Bukti
GO
INSERT INTO ISAdb.dbo.Bukti
(
	RowID, 
	RecordID, 
	KeluarMasuk, 
	JenisBukti, 
	NoBukti, 
	TglBukti, 
	Kepada, 
	Lampiran, 
	Pembukuan, 
	NoACC, 
	Kasir, 
	Penerima, 
	JmlKas, 
	JmlBG, 
	LembarBG, 
	JmlBonSementara, 
	nPrint, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	RTRIM(idtr),
	RTRIM(mk),
	RTRIM(jns_bukti), 
	RTRIM(no_bukti), 
	tgl_bukti, 
	RTRIM(kepada), 
	RTRIM(lampiran), 
	RTRIM(pembukuan), 
	RTRIM(acc), 
	RTRIM(kasir), 
	RTRIM(penerima), 
	jml_kas, 
	jml_bg, 
	lbr_bg, 
	jml_bs, 
	nprint, 
	id_match, 
	'Admin', 
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM hbukti')

--GO
--SELECT * FROM Bukti
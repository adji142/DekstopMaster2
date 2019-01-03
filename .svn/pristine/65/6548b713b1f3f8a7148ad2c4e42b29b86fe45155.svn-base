USE ISAdb
GO
DELETE FROM ISAdb.dbo.IndenSubDetail
GO
INSERT INTO ISAdb.dbo.IndenSubDetail
(
	DetailRecID, 
	RecordID, 
	ColTokoID, 
	KPID, 
	NamaToko, 
	TglBPP, 
	NoReg, 
	Ref, 
	NoBukti, 
	TglInden, 
	RpInden, 
	TglJatuhTempo, 
	NoNota, 
	RpNota, 
	RpTagih, 
	Kode, 
	Sub, 
	SyncFlag, 
	NoPerk
)
SELECT
	RTRIM(iddrec),
	RTRIM(idrec),
	RTRIM(id_coltoko),
	RTRIM(id_kp),
	RTRIM(namatoko),
	tgl_bpp,
	RTRIM(no_reg),
	RTRIM(ref),
	RTRIM(no_bukti),
	tgl_ind,
	rp_ind,
	tgl_jt,
	RTRIM(no_nota),
	rp_nota,
	rp_tagih,
	RTRIM(kode),
	RTRIM(sub),
	id_match,
	RTRIM(no_perk)
	FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM ddinden')

GO
--SELECT * FROM IndenSubDetail 
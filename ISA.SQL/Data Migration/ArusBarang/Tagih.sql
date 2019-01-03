-- last edited by ferry
USE ISAdb
GO
DELETE FROM ISAdb.dbo.Tagih
GO
INSERT INTO ISAdb.dbo.Tagih
(
	RecordID, 
	ColTokoID, 
	WilID, 
	KodeToko, 
	NamaToko, 
	NoReg, 
	NoBPP, 
	TglBPP, 
	TglKasir, 
	RpNota, 
	RpBayar, 
	RpTagih, 
	RpNominal, 
	SyncFlag
)
SELECT
	RTRIM(idrec),
	RTRIM(id_coltoko),
	RTRIM(idwil),
	RTRIM(kd_toko),
	RTRIM(namatoko),
	RTRIM(no_reg),
	RTRIM(no_bpp),
	CASE WHEN SUBSTRING(tgl_bpp,7,4) < 1900 THEN NULL ELSE CONVERT(DATETIME,tgl_bpp) END,
	CASE WHEN SUBSTRING(tgl_kasir,7,4) < 1900 THEN NULL ELSE CONVERT(DATETIME,tgl_kasir) END,
	rp_nota,
	rp_bayar,
	rp_tagih,
	rp_nominal,
	id_match
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT 
    idrec,
	id_coltoko,
	idwil,
	kd_toko,
	namatoko,
	no_reg,
	no_bpp,
	DTOC(tgl_bpp) AS tgl_bpp,
	DTOC(tgl_kasir) AS tgl_kasir,
	rp_nota,
	rp_bayar,
	rp_tagih,
	rp_nominal,
	id_match
    FROM tagih')

GO
--SELECT * FROM Tagih 
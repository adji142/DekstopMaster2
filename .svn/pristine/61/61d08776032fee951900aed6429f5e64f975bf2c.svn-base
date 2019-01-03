USE ISAdb 
GO
DELETE FROM ISAdb.dbo.Giro
GO
INSERT INTO ISAdb.dbo.Giro
(
	VoucherID, 
	BBMID, 
	TitipID, 
	GiroID, 
	KodeToko, 
	AsalGiro, 
	NamaBank, 
	Lokasi, 
	Chbg, 
	Nomor, 
	TglGiro, 
	TglJatuhTempo, 
	Nominal, 
	CairTolak, 
	tglCair, 
	MainTitip, 
	SubTitip, 
	MainPiutang, 
	SubPiutang, 
	BankID, 
	NamaBankI, 
	NoPerk, 
	TglTitip, 
	SyncFlag, 
	NoACCPiutang, 
	MainPerk, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	RTRIM(idvoucher), 
	RTRIM(idbbm),
	RTRIM(idtitip),
	RTRIM(idgiro),
	RTRIM(kd_toko),
	RTRIM(asalgiro),
	RTRIM(namabank),
	RTRIM(lokasi),
	RTRIM(chbg),
	RTRIM(nomor),
		CAST((CASE WHEN tgl_giro = '  /  /  ' THEN NULL
					   WHEN RIGHT(tgl_giro,4) < 1900 THEN NULL
					  ELSE tgl_giro 
					  END) AS DATETIME) AS tgl_giro,
		CAST((CASE WHEN tgl_jt = '  /  /  ' THEN NULL
					   WHEN RIGHT(tgl_jt,4) < 1900 THEN NULL
					  ELSE tgl_jt 
					  END) AS DATETIME) AS tgl_jt,
	nominal,
	RTRIM(cairtolak),
	CAST((CASE WHEN tgl_cair = '  /  /  ' THEN NULL
					   WHEN RIGHT(tgl_cair,4) < 1900 THEN NULL
					  ELSE tgl_cair 
					  END) AS DATETIME) AS tgl_cair,
	RTRIM(maintitip),
	RTRIM(subtitip),
	RTRIM(mainpiut),
	RTRIM(subpiut),
	RTRIM(idbank),
	RTRIM(nm_banki),
	RTRIM(no_perk),
	CAST((CASE WHEN tgl_titip = '  /  /  ' THEN NULL
					   WHEN RIGHT(tgl_titip,4) < 1900 THEN NULL
					  ELSE tgl_titip 
					  END) AS DATETIME) AS tgl_titip,
	id_match,
	RTRIM(no_acc),
	RTRIM(mainperk),
	'DELTA CRB',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT
	idvoucher,
	idbbm,
	idtitip,
	idgiro,
	kd_toko,
	asalgiro,
	namabank,
	lokasi,
	chbg,
	nomor,
	DTOC(tgl_giro) as tgl_giro,
    DTOC(tgl_jt) AS tgl_jt,
	nominal,
	cairtolak,
	DTOC(tgl_cair) as tgl_cair,
	maintitip,
	subtitip,
	mainpiut,
	subpiut,
    idbank,
	nm_banki,
	no_perk,
	DTOC(tgl_titip) as tgl_titip,
	id_match,
	no_acc,
	mainperk
 FROM giro')


GO

--SELECT * FROM Giro 
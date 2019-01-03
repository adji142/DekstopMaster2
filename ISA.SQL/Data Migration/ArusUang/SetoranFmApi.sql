USE ISAFinance
GO
TRUNCATE TABLE dbo.SetoranFmApi
GO
 INSERT INTO dbo.SetoranFmApi(	RowID, KPID, KodeToko, WilID, NoTransaksi, 
							TglTransaksi, TglJthTempo, TglRealGiro, TglPrediksiCair, TglRealCair, TglPotongan, TglHitung, 
							QtyNota2Giro, QtyGiro2Cair, RpGiro, RpRealGiro, RpCair, RpRealCair, RpPotongan, KasGiro, NoAcc, Catatan)
SELECT	k.RowID, a.id_kp, a.kd_toko, t.WilID, a.no_nota,
		a.tgl_nota, a.tgl_jt,  tgl_realg, tgl_predc, tgl_realc, tgl_ptg, tgl_hitung,
		nota2giro, giro2cair, jml_g, jml_realg, jml_c, jml_realc, potongan, kasbg, 
		'' no_acc, '' catatan
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM fmapi') a
LEFT OUTER JOIN dbo.KartuPiutang k ON k.KPID = a.id_kp
LEFT OUTER JOIN ISAdb.dbo.Toko t ON a.kd_toko = t.KodeToko
GO
UPDATE dbo.SetoranFmApi 
	SET 
	TglJthTempo=CASE WHEN YEAR(TglJthTempo )<1900 THEN NULL ELSE TglJthTempo END,  
	TglRealGiro=CASE WHEN YEAR(TglRealGiro )<1900 THEN NULL ELSE TglRealGiro END,  
	TglPrediksiCair=CASE WHEN YEAR( TglPrediksiCair)<1900 THEN NULL ELSE TglPrediksiCair END,  
	TglRealCair=CASE WHEN YEAR(TglRealCair )<1900 THEN NULL ELSE TglRealCair END,  
	TglPotongan=CASE WHEN YEAR(TglPotongan )<1900 THEN NULL ELSE TglPotongan  END,  
	TglHitung=CASE WHEN YEAR(TglHitung )<1900 THEN NULL ELSE TglHitung END 

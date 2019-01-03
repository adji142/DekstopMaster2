USE ISAFinance 
GO
TRUNCATE TABLE dbo.SetoranFmApiBayar
GO
SELECT	k.RowID, a.id_kp, kd.RowID AS RowIDDetail,a.idrec,  a.kd_toko,ISNULL( t.WilID,'') AS WilID, a.no_nota,
		a.tgl_nota, a.tgl_jt,  tgl_realg, tgl_predc, tgl_realc, tgl_ptg, 
		nota2giro, giro2cair, jml_g, jml_realg, jml_c, jml_realc, potongan, kasbg,
		Tgl_i
		INTO #Tempp
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM fmapibyr') a
LEFT OUTER JOIN dbo.KartuPiutang k (NOLOCK) ON k.KPID = a.id_kp
LEFT OUTER JOIN dbo.KartuPiutangDetail kd (NOLOCK) ON kd.RecordID = a.idrec
LEFT OUTER JOIN ISAdb.dbo.Toko t (NOLOCK) ON a.kd_toko = t.KodeToko


UPDATE #Tempp
SET tgl_jt = CASE WHEN CHARINDEX('1899',tgl_jt)>0 OR YEAR(tgl_jt)<1900 THEN null ELSE tgl_jt END,
    tgl_realg = CASE WHEN CHARINDEX('1899',tgl_realg)>0 OR YEAR(tgl_realg)<1900 THEN null ELSE tgl_realg END,
    tgl_predc = CASE WHEN CHARINDEX('1899',tgl_predc)>0 THEN null ELSE tgl_predc END,
    tgl_ptg = CASE WHEN CHARINDEX('1899',tgl_ptg)>0 THEN null ELSE tgl_ptg END,
    tgl_nota = CASE WHEN CHARINDEX('1899',tgl_nota)>0 THEN null ELSE tgl_nota END,
    tgl_realc = CASE WHEN CHARINDEX('1899',tgl_realc)>0 THEN null ELSE tgl_realc END,
    tgl_i = CASE WHEN CHARINDEX('1899',tgl_i)>0 THEN null ELSE tgl_i END

    
INSERT INTO dbo.SetoranFmApiBayar
(RowID, 
KPID,
RowIDDetail, 
RecordIDDetail, 
KodeToko, WilID, 
NoTransaksi, 
TglTransaksi, 
TglJthTempo, 
TglRealGiro, 
TglPrediksiCair, 
TglRealCair, 
TglPotongan, 
QtyNota2Giro, 
QtyGiro2Cair, 
RpGiro,
RpRealGiro, 
RpCair, 
RpRealCair, 
RpPotongan,
KasGiro, 
TglInden)
SELECT
RowID, 
id_kp,
RowIDDetail,
idrec,  
kd_toko,
WilID, 
no_nota,
tgl_nota, 
tgl_jt,  
tgl_realg, 
tgl_predc, 
tgl_realc, 
tgl_ptg, 
nota2giro, 
giro2cair, 
jml_g, 
jml_realg, 
jml_c, 
jml_realc, 
potongan, 
kasbg,
Tgl_i
FROM #Tempp					

   
DROP TABLE #Tempp

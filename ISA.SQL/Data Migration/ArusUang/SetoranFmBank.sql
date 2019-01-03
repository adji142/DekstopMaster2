USE ISAFinance
GO
TRUNCATE table dbo.SetoranFmBank
GO

INSERT INTO dbo.SetoranFmBank(	RowID, RecordID, BankID, 
								TglTerima, NamaBank, Kota, NoGiro, TglJthGiro, 
								TglTolak, TglSetor, 
								TglPrediksiCair, TglInden, 
								TglRealCair, TglHitung, QtyGiro2Cair, 
								RpJumlah, RpBayar, Keterangan1, Keterangan2, KasGiro)
SELECT	ISNULL(kd.RowID,NEWID()), idrec, idbank,
		tgl_terima,RTRIM(LTRIM(bank)), RTRIM(LTRIM(kota)),no_giro, CASE WHEN CHARINDEX('1899',tgl_jt)>0 THEN null ELSE tgl_jt END,
		CASE WHEN CHARINDEX('1899',tgl_tolak)>0 THEN null ELSE tgl_tolak END, CASE WHEN CHARINDEX('1899',tgl_setor)>0 THEN null ELSE tgl_setor END,
		CASE WHEN CHARINDEX('1899',tgl_predc)>0 THEN null ELSE tgl_predc END, CASE WHEN CHARINDEX('1899',tgl_i)>0 THEN null ELSE tgl_i END,
		CASE WHEN CHARINDEX('1899',tgl_realc)>0 THEN null ELSE tgl_realc END, CASE WHEN CHARINDEX('1899',tgl_hitung)>0 THEN null ELSE tgl_hitung END,giro2cair,
		jumlah,jml_byr,ket_1,ket_2,RTRIM(LTRIM(kasbg))
FROM sasdb...fmbank a
OUTER APPLY (
			SELECT TOP 1 RowID
			FROM dbo.KartuPiutangDetail kd
			WHERE kd.RecordID = a.idrec
		)kd 
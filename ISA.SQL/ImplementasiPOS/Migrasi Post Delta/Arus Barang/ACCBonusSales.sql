USE ISAdb_JKT
GO


UPDATE dbo.ACCBonusSales
	SET
		KodeGudang = b.KodeGudang, 
		KodeSales = b.KodeSales, 
		KodeToko = b.KodeToko, 
		TglJatuhTempo = b.TglJatuhTempo, 
		RpSuratJalan = b.RpSuratJalan, 
		RpSisa = b.RpSisa, 
		RpGiro = b.RpGiro, 
		RpRetur = b.RpRetur, 
		RpPotongan = b.RpPotongan, 
		RpLain = b.RpLain, 
		NoACC = b.NoACC, 
		TglACC = b.TglACC, 
		isChecked = b.isChecked, 
		Keterangan = b.Keterangan		
FROM dbo.ACCBonusSales a
INNER JOIN ISAdb.dbo.ACCBonusSales b ON a.NotaRecID = b.NotaRecID

GO 
 USE ISAFinance_JKT
GO

UPDATE dbo.Bank
	SET		
		JRek = b.JRek, 
		NamaBank = b.NamaBank, 
		NamaAccount = b.NamaAccount, 
		NoAccount = b.NoAccount, 
		Alamat1 = b.Alamat1, 
		Alamat2 = b.Alamat2, 
		Kota = b.Kota, 
		Telp = b.Telp, 
		CService = b.CService, 
		NoGiro = b.NoGiro, 
		[NoCheck] = b.[NoCheck], 
		NoBBK = b.NoBBK, 
		VTA = b.VTA, 
		Saldo = b.Saldo, 
		Limit = b.Limit, 
		TglRek = b.TglRek, 
		SaldoAwal = b.SaldoAwal, 
		SaldoAkhir = b.SaldoAkhir, 
		Kode = b.Kode, 
		Sub = b.Sub, 
		MainTitip = b.MainTitip, 
		SubTitip = b.SubTitip, 
		SyncFlag = b.SyncFlag, 
		NoPerkiraan = b.NoPerkiraan, 
		MainPerkiraan = b.MainPerkiraan 
FROM dbo.Bank a
INNER JOIN ISAFinance.dbo.Bank b ON a.BankID = b.BankID

GO
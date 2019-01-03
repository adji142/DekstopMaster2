  USE ISAFinance_JKT
GO

UPDATE dbo.BankDetail
	SET	
		RegID = b.RegID, 
		TglTran = b.TglTran, 
		NoBBK = b.NoBBK, 
		JnsTran = b.JnsTran, 
		NoBGCH = b.NoBGCH, 
		Keterangan = b.Keterangan, 
		VTA = b.VTA, 
		Debet = b.Debet, 
		Kredit = b.Kredit, 
		TglBank = b.TglBank, 
		TglRK = b.TglRK, 
		Saldo = b.Saldo, 
		NPrint = b.NPrint, 
		SyncFlag = b.SyncFlag, 
		LinkRK = b.LinkRK, 
		Kode = b.Kode, 
		Sub = b.Sub, 
		Catatan = b.Catatan, 
		NoPerkiraan = b.NoPerkiraan
FROM dbo.BankDetail a
INNER JOIN ISAFinance.dbo.BankDetail b ON a.RecordID = b.RecordID and a.HRecordID = b.HRecordID

GO
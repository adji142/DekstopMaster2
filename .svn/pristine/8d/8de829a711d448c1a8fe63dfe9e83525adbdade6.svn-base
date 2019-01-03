USE ISAFinance 
GO
DELETE FROM dbo.Bank 
GO
INSERT INTO dbo.Bank
(
	RowID,
	BankID, 
	JRek, 
	NamaBank, 
	NamaAccount, 
	NoAccount, 
	Alamat1, 
	Alamat2, 
	Kota, 
	Telp, 
	CService, 
	NoGiro, 
	[NoCheck], 
	NoBBK, 
	VTA, 
	Saldo, 
	Limit, 
	TglRek, 
	SaldoAwal, 
	SaldoAkhir, 
	Kode, 
	Sub, 
	MainTitip, 
	SubTitip, 
	SyncFlag, 
	NoPerkiraan, 
	MainPerkiraan, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	RTRIM(idbank), 
	RTRIM(j_rek), 
	RTRIM(nama_bank),
	RTRIM(nama_acc),
	RTRIM(no_acc), 
	RTRIM(alm1),
	RTRIM(alm2),
	RTRIM(kota),
	RTRIM(telp),
	RTRIM(cservis),
	RTRIM(no_giro),
	RTRIM(no_ch),
	RTRIM(no_bbk),
	RTRIM(vta),
	RTRIM(saldo),
	RTRIM(limit),
	RTRIM(tgl_rk),
	RTRIM(saldo_aw),
	RTRIM(saldo_ak),
	RTRIM(kode),
	RTRIM(sub),
	RTRIM(maintitip),
	RTRIM(subtitip),
	RTRIM(id_match),
	RTRIM(no_perk),
	RTRIM(mainperk),
	'DELTA CRB',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM Bank')

GO
UPDATE dbo.Bank
SET
	RowID = b.RowID
FROM dbo.Bank a
INNER JOIN ISAFinance_JKT.dbo.Bank b ON  a.BankID = b.BankID
 
GO
--SELECT * FROM Cabang  
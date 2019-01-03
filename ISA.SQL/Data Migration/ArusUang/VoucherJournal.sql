USE ISAFinance 
GO
DELETE FROM dbo.VoucherJournal
GO
INSERT INTO dbo.VoucherJournal
(
	RowID, 
	RecordID, 
	Tipe, 
	TglVoucher, 
	NoVoucher, 
	Uraian1, 
	Uraian2, 
	Uraian3, 	 
	Dibuat, 
	Dibukukan, 
	Mengetahui, 
	BankID, 
	NamaBank, 
	NPrint, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	idvoucher,
	Tipe,
	tgl_vch,
	no_vch,
	uraian1,
	uraian2,
	uraian3,	
	dibuat,
	dibukukan,
	mengetahui,
	idbank,
	nama_bank,
	nprint,
	id_match,
	'Import',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM hvoucher')

GO





UPDATE VoucherJournal SET
RefRowID=b.RowID
FROM VoucherJournal a INNER JOIN Inden b ON SUBSTRING(a.RecordID,1,22)=SUBSTRING(b.RecordID,1,22)
GO 


UPDATE DBO.VoucherJournal 
SET RefRowID = b.RowID
FROM DBO.VoucherJournal a INNER JOIN DBO.KasBon b ON SUBSTRING(a.RecordID,1,22) = SUBSTRING(b.RecordID,1,22)
GO


 


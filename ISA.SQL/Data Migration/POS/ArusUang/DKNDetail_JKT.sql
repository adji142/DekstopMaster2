USE ISAFinance 
GO
DELETE FROM dbo.DKNDetail
GO
INSERT INTO dbo.DKNDetail
(
	RowID, 
	HeaderID, 
	RecordID, 
	HRecordID, 
	NoPerkiraan, 
	Uraian, 
	Jumlah, 
	Tolak, 
	Dari, 
	Alasan, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	NULL,
	idrec,
	idhdnota,
	no_perk,
	uraian,
	jumlah,
	ltolak,
	dari,
	alasan,	
	'DELTA CRB',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM ddnota')

GO

UPDATE dbo.DKNDetail
SET
	HeaderID = (SELECT TOP 1 RowID FROM dbo.DKN b WHERE b.RecordID = a.HRecordID)
FROM dbo.DKNDetail a

GO

UPDATE DBO.DKNDetail
SET RefRowID = b.RowID
FROM DBO.DKNDetail a INNER JOIN DBO.BuktiDetail b ON SUBSTRING(a.RecordID,1,22) = SUBSTRING(b.RecordID,1,22)
GO

UPDATE DBO.DKNDetail
SET RefRowID = b.RowID
FROM DBO.DKNDetail a INNER JOIN DBO.VoucherJournalDetail b ON SUBSTRING(a.RecordID,1,22) = SUBSTRING(b.RecordID,1,22)
GO

   
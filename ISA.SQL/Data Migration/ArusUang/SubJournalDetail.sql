USE ISAFinance
GO

DELETE FROM dbo.SubJOurnalDetail

GO

INSERT INTO dbo.SubJOurnalDetail
(
	RowID, 
	HeaderID, 
	RecordID, 
	HRecordID, 
	PartnerID, 
	PartnerNo, 
	NamaPartner, 
	Persen,
	Currency, 
	Amount, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	NEWID(),
	DStamp,
	idsub,
	idpart,
	nopart,
	nm_part,
	procent,
	tr_curr,
	tr_amount,
	'Import',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_GL\'; ' '; ' ', 'SELECT * FROM DSubj')

GO

UPDATE dbo.SubJournalDetail
SET HeaderID = (SELECT TOP 1 RowID FROM dbo.SubJournal x WHERE x.RecordID = a.HRecordID)
FROM dbo.SubJournalDetail a


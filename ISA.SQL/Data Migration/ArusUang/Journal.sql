USE ISAFinance 
GO
DELETE FROM dbo.Journal
GO
INSERT INTO dbo.Journal
(
	RowID, 
	RecordID, 
	Tanggal, 
	NoReff, 
	Uraian, 
	Src, 
	KodeGudang, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	idtrans,
	tanggal,
	no_reff,
	uraian,
	src,
	kd_gdg,
	id_match,
	'Import',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_GL\'; ' '; ' ', 'SELECT * FROM Transact')

GO

UPDATE dbo.Journal
SET RowID = ISNULL((SELECT TOP 1 RowID FROM dbo.Bukti b WHERE b.RecordID = a.RecordID),NEWID())
From dbo.Journal a
WHERE 
a.Src IN ('BKK','BKM')

GO

UPDATE dbo.Journal
SET RowID = ISNULL((SELECT TOP 1 RowID FROM dbo.BankDetail b WHERE b.RecordID = a.RecordID),NEWID())
From dbo.Journal a
WHERE 
a.Src = 'BBB'

GO


UPDATE dbo.Journal
SET RowID = ISNULL((SELECT TOP 1 RowID FROM dbo.BBM b WHERE b.RecordID = a.RecordID),NEWID())
From dbo.Journal a
WHERE 
a.Src = 'BBM'

GO



UPDATE dbo.Journal
SET RowID = ISNULL((SELECT TOP 1 VoucherID FROM dbo.Giro b WHERE b.VoucherRecID = a.RecordID),NEWID())
From dbo.Journal a
WHERE 
a.Src = 'VPG'

GO
 
UPDATE dbo.Journal
SET RowID = ISNULL((SELECT TOP 1 TitipID FROM dbo.Giro b WHERE b.TitipRecID = a.RecordID),NEWID())
From dbo.Journal a
WHERE 
a.Src = 'VTG'

GO


UPDATE dbo.Journal
SET RowID = ISNULL((SELECT TOP 1 RowID FROM dbo.VoucherJournal b WHERE b.RecordID = a.RecordID),NEWID())
From dbo.Journal a
WHERE 
a.Src = 'VJU'


GO

UPDATE dbo.Journal
SET RowID = NEWID()
WHERE
RowID IS NULL

GO
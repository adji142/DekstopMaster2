USE ISAFinance 
GO
DELETE FROM dbo.DKN
GO
INSERT INTO dbo.DKN
(
	RowID, 
	RecordID, 
	Tanggal, 
	NoDKN, 
	DK, 
	Cabang, 
	CD, 
	Src, 
	SyncFlag, 
	NPrint, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	idrec,
	tanggal,
	no_dkn,
	dk,
	cabang,
	cd,
	src,
	lupload,
	nprint,
	'DELTA CRB',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM hdnota')

GO

UPDATE DBO.DKN
SET RowID = b.RowID,
RefRowID = b.RefRowID

FROM DBO.DKN a INNER JOIN ISAFinance_JKT.DBO.DKN b ON a.RecordID =  b.RecordID


GO 

UPDATE DBO.DKN 
SET RefRowID = b.RowID,
RefTipe = 'VJU',
RefNoBukti = b.NoVoucher
FROM DBO.DKN a INNER JOIN DBO.VoucherJournal b ON SUBSTRING(a.RecordID,1,22) = SUBSTRING(b.RecordID,1,22)
GO

UPDATE DBO.DKN 
SET RefRowID = b.RowID,
RefTipe = 'BKK',
RefNoBukti = b.NoBukti
FROM DBO.DKN a INNER JOIN DBO.Bukti b ON SUBSTRING(a.RecordID,1,22) = SUBSTRING(b.RecordID,1,22)
WHERE b.MK = 'K'
GO

UPDATE DBO.DKN 
SET RefRowID = b.RowID,
RefTipe = 'BKM',
RefNoBukti = b.NoBukti
FROM DBO.DKN a INNER JOIN DBO.Bukti b ON SUBSTRING(a.RecordID,1,22) = SUBSTRING(b.RecordID,1,22)
WHERE b.MK = 'M'
GO


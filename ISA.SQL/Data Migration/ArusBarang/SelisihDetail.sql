USE ISAdb

GO
DELETE FROM ISAdb.dbo.SelisihDetail

GO

INSERT INTO dbo.SelisihDetail
(
	RowID,
	HeaderID,
	RecordID,
	TransactionID,
	KodeBarang,
	QtyComp,
	QtyOpname,
	Catatan,
	SyncFlag,
	LastUpdatedBy,
	LastUpdatedTime
)

SELECT 
	NEWID(),
	NULL,
	RTRIM(iddselisih),
	RTRIM(idhselisih),
	RTRIM(id_brg),
	q_comp,
	q_opn,
	RTRIM(catatan),
	RTRIM(id_match),
	'Admin',
	GETDATE()

FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM DSelisih')
GO
UPDATE dbo.SelisihDetail
SET HeaderID = b.RowID
FROM SelisihDetail a LEFT OUTER JOIN Selisih b ON a.TransactionID = b.RecordID
GO
--SELECT * FROM   dbo.SelisihDetail  
 
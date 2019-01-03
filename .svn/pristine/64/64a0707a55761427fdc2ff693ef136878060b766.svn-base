USE ISAdb

GO
DELETE FROM ISAdb.dbo.PengembalianDetail

GO

INSERT INTO dbo.PengembalianDetail
(
	RowID,
	HeaderID,
	PeminjamanID,
	RecordID,
	TransactionID,
	IDPinjam,
	NoPinjam,
	QtyKembali,
	Catatan,
	SyncFlag,
	LastUpdatedBy,
	LastUpdatedTime
)

SELECT 
	NEWID(),
	NULL,
	NULL,
	RTRIM(idrec),
	RTRIM(idtr),
	RTRIM(iddpinjam),
	RTRIM(nopjm),
	qty_kmb,
	RTRIM(Catatan),
	RTRIM(id_match),
	'DELTA CRB',
	GETDATE()

FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM DKembali')

GO

UPDATE DBO.PengembalianDetail
SET RowID = b.RowID,
HeaderID = b.HeaderID,
PeminjamanID = b.PeminjamanID

FROM DBO.PengembalianDetail a INNER JOIN ISAdb_JKT.DBO.PengembalianDetail b ON a.RecordID = b.RecordID

GO 

UPDATE dbo.PengembalianDetail
SET 
	HeaderID=b.RowID
FROM PengembalianDetail a LEFT OUTER JOIN Pengembalian b 
ON b.RecordID = a.TransactionID
GO
 UPDATE dbo.PengembalianDetail
SET 
	PeminjamanID=b.RowID
FROM PengembalianDetail a LEFT OUTER JOIN PeminjamanDetail b 
ON a.IDPinjam= b.RecordID
GO
--SELECT * FROM   dbo.PengembalianDetail
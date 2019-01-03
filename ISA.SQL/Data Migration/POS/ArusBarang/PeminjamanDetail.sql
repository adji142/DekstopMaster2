USE ISAdb

GO
DELETE FROM ISAdb.dbo.PeminjamanDetail

GO

INSERT INTO dbo.PeminjamanDetail
(
	RowID,
	HeaderID,
	TransactionID,
	RecordID,
	KodeBarang,
	QtyMemo,
	QtyKeluarGudang,
	Catatan,
	SyncFlag,
	LastUpdatedBy,
	LastUpdatedTime
)

SELECT 
	NEWID(),
	NULL,
	RTRIM(idtr),
	RTRIM(idrec),
	RTRIM(id_brg),
	RTRIM(qty_kelpj),
	RTRIM(qty_kelgd),
	RTRIM(catatan),
	id_match,	
	'DELTA CRB',
	GETDATE()

FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT
idtr,
idrec,
id_brg,
qty_kelpj,
qty_kelgd,
catatan,
id_match
FROM Dpinjam')
GO

UPDATE DBO.PeminjamanDetail
SET RowID = b.RowID,
HeaderID = b.HeaderID

FROM DBO.PeminjamanDetail a INNER JOIN ISAdb_JKT.DBO.PeminjamanDetail b ON a.RecordID = b.RecordID



GO 

UPDATE	dbo.PeminjamanDetail
SET HeaderID=b.RowID
FROM PeminjamanDetail a LEFT OUTER JOIN Peminjaman b ON a.TransactionID=b.RecordID
GO
--SELECT * FROM   dbo.PeminjamanDetail  



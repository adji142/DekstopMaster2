	   USE ISAdb

GO
DELETE FROM ISAdb.dbo.AntarGudangDetail

GO

INSERT INTO dbo.AntarGudangDetail
(
	RowID,
	HeaderID,
	RecordID,
	TransactionID,
	KodeBarang,
	QtyKirim,
	QtyTerima,
	Catatan,
	Ongkos,
	SyncFlag,
	QtyDO,
	LastUpdatedTime,
	LastUpdatedBy
)

SELECT 
	NEWID(),
	NULL,
	RTRIM(iddkrmagud),
	RTRIM(idhkrmagud),
	RTRIM(id_brg),
	qty_krm,
	qty_trm,
	RTRIM(catatan),
	ongkos,
	RTRIM(id_match),
	qty_do,
	GETDATE(),
	'DELTA CRB'
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM Dkrmagud')

GO


UPDATE dbo.AntarGudangDetail
SET
	RowID = b.RowID,
	HeaderID = b.HeaderID
FROM dbo.AntarGudangDetail a
INNER JOIN ISAdb_JKT.dbo.AntarGudangDetail b ON a.RecordID = b.RecordID
 
GO 

UPDATE	dbo.AntarGudangDetail
SET HeaderID=b.RowID
FROM  AntarGudangDetail a LEFT OUTER JOIN AntarGudang b on a.TransactionID = b.RecordID
GO
--SELECT * FROM   dbo.AntarGudangDetail   
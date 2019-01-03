-- update length field no_rq become 15 characters.
USE ISAdb 
GO
DELETE ISAdb.dbo.OrderPembelian
GO
INSERT INTO ISAdb.dbo.OrderPembelian
(
	RowID, 
	RecordID, 
	NoRequest, 
	TglRequest, 
	Pemasok, 
	Cabang1, 
	Cabang2, 
	EstHrgJual, 
	EstHPP, 
	NoACC, 
	Catatan, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	RTRIM(idrec),
	RTRIM(no_rq),
	tgl_rq,
	RTRIM(pemasok),
	RTRIM(c1),
	RTRIM(c2),
	est_rpJual,
	est_rphpp,
	LEFT(RTRIM(no_acc),5),
	RTRIM(catatan),
	(CASE WHEN id_match = '1' THEN 1 ELSE 0 END),
	'DELTA CRB',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM hosheet')
 
GO

UPDATE DBO.OrderPembelian
SET RowID = b.RowID
FROM DBO.OrderPembelian a INNER JOIN ISAdb_JKT.DBO.OrderPembelian b ON a.RecordID = b.RecordID

GO
--SELECT * FROM OrderPembelian
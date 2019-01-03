USE ISAdb 
GO
DELETE FROM ISAdb.dbo.RekapKoliSubDetail
GO
INSERT INTO ISAdb.dbo.RekapKoliSubDetail
(
	RowID,
	HeaderID,
	RecordID,
	HtrID,
	Uraian,
	Jumlah,
	Satuan,
	Keterangan,
	SyncFlag,
	LastUpdatedBy,
	LastUpdatedTime
)
SELECT 
	NEWID(),
	b.RowID,
	RTRIM(a.idrec),
	RTRIM(a.idtr),
	RTRIM(a.uraian),
	jumlah,
	RTRIM(satuan),
	RTRIM(ket),
	id_match,
	'DELTA CRB',
	GETDATE()	  
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM cxpdc') a 
LEFT OUTER JOIN dbo.RekapKoliDetail b
ON RTRIM(a.idtr) = b.RecordID

GO

UPDATE DBO.RekapKoliSubDetail
SET RowID = b.RowID,
HeaderID = b.HeaderID
FROM DBO.RekapKoliSubDetail a INNER JOIN ISAdb_JKT.DBO.RekapKoliSubDetail b ON a.RecordID = b.RecordID

GO 
--SELECT * FROM RekapKoliSubDetail 
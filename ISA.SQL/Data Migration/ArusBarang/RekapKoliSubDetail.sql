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
	1,
	'Admin',
	GETDATE()	  
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM cxpdc') a 
LEFT OUTER JOIN dbo.RekapKoliDetail b
ON RTRIM(a.idtr) = b.RecordID

GO
--SELECT * FROM RekapKoliSubDetail 
USE ISAdb 
GO
DELETE FROM ISAdb.dbo.RekapKoliDetail
GO
INSERT INTO ISAdb.dbo.RekapKoliDetail
(
	RowID, 
	HeaderID, 
	NotaJualID,
	RecordID, 
	HtrID, 
	NotaJualRecID, 
	NoNota, 
	TunaiKredit, 
	Nominal, 
	Uraian, 
	Keterangan,
	NoResi, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	b.RowID,
	c.RowID,
	RTRIM(a.idrec),
	RTRIM(a.idtr),
	RTRIM(a.idhtr),
	RTRIM(a.no_nota),
	RTRIM(a.tk),
	a.nominal,	
	RTRIM(a.uraian),
	RTRIM(a.ket),
	RTRIM(a.no_resi),
	a.id_match,
	'DELTA CRB',
	GETDATE()	  
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM dxpdc') a 
LEFT OUTER JOIN dbo.RekapKoli b ON a.idtr = b.RecordID
LEFT OUTER JOIN dbo.NotaPenjualan c ON RTRIM(a.idhtr) = c.RecordID

GO

UPDATE DBO.RekapKoliDetail
SET RowID = b.RowID,
HeaderID = b.HeaderID,
NotaJualID = b.NotaJualID
FROM DBO.RekapKoliDetail a INNER JOIN ISAdb_JKT.DBO.RekapKoliDetail b ON a.RecordID = b.RecordID

GO
--SELECT * FROM RekapKoliDetail


USE ISAFinance 
GO
DELETE FROM dbo.BBK
GO

INSERT INTO dbo.BBK
(
	RowID, 
	RecordID, 
	TglBBK, 
	NoBBK, 
	BankID, 
	Dibukukan, 
	Diketahui, 
	Kasir, 
	Penerima, 
	RpGiro, 
	RpCair, 
	RpTolak, 
	NPrint, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),	
	RTRIM(idbbk),
	tgl_BBK,
	RTRIM(no_BBK),
	RTRIM(id_bank),
	RTRIM(dibukuan),
	RTRIM(diketahui),
	RTRIM(kasir),
	RTRIM(penerima),
	rp_giro,
	rp_cair,
	rp_tolak,
	nprint,
	id_match,
	'DELTA CRB',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM BBK')

GO

UPDATE dbo.BBK
SET
	RowID = b.RowID
FROM dbo.BBK a
INNER JOIN ISAFinance_JKT.dbo.BBK b ON  a.RecordID = b.RecordID
 
GO
 
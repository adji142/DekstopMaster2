USE ISAFinance 
GO
DELETE FROM dbo.BBM
GO

INSERT INTO dbo.BBM
(
	RowID, 
	RecordID, 
	TglBBM, 
	NoBBM, 
	BankID, 
	Dibukukan, 
	Diketahui, 
	Kasir, 
	Penyetor, 
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
	RTRIM(idbbm),
	tgl_BBM,
	RTRIM(no_BBM),
	RTRIM(id_bank),
	RTRIM(dibukuan),
	RTRIM(diketahui),
	RTRIM(kasir),
	RTRIM(penyetor),
	rp_giro,
	rp_cair,
	rp_tolak,
	nprint,
	id_match,
	'DELTA CRB',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM BBM')

GO
 
 UPDATE dbo.BBM
SET
	RowID = b.RowID
FROM dbo.BBM a
INNER JOIN ISAFinance_JKT.dbo.BBM b ON  a.RecordID = b.RecordID
 
GO 
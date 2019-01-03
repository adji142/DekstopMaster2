 USE ISAFinance 
GO
DELETE FROM dbo.Inden 
GO
INSERT INTO dbo.Inden
(
	RowID, 
	RecordID, 
	TglKasir, 
	Kasir, 
	NoBukti, 
	CollectorID, 
	NamaCollector,	
	Acc, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	idtr,
	CASE WHEN tgl_kasir = '  /  /    ' THEN NULL ELSE tgl_kasir END,
	kasir,	
	no_bukti,
	nm_coll,
	collector,
	acc,
	id_match,
	'DELTA CRB',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT 
idtr,
no_bukti,
collector,
nm_coll,
rp_cash,
rp_giro,
rp_trf,
lbr_giro,
dtoc(tgl_kasir) as tgl_kasir,
kasir,
acc,
id_match,
rp_crd,
rp_dbt
FROM hinden')
ORDER BY tgl_kasir 

GO

UPDATE DBO.Inden
SET 
RowID = b.RowID

FROM DBO.Inden a INNER JOIN ISAFinance_JKT.DBO.Inden b ON a.RecordID =  b.RecordID


GO 


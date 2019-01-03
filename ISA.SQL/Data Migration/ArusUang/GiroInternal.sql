 USE ISAFinance 
GO
DELETE FROM dbo.GiroInternal
GO

INSERT INTO dbo.GiroInternal
(
	RowID, 
	BBKID, 
	GiroID, 
	BBKRecID, 
	GiroRecID, 
	IndRecID, 
	BankID, 
	Kode, 
	Sub, 
	GC, 
	Bank, 
	NoGiro, 
	TglGiro, 
	TglJth, 
	CairTolak, 
	TglCair, 
	VTA, 
	Nominal, 
	Kepada, 
	Keperluan, 
	SyncFlag, 
	NoPerkiraan, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),	
	NULL,
	NULL,
	idbbk,
	idgiro,
	idbank,
	idind,
	kode,
	sub,
	gc,
	Bank,
	no_giro,
	tgl_giro,
	tgl_jt,
	cairtolak,
	tgl_cair,
	vta,
	nominal,
	kepada,
	keperluan,
	id_match,
	no_perk,	
	'Import',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM GiroIN')

GO

UPDATE dbo.GiroInternal
SET GiroID = bd.RowID
FROM DBO.GiroInternal gi
INNER JOIN DBO.BankDetail bd
ON gi.GiroRecID = bd.RecordID


UPDATE DBO.GiroInternal
SET BBKID = bbk.RowID
FROM DBO.GiroInternal gi
INNER JOIN DBO.BBK bbk
ON gi.BBKRecID = bbk.RecordID
USE ISAFinance
GO

DELETE FROM DBO.IndenDetail
GO

CREATE TABLE [dbo].[IndenDetail_import](
	[RowID] [uniqueidentifier] NOT NULL,
	[HeaderID] [uniqueidentifier] NULL,
	[RecordID] [varchar](23) NOT NULL,
	[HRecordID] [varchar](23) NOT NULL,
	[TglTrf] [varchar](20) NULL,
	[BankID] [varchar](23) NOT NULL,
	[NamaBank] [varchar](20) NULL,
	[Lokasi] [varchar](20) NOT NULL,
	[CHBG] [char](1) NOT NULL,
	[Nomor] [varchar](15) NOT NULL,
	[TglGiro] [varchar](20) NULL,
	[TglJt] [varchar](20) NULL,
	[Ket] [varchar](40) NOT NULL,
	[NoAcc] [varchar](15) NOT NULL,
	[RpCash] [money] NOT NULL,
	[RpGiro] [money] NOT NULL,
	[RpTrf] [money] NOT NULL,
	[RpCrd] [money] NOT NULL,
	[RpDbt] [money] NOT NULL,
	[SyncFlag] [bit] NOT NULL,
	[LastUpdatedBy] [varchar](250) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
 
) ON [PRIMARY]


INSERT INTO IndenDetail_import
(	RowID,
	HeaderID,
	RecordID,
	HRecordID,
	TglTrf,
	BankID,
	NamaBank,
	Lokasi,
	CHBG,
	Nomor,
	TglGiro,
	TglJt,
	Ket,
	NoAcc,
	RpCash,
	RpGiro,
	RpTrf,
	RpCrd,
	RpDbt,
	SyncFlag,
	LastUpdatedBy,
	LastUpdatedTime
)
SELECT
	NEWID()AS RowID,
	NULL AS HeaderID,
	idrec,
	idtr,
	tgl_trf,
	idbank,
	namabank,
	lokasi,
	chbg,
	nomor,
	tgl_giro,
	tgl_jt,
	ket,
	no_acc,
	rp_cash,
	rp_giro,
	rp_trf,	
	rp_crd,
	rp_dbt,
	id_match,
	'Import' AS LastUpdatedBy,
	GETDATE() AS LastUpdatedTime	
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT 
idtr,
idrec,
rp_cash,
rp_giro,
rp_trf,
cash,
trf,
giro,
dtoc(tgl_trf) as tgl_trf,
idbank,
namabank,
lokasi,
chbg,
nomor,
dtoc(tgl_giro) as tgl_giro,
dtoc(tgl_jt) as tgl_jt,
ket,
id_match,
no_acc,
rp_crd,
rp_dbt,
crd,
dbt
FROM DINDEN')


GO


UPDATE IndenDetail_import
SET TglTrf =    CAST(CASE WHEN TglTrf = '  /  /  ' THEN NULL
			    WHEN CAST(RIGHT(TglTrf,4) as int) < 1900  THEN NULL ELSE TglTrf END AS varchar),
TglGiro  =	CAST(CASE WHEN TglGiro = '  /  /  ' THEN NULL
			    WHEN CAST(RIGHT(TglGiro,4) as int) < 1900  THEN NULL ELSE TglGiro END AS varchar),
TglJt  = 	CAST(CASE WHEN TglJt = '  /  /  ' THEN NULL
			    WHEN CAST(RIGHT(TglJt,4) as int) < 1900  THEN NULL ELSE TglJt END AS varchar)			 


INSERT INTO dbo.IndenDetail
(
	RowID, 
	HeaderID, 
	RecordID, 
	HRecordID, 
	TglTrf, 
	BankID, 
	NamaBank, 
	Lokasi, 
	CHBG, 
	Nomor, 
	TglGiro, 
	TglJt, 
	Ket, 	 
	NoAcc, 
	RpCash, 
	RpGiro, 
	RpTrf, 
	RpCrd, 
	RpDbt, 
	SyncFlag,
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	RowID, 
	HeaderID, 
	RecordID, 
	HRecordID, 
	CAST(TglTrf AS Datetime) , 
	BankID, 
	NamaBank, 
	Lokasi, 
	CHBG, 
	Nomor, 
	CAST(TglGiro AS Datetime) , 
	CAST(TglJt AS Datetime) , 
	Ket, 	 
	NoAcc, 
	RpCash, 
	RpGiro, 
	RpTrf, 
	RpCrd, 
	RpDbt, 
	SyncFlag,
	LastUpdatedBy, 
	LastUpdatedTime
FROM IndenDetail_import





UPDATE dbo.IndenDetail
SET HeaderID = (SELECT TOP 1 RowID FROM dbo.Inden b WHERE b.RecordID = a.HRecordID)
FROM dbo.IndenDetail a


UPDATE dbo.IndenDetail
SET TglGiro = NULL
WHERE YEAR(TglGiro) <= 1900

UPDATE dbo.IndenDetail
SET TglTrf = NULL
WHERE YEAR(TglGiro) <= 1900


UPDATE dbo.IndenDetail
SET TglJt = NULL
WHERE YEAR(TglGiro) <= 1900

GO

DROP TABLE IndenDetail_import

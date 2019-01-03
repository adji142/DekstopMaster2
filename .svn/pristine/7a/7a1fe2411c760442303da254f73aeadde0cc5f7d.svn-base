USE ISAFinance
GO
DELETE FROM dbo.IndenSubDetail
GO

CREATE TABLE [dbo].[IndenSubDetail_Import](
	[RowID] [uniqueidentifier] NOT NULL,
	[HeaderID] [uniqueidentifier] NULL,	
	[RecordID] [varchar](23) NOT NULL,
	[HRecordID] [varchar](23) NOT NULL,
	[KodeToko] [varchar](19) NOT NULL,
	[NamaToko] [varchar](31) NOT NULL,
	[NoReg] [varchar](10) NOT NULL,
	[NoBPP] [varchar](10) NOT NULL,
	[TglBPP] [varchar](20) NULL,
	[TglKasir] [varchar](20) NULL,
	[RpNominal] [money] NOT NULL,
	[SyncFlag] [bit] NOT NULL,
	[LastUpdatedBy] [varchar](250) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
) ON [PRIMARY]

INSERT INTO dbo.IndenSubDetail_Import
(
	RowID, 
	HeaderID, 
	RecordID, 
	HRecordID,	
	KodeToko, 
	NamaToko,
	NoReg, 
	NoBPP, 
	TglBPP,	
	TglKasir,	 	 	
	RpNominal, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT
	NEWID(),
	NULL,	
	RTRIM(id_coltoko),
	RTRIM(idrec),	
	RTRIM(kd_toko),
	RTRIM(namatoko),
	RTRIM(no_reg),
	RTRIM(no_bpp),	
	tgl_bpp,
	tgl_kasir,	
	rp_nominal,
	id_match,
	'Import',
	GETDATE()	
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir'; ' '; ' ', 'SELECT
idrec,
id_coltoko,
idwil,
kd_toko,
namatoko,
no_reg,
no_bpp,
dtoc(tgl_bpp) as tgl_bpp,
dtoc(tgl_kasir) as tgl_kasir,
rp_nota,
rp_bayar,
rp_tagih,
rp_nominal,
id_match,
nota
FROM tagih')

--UPDATE DBO.IndenSubDetail_Import
--SET TglKasir = '2011-10-19'
--WHERE RecordID = 'C092011101912:38:26NNK'

DELETE FROM DBO.IndenSubDetail_Import
WHERE RTRIM(RecordID) = ''


UPDATE IndenSubDetail_Import
SET TglBPP =    CAST(CASE WHEN TglBPP = '  /  /  ' THEN NULL
			    WHEN CAST(RIGHT(TglBPP,4) as int) < 1900  THEN NULL ELSE TglBPP END AS varchar),
TglKasir  =	CAST(CASE WHEN TglKasir = '  /  /  ' THEN NULL
			    WHEN CAST(RIGHT(TglKasir,4) as int) < 1900  THEN NULL ELSE TglKasir END AS varchar)

INSERT INTO DBO.IndenSubDetail
(RowID, 
	HeaderID, 
	RecordID, 
	HRecordID,	
	KodeToko, 
	NamaToko,
	NoReg, 
	NoBPP, 
	TglBPP,	
	TglKasir,	 	 	
	RpNominal, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 

	RowID, 
	HeaderID, 
	RecordID, 
	HRecordID,	
	KodeToko, 
	NamaToko,
	NoReg, 
	NoBPP, 
	CAST(TglBPP as datetime),	
	CAST(TglKasir as datetime),	 	 	
	RpNominal, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime

FROM dbo.IndenSubDetail_Import
GO

UPDATE dbo.IndenSubDetail
SET HeaderID = (SELECT TOP 1 RowID FROM dbo.IndenDetail b WHERE b.RecordID = a.HRecordID)
FROM dbo.IndenSubDetail a


UPDATE dbo.IndenSubDetail
SET IndenID = (SELECT TOP 1 a.RowID FROM dbo.Inden a INNER JOIN dbo.IndenDetail b  ON a.RowID = b.HeaderID WHERE b.RowID = c.HeaderID)
FROM dbo.IndenSubDetail c

DROP TABLE IndenSubDetail_Import
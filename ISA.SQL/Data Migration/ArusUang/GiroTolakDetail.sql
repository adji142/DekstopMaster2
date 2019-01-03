 USE ISAFinance 
GO
DELETE FROM dbo.GiroTolakDetail
GO
IF EXISTS (SELECT * FROM sys.all_objects a WHERE a.name='GiroTolakDetail_Import')
DROP TABLE dbo.GiroTolakDetail_Import
CREATE TABLE [dbo].[GiroTolakDetail_Import](
	[RowID] [uniqueidentifier] NOT NULL,
	[HeaderID] [uniqueidentifier] NULL,
	[RecordID] [varchar](23) NOT NULL,
	[HRecordID] [varchar](23) NOT NULL,
	[TglBayar] [varchar](20) NULL,
	[KodeBayar] [varchar](3) NOT NULL,
	[Kredit] [money] NOT NULL,
	[CbgJt] [varchar](20) NULL,
	[Uraian] [varchar](43) NOT NULL,	
	[NoBKM] [varchar](5) NOT NULL,
	[NoBG] [varchar](10) NOT NULL,
	[Bank] [varchar](15) NOT NULL,
	[NoACC] [varchar](15) NOT NULL,
	[SyncFlag] [bit] NOT NULL,
	[LastUpdatedBy] [varchar](250) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
) ON [PRIMARY]

GO


INSERT INTO dbo.GiroTolakDetail_Import
(
	RowID, 
	HeaderID, 
	RecordID, 
	HRecordID, 
	TglBayar, 
	KodeBayar, 
	Kredit, 
	CbgJt, 
	Uraian, 
	NoBKM, 
	NoBG, 
	Bank, 
	NoACC, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	NULL,
    dstamp,
	idrec,
	tgl_byr,
	kd_bayar,
	kredit,
	cbg_jt,
	uraian,
	no_bkm,
	no_bg,
	Bank,
	no_acc,
	id_match,
	'Import',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'c:\SAS_Database\'; ' '; ' ', 'SELECT * FROM dBGTolak')

   
GO


UPDATE GiroTolakDetail_Import
SET 
TglBayar = NULL
WHERE
LEFT(TglBayar,4) <'1900'


UPDATE GiroTolakDetail_Import
SET 
CbgJt = NULL
WHERE
CbgJt <'1900'

GO

INSERT INTO dbo.GiroTolakDetail
(	RowID, 
	HeaderID, 
	RecordID, 
	HRecordID, 
	TglBayar, 
	KodeBayar, 
	Kredit, 
	CbgJt, 
	Uraian, 
	NoBKM, 
	NoBG, 
	Bank, 
	NoACC, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	RowID, 
	HeaderID, 
	RecordID, 
	HRecordID, 
	TglBayar, 
	KodeBayar, 
	Kredit, 
	CbgJt, 
	Uraian, 
	NoBKM, 
	NoBG, 
	Bank, 
	NoACC, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime

FROM dbo.GiroTolakDetail_Import

GO
 

GO 


UPDATE dbo.GiroTolakDetail
SET HeaderID = (SELECT TOP 1 RowID FROM GiroTolak b WHERE b.RecordID = a.HRecordID )
FROM dbo.GiroTolakDetail a

GO

UPDATE GiroTolak 
SET STATUS = 'OPEN'

GO

UPDATE GiroTolak 
SET STATUS = 'CLOSE'
from Girotolak gt
where 
Debet = ISNULL((select SUM(kredit) from GiroTolakDetail dt where dt.HeaderID = gt.RowID),0)


--GO

update girotolakdetail
set rowid=b.rowid
from girotolakdetail a inner join indensuperdetail b
on a.recordid=substring(b.recordid,4,19)

GO

IF EXISTS (SELECT * FROM sys.all_objects a WHERE a.name='GiroTolakDetail_Import')
DROP TABLE dbo.GiroTolakDetail_Import
GO
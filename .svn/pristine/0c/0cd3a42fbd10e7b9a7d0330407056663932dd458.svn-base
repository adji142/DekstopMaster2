USE ISAFinance 
GO

DELETE FROM dbo.Tagihan
GO
IF EXISTS (SELECT * FROM sys.all_objects a WHERE a.name='Tagihan_Import')
DROP TABLE Tagihan_Import

CREATE TABLE [dbo].[Tagihan_Import](
	[RowID] [uniqueidentifier] NOT NULL,
	[RecordID] [varchar](23) NOT NULL,
	[NoReg] [varchar](50) NOT NULL,
	[TglReg] [datetime] NOT NULL,
	[TglKembali] [datetime] NOT NULL,
	[CollectorID] [varchar](23) NOT NULL,
	[Wilayah] [varchar](50) NOT NULL,
	[Periode1] [varchar](20) NULL,
	[Periode2] [varchar](20) NULL,
	[TLama] [money] NOT NULL,
	[Kasir] [varchar](10) NOT NULL,
	[NPrint] [int] NOT NULL,
	[SyncFlag] [bit] NOT NULL,
	[LastUpdatedBy] [varchar](250) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Tagih_Import] PRIMARY KEY CLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

GO
INSERT INTO dbo.Tagihan_Import
(
	RowID, 
	RecordID, 
	NoReg, 
	TglReg, 
	TglKembali,
	CollectorID, 
	Wilayah, 
	Periode1, 
	Periode2,  
	TLama, 
	Kasir, 
	NPrint, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	id_reg,
	no_reg,
	tgl_reg,
	tgl_kbl,
	nm_coll,
	wilayah,
	periode_1,
	periode_2,
	t_lama,
	nm_kasir,
	nprint,
	id_match,
	'DELTA CRB',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM htagihan')

GO


UPDATE Tagihan_Import SET Periode1 = NULL
WHERE
LEFT(Periode1,4) <= '1900'

UPDATE Tagihan_Import SET Periode2 = NULL
WHERE
LEFT(Periode2,4) <= '1900'

GO



INSERT INTO Tagihan
SELECT * FROM Tagihan_Import

GO
IF EXISTS (SELECT * FROM sys.all_objects a WHERE a.name='Tagihan_Import')
DROP TABLE Tagihan_Import
GO

UPDATE DBO.Tagihan
SET 
RowID = b.RowID

FROM DBO.Tagihan a INNER JOIN ISAFinance_JKT.DBO.Tagihan b ON a.RecordID =  b.RecordID


GO 
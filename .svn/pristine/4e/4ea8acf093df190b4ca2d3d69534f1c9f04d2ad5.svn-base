USE [ISAdb]
GO

/****** Object:  Table [dbo].[P_OrderPenjualan]    Script Date: 08/20/2011 15:25:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[P_OrderPenjualan](
	[RowID] [uniqueidentifier] NOT NULL,
	[HtrID] [varchar](23) NOT NULL,
	[Cabang1] [varchar](2) NOT NULL,
	[Cabang2] [varchar](2) NOT NULL,
	[Cabang3] [varchar](2) NOT NULL,
	[NoRequest] [varchar](7) NOT NULL,
	[TglRequest] [datetime] NULL,
	[NoDO] [varchar](7) NOT NULL,
	[TglDO] [datetime] NULL,
	[NoACCPusat] [varchar](7) NOT NULL,
	[ACCPiutangID] [varchar](11) NOT NULL,
	[NoACCPiutang] [varchar](7) NOT NULL,
	[TglACCPiutang] [datetime] NULL,
	[RpACCPiutang] [money] NOT NULL,
	[RpPlafonToko] [money] NOT NULL,
	[RpPiutangTerakhir] [money] NOT NULL,
	[RpGiroTolakTerakhir] [money] NOT NULL,
	[RpOverdue] [money] NOT NULL,
	[StatusBatal] [varchar](7) NOT NULL,
	[KodeToko] [varchar](19) NOT NULL,
	[KodeSales] [varchar](11) NOT NULL,
	[AlamatKirim] [varchar](60) NOT NULL,
	[Kota] [varchar](20) NOT NULL,
	[DiscFormula] [varchar](7) NOT NULL,
	[Disc1] [decimal](5, 2) NOT NULL,
	[Disc2] [decimal](5, 2) NOT NULL,
	[Disc3] [decimal](5, 2) NOT NULL,
	[Plafon] [money] NULL,
	[SaldoPiutang] [money] NULL,
	[QtyTolak] [int] NULL,
	[Overdue] [money] NULL,
	[isClosed] [bit] NOT NULL,
	[Catatan1] [varchar](40) NOT NULL,
	[Catatan2] [varchar](40) NOT NULL,
	[Catatan3] [varchar](40) NOT NULL,
	[Catatan4] [varchar](40) NOT NULL,
	[Catatan5] [varchar](40) NOT NULL,
	[NoDOBO] [varchar](7) NOT NULL,
	[TglReorder] [datetime] NULL,
	[StatusBO] [bit] NOT NULL,
	[SyncFlag] [bit] NOT NULL,
	[LinkID] [varchar](1) NOT NULL,
	[TransactionType] [varchar](2) NOT NULL,
	[Expedisi] [varchar](3) NOT NULL,
	[Shift] [varchar](1) NULL,
	[HariKredit] [int] NOT NULL,
	[HariKirim] [int] NOT NULL,
	[HariSales] [int] NOT NULL,
	[NPrint] [int] NOT NULL,
	[LastUpdatedBy] [varchar](250) NOT NULL,
	[LastUpdatedTime] [datetime] NULL,
 CONSTRAINT [PK_P_OrderPenjualan] PRIMARY KEY NONCLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON ISAdb_PartitionNON_NOTA_DATE_Scheme(TglDO)

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_HtrID]  DEFAULT ('') FOR [HtrID]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_Cabang1]  DEFAULT ('') FOR [Cabang1]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_Cabang2]  DEFAULT ('') FOR [Cabang2]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_Cabang3]  DEFAULT ('') FOR [Cabang3]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_NoRequest]  DEFAULT ('') FOR [NoRequest]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_NoDO]  DEFAULT ('') FOR [NoDO]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_NoACCPusat]  DEFAULT ('') FOR [NoACCPusat]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_ACCPiutangID]  DEFAULT ('') FOR [ACCPiutangID]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_NoACCPiutang]  DEFAULT ('') FOR [NoACCPiutang]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_StatusBatal]  DEFAULT ('') FOR [StatusBatal]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_KodeToko]  DEFAULT ('') FOR [KodeToko]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_KodeSales]  DEFAULT ('') FOR [KodeSales]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_AlamatKirim]  DEFAULT ('') FOR [AlamatKirim]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_Kota]  DEFAULT ('') FOR [Kota]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_DiscFormula]  DEFAULT ('') FOR [DiscFormula]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_Disc1]  DEFAULT ((0)) FOR [Disc1]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_Disc2]  DEFAULT ((0)) FOR [Disc2]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_Disc3]  DEFAULT ((0)) FOR [Disc3]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_Fee1]  DEFAULT ((0)) FOR [QtyTolak]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_Fee2]  DEFAULT ((0)) FOR [Overdue]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_isClosed]  DEFAULT ((0)) FOR [isClosed]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_Catatan1]  DEFAULT ('') FOR [Catatan1]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_Catatan2]  DEFAULT ('') FOR [Catatan2]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_Catatan3]  DEFAULT ('') FOR [Catatan3]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_Catatan4]  DEFAULT ('') FOR [Catatan4]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_Catatan5]  DEFAULT ('') FOR [Catatan5]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_NoDOBO]  DEFAULT ('') FOR [NoDOBO]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_StatusBO]  DEFAULT ((0)) FOR [StatusBO]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_SyncFlag]  DEFAULT ((0)) FOR [SyncFlag]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_LinkID]  DEFAULT ('') FOR [LinkID]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_HariKredit]  DEFAULT ((0)) FOR [HariKredit]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_HariKirim]  DEFAULT ((0)) FOR [HariKirim]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_HariSelesai]  DEFAULT ((0)) FOR [HariSales]
GO

ALTER TABLE [dbo].[P_OrderPenjualan] ADD  CONSTRAINT [DF_P_OrderPenjualan_NPrint]  DEFAULT ((0)) FOR [NPrint]
GO


CREATE CLUSTERED INDEX IX_P_OrderPenjualan
 ON P_OrderPenjualan(TglDO,Cabang1,Cabang2)
 ON ISAdb_PartitionNON_NOTA_DATE_Scheme(TglDO)

CREATE INDEX IX_P_OrderPenjualan_HtrID
 ON P_OrderPenjualan(HtrID,RowID)
 ON ISAdb_PartitionNON_NOTA_DATE_Scheme(TglDO)
 
 
 INSERT INTO P_OrderPenjualan
 SELECT * FROM OrderPenjualan
 
DBCC FREEPROCCACHE
DBCC DROPCLEANBUFFERS
SELECT * FROM P_OrderPenjualan where TglDO between '2011/01/01' AND '2011/06/01'


SELECT * FROM OrderPenjualan where TglDO between '2011/01/01' AND '2011/06/01' 
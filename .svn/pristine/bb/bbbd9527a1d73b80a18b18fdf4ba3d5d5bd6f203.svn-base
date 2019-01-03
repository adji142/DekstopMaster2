USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_ReturPenjualanTarikanDetail]    Script Date: 10/11/2011 13:49:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nobon
-- Create date: 23 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_ReturPenjualanDetail '<root><row RowID="49546A0F-A331-45E4-B626-E799CE2D7E9F" HeaderID="827E444E-7644-4E1E-AE2E-7EFEC69F7705" NotaJualDetailID="7EA23AD1-DFA3-4EFC-AC91-B2DB8BBDFE83" RecordID="MDN2005082913:51:57SJN" ReturID="MDN2005082913:50:38SJN" NotaJualDetailRecID="MDN2005072013:03:30DV01" KodeRetur="1" QtyMemo="2" QtyTarik="2" QtyTerima="0" QtyGudang="2" QtyTolak="0" Catatan1="MINTA YANG JUMBO LONG BIASA" Catatan2="" SyncFlag="1" Kategori="F" KodeGudang="0902" NoACC="" LastUpdatedBy="Admin" LastUpdatedTime="2011-05-16T11:08:11.043"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_ReturPenjualanTarikanDetail] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @HeaderID UNIQUEIDENTIFIER
	DECLARE @RecordID VARCHAR(23)
	DECLARE @ReturID VARCHAR(23)
	DECLARE @NotaAsal VARCHAR(7)
	DECLARE @KodeRetur VARCHAR(1)
	DECLARE @BarangID VARCHAR(23)
	DECLARE @KodeSales VARCHAR(11)
	DECLARE @QtyMemo INT
	DECLARE @QtyTarik INT
	DECLARE @QtyTerima INT
	DECLARE @QtyGudang INT
	DECLARE @QtyTolak INT
	DECLARE @HrgJual MONEY
	DECLARE @Pot MONEY
	DECLARE @Catatan1 VARCHAR(30)
	DECLARE @Catatan2 VARCHAR(30)
	DECLARE @SyncFlag BIT
	DECLARE @Kategori VARCHAR(1)
	DECLARE @KodeGudang VARCHAR(4)
	DECLARE @NoACC VARCHAR(6)
	DECLARE @LastUpdatedBy VARCHAR(250)
	DECLARE @LastUpdatedTime DATETIME

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- INTerfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	
	DECLARE @Temp TABLE
	(
		RowID UNIQUEIDENTIFIER,
		HeaderID UNIQUEIDENTIFIER,
		RecordID VARCHAR(23),
		ReturID VARCHAR(23),
		NotaAsal VARCHAR(7),
		KodeRetur VARCHAR(1),
		BarangID VARCHAR(23),
		KodeSales VARCHAR(11),
		QtyMemo INT,
		QtyTarik INT,
		QtyTerima INT,
		QtyGudang INT,
		QtyTolak INT,
		HrgJual MONEY,
		Pot MONEY,
		Catatan1 VARCHAR(30),
		Catatan2 VARCHAR(30),
		SyncFlag BIT,
		Kategori VARCHAR(1),
		KodeGudang VARCHAR(4),
		NoACC VARCHAR(6),
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc
	INSERT INTO @Temp
	(
		RowID, HeaderID, RecordID, ReturID, NotaAsal, KodeRetur, BarangID, KodeSales, QtyMemo, QtyTarik, QtyTerima, QtyGudang, QtyTolak, HrgJual, Pot, Catatan1, Catatan2, SyncFlag, Kategori, KodeGudang, NoACC, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		HeaderID, 
		RecordID, 
		ReturID, 
		NotaAsal, 
		KodeRetur, 
		BarangID, 
		KodeSales, 
		QtyMemo, 
		QtyTarik, 
		QtyTerima, 
		QtyGudang, 
		QtyTolak, 
		HrgJual, 
		Pot, 
		Catatan1, 
		Catatan2, 
		SyncFlag, 
		Kategori, 
		KodeGudang, 
		NoACC, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		HeaderID UNIQUEIDENTIFIER '@HeaderID',
		RecordID VARCHAR(23) '@RecordID',
		ReturID VARCHAR(23) '@ReturID',
		NotaAsal Varchar(7) '@NotaAsal',
		KodeRetur VARCHAR(1) '@KodeRetur',
		BarangID VARCHAR(23)  '@BarangID',
		KodeSales VARCHAR(11) '@KodeSales',
		QtyMemo INT '@QtyMemo',
		QtyTarik INT '@QtyTarik',
		QtyTerima INT '@QtyTerima',
		QtyGudang INT '@QtyGudang',
		QtyTolak INT '@QtyTolak',
		HrgJual MONEY '@HrgJual',
		Pot MONEY '@Pot',
		Catatan1 VARCHAR(30) '@Catatan1',
		Catatan2 VARCHAR(30) '@Catatan2',
		SyncFlag BIT '@SyncFlag',
		Kategori VARCHAR(1) '@Kategori',
		KodeGudang VARCHAR(4) '@KodeGudang',
		NoACC VARCHAR(6) '@NoACC',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy',
		LastUpdatedTime DATETIME '@LastUpdatedTime'
	)

		exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID, 
		HeaderID, 
		RecordID, 
		ReturID, 
		NotaAsal, 
		KodeRetur, 
		BarangID, 
		KodeSales, 
		QtyMemo, 
		QtyTarik, 
		QtyTerima, 
		QtyGudang, 
		QtyTolak, 
		HrgJual, 
		Pot, 
		Catatan1, 
		Catatan2, 
		SyncFlag, 
		Kategori, 
		KodeGudang, 
		NoACC, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @HeaderID, @RecordID, @ReturID, @NotaAsal, @KodeRetur, @BarangID, @KodeSales, @QtyMemo, @QtyTarik, @QtyTerima, @QtyGudang, @QtyTolak, @HrgJual, @Pot, @Catatan1, @Catatan2, @SyncFlag, @Kategori, @KodeGudang, @NoACC, @LastUpdatedBy, @LastUpdatedTime
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here		
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.ReturPenjualanTarikanDetail (NOLOCK) WHERE RowID = @RowID)
			UPDATE ReturPenjualanTarikanDetail WITH (ROWLOCK)
			SET
				RowID = @RowID,
				HeaderID = @HeaderID,
				RecordID = @RecordID,
				ReturID = @ReturID,
				NotaAsal = @NotaAsal,
				KodeRetur = @KodeRetur,
				BarangID =  @BarangID,
				KodeSales = @KodeSales,
				QtyMemo = @QtyMemo,
				QtyTarik = @QtyTarik,
				QtyTerima = @QtyTerima,
				QtyGudang = @QtyGudang,
				QtyTolak = @QtyTolak,
				HrgJual = @HrgJual,
				Pot = @Pot,
				Catatan1 = @Catatan1,
				Catatan2 = @Catatan2,
				SyncFlag = @SyncFlag,
				Kategori = @Kategori,
				KodeGudang = @KodeGudang,
				NoACC = @NoACC,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			IF EXISTS (SELECT RowID FROM dbo.ReturPenjualan(NOLOCK) WHERE RowID = @HeaderID)
			BEGIN
				INSERT INTO ReturPenjualanTarikanDetail WITH (ROWLOCK)
				(RowID, HeaderID, RecordID, ReturID, NotaAsal, KodeRetur, BarangID, KodeSales, QtyMemo, QtyTarik, QtyTerima, QtyGudang, QtyTolak, HrgJual, Pot, Catatan1, Catatan2, SyncFlag, Kategori, KodeGudang, NoACC, LastUpdatedBy, LastUpdatedTime)
					VALUES	(
								@RowID,
								@HeaderID,
								@RecordID,
								@ReturID,
								@NotaAsal,
								@KodeRetur,
								@BarangID,
								@KodeSales,
								@QtyMemo,
								@QtyTarik,
								@QtyTerima,
								@QtyGudang,
								@QtyTolak,
								@HrgJual,
								@Pot,
								@Catatan1,
								@Catatan2,
								@SyncFlag,
								@Kategori,
								@KodeGudang,
								@NoACC,
								@LastUpdatedBy,
								@LastUpdatedTime
							)
			END
		FETCH NEXT FROM data_cursor INTO
		@RowID, @HeaderID, @RecordID, @ReturID, @NotaAsal, @KodeRetur, @BarangID, @KodeSales, @QtyMemo, @QtyTarik, @QtyTerima, @QtyGudang, @QtyTolak, @HrgJual, @Pot, @Catatan1, @Catatan2, @SyncFlag, @Kategori, @KodeGudang, @NoACC, @LastUpdatedBy, @LastUpdatedTime
	
	END
	
	CLOSE data_cursor	
	DEALLOCATE data_cursor
			

		
END



 
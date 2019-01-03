USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_PeminjamanDetail]    Script Date: 10/11/2011 13:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nobon
-- Create date: 20 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_PeminjamanDetail '<root><row RowID="EAC208C8-178E-45D5-B381-000513DC6A8A" HeaderID="E1B0B2FA-FE50-42FA-950C-DA8DAECD79B5" TransactionID="C092008112913:31:31DWC" RecordID="C092008112913:32:00DWC" KodeBarang="FE4TRM0069BG" QtyMemo="1" QtyKeluarGudang="1" Catatan="" SyncFlag="1" LastUpdatedTime="2011-03-11T15:15:39.623" LastUpdatedBy="Admin"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_PeminjamanDetail] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @HeaderID UNIQUEIDENTIFIER
	DECLARE @TransactionID VARCHAR(23)
	DECLARE @RecordID VARCHAR(23)
	DECLARE @KodeBarang VARCHAR(23)
	DECLARE @QtyMemo INT
	DECLARE @QtyKeluarGudang INT
	DECLARE @Catatan VARCHAR(25)
	DECLARE @SyncFlag BIT
	DECLARE @LastUpdatedTime DATETIME
	DECLARE @LastUpdatedBy VARCHAR(250)

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- INTerfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	
	DECLARE @Temp TABLE
	(
		RowID UNIQUEIDENTIFIER,
		HeaderID UNIQUEIDENTIFIER,
		TransactionID VARCHAR(23),
		RecordID VARCHAR(23),
		KodeBarang VARCHAR(23),
		QtyMemo INT,
		QtyKeluarGudang INT,
		Catatan VARCHAR(25),
		SyncFlag BIT,
		LastUpdatedTime DATETIME,
		LastUpdatedBy VARCHAR(250)
	)
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc
	INSERT INTO @Temp
	(
		RowID, HeaderID, TransactionID, RecordID, KodeBarang, QtyMemo, QtyKeluarGudang, Catatan, SyncFlag, LastUpdatedTime, LastUpdatedBy
	)
	SELECT 
		RowID, 
		HeaderID, 
		TransactionID, 
		RecordID, 
		KodeBarang, 
		QtyMemo, 
		QtyKeluarGudang, 
		Catatan, 
		SyncFlag, 
		LastUpdatedTime, 
		LastUpdatedBy
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		HeaderID UNIQUEIDENTIFIER '@HeaderID',
		TransactionID VARCHAR(23) '@TransactionID',
		RecordID VARCHAR(23) '@RecordID',
		KodeBarang VARCHAR(23) '@KodeBarang',
		QtyMemo INT '@QtyMemo',
		QtyKeluarGudang INT '@QtyKeluarGudang',
		Catatan VARCHAR(25) '@Catatan',
		SyncFlag BIT '@SyncFlag',
		LastUpdatedTime DATETIME '@LastUpdatedTime',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy'
	)

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID, 
		HeaderID, 
		TransactionID, 
		RecordID, 
		KodeBarang, 
		QtyMemo, 
		QtyKeluarGudang, 
		Catatan, 
		SyncFlag, 
		LastUpdatedTime, 
		LastUpdatedBy
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @HeaderID, @TransactionID, @RecordID, @KodeBarang, @QtyMemo, @QtyKeluarGudang, @Catatan, @SyncFlag, @LastUpdatedTime, @LastUpdatedBy

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.PeminjamanDetail (NOLOCK) WHERE RowID = @RowID)
			UPDATE PeminjamanDetail WITH (ROWLOCK)
			SET
				RowID = @RowID,
				HeaderID = @HeaderID,
				TransactionID = @TransactionID,
				RecordID = @RecordID,
				KodeBarang = @KodeBarang,
				QtyMemo = @QtyMemo,
				QtyKeluarGudang = @QtyKeluarGudang,
				Catatan = @Catatan,
				SyncFlag = @SyncFlag,
				LastUpdatedTime = @LastUpdatedTime,
				LastUpdatedBy = @LastUpdatedBy
			WHERE
				RowID = @RowID
		ELSE
			IF EXISTS (SELECT RowID FROM dbo.Peminjaman (NOLOCK) WHERE RowID=@HeaderID)
			BEGIN 
				INSERT INTO PeminjamanDetail WITH (ROWLOCK)
				(RowID, HeaderID, TransactionID, RecordID, KodeBarang, QtyMemo, QtyKeluarGudang, Catatan, SyncFlag, LastUpdatedTime, LastUpdatedBy)
				VALUES	(
							@RowID,
							@HeaderID,
							@TransactionID,
							@RecordID,
							@KodeBarang,
							@QtyMemo,
							@QtyKeluarGudang,
							@Catatan,
							@SyncFlag,
							@LastUpdatedTime,
							@LastUpdatedBy
						)
			END
		FETCH NEXT FROM data_cursor INTO
		@RowID, @HeaderID, @TransactionID, @RecordID, @KodeBarang, @QtyMemo, @QtyKeluarGudang, @Catatan, @SyncFlag, @LastUpdatedTime, @LastUpdatedBy

	END

	CLOSE data_cursor	
	DEALLOCATE data_cursor
			


END



 
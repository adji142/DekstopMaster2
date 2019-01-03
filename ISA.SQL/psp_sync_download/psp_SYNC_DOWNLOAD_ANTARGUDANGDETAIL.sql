USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_AntarGudangDetail]    Script Date: 10/11/2011 13:46:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Nobon
-- Create date: 20 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_AntarGudangDetail '<root><row RowID="606EA5D2-91D5-46A6-84AA-0001249B2C46" HeaderID="AFE282E0-7AFA-4BB4-91F5-2ABFD528D189" RecordID="C092006091213:15:01XXX" TransactionID="C092006091213:14:37XXX" KodeBarang="FB4BMCA105AI" QtyKirim="10" QtyTerima="10" Catatan="" Ongkos="0" SyncFlag="1" QtyDO="0" LastUpdatedTime="2011-05-16T15:06:15.140" LastUpdatedBy="Admin"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_AntarGudangDetail] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @HeaderID UNIQUEIDENTIFIER
	DECLARE @RecordID VARCHAR(23)
	DECLARE @TransactionID VARCHAR(23)
	DECLARE @KodeBarang VARCHAR(23)
	DECLARE @QtyKirim INT
	DECLARE @QtyTerima INT
	DECLARE @Catatan VARCHAR(20)
	DECLARE @Ongkos INT
	DECLARE @SyncFlag BIT
	DECLARE @QtyDO INT
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
		RecordID VARCHAR(23),
		TransactionID VARCHAR(23),
		KodeBarang VARCHAR(23),
		QtyKirim INT,
		QtyTerima INT,
		Catatan VARCHAR(20),
		Ongkos INT,
		SyncFlag BIT,
		QtyDO INT,
		LastUpdatedTime DATETIME,
		LastUpdatedBy VARCHAR(250)
	)

		exec sp_xml_preparedocument @hdoc OUTPUT, @doc
	
	INSERT INTO @Temp
	(
		RowID, HeaderID, RecordID, TransactionID, KodeBarang, QtyKirim, QtyTerima, Catatan, Ongkos, SyncFlag, QtyDO, LastUpdatedTime, LastUpdatedBy
	)
	SELECT 
		RowID, 
		HeaderID,
		RecordID, 
		TransactionID, 
		KodeBarang, 
		QtyKirim, 
		QtyTerima, 
		Catatan, 
		Ongkos, 
		SyncFlag, 
		QtyDO, 
		LastUpdatedTime, 
		LastUpdatedBy
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		HeaderID UNIQUEIDENTIFIER '@HeaderID',
		RecordID VARCHAR(23) '@RecordID',
		TransactionID VARCHAR(23) '@TransactionID',
		KodeBarang VARCHAR(23) '@KodeBarang',
		QtyKirim INT '@QtyKirim',
		QtyTerima INT '@QtyTerima',
		Catatan VARCHAR(20) '@Catatan',
		Ongkos INT '@Ongkos',
		SyncFlag BIT '@SyncFlag',
		QtyDO INT '@QtyDO',
		LastUpdatedTime DATETIME '@LastUpdatedTime',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy'
	)

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID, 
		HeaderID,
		RecordID, 
		TransactionID, 
		KodeBarang, 
		QtyKirim, 
		QtyTerima, 
		Catatan, 
		Ongkos, 
		SyncFlag, 
		QtyDO, 
		LastUpdatedTime, 
		LastUpdatedBy
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
	@RowID, @HeaderID, @RecordID, @TransactionID, @KodeBarang, @QtyKirim, @QtyTerima, @Catatan, @Ongkos, @SyncFlag, @QtyDO, @LastUpdatedTime, @LastUpdatedBy
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.AntarGudangDetail (NOLOCK) WHERE RowID = @RowID)
			UPDATE AntarGudangDetail WITH (ROWLOCK)
			SET
				RowID = @RowID,
				HeaderID = @HeaderID,
				RecordID = @RecordID,
				TransactionID = @TransactionID,
				KodeBarang = @KodeBarang,
				QtyKirim = @QtyKirim,
				QtyTerima = @QtyTerima,
				Catatan = @Catatan,
				Ongkos = @Ongkos,
				SyncFlag = @SyncFlag,
				QtyDO = @QtyDO,
				LastUpdatedTime = @LastUpdatedTime,
				LastUpdatedBy = @LastUpdatedBy
			WHERE
				RowID = @RowID
		ELSE
			IF EXISTS (SELECT RowID FROM dbo.AntarGudang (NOLOCK) WHERE RowID = @HeaderID)
			BEGIN
				INSERT INTO AntarGudangDetail WITH (ROWLOCK)
				(RowID, HeaderID, RecordID, TransactionID, KodeBarang, QtyKirim, QtyTerima, Catatan, Ongkos, SyncFlag, QtyDO, LastUpdatedTime, LastUpdatedBy)
				VALUES	(
							@RowID,
							@HeaderID,
							@RecordID,
							@TransactionID,
							@KodeBarang,
							@QtyKirim,
							@QtyTerima,
							@Catatan,
							@Ongkos,
							@SyncFlag,
							@QtyDO,
							@LastUpdatedTime,
							@LastUpdatedBy
						)
			END
		FETCH NEXT FROM data_cursor  INTO
		@RowID, @HeaderID, @RecordID, @TransactionID, @KodeBarang, @QtyKirim, @QtyTerima, @Catatan, @Ongkos, @SyncFlag, @QtyDO, @LastUpdatedTime, @LastUpdatedBy
		
	END	
	CLOSE data_cursor	
	DEALLOCATE data_cursor
			


END





 
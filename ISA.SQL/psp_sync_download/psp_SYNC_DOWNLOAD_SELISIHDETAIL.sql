 USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_SelisihDetail]    Script Date: 10/11/2011 13:49:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Nobon
-- Create date: 23 May 2011
-- Description:	<Description,,>
-- exec dbo.psp_SYNC_DOWNLOAD_SelisihDetail '<root><row RowID="063C35C5-F494-458A-B3BF-00199CD4A200" HeaderID="6812A6C8-1C35-45E7-8DA4-CC0C8321A230" RecordID="CRB2006071513:36:03MOE" TransactionID="CRB2006071513:31:45MOE" KodeBarang="FB4FOKG004SS" QtyComp="161" QtyOpname="276" Catatan="OPN SALAH WARNA" SyncFlag="1" LastUpdatedTime="2011-03-21T09:39:37.747" LastUpdatedBy="Admin"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_SelisihDetail]
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
	DECLARE @QtyComp INT
	DECLARE @QtyOpname INT
	DECLARE @Catatan VARCHAR(30)
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
		RecordID VARCHAR(23),
		TransactionID VARCHAR(23),
		KodeBarang VARCHAR(23),
		QtyComp INT,
		QtyOpname INT,
		Catatan VARCHAR(30),
		SyncFlag BIT,
		LastUpdatedTime DATETIME,
		LastUpdatedBy VARCHAR(250)
	)
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc

	INSERT INTO @Temp
	(
		RowID, HeaderID, RecordID, TransactionID, KodeBarang, QtyComp, QtyOpname, Catatan, SyncFlag, LastUpdatedTime, LastUpdatedBy
	)
	SELECT 
		RowID, 
		HeaderID, 
		RecordID, 
		TransactionID, 
		KodeBarang, 
		QtyComp, 
		QtyOpname, 
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
		RecordID VARCHAR(23) '@RecordID',
		TransactionID VARCHAR(23) '@TransactionID',
		KodeBarang VARCHAR(23) '@KodeBarang',
		QtyComp INT '@QtyComp',
		QtyOpname INT '@QtyOpname',
		Catatan VARCHAR(30) '@Catatan',
		SyncFlag BIT '@SyncFlag',
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
		QtyComp, 
		QtyOpname, 
		Catatan, 
		SyncFlag, 
		LastUpdatedTime, 
		LastUpdatedBy
	FROM @Temp
	
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @HeaderID, @RecordID, @TransactionID, @KodeBarang, @QtyComp, @QtyOpname, @Catatan, @SyncFlag, @LastUpdatedTime, @LastUpdatedBy

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.SelisihDetail (NOLOCK) WHERE RowID = @RowID)
			UPDATE SelisihDetail WITH (ROWLOCK)
			SET
				RowID = @RowID,
				HeaderID = @HeaderID,
				RecordID = @RecordID,
				TransactionID = @TransactionID,
				KodeBarang = @KodeBarang,
				QtyComp = @QtyComp,
				QtyOpname = @QtyOpname,
				Catatan = @Catatan,
				SyncFlag = @SyncFlag,
				LastUpdatedTime = @LastUpdatedTime,
				LastUpdatedBy = @LastUpdatedBy
			WHERE
				RowID = @RowID
		ELSE
			IF EXISTS (SELECT RowID FROM dbo.Selisih (NOLOCK) WHERE RowID=@HeaderID)
			BEGIN
				INSERT INTO SelisihDetail WITH (ROWLOCK)
				(RowID, HeaderID, RecordID, TransactionID, KodeBarang, QtyComp, QtyOpname, Catatan, SyncFlag, LastUpdatedTime, LastUpdatedBy)
					VALUES	(
								@RowID,
								@HeaderID,
								@RecordID,
								@TransactionID,
								@KodeBarang,
								@QtyComp,
								@QtyOpname,
								@Catatan,
								@SyncFlag,
								@LastUpdatedTime,
								@LastUpdatedBy
							)
			END
		FETCH NEXT FROM data_cursor INTO
		@RowID, @HeaderID, @RecordID, @TransactionID, @KodeBarang, @QtyComp, @QtyOpname, @Catatan, @SyncFlag, @LastUpdatedTime, @LastUpdatedBy

	END
	
	CLOSE data_cursor	
	DEALLOCATE data_cursor

END



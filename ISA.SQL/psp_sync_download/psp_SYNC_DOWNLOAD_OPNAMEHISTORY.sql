 USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_OpnameHistory]    Script Date: 10/11/2011 13:47:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Nobon
-- Create date: 20 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_Opname '<root><row RowID="EA24EA50-1ECD-4AAF-ABA0-C2A9D35CD299" RecordID="SAS2004062510:37:21MAN" KodeBarang="FA0GEMU112DZ" SyncFlag="0" TglStok="2010-02-01T00:00:00" TglProses="2011-04-06T00:00:00" QtyAwal="-48" LinkID="0" Flag="1" Flag2="1" LastUpdatedBy="Admin" LastUpdatedTime="2011-03-30T09:20:36.780"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_OpnameHistory] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @RecordID varchar(23) 
	DECLARE @TglOpname datetime
	DECLARE @QtyOpname int
	DECLARE @KodeBarang varchar(23)
	DECLARE @KodeGudang varchar(4)
	DECLARE @Keterangan varchar(50)
	DECLARE @SyncFlag bit	
	DECLARE @LastUpdatedBy VARCHAR(250)
	DECLARE @LastUpdatedTime DATETIME

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- INTerfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	
	DECLARE	@Temp TABLE
	(
		RowID UNIQUEIDENTIFIER,
		RecordID varchar(23),
		TglOpname datetime,
		QtyOpname int,
		KodeBarang varchar(23),
		KodeGudang varchar(4),
		Keterangan varchar(50),
		SyncFlag bit,
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc
	INSERT INTO	@Temp
	(
		RowID, RecordID, TglOpname, QtyOpname, KodeBarang, KodeGudang, Keterangan, SyncFlag, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		RecordID, 
		TglOpname, 
		QtyOpname, 
		KodeBarang, 
		KodeGudang, 
		Keterangan, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		RecordID VARCHAR(23) '@RecordID',
		TglOpname datetime '@TglOpname',
		QtyOpname int '@QtyOpname',
		KodeBarang varchar(23) '@KodeBarang',
		KodeGudang varchar(4) '@KodeGudang',
		Keterangan varchar(50) '@Keterangan',
		SyncFlag bit '@SyncFlag',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy',
		LastUpdatedTime DATETIME '@LastUpdatedTime'
	)

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID, 
		RecordID, 
		TglOpname, 
		QtyOpname, 
		KodeBarang, 
		KodeGudang, 
		Keterangan, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @RecordID, @TglOpname, @QtyOpname, @KodeBarang, @KodeGudang, @Keterangan, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.Opname (NOLOCK) WHERE RowID = @RowID)
			UPDATE dbo.OpnameHistory WITH (ROWLOCK)
			SET
				RecordID = @RecordID, 
				TglOpname = @TglOpname, 
				QtyOpname = @QtyOpname, 
				KodeBarang = @KodeBarang, 
				KodeGudang = @KodeGudang, 
				Keterangan = @Keterangan, 
				SyncFlag = @SyncFlag, 
				LastUpdatedBy = @LastUpdatedBy, 
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			INSERT INTO dbo.OpnameHistory WITH (ROWLOCK)
			(RowID, RecordID, TglOpname, QtyOpname, KodeBarang, KodeGudang, Keterangan, SyncFlag, LastUpdatedBy, LastUpdatedTime)
			VALUES	(
						@RowID, 
						@RecordID, 
						@TglOpname, 
						@QtyOpname, 
						@KodeBarang, 
						@KodeGudang, 
						@Keterangan, 
						@SyncFlag, 
						@LastUpdatedBy, 
						@LastUpdatedTime
					)
		FETCH NEXT FROM data_cursor INTO
		@RowID, @RecordID, @TglOpname, @QtyOpname, @KodeBarang, @KodeGudang, @Keterangan, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	END

	CLOSE data_cursor	
	DEALLOCATE data_cursor
			


END





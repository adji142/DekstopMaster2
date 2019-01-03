USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_RekapKoliSubDetail]    Script Date: 10/11/2011 13:48:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nobon
-- Create date: 23 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_RekapKoliSubDetail '<root><row RowID="A2DF3616-32E2-460D-8C68-5B623870381B" HeaderID="A7A79726-0724-456D-B943-F6FC07B7D7B7" RecordID="2002041123:28:16NOE" HtrID="2002041123:28:08NOE" Uraian="OND" Jumlah="5" Satuan="KOLI" Keterangan="" SyncFlag="1" LastUpdatedBy="Admin" LastUpdatedTime="2011-01-25T15:17:38.750"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_RekapKoliSubDetail] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @HeaderID UNIQUEIDENTIFIER
	DECLARE @RecordID VARCHAR(23)
	DECLARE @HtrID VARCHAR(23)
	DECLARE @Uraian VARCHAR(12)
	DECLARE @Jumlah INT
	DECLARE @Satuan VARCHAR(5)
	DECLARE @Keterangan VARCHAR(30)
	DECLARE @SyncFlag BIT
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
		HtrID VARCHAR(23),
		Uraian VARCHAR(12),
		Jumlah INT,
		Satuan VARCHAR(5),
		Keterangan VARCHAR(30),
		SyncFlag BIT,
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)
	
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc
	
	INSERT INTO @Temp
	(
		RowID, HeaderID, RecordID, HtrID, Uraian, Jumlah, Satuan, Keterangan, SyncFlag, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		HeaderID, 
		RecordID, 
		HtrID, 
		Uraian, 
		Jumlah, 
		Satuan, 
		Keterangan, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		HeaderID UNIQUEIDENTIFIER '@HeaderID',
		RecordID VARCHAR(23) '@RecordID',
		HtrID VARCHAR(23) '@HtrID',
		Uraian VARCHAR(12) '@Uraian',
		Jumlah INT '@Jumlah',
		Satuan VARCHAR(5) '@Satuan',
		Keterangan VARCHAR(30) '@Keterangan',
		SyncFlag BIT '@SyncFlag',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy',
		LastUpdatedTime DATETIME '@LastUpdatedTime'
	)

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID, 
		HeaderID, 
		RecordID, 
		HtrID, 
		Uraian, 
		Jumlah, 
		Satuan, 
		Keterangan, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @HeaderID, @RecordID, @HtrID, @Uraian, @Jumlah, @Satuan, @Keterangan, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.RekapKoliSubDetail (NOLOCK) WHERE RowID = @RowID)
			UPDATE RekapKoliSubDetail WITH (ROWLOCK)
			SET
				RowID = @RowID,
				HeaderID = @HeaderID,
				RecordID = @RecordID,
				HtrID = @HtrID,
				Uraian = @Uraian,
				Jumlah = @Jumlah,
				Satuan = @Satuan,
				Keterangan = @Keterangan,
				SyncFlag = @SyncFlag,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			IF EXISTS (SELECT RowID FROM dbo.RekapKoliDetail (NOLOCK) WHERE RowID=@HeaderID)
			BEGIN 
				INSERT INTO RekapKoliSubDetail WITH (ROWLOCK)
				(RowID, HeaderID, RecordID, HtrID, Uraian, Jumlah, Satuan, Keterangan, SyncFlag, LastUpdatedBy, LastUpdatedTime)
					VALUES	(
								@RowID,
								@HeaderID,
								@RecordID,
								@HtrID,
								@Uraian,
								@Jumlah,
								@Satuan,
								@Keterangan,
								@SyncFlag,
								@LastUpdatedBy,
								@LastUpdatedTime
						)
			END
		FETCH NEXT FROM data_cursor INTO
		@RowID, @HeaderID, @RecordID, @HtrID, @Uraian, @Jumlah, @Satuan, @Keterangan, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	END

	CLOSE data_cursor	
	DEALLOCATE data_cursor
			


END



 
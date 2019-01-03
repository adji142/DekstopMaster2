USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_Kompensasi]    Script Date: 10/11/2011 13:46:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Nobon
-- Create date: 20 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_Kompensasi ''
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_Kompensasi] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID uniqueidentifier
	DECLARE @RecordID varchar(23)
	DECLARE @DiscKompensasi decimal(5, 2)
	DECLARE @SyncFlag bit
	DECLARE @LastUpdatedBy varchar(250)
	DECLARE @LastUpdatedTime datetime

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- INTerfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	
	DECLARE @Temp TABLE
	(
		RowID uniqueidentifier,
		RecordID varchar(23),
		DiscKompensasi decimal(5, 2),
		SyncFlag bit,
		LastUpdatedBy varchar(250),
		LastUpdatedTime datetime
	)
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc
	
	INSERT INTO @Temp
	(
		RowID, RecordID, DiscKompensasi, SyncFlag, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		RecordID,	
		DiscKompensasi, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID uniqueidentifier' @RowID',
		RecordID varchar(23) '@RecordID',
		DiscKompensasi decimal(5, 2) '@DiscKompensasi',
		SyncFlag bit '@SyncFlag',
		LastUpdatedBy varchar(250) '@LastUpdatedBy',
		LastUpdatedTime datetime '@LastUpdatedTime'
	)

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID, 
		RecordID,	
		DiscKompensasi, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @RecordID, @DiscKompensasi, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	WHILE @@FETCH_STATUS = 0
	BEGIN
		   -- Insert statements for procedure here
		 SET @SyncFlag = 1  
		   
		IF EXISTS (SELECT RowID FROM dbo.Kompensasi (NOLOCK) WHERE RowID = @RowID)
			UPDATE Kompensasi WITH (ROWLOCK)
			SET
				RowID = @RowID,
				RecordID = @RecordID,
				DiscKompensasi = @DiscKompensasi,
				SyncFlag = @SyncFlag,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			INSERT INTO Kompensasi WITH (ROWLOCK)
			(RowID, RecordID, DiscKompensasi, SyncFlag, LastUpdatedBy, LastUpdatedTime)
			VALUES	(
						@RowID,
						@RecordID,
						@DiscKompensasi,
						@SyncFlag,
						@LastUpdatedBy,
						@LastUpdatedTime
					)

		FETCH NEXT FROM data_cursor INTO
		@RowID, @RecordID, @DiscKompensasi, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	END
	
	CLOSE data_cursor	
	DEALLOCATE data_cursor
			

END




 
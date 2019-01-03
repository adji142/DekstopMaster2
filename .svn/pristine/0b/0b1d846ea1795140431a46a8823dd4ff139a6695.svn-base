USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_Opname]    Script Date: 10/11/2011 13:47:32 ******/
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
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_Opname] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @RecordID VARCHAR(23)
	DECLARE @KodeBarang VARCHAR(23)
	DECLARE @SyncFlag BIT
	DECLARE @TglStok DATETIME
	DECLARE @TglProses DATETIME
	DECLARE @QtyAwal INT
	DECLARE @LinkID BIT
	DECLARE @TglTransfer DATETIME
	DECLARE @Flag VARCHAR(1)
	DECLARE @Flag2 VARCHAR(1)
	DECLARE @LastUpdatedBy VARCHAR(250)
	DECLARE @LastUpdatedTime DATETIME

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- INTerfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	
	DECLARE @Temp TABLE
	(
		RowID UNIQUEIDENTIFIER,
		RecordID VARCHAR(23),
		KodeBarang VARCHAR(23),
		SyncFlag BIT,
		TglStok DATETIME,
		TglProses DATETIME,
		QtyAwal INT,
		LinkID BIT,
		TglTransfer DATETIME,
		Flag VARCHAR(1),
		Flag2 VARCHAR(1),
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)

		exec sp_xml_preparedocument @hdoc OUTPUT, @doc

	INSERT INTO @Temp
	(
		RowID, RecordID, KodeBarang, SyncFlag, TglStok, TglProses, QtyAwal, LinkID, TglTransfer, Flag, Flag2, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		RecordID, 
		KodeBarang, 
		SyncFlag, 
		TglStok, 
		TglProses, 
		QtyAwal, 
		LinkID, 
		TglTransfer, 
		Flag, 
		Flag2, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		RecordID VARCHAR(23) '@RecordID',
		KodeBarang VARCHAR(23) '@KodeBarang',
		SyncFlag BIT '@SyncFlag',
		TglStok DATETIME '@TglStok',
		TglProses DATETIME '@TglProses',
		QtyAwal INT '@QtyAwal',
		LinkID BIT '@LinkID',
		TglTransfer DATETIME '@TglTransfer',
		Flag VARCHAR(1) '@Flag',
		Flag2 VARCHAR(1) '@Flag2',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy',
		LastUpdatedTime DATETIME '@LastUpdatedTime'
	)

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID, 
		RecordID, 
		KodeBarang, 
		SyncFlag, 
		TglStok, 
		TglProses, 
		QtyAwal, 
		LinkID, 
		TglTransfer, 
		Flag, 
		Flag2, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @RecordID, @KodeBarang, @SyncFlag, @TglStok, @TglProses, @QtyAwal, @LinkID, @TglTransfer, @Flag, @Flag2, @LastUpdatedBy, @LastUpdatedTime

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.Opname WHERE RowID = @RowID)
			UPDATE Opname
			SET
				RowID = @RowID,
				RecordID = @RecordID,
				KodeBarang = @KodeBarang,
				SyncFlag = @SyncFlag,
				TglStok = @TglStok,
				TglProses = @TglProses,
				QtyAwal = @QtyAwal,
				LinkID = @LinkID,
				TglTransfer = @TglTransfer,
				Flag = @Flag,
				Flag2 = @Flag2,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			INSERT INTO Opname
			VALUES	(
						@RowID,
						@RecordID,
						@KodeBarang,
						@SyncFlag,
						@TglStok,
						@TglProses,
						@QtyAwal,
						@LinkID,
						@TglTransfer,
						@Flag,
						@Flag2,
						@LastUpdatedBy,
						@LastUpdatedTime
					)
		FETCH NEXT FROM data_cursor INTO
		@RowID, @RecordID, @KodeBarang, @SyncFlag, @TglStok, @TglProses, @QtyAwal, @LinkID, @TglTransfer, @Flag, @Flag2, @LastUpdatedBy, @LastUpdatedTime

	END

	CLOSE data_cursor	
	DEALLOCATE data_cursor
			

END


 
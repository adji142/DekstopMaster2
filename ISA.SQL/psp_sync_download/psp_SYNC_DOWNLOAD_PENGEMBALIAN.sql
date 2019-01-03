USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_Pengembalian]    Script Date: 10/11/2011 13:48:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nobon
-- Create date: 20 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_Pengembalian '<root><row RowID="A2337D11-6E30-4DCC-90A2-000A525D4057" RecordID="C092006091911:24:18FER" NoBukti="0000483" TglKembaliPj="2006-09-19T00:00:00" TglKembaliGdg="2006-09-22T00:00:00" Catatan="KEMBALI" NPrint="1" SyncFlag="1" KodeSales="09-095-WIW" LastUpdatedBy="Admin" LastUpdatedTime="2011-03-11T15:15:58.513"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_Pengembalian] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @RecordID VARCHAR(23)
	DECLARE @NoBukti VARCHAR(10)
	DECLARE @TglKembaliPj DATETIME
	DECLARE @TglKembaliGdg DATETIME
	DECLARE @Catatan VARCHAR(25)
	DECLARE @NPrint INT
	DECLARE @SyncFlag BIT
	DECLARE @KodeSales VARCHAR(11)
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
		NoBukti VARCHAR(10),
		TglKembaliPj DATETIME,
		TglKembaliGdg DATETIME,
		Catatan VARCHAR(25),
		NPrint INT,
		SyncFlag BIT,
		KodeSales VARCHAR(11),
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)

		exec sp_xml_preparedocument @hdoc OUTPUT, @doc

	INSERT INTO	@Temp
	(
		RowID, RecordID, NoBukti, TglKembaliPj, TglKembaliGdg, Catatan, NPrint, SyncFlag, KodeSales, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		RecordID, 
		NoBukti, 
		TglKembaliPj, 
		TglKembaliGdg, 
		Catatan,	
		NPrint, 
		SyncFlag, 
		KodeSales, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		RecordID VARCHAR(23) '@RecordID',
		NoBukti VARCHAR(10) '@NoBukti',
		TglKembaliPj DATETIME '@TglKembaliPj',
		TglKembaliGdg DATETIME '@TglKembaliGdg',
		Catatan VARCHAR(25) '@Catatan',
		NPrint INT '@NPrint',
		SyncFlag BIT '@SyncFlag',
		KodeSales VARCHAR(11) '@KodeSales',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy',
		LastUpdatedTime DATETIME '@LastUpdatedTime'
	)

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID, 
		RecordID, 
		NoBukti, 
		TglKembaliPj, 
		TglKembaliGdg, 
		Catatan,	
		NPrint, 
		SyncFlag, 
		KodeSales, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @RecordID, @NoBukti, @TglKembaliPj, @TglKembaliGdg, @Catatan, @NPrint, @SyncFlag, @KodeSales, @LastUpdatedBy, @LastUpdatedTime

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.Pengembalian (NOLOCK) WHERE RowID = @RowID)
			UPDATE Pengembalian WITH (ROWLOCK)
			SET
				RowID = @RowID,
				RecordID = @RecordID,
				NoBukti = @NoBukti,
				TglKembaliPj = @TglKembaliPj,
				TglKembaliGdg = @TglKembaliGdg,
				Catatan = @Catatan,
				NPrint = @NPrint,
				SyncFlag = @SyncFlag,
				KodeSales = @KodeSales,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			INSERT INTO Pengembalian WITH (ROWLOCK)
			(RowID, RecordID, NoBukti, TglKembaliPj, TglKembaliGdg, Catatan, NPrint, SyncFlag, KodeSales, LastUpdatedBy, LastUpdatedTime)
			VALUES	(
						@RowID,
						@RecordID,
						@NoBukti,
						@TglKembaliPj,
						@TglKembaliGdg,
						@Catatan,
						@NPrint,
						@SyncFlag,
						@KodeSales,
						@LastUpdatedBy,
						@LastUpdatedTime
					)
		FETCH NEXT FROM data_cursor INTO
		@RowID, @RecordID, @NoBukti, @TglKembaliPj, @TglKembaliGdg, @Catatan, @NPrint, @SyncFlag, @KodeSales, @LastUpdatedBy, @LastUpdatedTime

	END

	CLOSE data_cursor	
	DEALLOCATE data_cursor
			


END



 
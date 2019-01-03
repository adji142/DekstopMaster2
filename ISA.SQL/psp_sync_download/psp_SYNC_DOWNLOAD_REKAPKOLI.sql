USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_RekapKoli]    Script Date: 10/11/2011 13:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nobon
-- Create date: 23 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_RekapKoli '<root><row RowID="F30D7C08-0B2D-4E8A-8E18-900DAE6B7875" RecordID="CRB2007010208:43:12PDC" TglSuratJalan="1967-12-30T00:00:00" NoSuratJalan="A066533" KodeToko="2000101010:04:12" TglKeluar="2006-12-30T00:00:00" KodeExp1="SAS" KodeExp2="" KodeExp3="" Shift="1" BiayaExp1="0.0000" BiayaExp2="0.0000" BiayaExp3="0.0000" NPrint="0" KP="KP!" SyncFlag="1" LastUpdatedBy="Admin" LastUpdatedTime="2011-01-25T15:00:21.633"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_RekapKoli] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @RecordID VARCHAR(23)
	DECLARE @TglSuratJalan DATETIME
	DECLARE @NoSuratJalan VARCHAR(7)
	DECLARE @KodeToko VARCHAR(19)
	DECLARE @TglKeluar DATETIME
	DECLARE @KodeExp1 VARCHAR(3)
	DECLARE @KodeExp2 VARCHAR(3)
	DECLARE @KodeExp3 VARCHAR(3)
	DECLARE @Shift INT
	DECLARE @BiayaExp1 MONEY
	DECLARE @BiayaExp2 MONEY
	DECLARE @BiayaExp3 MONEY
	DECLARE @NPrint INT
	DECLARE @KP VARCHAR(3)
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
		RecordID VARCHAR(23),
		TglSuratJalan DATETIME,
		NoSuratJalan VARCHAR(7),
		KodeToko VARCHAR(19),
		TglKeluar DATETIME,
		KodeExp1 VARCHAR(3),
		KodeExp2 VARCHAR(3),
		KodeExp3 VARCHAR(3),
		Shift INT,
		BiayaExp1 MONEY,
		BiayaExp2 MONEY,
		BiayaExp3 MONEY,
		NPrint INT,
		KP VARCHAR(3),
		SyncFlag BIT,
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)

		exec sp_xml_preparedocument @hdoc OUTPUT, @doc

	INSERT INTO	@Temp
	(
		RowID, RecordID, TglSuratJalan, NoSuratJalan, KodeToko, TglKeluar, KodeExp1, KodeExp2, KodeExp3, Shift, BiayaExp1, BiayaExp2, BiayaExp3, NPrint, KP, SyncFlag, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		RecordID, 
		TglSuratJalan, 
		NoSuratJalan, 
		KodeToko, 
		TglKeluar, 
		KodeExp1, 
		KodeExp2, 
		KodeExp3, 
		Shift,	
		BiayaExp1, 
		BiayaExp2, 
		BiayaExp3, 
		NPrint, 
		KP, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		RecordID VARCHAR(23) '@RecordID',
		TglSuratJalan DATETIME '@TglSuratJalan',
		NoSuratJalan VARCHAR(7) '@NoSuratJalan',
		KodeToko VARCHAR(19) '@KodeToko',
		TglKeluar DATETIME '@TglKeluar',
		KodeExp1 VARCHAR(3) '@KodeExp1',
		KodeExp2 VARCHAR(3) '@KodeExp2',
		KodeExp3 VARCHAR(3) '@KodeExp3',
		Shift INT '@Shift',
		BiayaExp1 MONEY '@BiayaExp1',
		BiayaExp2 MONEY '@BiayaExp2',
		BiayaExp3 MONEY '@BiayaExp3',
		NPrint INT '@NPrint',
		KP VARCHAR(3) '@KP',
		SyncFlag BIT '@SyncFlag',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy',
		LastUpdatedTime DATETIME '@LastUpdatedTime'
	)

	exec sp_xml_removedocument @hdoc


	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID, 
		RecordID, 
		TglSuratJalan, 
		NoSuratJalan, 
		KodeToko, 
		TglKeluar, 
		KodeExp1, 
		KodeExp2, 
		KodeExp3, 
		Shift,	
		BiayaExp1, 
		BiayaExp2, 
		BiayaExp3, 
		NPrint, 
		KP, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @RecordID, @TglSuratJalan, @NoSuratJalan, @KodeToko, @TglKeluar, @KodeExp1, @KodeExp2, @KodeExp3, @Shift, @BiayaExp1, @BiayaExp2, @BiayaExp3, @NPrint, @KP, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime	

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.RekapKoli (NOLOCK) WHERE RowID = @RowID)
			UPDATE RekapKoli WITH (ROWLOCK)
			SET
				RowID = @RowID,
				RecordID = @RecordID,
				TglSuratJalan = @TglSuratJalan,
				NoSuratJalan = @NoSuratJalan,
				KodeToko = @KodeToko,
				TglKeluar = @TglKeluar,
				KodeExp1 = @KodeExp1,
				KodeExp2 = @KodeExp2,
				KodeExp3 = @KodeExp3,
				Shift = @Shift,
				BiayaExp1 = @BiayaExp1,
				BiayaExp2 = @BiayaExp2,
				BiayaExp3 = @BiayaExp3,
				NPrint = @NPrint,
				KP = @KP,
				SyncFlag = @SyncFlag,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			INSERT INTO RekapKoli WITH (ROWLOCK)
			(RowID, RecordID, TglSuratJalan, NoSuratJalan, KodeToko, TglKeluar, KodeExp1, KodeExp2, KodeExp3, Shift, BiayaExp1, BiayaExp2, BiayaExp3, NPrint, KP, SyncFlag, LastUpdatedBy, LastUpdatedTime)
				VALUES	(
							@RowID,
							@RecordID,
							@TglSuratJalan,
							@NoSuratJalan,
							@KodeToko,
							@TglKeluar,
							@KodeExp1,
							@KodeExp2,
							@KodeExp3,
							@Shift,
							@BiayaExp1,
							@BiayaExp2,
							@BiayaExp3,
							@NPrint,
							@KP,
							@SyncFlag,
							@LastUpdatedBy,
							@LastUpdatedTime
					)
		FETCH NEXT FROM data_cursor INTO
		@RowID, @RecordID, @TglSuratJalan, @NoSuratJalan, @KodeToko, @TglKeluar, @KodeExp1, @KodeExp2, @KodeExp3, @Shift, @BiayaExp1, @BiayaExp2, @BiayaExp3, @NPrint, @KP, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime	

	END

	CLOSE data_cursor	
	DEALLOCATE data_cursor
			

END



 
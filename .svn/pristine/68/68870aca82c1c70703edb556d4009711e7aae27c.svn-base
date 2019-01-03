 USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_Selisih]    Script Date: 10/11/2011 13:49:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Nobon
-- Create date: 23 May 2011
-- Description:	<Description,,>
-- exec dbo.psp_SYNC_DOWNLOAD_Selisih '<root><row RowID="C072A17F-2707-46E8-B7CB-B12AABE1DA6F" RecordID="C092004012711:57:51LIA" KodeGudang="0901" TglSelisih="2004-01-19T00:00:00" NoSelisih="0000001" Keterangan="SALDO OPNM 19/01/04" Pemeriksa1="HENRY" Pemeriksa2="LIANA" SyncFlag="1" LastUpdatedTime="2011-03-21T09:20:28.030" LastUpdatedBy="Admin"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_Selisih]
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @RecordID VARCHAR(23)
	DECLARE @KodeGudang VARCHAR(4)
	DECLARE @TglSelisih DATETIME
	DECLARE @NoSelisih VARCHAR(11)
	DECLARE @Cabang VARCHAR(2)
	DECLARE @Keterangan VARCHAR(30)
	DECLARE @Pemeriksa1 VARCHAR(10)
	DECLARE @Pemeriksa2 VARCHAR(10)
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
		RecordID VARCHAR(23),
		KodeGudang VARCHAR(4),
		TglSelisih DATETIME,
		NoSelisih VARCHAR(11),
		Cabang VARCHAR(2),
		Keterangan VARCHAR(30),
		Pemeriksa1 VARCHAR(10),
		Pemeriksa2 VARCHAR(10),
		SyncFlag BIT,
		LastUpdatedTime DATETIME,
		LastUpdatedBy VARCHAR(250)
	)
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc

	INSERT INTO @Temp
	(
		RowID, RecordID, KodeGudang, TglSelisih, NoSelisih, Cabang, Keterangan, Pemeriksa1, Pemeriksa2, SyncFlag, LastUpdatedTime, LastUpdatedBy
	)
	SELECT 
		RowID, 
		RecordID, 
		KodeGudang, 
		TglSelisih, 
		NoSelisih, 
		Cabang, 
		Keterangan, 
		Pemeriksa1, 
		Pemeriksa2, 
		SyncFlag, 
		LastUpdatedTime, 
		LastUpdatedBy
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		RecordID VARCHAR(23) '@RecordID',
		KodeGudang VARCHAR(4) '@KodeGudang',
		TglSelisih DATETIME '@TglSelisih',
		NoSelisih VARCHAR(11) '@NoSelisih',
		Cabang VARCHAR(2) '@Cabang',
		Keterangan VARCHAR(30) '@Keterangan',
		Pemeriksa1 VARCHAR(10) '@Pemeriksa1',
		Pemeriksa2 VARCHAR(10) '@Pemeriksa2',
		SyncFlag BIT '@SyncFlag',
		LastUpdatedTime DATETIME '@LastUpdatedTime',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy'
	)

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID, 
		RecordID, 
		KodeGudang, 
		TglSelisih, 
		NoSelisih, 
		Cabang, 
		Keterangan, 
		Pemeriksa1, 
		Pemeriksa2, 
		SyncFlag, 
		LastUpdatedTime, 
		LastUpdatedBy
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @RecordID, @KodeGudang, @TglSelisih, @NoSelisih, @Cabang, @Keterangan, @Pemeriksa1, @Pemeriksa2, @SyncFlag, @LastUpdatedTime, @LastUpdatedBy

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.Selisih (NOLOCK) WHERE RowID = @RowID)
			UPDATE Selisih WITH (ROWLOCK)
			SET
				RowID = @RowID,
				RecordID = @RecordID,
				KodeGudang = @KodeGudang,
				TglSelisih = @TglSelisih,
				NoSelisih = @NoSelisih,
				Cabang = @Cabang,
				Keterangan = @Keterangan,
				Pemeriksa1 = @Pemeriksa1,
				Pemeriksa2 = @Pemeriksa2,
				SyncFlag = @SyncFlag,
				LastUpdatedTime = @LastUpdatedTime,
				LastUpdatedBy = @LastUpdatedBy
			WHERE
				RowID = @RowID
		ELSE
			INSERT INTO Selisih WITH (ROWLOCK)
			(RowID, RecordID, KodeGudang, TglSelisih, NoSelisih, Cabang, Keterangan, Pemeriksa1, Pemeriksa2, SyncFlag, LastUpdatedTime, LastUpdatedBy)
				VALUES	(
							@RowID,
							@RecordID,
							@KodeGudang,
							@TglSelisih,
							@NoSelisih,
							@Cabang,
							@Keterangan,
							@Pemeriksa1,
							@Pemeriksa2,
							@SyncFlag,
							@LastUpdatedTime,
							@LastUpdatedBy
						)
		FETCH NEXT FROM data_cursor INTO
		@RowID, @RecordID, @KodeGudang, @TglSelisih, @NoSelisih, @Cabang, @Keterangan, @Pemeriksa1, @Pemeriksa2, @SyncFlag, @LastUpdatedTime, @LastUpdatedBy

	END
	
	CLOSE data_cursor	
	DEALLOCATE data_cursor
			


END



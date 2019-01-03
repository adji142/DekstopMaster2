USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_Peminjaman]    Script Date: 10/11/2011 13:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nobon
-- Create date: 20 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_Peminjaman '<root><row RowID="F898EFD5-2DAA-42CB-AE58-28C308033DB0" NoBukti="" RecordID="" TglKeluar="1899-12-30T00:00:00" TglBatas="1899-12-30T00:00:00" StaffPenjualan="" Catatan="" NPrint="0" SyncFlag="0" KodeSales="" LastUpdatedTime="2011-03-11T15:15:08.327" LastUpdatedBy="Admin"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_Peminjaman] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @NoBukti VARCHAR(23)
	DECLARE @RecordID VARCHAR(23)
	DECLARE @TglKeluar DATETIME
	DECLARE @TglBatas DATETIME
	DECLARE @StaffPenjualan VARCHAR(10)
	DECLARE @Catatan VARCHAR(25)
	DECLARE @NPrint INT
	DECLARE @SyncFlag BIT
	DECLARE @KodeSales VARCHAR(11)
	DECLARE @LastUpdatedTime DATETIME
	DECLARE @LastUpdatedBy VARCHAR(250)

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- INTerfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	
	DECLARE @Temp TABLE
	(
		RowID UNIQUEIDENTIFIER,
		NoBukti VARCHAR(23),
		RecordID VARCHAR(23),
		TglKeluar DATETIME,
		TglBatas DATETIME,
		StaffPenjualan VARCHAR(10),
		Catatan VARCHAR(25),
		NPrint INT,
		SyncFlag BIT,
		KodeSales VARCHAR(11),
		LastUpdatedTime DATETIME,
		LastUpdatedBy VARCHAR(250)
	)
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc
	INSERT INTO @Temp
	(
		RowID, NoBukti, RecordID, TglKeluar, TglBatas, StaffPenjualan, Catatan, NPrint, SyncFlag, KodeSales, LastUpdatedTime, LastUpdatedBy
	)
	SELECT 
		RowID, 
		NoBukti, 
		RecordID, 
		TglKeluar, 
		TglBatas, 
		StaffPenjualan, 
		Catatan, 
		NPrint, 
		SyncFlag, 
		KodeSales, 
		LastUpdatedTime, 
		LastUpdatedBy
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		NoBukti VARCHAR(23) '@NoBukti',
		RecordID VARCHAR(23) '@RecordID',
		TglKeluar DATETIME '@TglKeluar',
		TglBatas DATETIME '@TglBatas',
		StaffPenjualan VARCHAR(10) '@StaffPenjualan',
		Catatan VARCHAR(25) '@Catatan',
		NPrint INT '@NPrint',
		SyncFlag BIT '@SyncFlag',
		KodeSales VARCHAR(11) '@KodeSales',
		LastUpdatedTime DATETIME '@LastUpdatedTime',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy'
	)

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID, 
		NoBukti, 
		RecordID, 
		TglKeluar, 
		TglBatas, 
		StaffPenjualan, 
		Catatan, 
		NPrint, 
		SyncFlag, 
		KodeSales, 
		LastUpdatedTime, 
		LastUpdatedBy
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @NoBukti, @RecordID, @TglKeluar, @TglBatas, @StaffPenjualan, @Catatan, @NPrint, @SyncFlag, @KodeSales, @LastUpdatedTime, @LastUpdatedBy	

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.Peminjaman (NOLOCK) WHERE RowID = @RowID)
			UPDATE Peminjaman WITH (ROWLOCK)
			SET
				RowID = @RowID,
				NoBukti = @NoBukti,
				RecordID = @RecordID,
				TglKeluar = @TglKeluar,
				TglBatas = @TglBatas,
				StaffPenjualan = @StaffPenjualan,
				Catatan = @Catatan,
				NPrint = @NPrint,
				SyncFlag = @SyncFlag,
				KodeSales = @KodeSales,
				LastUpdatedTime = @LastUpdatedTime,
				LastUpdatedBy = @LastUpdatedBy
			WHERE
				RowID = @RowID
		ELSE
			INSERT INTO Peminjaman WITH (ROWLOCK)
			(RowID, NoBukti, RecordID, TglKeluar, TglBatas, StaffPenjualan, Catatan, NPrint, SyncFlag, KodeSales, LastUpdatedTime, LastUpdatedBy)
			VALUES	(
						@RowID,
						@NoBukti,
						@RecordID,
						@TglKeluar,
						@TglBatas,
						@StaffPenjualan,
						@Catatan,
						@NPrint,
						@SyncFlag,
						@KodeSales,
						@LastUpdatedTime,
						@LastUpdatedBy
					)
		FETCH NEXT FROM data_cursor INTO
		@RowID, @NoBukti, @RecordID, @TglKeluar, @TglBatas, @StaffPenjualan, @Catatan, @NPrint, @SyncFlag, @KodeSales, @LastUpdatedTime, @LastUpdatedBy	

	END

	CLOSE data_cursor	
	DEALLOCATE data_cursor
			


END



 
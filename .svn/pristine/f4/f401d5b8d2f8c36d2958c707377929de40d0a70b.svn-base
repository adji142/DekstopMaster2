USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_KoreksiReturPembelian]    Script Date: 10/11/2011 13:46:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nobon
-- Create date: 20 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_KoreksiReturPembelian '<root><row RowID="39799C0D-5D20-4CB1-9E63-3BE8A3D5C2F6" RecordID="SAS2001042814:35:13" ReturBeliDetailRecID="SAS2001041814:33:45MAD" TglKoreksi="2001-04-24T00:00:00" NoKoreksi="000594" BarangID="FB4DOLL15300" QtyNotaBaru="23" HrgBeliBaru="30435.0000" Catatan="TOLAKAN" Pemasok="KP-SOLO" Sumber="NRB" LinkID="" HrgBeliKoreksi="-11473995.0000" QtyNotaKoreksi="-377" SyncFlag="1" LastUpdatedBy="Admin" LastUpdatedTime="2011-04-18T10:32:06.827"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_KoreksiReturPembelian] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @RecordID VARCHAR(19)
	DECLARE @ReturBeliDetailID UNIQUEIDENTIFIER
	DECLARE @ReturBeliDetailRecID VARCHAR(23)
	DECLARE @TglKoreksi DATETIME
	DECLARE @NoKoreksi VARCHAR(11)
	DECLARE @BarangID VARCHAR(23)
	DECLARE @QtyNotaBaru INT
	DECLARE @HrgBeliBaru MONEY
	DECLARE @Catatan VARCHAR(40)
	DECLARE @Pemasok VARCHAR(19)
	DECLARE @Sumber VARCHAR(3)
	DECLARE @LinkID VARCHAR(23)
	DECLARE @HrgBeliKoreksi MONEY
	DECLARE @QtyNotaKoreksi INT
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
		RecordID VARCHAR(19),
		ReturBeliDetailID UNIQUEIDENTIFIER,
		ReturBeliDetailRecID VARCHAR(23),
		TglKoreksi DATETIME,
		NoKoreksi VARCHAR(11),
		BarangID VARCHAR(23),
		QtyNotaBaru INT,
		HrgBeliBaru MONEY,
		Catatan VARCHAR(40),
		Pemasok VARCHAR(19),
		Sumber VARCHAR(3),
		LinkID VARCHAR(23),
		HrgBeliKoreksi MONEY,
		QtyNotaKoreksi INT,
		SyncFlag BIT,
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc
	
	INSERT INTO @Temp
	(
		RowID, RecordID, ReturBeliDetailID, ReturBeliDetailRecID, TglKoreksi, NoKoreksi, BarangID, QtyNotaBaru, HrgBeliBaru, Catatan, Pemasok, Sumber, LinkID, HrgBeliKoreksi, QtyNotaKoreksi, SyncFlag, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		RecordID, 
		ReturBeliDetailID, 
		ReturBeliDetailRecID, 
		TglKoreksi, 
		NoKoreksi, 
		BarangID, 
		QtyNotaBaru, 
		HrgBeliBaru, 
		Catatan, 
		Pemasok, 
		Sumber, 
		LinkID, 
		HrgBeliKoreksi, 
		QtyNotaKoreksi, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		RecordID VARCHAR(19) '@RecordID',
		ReturBeliDetailID UNIQUEIDENTIFIER '@ReturBeliDetailID',
		ReturBeliDetailRecID VARCHAR(23) '@ReturBeliDetailRecID',
		TglKoreksi DATETIME '@TglKoreksi',
		NoKoreksi VARCHAR(11) '@NoKoreksi',
		BarangID VARCHAR(23) '@BarangID',
		QtyNotaBaru INT '@QtyNotaBaru',
		HrgBeliBaru MONEY '@HrgBeliBaru',
		Catatan VARCHAR(40) '@Catatan',
		Pemasok VARCHAR(19) '@Pemasok',
		Sumber VARCHAR(3) '@Sumber',
		LinkID VARCHAR(23) '@LinkID',
		HrgBeliKoreksi MONEY '@HrgBeliKoreksi',
		QtyNotaKoreksi INT '@QtyNotaKoreksi',
		SyncFlag BIT '@SyncFlag',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy',
		LastUpdatedTime DATETIME '@LastUpdatedTime'
	)

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID, 
		RecordID, 
		ReturBeliDetailID, 
		ReturBeliDetailRecID, 
		TglKoreksi, 
		NoKoreksi, 
		BarangID, 
		QtyNotaBaru, 
		HrgBeliBaru, 
		Catatan, 
		Pemasok, 
		Sumber, 
		LinkID, 
		HrgBeliKoreksi, 
		QtyNotaKoreksi, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp

	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @RecordID, @ReturBeliDetailID, @ReturBeliDetailRecID, @TglKoreksi, @NoKoreksi, @BarangID, @QtyNotaBaru, @HrgBeliBaru, @Catatan, @Pemasok, @Sumber, @LinkID, @HrgBeliKoreksi, @QtyNotaKoreksi, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	WHILE @@FETCH_STATUS = 0
	BEGIN
    -- Insert statements for procedure here
    SET @SyncFlag = 1
    
		IF EXISTS (SELECT RowID FROM dbo.KoreksiReturPembelian (NOLOCK) WHERE RowID = @RowID)
			UPDATE KoreksiReturPembelian WITH (ROWLOCK)
			SET
				RowID = @RowID,
				RecordID = @RecordID,
				ReturBeliDetailID = @ReturBeliDetailID,
				ReturBeliDetailRecID = @ReturBeliDetailRecID,
				TglKoreksi = @TglKoreksi,
				NoKoreksi = @NoKoreksi,
				BarangID = @BarangID,
				QtyNotaBaru = @QtyNotaBaru,
				HrgBeliBaru = @HrgBeliBaru,
				Catatan = @Catatan,
				Pemasok = @Pemasok,
				Sumber = @Sumber,
				LinkID = (CASE WHEN (LinkID='') THEN @LinkID ELSE LinkID END ),    
				HrgBeliKoreksi = @HrgBeliKoreksi,
				QtyNotaKoreksi = @QtyNotaKoreksi,
				SyncFlag = @SyncFlag,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			INSERT INTO KoreksiReturPembelian WITH (ROWLOCK)
			(RowID, RecordID, ReturBeliDetailID, ReturBeliDetailRecID, TglKoreksi, NoKoreksi, BarangID, QtyNotaBaru, HrgBeliBaru, Catatan, Pemasok, Sumber, LinkID, HrgBeliKoreksi, QtyNotaKoreksi, SyncFlag, LastUpdatedBy, LastUpdatedTime)
			VALUES	(
						@RowID,
						@RecordID,
						@ReturBeliDetailID,
						@ReturBeliDetailRecID,
						@TglKoreksi,
						@NoKoreksi,
						@BarangID,
						@QtyNotaBaru,
						@HrgBeliBaru,
						@Catatan,
						@Pemasok,
						@Sumber,
						@LinkID,
						@HrgBeliKoreksi,
						@QtyNotaKoreksi,
						@SyncFlag,
						@LastUpdatedBy,
						@LastUpdatedTime
					)
	FETCH NEXT FROM data_cursor INTO
		@RowID, @RecordID, @ReturBeliDetailID, @ReturBeliDetailRecID, @TglKoreksi, @NoKoreksi, @BarangID, @QtyNotaBaru, @HrgBeliBaru, @Catatan, @Pemasok, @Sumber, @LinkID, @HrgBeliKoreksi, @QtyNotaKoreksi, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	END

	CLOSE data_cursor	
	DEALLOCATE data_cursor
			

END



 
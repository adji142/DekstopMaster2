USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_KoreksiPenjualan]    Script Date: 10/11/2011 13:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Nobon
-- Create date: 20 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_KoreksiPenjualan '<root><row RowID="2C7BA06D-427A-4301-9C2B-00101F71660C" RecordID="SAS2001091415:35:37" NotaJualDetailRecID="SAS2001091113:13:15HRI" TglKoreksi="2001-09-14T00:00:00" NoKoreksi="" BarangID="FE4WCR4053SA" QtyNotaBaru="10" HrgJualBaru="21500.0000" Catatan="" KodeToko="1997102904:26:11391" Sumber="NPJ" LinkID="2001091708:07:30" HrgJualKoreksi="10000.0000" QtyNotaKoreksi="0" SyncFlag="1" LastUpdatedBy="Admin" LastUpdatedTime="2011-05-16T17:30:10.780"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_KoreksiPenjualan] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @RecordID VARCHAR(19)
	DECLARE @NotaJualDetailID UNIQUEIDENTIFIER
	DECLARE @NotaJualDetailRecID VARCHAR(23)
	DECLARE @TglKoreksi DATETIME
	DECLARE @NoKoreksi VARCHAR(11)
	DECLARE @BarangID VARCHAR(23)
	DECLARE @QtyNotaBaru INT
	DECLARE @HrgJualBaru MONEY
	DECLARE @Catatan VARCHAR(40)
	DECLARE @KodeToko VARCHAR(19)
	DECLARE @Sumber VARCHAR(3)
	DECLARE @LinkID VARCHAR(23)
	DECLARE @HrgJualKoreksi MONEY
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
		NotaJualDetailID UNIQUEIDENTIFIER,
		NotaJualDetailRecID VARCHAR(23),
		TglKoreksi DATETIME,
		NoKoreksi VARCHAR(11),
		BarangID VARCHAR(23),
		QtyNotaBaru INT,
		HrgJualBaru MONEY,
		Catatan VARCHAR(40),
		KodeToko VARCHAR(19),
		Sumber VARCHAR(3),
		LinkID VARCHAR(23),
		HrgJualKoreksi MONEY,
		QtyNotaKoreksi INT,
		SyncFlag BIT,
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc
	
	INSERT INTO @Temp
	(
		RowID, RecordID, NotaJualDetailID, NotaJualDetailRecID, TglKoreksi, NoKoreksi, BarangID, QtyNotaBaru, HrgJualBaru, Catatan, KodeToko, Sumber, LinkID, HrgJualKoreksi, QtyNotaKoreksi, SyncFlag, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		RecordID, 
		NotaJualDetailID,	
		NotaJualDetailRecID, 
		TglKoreksi, 
		NoKoreksi, 
		BarangID, 
		QtyNotaBaru, 
		HrgJualBaru, 
		Catatan, 
		KodeToko, 
		Sumber, 
		LinkID, 
		HrgJualKoreksi, 
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
		NotaJualDetailID UNIQUEIDENTIFIER '@NotaJualDetailID',
		NotaJualDetailRecID VARCHAR(23) '@NotaJualDetailRecID',
		TglKoreksi DATETIME '@TglKoreksi',
		NoKoreksi VARCHAR(11) '@NoKoreksi',
		BarangID VARCHAR(23) '@BarangID',
		QtyNotaBaru INT '@QtyNotaBaru',
		HrgJualBaru MONEY '@HrgJualBaru',
		Catatan VARCHAR(40) '@Catatan',
		KodeToko VARCHAR(19) '@KodeToko',
		Sumber VARCHAR(3) '@Sumber',
		LinkID VARCHAR(23) '@LinkID',
		HrgJualKoreksi MONEY '@HrgJualKoreksi',
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
		NotaJualDetailID,	
		NotaJualDetailRecID, 
		TglKoreksi, 
		NoKoreksi, 
		BarangID, 
		QtyNotaBaru, 
		HrgJualBaru, 
		Catatan, 
		KodeToko, 
		Sumber, 
		LinkID, 
		HrgJualKoreksi, 
		QtyNotaKoreksi, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @RecordID, @NotaJualDetailID, @NotaJualDetailRecID, @TglKoreksi, @NoKoreksi, @BarangID, @QtyNotaBaru, @HrgJualBaru, @Catatan, @KodeToko, @Sumber, @LinkID, @HrgJualKoreksi, @QtyNotaKoreksi, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.KoreksiPenjualan (NOLOCK) WHERE RowID = @RowID)
			UPDATE KoreksiPenjualan WITH (ROWLOCK)
			SET
				RowID = @RowID,
				RecordID = @RecordID,
				NotaJualDetailID = @NotaJualDetailID,
				NotaJualDetailRecID = @NotaJualDetailRecID,
				TglKoreksi = @TglKoreksi,
				NoKoreksi = @NoKoreksi,
				BarangID = @BarangID,
				QtyNotaBaru = @QtyNotaBaru,
				HrgJualBaru = @HrgJualBaru,
				Catatan = @Catatan,
				KodeToko = @KodeToko,
				Sumber = @Sumber,
				LinkID = (CASE WHEN (LinkID='') THEN @LinkID ELSE LinkID END ),    
				HrgJualKoreksi = @HrgJualKoreksi,
				QtyNotaKoreksi = @QtyNotaKoreksi,
				SyncFlag = @SyncFlag,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			INSERT INTO KoreksiPenjualan WITH (ROWLOCK)
			(RowID, RecordID, NotaJualDetailID, NotaJualDetailRecID, TglKoreksi, NoKoreksi, BarangID, QtyNotaBaru, HrgJualBaru, Catatan, KodeToko, Sumber, LinkID, HrgJualKoreksi, QtyNotaKoreksi, SyncFlag, LastUpdatedBy, LastUpdatedTime)
			VALUES	(
						@RowID,
						@RecordID,
						@NotaJualDetailID,
						@NotaJualDetailRecID,
						@TglKoreksi,
						@NoKoreksi,
						@BarangID,
						@QtyNotaBaru,
						@HrgJualBaru,
						@Catatan,
						@KodeToko,
						@Sumber,
						@LinkID,
						@HrgJualKoreksi,
						@QtyNotaKoreksi,
						@SyncFlag,
						@LastUpdatedBy,
						@LastUpdatedTime
					)
		FETCH NEXT FROM data_cursor INTO
		@RowID, @RecordID, @NotaJualDetailID, @NotaJualDetailRecID, @TglKoreksi, @NoKoreksi, @BarangID, @QtyNotaBaru, @HrgJualBaru, @Catatan, @KodeToko, @Sumber, @LinkID, @HrgJualKoreksi, @QtyNotaKoreksi, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	END

	CLOSE data_cursor	
	DEALLOCATE data_cursor

END




 
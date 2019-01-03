USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_KoreksiPembelian]    Script Date: 10/11/2011 13:46:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Nobon
-- Create date: 20 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_KoreksiPembelian '<root><row RowID="6D012266-D8D8-432C-AB39-0171ECAB3523" RecordID="C092006092712:56:25" NotaBeliDetailID="1B64653D-7935-4131-8157-3B1741A72E8C" NotaBeliDetailRecID="2006091213:29:0939    1" TglKoreksi="2006-09-27T00:00:00" NoKoreksi="K000246" BarangID="FB2PO05060GB" QtyNotaBaru="20" HrgBeliBaru="7400.0000" Catatan="" Pemasok="KP-SOLO" Sumber="NPB" LinkID="" HrgBeliKoreksi="-148000.0000" QtyNotaKoreksi="-20" SyncFlag="1" LastUpdatedBy="Admin" LastUpdatedTime="2011-04-12T11:07:13.123"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_KoreksiPembelian] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @RecordID VARCHAR(19)
	DECLARE @NotaBeliDetailID UNIQUEIDENTIFIER
	DECLARE @NotaBeliDetailRecID VARCHAR(23)
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
		NotaBeliDetailID UNIQUEIDENTIFIER,
		NotaBeliDetailRecID VARCHAR(23),
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
		RowID, RecordID, NotaBeliDetailID, NotaBeliDetailRecID, TglKoreksi, NoKoreksi, BarangID, QtyNotaBaru, HrgBeliBaru, Catatan, Pemasok, Sumber, LinkID, HrgBeliKoreksi, QtyNotaKoreksi, SyncFlag, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		RecordID, 
		NotaBeliDetailID, 
		NotaBeliDetailRecID, 
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
		NotaBeliDetailID UNIQUEIDENTIFIER '@NotaBeliDetailID',
		NotaBeliDetailRecID VARCHAR(23) '@NotaBeliDetailRecID',
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
		NotaBeliDetailID, 
		NotaBeliDetailRecID, 
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
		@RowID, @RecordID, @NotaBeliDetailID, @NotaBeliDetailRecID, @TglKoreksi, @NoKoreksi, @BarangID, @QtyNotaBaru, @HrgBeliBaru, @Catatan, @Pemasok, @Sumber, @LinkID, @HrgBeliKoreksi, @QtyNotaKoreksi, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
    -- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.KoreksiPembelian (NOLOCK) WHERE RowID = @RowID)
			UPDATE KoreksiPembelian WITH (ROWLOCK)
			SET
				RowID = @RowID,
				RecordID = @RecordID,
				NotaBeliDetailID = @NotaBeliDetailID,
				NotaBeliDetailRecID = @NotaBeliDetailRecID,
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
			INSERT INTO KoreksiPembelian WITH (ROWLOCK)
			(RowID, RecordID, NotaBeliDetailID, NotaBeliDetailRecID, TglKoreksi, NoKoreksi, BarangID, QtyNotaBaru, HrgBeliBaru, Catatan, Pemasok, Sumber, LinkID, HrgBeliKoreksi, QtyNotaKoreksi, SyncFlag, LastUpdatedBy, LastUpdatedTime)
			VALUES	(
						@RowID,
						@RecordID,
						@NotaBeliDetailID,
						@NotaBeliDetailRecID,
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
		@RowID, @RecordID, @NotaBeliDetailID, @NotaBeliDetailRecID, @TglKoreksi, @NoKoreksi, @BarangID, @QtyNotaBaru, @HrgBeliBaru, @Catatan, @Pemasok, @Sumber, @LinkID, @HrgBeliKoreksi, @QtyNotaKoreksi, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime
		
	END
	
	CLOSE data_cursor	
	DEALLOCATE data_cursor


END





 
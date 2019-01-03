 USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_ReturPembelianDetail]    Script Date: 10/11/2011 13:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nobon
-- Create date: 23 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_ReturPembelianDetail '<root><row RowID="A29C04C4-1445-4600-B31E-A8B8EB430C2A" HeaderID="1FDDFE7A-84F8-4CF3-81DD-B85867C583E4" NotaBeliDetailID="DBC85F56-CC63-450E-A1D8-FC5D52F5A2C8" RecordID="CRB2007030811:07:36MOE" ReturID="CRB2007030811:04:04MOE" NotaBeliDetailRecID="CRB2006112411:25:35MOE3" KodeRetur="1" QtyGudang="3" QtyTerima="3" HrgBeli="10515.0000" HrgNet="0.0000" HrgPokok="10515.0000" HPPSolo="10515.0000" Catatan="N KEMASAN RUSAK" TglKeluar="2007-03-08T00:00:00" KodeGudang="0905" LastUpdatedBy="Admin" LastUpdatedTime="2011-04-18T16:18:46.373"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_ReturPembelianDetail] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @HeaderID UNIQUEIDENTIFIER
	DECLARE @NotaBeliDetailID UNIQUEIDENTIFIER
	DECLARE @RecordID VARCHAR(23)
	DECLARE @ReturID VARCHAR(23)
	DECLARE @NotaBeliDetailRecID VARCHAR(23)
	DECLARE @KodeRetur VARCHAR(1)
	DECLARE @BarangID VARCHAR(23)
	DECLARE @QtyGudang INT
	DECLARE @QtyTerima INT
	DECLARE @HrgBeli MONEY
	DECLARE @HrgNet MONEY
	DECLARE @HrgPokok MONEY
	DECLARE @HPPSolo MONEY
	DECLARE @Catatan VARCHAR(23)
	DECLARE @TglKeluar DATETIME
	DECLARE @KodeGudang VARCHAR(4)
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
		NotaBeliDetailID UNIQUEIDENTIFIER,
		RecordID VARCHAR(23),
		ReturID VARCHAR(23),
		NotaBeliDetailRecID VARCHAR(23),
		KodeRetur VARCHAR(1),
		BarangID VARCHAR(23),
		QtyGudang INT,
		QtyTerima INT,
		HrgBeli MONEY,
		HrgNet MONEY,
		HrgPokok MONEY,
		HPPSolo MONEY,
		Catatan VARCHAR(23),
		TglKeluar DATETIME,
		KodeGudang VARCHAR(4),
		SyncFlag BIT,
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)
	
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc
	
	INSERT INTO @Temp
	(
		RowID, HeaderID, NotaBeliDetailID, RecordID, ReturID, NotaBeliDetailRecID, KodeRetur, BarangID, QtyGudang, QtyTerima, HrgBeli, HrgNet, HrgPokok, HPPSolo, Catatan, TglKeluar, KodeGudang, SyncFlag, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		HeaderID, 
		NotaBeliDetailID, 
		RecordID, 
		ReturID, 
		NotaBeliDetailRecID, 
		KodeRetur, 
		BarangID, 
		QtyGudang, 
		QtyTerima, 
		HrgBeli, 
		HrgNet, 
		HrgPokok, 
		HPPSolo, 
		Catatan, 
		TglKeluar, 
		KodeGudang, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		HeaderID UNIQUEIDENTIFIER '@HeaderID',
		NotaBeliDetailID UNIQUEIDENTIFIER '@NotaBeliDetailID',
		RecordID VARCHAR(23) '@RecordID',
		ReturID VARCHAR(23) '@ReturID',
		NotaBeliDetailRecID VARCHAR(23) '@NotaBeliDetailRecID',
		KodeRetur VARCHAR(1) '@KodeRetur',
		BarangID VARCHAR(23) '@BarangID',
		QtyGudang INT '@QtyGudang',
		QtyTerima INT '@QtyTerima',
		HrgBeli MONEY '@HrgBeli',
		HrgNet MONEY '@HrgNet',
		HrgPokok MONEY '@HrgPokok',
		HPPSolo MONEY '@HPPSolo',
		Catatan VARCHAR(23) '@Catatan',
		TglKeluar DATETIME '@TglKeluar',
		KodeGudang VARCHAR(4) '@KodeGudang',
		SyncFlag BIT '@SyncFlag', 
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy',
		LastUpdatedTime DATETIME '@LastUpdatedTime'
	)

	exec sp_xml_removedocument @hdoc
	
	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID, 
		HeaderID, 
		NotaBeliDetailID, 
		RecordID, 
		ReturID, 
		NotaBeliDetailRecID, 
		KodeRetur, 
		BarangID, 
		QtyGudang, 
		QtyTerima, 
		HrgBeli, 
		HrgNet, 
		HrgPokok, 
		HPPSolo, 
		Catatan, 
		TglKeluar, 
		KodeGudang, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @HeaderID, @NotaBeliDetailID, @RecordID, @ReturID, @NotaBeliDetailRecID, @KodeRetur, @BarangID, @QtyGudang, @QtyTerima, @HrgBeli, @HrgNet, @HrgPokok, @HPPSolo, @Catatan, @TglKeluar, @KodeGudang, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.ReturPembelianDetail (NOLOCK) WHERE RowID = @RowID)
			UPDATE ReturPembelianDetail WITH (ROWLOCK)
			SET
				RowID = @RowID,
				HeaderID = @HeaderID,
				NotaBeliDetailID = @NotaBeliDetailID,
				RecordID = @RecordID,
				ReturID = @ReturID,
				NotaBeliDetailRecID = @NotaBeliDetailRecID,
				KodeRetur = @KodeRetur,
				BarangID = @BarangID,
				QtyGudang = @QtyGudang,
				QtyTerima = @QtyTerima,
				HrgBeli = @HrgBeli,
				HrgNet = @HrgNet,
				HrgPokok = @HrgPokok,
				HPPSolo = @HPPSolo,
				Catatan = @Catatan,
				TglKeluar = @TglKeluar,
				KodeGudang = @KodeGudang,
				SyncFlag = @SyncFlag, 
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			IF EXISTS (SELECT RowID FROM dbo.ReturPembelian (NOLOCK) WHERE RowID = @HeaderID)
			BEGIN
				INSERT INTO ReturPembelianDetail WITH (ROWLOCK)
				(RowID, HeaderID, NotaBeliDetailID, RecordID, ReturID, NotaBeliDetailRecID, KodeRetur, BarangID, QtyGudang, QtyTerima, HrgBeli, HrgNet, HrgPokok, HPPSolo, Catatan, TglKeluar, KodeGudang, SyncFlag, LastUpdatedBy, LastUpdatedTime)
					VALUES	(
								@RowID,
								@HeaderID,
								@NotaBeliDetailID,
								@RecordID,
								@ReturID,
								@NotaBeliDetailRecID,
								@KodeRetur,
								@BarangID,
								@QtyGudang,
								@QtyTerima,
								@HrgBeli,
								@HrgNet,
								@HrgPokok,
								@HPPSolo,
								@Catatan,
								@TglKeluar,
								@KodeGudang,
								@SyncFlag, 
								@LastUpdatedBy,
								@LastUpdatedTime
							)
			END
		FETCH NEXT FROM data_cursor INTO
		@RowID, @HeaderID, @NotaBeliDetailID, @RecordID, @ReturID, @NotaBeliDetailRecID, @KodeRetur, @BarangID, @QtyGudang, @QtyTerima, @HrgBeli, @HrgNet, @HrgPokok, @HPPSolo, @Catatan, @TglKeluar, @KodeGudang, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	END

	CLOSE data_cursor	
	DEALLOCATE data_cursor
			


END




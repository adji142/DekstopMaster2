USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_MutasiDetail]    Script Date: 10/11/2011 13:47:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nobon
-- Create date: 20 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_MutasiDetail '<root><row RowID="6F20F913-7C2B-4FAA-940D-3D6EA3E961DB" MutasiID="CRB2007092609:57:37" RecordID="2007092614:04:20" QtyMutasi="-2" KodeBarang="FB4KOI1000DI" Keterangan="LELANG" Gudang="0905" SyncFlag="1" LastUpdatedBy="Admin" LastUpdatedTime="2011-03-04T08:50:04.930"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_MutasiDetail] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @HeaderID UNIQUEIDENTIFIER
	DECLARE @MutasiID VARCHAR(19)
	DECLARE @RecordID VARCHAR(19)
	DECLARE @QtyMutasi INT
	DECLARE @KodeBarang VARCHAR(23)
	DECLARE @Keterangan VARCHAR(43)
	DECLARE @Gudang VARCHAR(4)
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
		MutasiID VARCHAR(19),
		RecordID VARCHAR(19),
		QtyMutasi INT,
		KodeBarang VARCHAR(23),
		Keterangan VARCHAR(43),
		Gudang VARCHAR(4),
		SyncFlag BIT,
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc

	INSERT INTO @Temp
	(
		RowID, HeaderID, MutasiID, RecordID, QtyMutasi, KodeBarang, Keterangan, Gudang, SyncFlag, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		HeaderID, 
		MutasiID, 
		RecordID, 
		QtyMutasi, 
		KodeBarang, 
		Keterangan, 
		Gudang, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		HeaderID UNIQUEIDENTIFIER '@HeaderID',
		MutasiID VARCHAR(19) '@MutasiID',
		RecordID VARCHAR(19) '@RecordID',
		QtyMutasi INT '@QtyMutasi',
		KodeBarang VARCHAR(23) '@KodeBarang',
		Keterangan VARCHAR(43) '@Keterangan',
		Gudang VARCHAR(4) '@Gudang',
		SyncFlag BIT '@SyncFlag',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy',
		LastUpdatedTime DATETIME '@LastUpdatedTime'
	)

	exec sp_xml_removedocument @hdoc


	DECLARE data_cursor CURSOR FOR
	SELECT 
		RowID, 
		HeaderID, 
		MutasiID, 
		RecordID, 
		QtyMutasi, 
		KodeBarang, 
		Keterangan, 
		Gudang, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @HeaderID, @MutasiID, @RecordID, @QtyMutasi, @KodeBarang, @Keterangan, @Gudang, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.MutasiDetail (NOLOCK) WHERE RowID = @RowID)
			UPDATE MutasiDetail WITH (ROWLOCK)
			SET
				RowID = @RowID,
				HeaderID = @HeaderID,
				MutasiID = @MutasiID,
				RecordID = @RecordID,
				QtyMutasi = @QtyMutasi,
				KodeBarang = @KodeBarang,
				Keterangan = @Keterangan,
				Gudang = @Gudang,
				SyncFlag = @SyncFlag,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			INSERT INTO MutasiDetail WITH (ROWLOCK)
			(RowID, HeaderID, MutasiID, RecordID, QtyMutasi, KodeBarang, Keterangan, Gudang, SyncFlag, LastUpdatedBy, LastUpdatedTime)
			VALUES	(
						@RowID,
						@HeaderID,
						@MutasiID,
						@RecordID,
						@QtyMutasi,
						@KodeBarang,
						@Keterangan,
						@Gudang,
						@SyncFlag,
						@LastUpdatedBy,
						@LastUpdatedTime
					)
		FETCH NEXT FROM data_cursor INTO
		@RowID, @HeaderID, @MutasiID, @RecordID, @QtyMutasi, @KodeBarang, @Keterangan, @Gudang, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	END

	CLOSE data_cursor	
	DEALLOCATE data_cursor
			


END



 
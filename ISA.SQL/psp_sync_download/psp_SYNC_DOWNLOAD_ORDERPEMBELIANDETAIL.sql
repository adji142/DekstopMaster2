USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_OrderPembelianDetail]    Script Date: 10/11/2011 13:47:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nobon
-- Create date: 20 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_OrderPembelianDetail '<root><row RowID="6245D7DE-886F-404B-BFFE-FCEFB11F5C93" HeaderID="67CF8C86-6EC6-4E8F-937C-412FB4960DF3" RecordID="CRB2009062613:54:45MMU" HeaderRecID="CRB2009062613:49:45MMU" BarangID="FB4FO0200300" QtyDO="0" QtyBO="0" QtyTambahan="60" QtyJual="20" QtyAkhir="45" Keterangan="" KodeGudang="0905" Catatan="" SyncFlag="1" LastUpdatedBy="Admin" LastUpdatedTime="2011-04-01T17:41:04.903"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_OrderPembelianDetail] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @HeaderID UNIQUEIDENTIFIER
	DECLARE @RecordID VARCHAR(23)
	DECLARE @HeaderRecID VARCHAR(23)
	DECLARE @BarangID VARCHAR(23)
	DECLARE @QtyDO INT
	DECLARE @QtyBO INT
	DECLARE @QtyTambahan INT
	DECLARE @QtyJual INT
	DECLARE @QtyAkhir INT
	DECLARE @Keterangan VARCHAR(40)
	DECLARE @KodeGudang VARCHAR(4)
	DECLARE @Catatan VARCHAR(90)
	DECLARE @SyncFlag BIT
	DECLARE @LastUpdatedBy VARCHAR(250)
	DECLARE @LastUpdatedTime DATETIME

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- INTerfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	
	DECLARE	@Temp TABLE
	(
		RowID UNIQUEIDENTIFIER,
		HeaderID UNIQUEIDENTIFIER,
		RecordID VARCHAR(23),
		HeaderRecID VARCHAR(23),
		BarangID VARCHAR(23),
		QtyDO INT,
		QtyBO INT,
		QtyTambahan INT,
		QtyJual INT,
		QtyAkhir INT,
		Keterangan VARCHAR(40),
		KodeGudang VARCHAR(4),
		Catatan VARCHAR(90),
		SyncFlag BIT,
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc
	INSERT INTO	@Temp
	(
		RowID, HeaderID, RecordID, HeaderRecID, BarangID, QtyDO, QtyBO, QtyTambahan, QtyJual, QtyAkhir, Keterangan, KodeGudang, Catatan, SyncFlag, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		HeaderID, 
		RecordID, 
		HeaderRecID, 
		BarangID, 
		QtyDO, 
		QtyBO, 
		QtyTambahan, 
		QtyJual, 
		QtyAkhir, 
		Keterangan, 
		KodeGudang, 
		Catatan, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		HeaderID UNIQUEIDENTIFIER '@HeaderID',
		RecordID VARCHAR(23) '@RecordID',
		HeaderRecID VARCHAR(23) '@HeaderRecID',
		BarangID VARCHAR(23) '@BarangID',
		QtyDO INT '@QtyDO',
		QtyBO INT '@QtyBO',
		QtyTambahan INT '@QtyTambahan',
		QtyJual INT '@QtyJual',
		QtyAkhir INT '@QtyAkhir',
		Keterangan VARCHAR(40) '@Keterangan',
		KodeGudang VARCHAR(4) '@KodeGudang',
		Catatan VARCHAR(90) '@Catatan',
		SyncFlag BIT '@SyncFlag',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy',
		LastUpdatedTime DATETIME '@LastUpdatedTime'
	)

	exec sp_xml_removedocument @hdoc	

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID, 
		HeaderID, 
		RecordID, 
		HeaderRecID, 
		BarangID, 
		QtyDO, 
		QtyBO, 
		QtyTambahan, 
		QtyJual, 
		QtyAkhir, 
		Keterangan, 
		KodeGudang, 
		Catatan, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp

	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @HeaderID, @RecordID, @HeaderRecID, @BarangID, @QtyDO, @QtyBO, @QtyTambahan, @QtyJual, @QtyAkhir, @Keterangan, @KodeGudang, @Catatan, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.OrderPembelianDetail (NOLOCK) WHERE RowID = @RowID)
			UPDATE OrderPembelianDetail WITH (ROWLOCK)
			SET
				RowID = @RowID,
				HeaderID = @HeaderID,
				RecordID = @RecordID,
				HeaderRecID = @HeaderRecID,
				BarangID = @BarangID,
				QtyDO = @QtyDO,
				QtyBO = @QtyBO,
				QtyTambahan = @QtyTambahan,
				QtyJual = @QtyJual,
				QtyAkhir = @QtyAkhir,
				Keterangan = @Keterangan,
				KodeGudang = @KodeGudang,
				Catatan = @Catatan,
				SyncFlag = @SyncFlag,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			IF EXISTS (SELECT RowID FROM dbo.OrderPembelian (NOLOCK) WHERE RowID=@HeaderID)
			BEGIN 
				INSERT INTO OrderPembelianDetail WITH (ROWLOCK)
				(RowID, HeaderID, RecordID, HeaderRecID, BarangID, QtyDO, QtyBO, QtyTambahan, QtyJual, QtyAkhir, Keterangan, KodeGudang, Catatan, SyncFlag, LastUpdatedBy, LastUpdatedTime)
				VALUES	(
							@RowID,
							@HeaderID,
							@RecordID,
							@HeaderRecID,
							@BarangID,
							@QtyDO,
							@QtyBO,
							@QtyTambahan,
							@QtyJual,
							@QtyAkhir,
							@Keterangan,
							@KodeGudang,
							@Catatan,
							@SyncFlag,
							@LastUpdatedBy,
							@LastUpdatedTime
						)
			END
		FETCH NEXT FROM data_cursor INTO
		@RowID, @HeaderID, @RecordID, @HeaderRecID, @BarangID, @QtyDO, @QtyBO, @QtyTambahan, @QtyJual, @QtyAkhir, @Keterangan, @KodeGudang, @Catatan, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime
		
	END

	CLOSE data_cursor	
	DEALLOCATE data_cursor
			


END



 
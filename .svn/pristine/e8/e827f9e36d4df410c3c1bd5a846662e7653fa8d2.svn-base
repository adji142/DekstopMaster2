USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_PengembalianDetail]    Script Date: 10/11/2011 13:48:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nobon
-- Create date: 23 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_PengembalianDetail '<root><row RowID="9E82B7DE-08CA-46E8-80B3-0005BF889BF6" HeaderID="F1348EA1-6388-4E7C-B575-C5CD4E553721" PeminjamanID="95DD3FBD-1BCC-4FBC-9BCF-864E72466EF4" RecordID="C092006051613:47:19WID" TransactionID="C092006051613:44:35WID" IDPinjam="C092006050509:38:16PUR" NoPinjam="0000239" QtyKembali="1" Catatan="" SyncFlag="1" LastUpdatedBy="Admin" LastUpdatedTime="2011-03-11T15:16:10.013"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_PengembalianDetail] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @HeaderID UNIQUEIDENTIFIER
	DECLARE @PeminjamanID UNIQUEIDENTIFIER
	DECLARE @RecordID VARCHAR(23)
	DECLARE @TransactionID VARCHAR(23)
	DECLARE @IDPinjam VARCHAR(23)
	DECLARE @NoPinjam VARCHAR(10)
	DECLARE @QtyKembali INT
	DECLARE @Catatan VARCHAR(25)
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
		PeminjamanID UNIQUEIDENTIFIER,
		RecordID VARCHAR(23),
		TransactionID VARCHAR(23),
		IDPinjam VARCHAR(23),
		NoPinjam VARCHAR(10),
		QtyKembali INT,
		Catatan VARCHAR(25),
		SyncFlag BIT,
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)

		exec sp_xml_preparedocument @hdoc OUTPUT, @doc

	INSERT INTO	@Temp
	(
		RowID, HeaderID, PeminjamanID, RecordID, TransactionID, IDPinjam, NoPinjam, QtyKembali, Catatan, SyncFlag, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		HeaderID, 
		PeminjamanID, 
		RecordID, 
		TransactionID, 
		IDPinjam, 
		NoPinjam, 
		QtyKembali, 
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
		PeminjamanID UNIQUEIDENTIFIER '@PeminjamanID',
		RecordID VARCHAR(23) '@RecordID',
		TransactionID VARCHAR(23) '@TransactionID',
		IDPinjam VARCHAR(23) '@IDPinjam',
		NoPinjam VARCHAR(10) '@NoPinjam',
		QtyKembali INT '@QtyKembali',
		Catatan VARCHAR(25) '@Catatan',
		SyncFlag BIT '@SyncFlag',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy',
		LastUpdatedTime DATETIME '@LastUpdatedTime'
	)

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID, 
		HeaderID, 
		PeminjamanID, 
		RecordID, 
		TransactionID, 
		IDPinjam, 
		NoPinjam, 
		QtyKembali, 
		Catatan, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
		
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @HeaderID, @PeminjamanID, @RecordID, @TransactionID, @IDPinjam, @NoPinjam, @QtyKembali, @Catatan, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.PengembalianDetail (NOLOCK) WHERE RowID = @RowID)
			UPDATE PengembalianDetail WITH (ROWLOCK)
			SET
				RowID = @RowID,
				HeaderID = @HeaderID,
				PeminjamanID = @PeminjamanID,
				RecordID = @RecordID,
				TransactionID = @TransactionID,
				IDPinjam = @IDPinjam,
				NoPinjam = @NoPinjam,
				QtyKembali = @QtyKembali,
				Catatan = @Catatan,
				SyncFlag = @SyncFlag,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			IF EXISTS (SELECT RowID FROM dbo.Pengembalian (NOLOCK) WHERE RowID=@HeaderID)
			BEGIN 
				INSERT INTO PengembalianDetail WITH (ROWLOCK)
				(RowID, HeaderID, PeminjamanID, RecordID, TransactionID, IDPinjam, NoPinjam, QtyKembali, Catatan, SyncFlag, LastUpdatedBy, LastUpdatedTime)
				VALUES	(
							@RowID,
							@HeaderID,
							@PeminjamanID,
							@RecordID,
							@TransactionID,
							@IDPinjam,
							@NoPinjam,
							@QtyKembali,
							@Catatan,
							@SyncFlag,
							@LastUpdatedBy,
							@LastUpdatedTime
						)
			END
		FETCH NEXT FROM data_cursor INTO
		@RowID, @HeaderID, @PeminjamanID, @RecordID, @TransactionID, @IDPinjam, @NoPinjam, @QtyKembali, @Catatan, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	END

	CLOSE data_cursor	
	DEALLOCATE data_cursor
			


END



 
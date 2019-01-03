USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_RekapKoliDetail]    Script Date: 10/11/2011 13:48:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nobon
-- Create date: 23 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_RekapKoliDetail '<root><row RowID="52DCB57D-4D1E-42E1-80C4-EF30767AB0AA" HeaderID="F8098918-D52D-4199-9AA5-0001116A0CBD" NotaJualID="CF102DDC-D6FB-4FE1-92EB-51D22D31B073" RecordID="MDN2006092811:51:16SJT" HtrID="MDN2006092811:51:10SJT" NotaJualRecID="MDN2006092809:44:53DNG" NoNota="IAP5993" TunaiKredit="K" Nominal="0.0000" Uraian="" Keterangan="kirim ke pengangkutan berbunga" NoResi="" SyncFlag="1" LastUpdatedBy="Admin" LastUpdatedTime="2011-01-25T15:10:54.317"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_RekapKoliDetail] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @HeaderID UNIQUEIDENTIFIER
	DECLARE @NotaJualID UNIQUEIDENTIFIER
	DECLARE @RecordID VARCHAR(23)
	DECLARE @HtrID VARCHAR(23)
	DECLARE @NotaJualRecID VARCHAR(23)
	DECLARE @NoNota VARCHAR(7)
	DECLARE @TunaiKredit VARCHAR(1)
	DECLARE @Nominal MONEY
	DECLARE @Uraian VARCHAR(12)
	DECLARE @Keterangan VARCHAR(30)
	DECLARE @NoResi VARCHAR(15)
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
		NotaJualID UNIQUEIDENTIFIER,
		RecordID VARCHAR(23),
		HtrID VARCHAR(23),
		NotaJualRecID VARCHAR(23),
		NoNota VARCHAR(7),
		TunaiKredit VARCHAR(1),
		Nominal MONEY,
		Uraian VARCHAR(12),
		Keterangan VARCHAR(30),
		NoResi VARCHAR(15),
		SyncFlag BIT,
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)
	
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc
	
	INSERT INTO @Temp
	(
		RowID, HeaderID, NotaJualID, RecordID, HtrID, NotaJualRecID, NoNota, TunaiKredit, Nominal, Uraian, Keterangan, NoResi, SyncFlag, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		HeaderID, 
		NotaJualID, 
		RecordID, 
		HtrID, 
		NotaJualRecID, 
		NoNota, 
		TunaiKredit, 
		Nominal,	
		Uraian, 
		Keterangan, 
		NoResi, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		HeaderID UNIQUEIDENTIFIER '@HeaderID',
		NotaJualID UNIQUEIDENTIFIER '@NotaJualID',
		RecordID VARCHAR(23) '@RecordID',
		HtrID VARCHAR(23) '@HtrID',
		NotaJualRecID VARCHAR(23) '@NotaJualRecID',
		NoNota VARCHAR(7) '@NoNota',
		TunaiKredit VARCHAR(1) '@TunaiKredit',
		Nominal MONEY '@Nominal',
		Uraian VARCHAR(12) '@Uraian',
		Keterangan VARCHAR(30) '@Keterangan',
		NoResi VARCHAR(15) '@NoResi',
		SyncFlag BIT '@SyncFlag',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy',
		LastUpdatedTime DATETIME '@LastUpdatedTime'
	)

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID, 
		HeaderID, 
		NotaJualID, 
		RecordID, 
		HtrID, 
		NotaJualRecID, 
		NoNota, 
		TunaiKredit, 
		Nominal,	
		Uraian, 
		Keterangan, 
		NoResi, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @HeaderID, @NotaJualID, @RecordID, @HtrID, @NotaJualRecID, @NoNota, @TunaiKredit, @Nominal, @Uraian, @Keterangan, @NoResi, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.RekapKoliDetail (NOLOCK) WHERE RowID = @RowID)
			UPDATE RekapKoliDetail WITH (ROWLOCK)
			SET
				RowID = @RowID,
				HeaderID = @HeaderID,
				NotaJualID = @NotaJualID,
				RecordID = @RecordID,
				HtrID = @HtrID,
				NotaJualRecID = @NotaJualRecID,
				NoNota = @NoNota,
				TunaiKredit = @TunaiKredit,
				Nominal = @Nominal,
				Uraian = @Uraian,
				Keterangan = @Keterangan,
				NoResi = @NoResi,
				SyncFlag = @SyncFlag,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			IF EXISTS (SELECT RowID FROM dbo.RekapKoli (NOLOCK) WHERE RowID=@HeaderID)
			BEGIN 
				INSERT INTO RekapKoliDetail WITH (ROWLOCK)
				(RowID, HeaderID, NotaJualID, RecordID, HtrID, NotaJualRecID, NoNota, TunaiKredit, Nominal, Uraian, Keterangan, NoResi, SyncFlag, LastUpdatedBy, LastUpdatedTime)
					VALUES	(
								@RowID,
								@HeaderID,
								@NotaJualID,
								@RecordID,
								@HtrID,
								@NotaJualRecID,
								@NoNota,
								@TunaiKredit,
								@Nominal,
								@Uraian,
								@Keterangan,
								@NoResi,
								@SyncFlag,
								@LastUpdatedBy,
								@LastUpdatedTime
						)
			END
		FETCH NEXT FROM data_cursor INTO
		@RowID, @HeaderID, @NotaJualID, @RecordID, @HtrID, @NotaJualRecID, @NoNota, @TunaiKredit, @Nominal, @Uraian, @Keterangan, @NoResi, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	END

	CLOSE data_cursor	
	DEALLOCATE data_cursor
			


END



 
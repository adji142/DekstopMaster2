USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_OrderPembelian]    Script Date: 10/11/2011 13:47:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nobon
-- Create date: 20 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_OrderPembelian '<root><row RowID="39F9B9F0-EAB0-4956-BEE9-3BA349759833" RecordID="   2003012017:01:27XXX" NoRequest="0002" TglRequest="2003-01-20T00:00:00" Pemasok="KP-SOLO" Cabang1="09" Cabang2="09" EstHrgJual="0.0000" EstHPP="0.0000" NoACC="" Catatan="" SyncFlag="1" LastUpdatedBy="Admin" LastUpdatedTime="2011-04-01T17:23:03.733"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_OrderPembelian] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @RecordID VARCHAR(23)
	DECLARE @NoRequest VARCHAR(7)
	DECLARE @TglRequest DATETIME
	DECLARE @Pemasok VARCHAR(19)
	DECLARE @Cabang1 VARCHAR(2)
	DECLARE @Cabang2 VARCHAR(2)
	DECLARE @EstHrgJual MONEY
	DECLARE @EstHPP MONEY
	DECLARE @NoACC VARCHAR(5)
	DECLARE @Catatan VARCHAR(50)
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
		RecordID VARCHAR(23),
		NoRequest VARCHAR(7),
		TglRequest DATETIME,
		Pemasok VARCHAR(19),
		Cabang1 VARCHAR(2),
		Cabang2 VARCHAR(2),
		EstHrgJual MONEY,
		EstHPP MONEY,
		NoACC VARCHAR(5),
		Catatan VARCHAR(50),
		SyncFlag BIT,
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc
	INSERT INTO	@Temp
	(
		RowID, RecordID, NoRequest, TglRequest, Pemasok, Cabang1, Cabang2, EstHrgJual, EstHPP, NoACC, Catatan, SyncFlag, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		RecordID, 
		NoRequest, 
		TglRequest, 
		Pemasok, 
		Cabang1, 
		Cabang2, 
		EstHrgJual, 
		EstHPP, 
		NoACC, 
		Catatan, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		RecordID VARCHAR(23) '@RecordID',
		NoRequest VARCHAR(7) '@NoRequest',
		TglRequest DATETIME '@TglRequest',
		Pemasok VARCHAR(19) '@Pemasok',
		Cabang1 VARCHAR(2) '@Cabang1',
		Cabang2 VARCHAR(2) '@Cabang2',
		EstHrgJual MONEY '@EstHrgJual',
		EstHPP MONEY '@EstHPP',
		NoACC VARCHAR(5) '@NoACC',
		Catatan VARCHAR(50) '@Catatan',
		SyncFlag BIT '@SyncFlag',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy',
		LastUpdatedTime DATETIME '@LastUpdatedTime'
	)

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID, 
		RecordID, 
		NoRequest, 
		TglRequest, 
		Pemasok, 
		Cabang1, 
		Cabang2, 
		EstHrgJual, 
		EstHPP, 
		NoACC, 
		Catatan, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @RecordID, @NoRequest, @TglRequest, @Pemasok, @Cabang1, @Cabang2, @EstHrgJual, @EstHPP, @NoACC, @Catatan, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.OrderPembelian (NOLOCK) WHERE RowID = @RowID)
			UPDATE OrderPembelian WITH (ROWLOCK)
			SET
				RowID = @RowID,
				RecordID = @RecordID,
				NoRequest = @NoRequest,
				TglRequest = @TglRequest,
				Pemasok = @Pemasok,
				Cabang1 = @Cabang1,
				Cabang2 = @Cabang2,
				EstHrgJual = @EstHrgJual,
				EstHPP = @EstHPP,
				NoACC = @NoACC,
				Catatan = @Catatan,
				SyncFlag = @SyncFlag,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			INSERT INTO OrderPembelian WITH (ROWLOCK)
			(RowID, RecordID, NoRequest, TglRequest, Pemasok, Cabang1, Cabang2, EstHrgJual, EstHPP, NoACC, Catatan, SyncFlag, LastUpdatedBy, LastUpdatedTime)
			VALUES	(
						@RowID,
						@RecordID,
						@NoRequest,
						@TglRequest,
						@Pemasok,
						@Cabang1,
						@Cabang2,
						@EstHrgJual,
						@EstHPP,
						@NoACC,
						@Catatan,
						@SyncFlag,
						@LastUpdatedBy,
						@LastUpdatedTime				
					)
		FETCH NEXT FROM data_cursor INTO
		@RowID, @RecordID, @NoRequest, @TglRequest, @Pemasok, @Cabang1, @Cabang2, @EstHrgJual, @EstHPP, @NoACC, @Catatan, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	END

	CLOSE data_cursor	
	DEALLOCATE data_cursor
			


END



 
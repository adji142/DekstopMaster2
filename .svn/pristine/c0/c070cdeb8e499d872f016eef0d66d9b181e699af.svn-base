USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_OrderPenjualanDetail]    Script Date: 10/11/2011 13:47:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Nobon
-- Create date: 20 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_OrderPenjualanDetail '<root><row RowID="7875E951-9406-4608-ADF2-FBCF7CBC061E" HeaderID="BE867ABD-06D3-485E-9FA3-6D0A2B9FC30F" RecordID="CRB2010050614:00:39ANG" HtrID="CRB2010050613:59:50ANG" BarangID="FB4DO05001ML" QtyRequest="3" QtyDO="3" HrgJual="70000.0000" KodeToko="2004051815:43:18   " TglSuratJalan="2010-05-06T00:00:00" Disc1="0.00" Disc2="0.00" Disc3="0.00" Pot="0.0000" DiscFormula="" NoDOBO="" NoACC="09L7809" Catatan="" SyncFlag="1" NBOPrint="0" LastUpdatedBy="Admin" LastUpdatedTime="2011-04-01T12:29:33.140"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_OrderPenjualanDetail] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @HeaderID UNIQUEIDENTIFIER
	DECLARE @RecordID VARCHAR(23)
	DECLARE @HtrID VARCHAR(23)
	DECLARE @BarangID VARCHAR(23)
	DECLARE @QtyRequest INT
	DECLARE @QtyDO INT
	DECLARE @HrgJual MONEY
	DECLARE @KodeToko VARCHAR(19)
	DECLARE @TglSuratJalan DATETIME
	DECLARE @Disc1 DECIMAL(5, 2)
	DECLARE @Disc2 DECIMAL(5, 2)
	DECLARE @Disc3 DECIMAL(5, 2)
	DECLARE @Pot MONEY
	DECLARE @DiscFormula VARCHAR(7)
	DECLARE @NoDOBO VARCHAR(7)
	DECLARE @NoACC VARCHAR(7)
	DECLARE @Catatan VARCHAR(23)
	DECLARE @SyncFlag BIT
	DECLARE @NBOPrint VARCHAR(50)
	DECLARE @DOBeliDetailID UNIQUEIDENTIFIER
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
		RecordID VARCHAR(23),
		HtrID VARCHAR(23),
		BarangID VARCHAR(23),
		QtyRequest INT,
		QtyDO INT,
		HrgJual MONEY,
		KodeToko VARCHAR(19),
		TglSuratJalan DATETIME,
		Disc1 DECIMAL(5, 2),
		Disc2 DECIMAL(5, 2),
		Disc3 DECIMAL(5, 2),
		Pot MONEY,
		DiscFormula VARCHAR(7),
		NoDOBO VARCHAR(7),
		NoACC VARCHAR(7),
		Catatan VARCHAR(23),
		SyncFlag BIT,
		NBOPrint VARCHAR(50),
		DOBeliDetailID UNIQUEIDENTIFIER,
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc
	INSERT INTO @Temp
	(
		RowID, HeaderID, RecordID, HtrID, BarangID, QtyRequest, QtyDO, HrgJual, Disc1, Disc2, Disc3, Pot, DiscFormula, NoDOBO, NoACC, Catatan, SyncFlag, NBOPrint, DOBeliDetailID, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		HeaderID, 
		RecordID, 
		HtrID, 
		BarangID, 
		QtyRequest, 
		QtyDO, 
		HrgJual, 
		Disc1, 
		Disc2, 
		Disc3, 
		Pot, 
		DiscFormula, 
		NoDOBO, 
		NoACC, 
		Catatan, 
		SyncFlag, 
		NBOPrint, 
		DOBeliDetailID, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		HeaderID UNIQUEIDENTIFIER '@HeaderID',
		RecordID VARCHAR(23) '@RecordID',
		HtrID VARCHAR(23) '@HtrID',
		BarangID VARCHAR(23) '@BarangID',
		QtyRequest INT '@QtyRequest',
		QtyDO INT '@QtyDO',
		HrgJual MONEY '@HrgJual',
		Disc1 DECIMAL(5, 2) '@Disc1',
		Disc2 DECIMAL(5, 2) '@Disc2',
		Disc3 DECIMAL(5, 2) '@Disc3',
		Pot MONEY '@Pot',
		DiscFormula VARCHAR(7) '@DiscFormula',
		NoDOBO VARCHAR(7) '@NoDOBO',
		NoACC VARCHAR(7) '@NoACC',
		Catatan VARCHAR(23) '@Catatan',
		SyncFlag BIT '@SyncFlag',
		NBOPrint VARCHAR(50) '@NBOPrint',
		DOBeliDetailID UNIQUEIDENTIFIER '@DOBeliDetailID',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy',
		LastUpdatedTime DATETIME '@LastUpdatedTime'
	)

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID, 
		HeaderID, 
		RecordID, 
		HtrID, 
		BarangID, 
		QtyRequest, 
		QtyDO, 
		HrgJual, 
		Disc1, 
		Disc2, 
		Disc3, 
		Pot, 
		DiscFormula, 
		NoDOBO, 
		NoACC, 
		Catatan, 
		SyncFlag, 
		NBOPrint, 
		DOBeliDetailID, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
	
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
	@RowID, @HeaderID, @RecordID, @HtrID, @BarangID, @QtyRequest, @QtyDO, @HrgJual, @Disc1, @Disc2, @Disc3, @Pot, @DiscFormula, @NoDOBO, @NoACC, @Catatan, @SyncFlag, @NBOPrint, @DOBeliDetailID, @LastUpdatedBy, @LastUpdatedTime

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.OrderPenjualanDetail (NOLOCK) WHERE RowID = @RowID)
			UPDATE OrderPenjualanDetail WITH (ROWLOCK)
			SET
				RowID = @RowID,
				HeaderID = @HeaderID,
				RecordID = @RecordID,
				HtrID = @HtrID,
				BarangID = @BarangID,
				QtyRequest = @QtyRequest,
				QtyDO = @QtyDO,
				HrgJual = @HrgJual,
				Disc1 = @Disc1,
				Disc2 = @Disc2,
				Disc3 = @Disc3,
				Pot = @Pot,
				DiscFormula = @DiscFormula,
				NoDOBO = @NoDOBO,
				NoACC = @NoACC,
				Catatan = @Catatan,
				SyncFlag = @SyncFlag,
				NBOPrint = @NBOPrint,
				DOBeliDetailID = @DOBeliDetailID,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			IF EXISTS (SELECT RowID FROM dbo.OrderPenjualan (NOLOCK) WHERE RowID=@HeaderID)
			BEGIN 
				INSERT INTO OrderPenjualanDetail WITH (ROWLOCK)
					(RowID, HeaderID, RecordID, HtrID, BarangID, QtyRequest, QtyDO, HrgJual, Disc1, Disc2, Disc3, Pot, DiscFormula, NoDOBO, NoACC, Catatan, SyncFlag, NBOPrint, DOBeliDetailID, LastUpdatedBy, LastUpdatedTime)
					VALUES	(
							@RowID,
							@HeaderID,
							@RecordID,
							@HtrID,
							@BarangID,
							@QtyRequest,
							@QtyDO,
							@HrgJual,
							@Disc1,
							@Disc2,
							@Disc3,
							@Pot,
							@DiscFormula,
							@NoDOBO,
							@NoACC,
							@Catatan,
							@SyncFlag,
							@NBOPrint,
							@DOBeliDetailID,
							@LastUpdatedBy,
							@LastUpdatedTime
						)		
			END
		FETCH NEXT FROM data_cursor INTO
		@RowID, @HeaderID, @RecordID, @HtrID, @BarangID, @QtyRequest, @QtyDO, @HrgJual, @Disc1, @Disc2, @Disc3, @Pot, @DiscFormula, @NoDOBO, @NoACC, @Catatan, @SyncFlag, @NBOPrint, @DOBeliDetailID, @LastUpdatedBy, @LastUpdatedTime

	END
	
	CLOSE data_cursor	
	DEALLOCATE data_cursor
			

	
	



END




 
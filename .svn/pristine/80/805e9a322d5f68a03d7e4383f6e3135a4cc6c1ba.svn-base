USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_OrderPenjualan]    Script Date: 10/11/2011 13:47:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Nobon
-- Create date: 18 May 2011
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_OrderPenjualan] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc int
	DECLARE	@RowID UNIQUEIDENTIFIER
	DECLARE @HtrID VARCHAR(23)
	DECLARE @Cabang1 VARCHAR(2)
	DECLARE @Cabang2 VARCHAR(2)
	DECLARE @Cabang3 VARCHAR(2)
	DECLARE @NoRequest VARCHAR(7)
	DECLARE @TglRequest DATETIME
	DECLARE @NoDO VARCHAR(7)
	DECLARE @TglDO DATETIME
	DECLARE @NoACCPusat VARCHAR(7)
	DECLARE @ACCPiutangID VARCHAR(11)
	DECLARE @NoACCPiutang VARCHAR(7)
	DECLARE @TglACCPiutang DATETIME
	DECLARE @RpACCPiutang MONEY
	DECLARE @RpPlafonToko MONEY
	DECLARE @RpPiutangTerakhir MONEY
	DECLARE @RpGiroTolakTerakhir MONEY
	DECLARE @RpOverdue MONEY
	DECLARE @StatusBatal VARCHAR(7)
	DECLARE @KodeToko VARCHAR(19)
	DECLARE @KodeSales VARCHAR(11)
	DECLARE @StsToko VARCHAR(2)
	DECLARE @AlamatKirim VARCHAR(60)
	DECLARE @Kota VARCHAR(20)
	DECLARE @DiscFormula VARCHAR(7)
	DECLARE @Disc1 DECIMAL(5, 2)
	DECLARE @Disc2 DECIMAL(5, 2)
	DECLARE @Disc3 DECIMAL(5, 2)
	DECLARE @Plafon MONEY
	DECLARE @SaldoPiutang MONEY
	DECLARE @QtyTolak INT
	DECLARE @Overdue MONEY
	DECLARE @isClosed BIT
	DECLARE @Catatan1 VARCHAR(40)
	DECLARE @Catatan2 VARCHAR(40)
	DECLARE @Catatan3 VARCHAR(40)
	DECLARE @Catatan4 VARCHAR(40)
	DECLARE @Catatan5 VARCHAR(40)
	DECLARE @NoDOBO VARCHAR(7)
	DECLARE @TglReorder DATETIME
	DECLARE @StatusBO BIT
	DECLARE @SyncFlag BIT
	DECLARE @LinkID VARCHAR(1)
	DECLARE @TransactionType VARCHAR(2)
	DECLARE @Expedisi VARCHAR(3)
	DECLARE @Shift VARCHAR(1)
	DECLARE @HariKredit INT
	DECLARE @HariKirim INT
	DECLARE @HariSales INT
	DECLARE @NPrINT INT
	DECLARE @LastUpdatedBy VARCHAR(250)
	DECLARE @LastUpdatedTime DATETIME	

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- INTerfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	
	DECLARE	@Temp TABLE
	(
		RowID UNIQUEIDENTIFIER,
		HtrID VARCHAR(23),
		Cabang1 VARCHAR(2),
		Cabang2 VARCHAR(2),
		Cabang3 VARCHAR(2),
		NoRequest VARCHAR(7),
		TglRequest DATETIME,
		NoDO VARCHAR(7),
		TglDO DATETIME,
		NoACCPusat VARCHAR(7),
		ACCPiutangID VARCHAR(11),
		NoACCPiutang VARCHAR(7),
		TglACCPiutang DATETIME,
		RpACCPiutang MONEY,
		RpPlafonToko MONEY,
		RpPiutangTerakhir MONEY,
		RpGiroTolakTerakhir MONEY,
		RpOverdue MONEY,
		StatusBatal VARCHAR(7),
		KodeToko VARCHAR(19),
		KodeSales VARCHAR(11),
		StsToko VARCHAR(2),
		AlamatKirim VARCHAR(60),
		Kota VARCHAR(20),
		DiscFormula VARCHAR(7),
		Disc1 DECIMAL(5, 2),
		Disc2 DECIMAL(5, 2),
		Disc3 DECIMAL(5, 2),
		Plafon MONEY,
		SaldoPiutang MONEY,
		QtyTolak INT,
		Overdue MONEY,
		isClosed BIT,
		Catatan1 VARCHAR(40),
		Catatan2 VARCHAR(40),
		Catatan3 VARCHAR(40),
		Catatan4 VARCHAR(40),
		Catatan5 VARCHAR(40),
		NoDOBO VARCHAR(7),
		TglReorder DATETIME,
		StatusBO BIT,
		SyncFlag BIT,
		LinkID VARCHAR(1),
		TransactionType VARCHAR(2),
		Expedisi VARCHAR(3),
		Shift VARCHAR(1),
		HariKredit INT,
		HariKirim INT,
		HariSales INT,
		NPrINT INT,
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME	
	)
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc
	INSERT INTO	@Temp
	(
		RowID, HtrID, Cabang1, Cabang2, Cabang3, NoRequest, TglRequest, NoDO, TglDO, NoACCPusat, ACCPiutangID, NoACCPiutang, TglACCPiutang, RpACCPiutang, RpPlafonToko, RpPiutangTerakhir, RpGiroTolakTerakhir, RpOverdue, StatusBatal, KodeToko, KodeSales, StsToko, AlamatKirim, Kota, DiscFormula, Disc1, Disc2, Disc3, isClosed, Catatan1, Catatan2, Catatan3, Catatan4, Catatan5, NoDOBO, TglReorder, StatusBO, SyncFlag, LinkID, TransactionType, Expedisi, Shift, HariKredit, HariKirim, HariSales, NPrint, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		HtrID, 
		Cabang1, 
		Cabang2, 
		Cabang3, 
		NoRequest, 
		TglRequest, 
		NoDO, 
		TglDO, 
		NoACCPusat, 
		ACCPiutangID, 
		NoACCPiutang, 
		TglACCPiutang, 
		RpACCPiutang, 
		RpPlafonToko, 
		RpPiutangTerakhir, 
		RpGiroTolakTerakhir, 
		RpOverdue, 
		StatusBatal, 
		KodeToko, 
		KodeSales, 
		StsToko, 
		AlamatKirim, 
		Kota, 
		DiscFormula, 
		Disc1, 
		Disc2, 
		Disc3, 
		isClosed, 
		Catatan1, 
		Catatan2, 
		Catatan3, 
		Catatan4, 
		Catatan5, 
		NoDOBO, 
		TglReorder, 
		StatusBO, 
		SyncFlag, 
		LinkID, 
		TransactionType, 
		Expedisi, 
		Shift, 
		HariKredit, 
		HariKirim, 
		HariSales, 
		NPrint, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		HtrID VARCHAR(23) '@HtrID',
		Cabang1 VARCHAR(2) '@Cabang1',
		Cabang2 VARCHAR(2) '@Cabang2',
		Cabang3 VARCHAR(2) '@Cabang3',
		NoRequest VARCHAR(7) '@NoRequest',
		TglRequest DATETIME '@TglRequest',
		NoDO VARCHAR(7) '@NoDO',
		TglDO DATETIME '@TglDO',
		NoACCPusat VARCHAR(7) '@NoACCPusat',
		ACCPiutangID VARCHAR(11) '@ACCPiutangID',
		NoACCPiutang VARCHAR(7) '@NoACCPiutang',
		TglACCPiutang DATETIME '@TglACCPiutang',
		RpACCPiutang MONEY '@RpACCPiutang',
		RpPlafonToko MONEY '@RpPlafonToko',
		RpPiutangTerakhir MONEY '@RpPiutangTerakhir',
		RpGiroTolakTerakhir MONEY '@RpGiroTolakTerakhir',
		RpOverdue MONEY '@RpOverdue',
		StatusBatal VARCHAR(7) '@StatusBatal',
		KodeToko VARCHAR(19) '@KodeToko',
		KodeSales VARCHAR(11) '@KodeSales',
		StsToko VARCHAR(2) '@StsToko',
		AlamatKirim VARCHAR(60) '@AlamatKirim',
		Kota VARCHAR(20) '@Kota',
		DiscFormula VARCHAR(7) '@DiscFormula',
		Disc1 DECIMAL(5, 2) '@Disc1',
		Disc2 DECIMAL(5, 2) '@Disc2',
		Disc3 DECIMAL(5, 2) '@Disc3',
		isClosed BIT '@isClosed',
		Catatan1 VARCHAR(40) '@Catatan1',
		Catatan2 VARCHAR(40) '@Catatan2',
		Catatan3 VARCHAR(40) '@Catatan3',
		Catatan4 VARCHAR(40) '@Catatan4',
		Catatan5 VARCHAR(40) '@Catatan5',
		NoDOBO VARCHAR(7) '@NoDOBO',
		TglReorder DATETIME '@TglReorder',
		StatusBO BIT '@StatusBO',
		SyncFlag BIT '@SyncFlag',
		LinkID VARCHAR(1) '@LinkID',
		TransactionType VARCHAR(2) '@TransactionType',
		Expedisi VARCHAR(3) '@Expedisi',
		Shift VARCHAR(1) '@Shift',
		HariKredit INT '@HariKredit',
		HariKirim INT '@HariKirim',
		HariSales INT '@HariSales',
		NPrint INT '@NPrint',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy',
		LastUpdatedTime DATETIME '@LastUpdatedTime'	
	)

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID, 
		HtrID, 
		Cabang1, 
		Cabang2, 
		Cabang3, 
		NoRequest, 
		TglRequest, 
		NoDO, 
		TglDO, 
		NoACCPusat, 
		ACCPiutangID, 
		NoACCPiutang, 
		TglACCPiutang, 
		RpACCPiutang, 
		RpPlafonToko, 
		RpPiutangTerakhir, 
		RpGiroTolakTerakhir, 
		RpOverdue, 
		StatusBatal, 
		KodeToko, 
		KodeSales, 
		StsToko, 
		AlamatKirim, 
		Kota, 
		DiscFormula, 
		Disc1, 
		Disc2, 
		Disc3, 
		isClosed, 
		Catatan1, 
		Catatan2, 
		Catatan3, 
		Catatan4, 
		Catatan5, 
		NoDOBO, 
		TglReorder, 
		StatusBO, 
		SyncFlag, 
		LinkID, 
		TransactionType, 
		Expedisi, 
		Shift, 
		HariKredit, 
		HariKirim, 
		HariSales, 
		NPrint, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
	
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
	@RowID, @HtrID, @Cabang1, @Cabang2, @Cabang3, @NoRequest, @TglRequest, @NoDO, @TglDO, @NoACCPusat, @ACCPiutangID, @NoACCPiutang, @TglACCPiutang, @RpACCPiutang, @RpPlafonToko, @RpPiutangTerakhir, @RpGiroTolakTerakhir, @RpOverdue, @StatusBatal, @KodeToko, @KodeSales, @StsToko, @AlamatKirim, @Kota, @DiscFormula, @Disc1, @Disc2, @Disc3, @isClosed, @Catatan1, @Catatan2, @Catatan3, @Catatan4, @Catatan5, @NoDOBO, @TglReorder, @StatusBO, @SyncFlag, @LinkID, @TransactionType, @Expedisi, @Shift, @HariKredit, @HariKirim, @HariSales, @NPrint, @LastUpdatedBy, @LastUpdatedTime		
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
	SET @SyncFlag = 1
	
	IF EXISTS (SELECT RowID FROM dbo.OrderPenjualan (NOLOCK) WHERE RowID = @RowID)
		UPDATE OrderPenjualan WITH (ROWLOCK)
		SET
			RowID = @RowID,
			HtrID = @HtrID,
			Cabang1 = @Cabang1,
			Cabang2 = @Cabang2,
			Cabang3 = @Cabang3,
			NoRequest = @NoRequest,
			TglRequest = @TglRequest,
			NoDO = @NoDO,
			TglDO = @TglDO,
			NoACCPusat = @NoACCPusat,
			ACCPiutangID = @ACCPiutangID,
			NoACCPiutang = @NoACCPiutang,
			TglACCPiutang = @TglACCPiutang,
			RpACCPiutang = @RpACCPiutang,
			RpPlafonToko = @RpPlafonToko,
			RpPiutangTerakhir = @RpPiutangTerakhir,
			RpGiroTolakTerakhir = @RpGiroTolakTerakhir,
			RpOverdue = @RpOverdue,
			StatusBatal = @StatusBatal,
			KodeToko = @KodeToko,
			KodeSales = @KodeSales,
			StsToko = @StsToko,
			AlamatKirim = @AlamatKirim,
			Kota = @Kota,
			DiscFormula = @DiscFormula,
			Disc1 = @Disc1,
			Disc2 = @Disc2,
			Disc3 = @Disc3,			
			isClosed = @isClosed,
			Catatan1 = @Catatan1,
			Catatan2 = @Catatan2,
			Catatan3 = @Catatan3,
			Catatan4 = @Catatan4,
			Catatan5 = @Catatan5,
			NoDOBO = @NoDOBO,
			TglReorder = @TglReorder,
			StatusBO = @StatusBO,
			SyncFlag = @SyncFlag,
			LinkID = @LinkID,
			TransactionType = @TransactionType,
			Expedisi = @Expedisi,
			Shift = @Shift,
			HariKredit = @HariKredit,
			HariKirim = @HariKirim,
			HariSales = @HariSales,
			NPrint = @NPrint,
			LastUpdatedBy = @LastUpdatedBy,
			LastUpdatedTime = @LastUpdatedTime	

		WHERE
			RowID = @RowID
	ELSE
		INSERT INTO dbo.OrderPenjualan WITH (ROWLOCK)
			(RowID, HtrID, Cabang1, Cabang2, Cabang3, NoRequest, TglRequest, NoDO, TglDO, NoACCPusat, ACCPiutangID, NoACCPiutang, TglACCPiutang, RpACCPiutang, RpPlafonToko, RpPiutangTerakhir, RpGiroTolakTerakhir, RpOverdue, StatusBatal, KodeToko, KodeSales, StsToko, AlamatKirim, Kota, DiscFormula, Disc1, Disc2, Disc3, isClosed, Catatan1, Catatan2, Catatan3, Catatan4, Catatan5, NoDOBO, TglReorder, StatusBO, SyncFlag, LinkID, TransactionType, Expedisi, Shift, HariKredit, HariKirim, HariSales, NPrint, LastUpdatedBy, LastUpdatedTime)
		VALUES	(@RowID,
				@HtrID,
				@Cabang1,
				@Cabang2,
				@Cabang3,
				@NoRequest,
				@TglRequest,
				@NoDO,
				@TglDO,
				@NoACCPusat,
				@ACCPiutangID,
				@NoACCPiutang,
				@TglACCPiutang,
				@RpACCPiutang,
				@RpPlafonToko,
				@RpPiutangTerakhir,
				@RpGiroTolakTerakhir,
				@RpOverdue,
				@StatusBatal,
				@KodeToko,
				@KodeSales,
				@StsToko,
				@AlamatKirim,
				@Kota,
				@DiscFormula,
				@Disc1,
				@Disc2,
				@Disc3,
				@isClosed,
				@Catatan1,
				@Catatan2,
				@Catatan3,
				@Catatan4,
				@Catatan5,
				@NoDOBO,
				@TglReorder,
				@StatusBO,
				@SyncFlag,
				@LinkID,
				@TransactionType,
				@Expedisi,
				@Shift,
				@HariKredit,
				@HariKirim,
				@HariSales,
				@NPrint,
				@LastUpdatedBy,
				@LastUpdatedTime	
				)

		
		FETCH NEXT FROM data_cursor INTO
		@RowID, @HtrID, @Cabang1, @Cabang2, @Cabang3, @NoRequest, @TglRequest, @NoDO, @TglDO, @NoACCPusat, @ACCPiutangID, @NoACCPiutang, @TglACCPiutang, @RpACCPiutang, @RpPlafonToko, @RpPiutangTerakhir, @RpGiroTolakTerakhir, @RpOverdue, @StatusBatal, @KodeToko, @KodeSales, @StsToko, @AlamatKirim, @Kota, @DiscFormula, @Disc1, @Disc2, @Disc3, @isClosed, @Catatan1, @Catatan2, @Catatan3, @Catatan4, @Catatan5, @NoDOBO, @TglReorder, @StatusBO, @SyncFlag, @LinkID, @TransactionType, @Expedisi, @Shift, @HariKredit, @HariKirim, @HariSales, @NPrint, @LastUpdatedBy, @LastUpdatedTime				
	END
	
	CLOSE data_cursor
	
	DEALLOCATE data_cursor
	
END




 
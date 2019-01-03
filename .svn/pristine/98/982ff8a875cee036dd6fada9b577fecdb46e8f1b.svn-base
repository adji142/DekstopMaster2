USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_NotaPenjualan]    Script Date: 10/11/2011 13:47:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


    
-- =============================================    
-- Author:  Nobon    
-- Create date: 20 May 2011    
-- Description: <Description,,>    
-- =============================================    
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_NotaPenjualan]     
 -- Add the parameters for the stored procedure here    
 @doc text = '<root><row/></root>'    
    
AS    
BEGIN     
 DECLARE @hdoc INT    
 DECLARE @RowID UNIQUEIDENTIFIER    
 DECLARE @HtrID VARCHAR(23)    
 DECLARE @RecordID VARCHAR(23)    
 DECLARE @DOID UNIQUEIDENTIFIER 
 DECLARE @Cabang1 VARCHAR(2)
 DECLARE @Cabang2 VARCHAR(2)
 DECLARE @Cabang3 VARCHAR(2) 
 DECLARE @NoNota VARCHAR(7)    
 DECLARE @TglNota DATETIME    
 DECLARE @NoSuratJalan VARCHAR(7)    
 DECLARE @TglSuratJalan DATETIME 
 DECLARE @KodeToko VARCHAR(19)
 DECLARE @KodeSales VARCHAR(11)
 DECLARE @TglTerima DATETIME    
 DECLARE @TglSerahTerimaChecker DATETIME    
 DECLARE @TglExpedisi DATETIME    
 DECLARE @AlamatKirim VARCHAR(60)    
 DECLARE @Kota VARCHAR(20)    
 DECLARE @isClosed BIT    
 DECLARE @Catatan1 VARCHAR(40)    
 DECLARE @Catatan2 VARCHAR(40)    
 DECLARE @Catatan3 VARCHAR(40)    
 DECLARE @Catatan4 VARCHAR(40)    
 DECLARE @Catatan5 VARCHAR(40)    
 DECLARE @SyncFlag BIT    
 DECLARE @LinkID VARCHAR(1)    
 DECLARE @NPrint INT    
 DECLARE @TransactionType VARCHAR(2)  
 DECLARE @HariKredit INT
 DECLARE @HariKirim INT
 DECLARE @HariSales INT
 DECLARE @Checker1 VARCHAR(11)    
 DECLARE @Checker2 VARCHAR(11)    
 DECLARE @LastUpdatedBy VARCHAR(250)    
 DECLARE @LastUpdatedTime DATETIME    
    
 -- SET NOCOUNT ON added to prevent extra result sets from    
 -- INTerfering with SELECT statements.    
 SET NOCOUNT ON;    
 SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;    
     
	DECLARE @Temp TABLE
	(
		 RowID UNIQUEIDENTIFIER ,   
		 HtrID VARCHAR(23),
		 RecordID VARCHAR(23),
		 DOID UNIQUEIDENTIFIER, 
		 Cabang1 VARCHAR(2),
		 Cabang2 VARCHAR(2),
		 Cabang3 VARCHAR(2),
		 NoNota VARCHAR(7), 
		 TglNota DATETIME,  
		 NoSuratJalan VARCHAR(7),
		 TglSuratJalan DATETIME,
		 KodeToko VARCHAR(19),
		 KodeSales VARCHAR(11),
		 TglTerima DATETIME,
		 TglSerahTerimaChecker DATETIME,
		 TglExpedisi DATETIME,
		 AlamatKirim VARCHAR(60),
		 Kota VARCHAR(20),
		 isClosed BIT,
		 Catatan1 VARCHAR(40), 
		 Catatan2 VARCHAR(40),   
		 Catatan3 VARCHAR(40),   
		 Catatan4 VARCHAR(40),   
		 Catatan5 VARCHAR(40),   
		 SyncFlag BIT,
		 LinkID VARCHAR(1),
		 NPrint INT,
		 TransactionType VARCHAR(2),
		 HariKredit INT,
		 HariKirim INT,
		 HariSales INT,
		 Checker1 VARCHAR(11),
		 Checker2 VARCHAR(11),   
		 LastUpdatedBy VARCHAR(250),
		 LastUpdatedTime DATETIME   
	)

		exec sp_xml_preparedocument @hdoc OUTPUT, @doc

	INSERT INTO @Temp
	(
		RowID, HtrID, RecordID, DOID, Cabang1, Cabang2, Cabang3, NoNota, TglNota, NoSuratJalan, TglSuratJalan, KodeToko, KodeSales, TglTerima, TglSerahTerimaChecker, TglExpedisi, AlamatKirim, Kota, isClosed, Catatan1, Catatan2, Catatan3, Catatan4, Catatan5, SyncFlag, LinkID, NPrint, TransactionType, HariKredit, HariKirim, HariSales, Checker1, Checker2, LastUpdatedBy, LastUpdatedTime
	) 
	SELECT   
		RowID, 
		HtrID, 
		RecordID, 
		DOID, 
		Cabang1, 
		Cabang2, 
		Cabang3, 
		NoNota, 
		TglNota, 
		NoSuratJalan, 
		TglSuratJalan, 
		KodeToko, 
		KodeSales, 
		TglTerima, 
		TglSerahTerimaChecker, 
		TglExpedisi, 
		AlamatKirim, 
		Kota,	
		isClosed, 
		Catatan1, 
		Catatan2, 
		Catatan3, 
		Catatan4, 
		Catatan5, 
		SyncFlag, 
		LinkID, 
		NPrint, 
		TransactionType, 
		HariKredit, 
		HariKirim, 
		HariSales, 
		Checker1, 
		Checker2, 
		LastUpdatedBy, 
		LastUpdatedTime  		   
	FROM    
	OPENXML(@hdoc, 'root/row')    
	WITH     
	(     
		 RowID UNIQUEIDENTIFIER '@RowID',    
		 HtrID VARCHAR(23) '@HtrID',    
		 RecordID VARCHAR(23) '@RecordID',    
		 DOID UNIQUEIDENTIFIER '@DOID',
		 Cabang1 VARCHAR(2) '@Cabang1',
		 Cabang2 VARCHAR(2) '@Cabang2',
		 Cabang3 VARCHAR(2) '@Cabang3',
		 NoNota VARCHAR(7) '@NoNota',    
		 TglNota DATETIME '@TglNota',    
		 NoSuratJalan VARCHAR(7) '@NoSuratJalan',    
		 TglSuratJalan DATETIME '@TglSuratJalan', 
		 KodeToko VARCHAR(19) '@KodeToko',
		 KodeSales VARCHAR(11) '@KodeSales',
		 TglTerima DATETIME '@TglTerima',    
		 TglSerahTerimaChecker DATETIME '@TglSerahTerimaChecker',    
		 TglExpedisi DATETIME '@TglExpedisi',    
		 AlamatKirim VARCHAR(60) '@AlamatKirim',    
		 Kota VARCHAR(20) '@Kota',    
		 isClosed BIT '@isClosed',    
		 Catatan1 VARCHAR(40) '@Catatan1',    
		 Catatan2 VARCHAR(40) '@Catatan2',    
		 Catatan3 VARCHAR(40) '@Catatan3',    
		 Catatan4 VARCHAR(40) '@Catatan4',    
		 Catatan5 VARCHAR(40) '@Catatan5',    
		 SyncFlag BIT '@SyncFlag',    
		 LinkID VARCHAR(1) '@LinkID',    
		 NPrint INT '@NPrint',    
		 TransactionType VARCHAR(2) '@TransactionType', 
		 HariKredit INT '@HariKredit',
		 HariKirim INT '@HariKirim',
		 HariSales INT '@HariSales',
		 Checker1 VARCHAR(11) '@Checker1',    
		 Checker2 VARCHAR(11) '@Checker2',    
		 LastUpdatedBy VARCHAR(250) '@LastUpdatedBy',    
		 LastUpdatedTime DATETIME '@LastUpdatedTime'    
	)    

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR     
	SELECT   
		RowID, 
		HtrID, 
		RecordID, 
		DOID, 
		Cabang1, 
		Cabang2, 
		Cabang3, 
		NoNota, 
		TglNota, 
		NoSuratJalan, 
		TglSuratJalan, 
		KodeToko, 
		KodeSales, 
		TglTerima, 
		TglSerahTerimaChecker, 
		TglExpedisi, 
		AlamatKirim, 
		Kota,	
		isClosed, 
		Catatan1, 
		Catatan2, 
		Catatan3, 
		Catatan4, 
		Catatan5, 
		SyncFlag, 
		LinkID, 
		NPrint, 
		TransactionType, 
		HariKredit, 
		HariKirim, 
		HariSales, 
		Checker1, 
		Checker2, 
		LastUpdatedBy, 
		LastUpdatedTime  		   
	FROM @Temp
       
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @HtrID, @RecordID, @DOID, @Cabang1, @Cabang2, @Cabang3, @NoNota, @TglNota, @NoSuratJalan, @TglSuratJalan, @KodeToko, @KodeSales, @TglTerima, @TglSerahTerimaChecker, @TglExpedisi, @AlamatKirim, @Kota, @isClosed, @Catatan1, @Catatan2, @Catatan3, @Catatan4, @Catatan5, @SyncFlag, @LinkID, @NPrint, @TransactionType, @HariKredit, @HariKirim, @HariSales, @Checker1, @Checker2, @LastUpdatedBy, @LastUpdatedTime

	WHILE @@FETCH_STATUS = 0
	BEGIN
		  -- Insert statements for procedure here    
		  SET @SyncFlag = 1
		  
		 IF EXISTS (SELECT TOP 1 RowID FROM dbo.NotaPenjualan (NOLOCK) WHERE HtrID = @HtrID)    
		  UPDATE NotaPenjualan    WITH (ROWLOCK)
		  SET    
			RecordID = @RecordID, 
			HtrID = @HtrID, 
			DOID = @DOID,  
			Cabang1 = @Cabang1,
			Cabang2 = @Cabang2,
			Cabang3 = @Cabang3,   
			NoNota = @NoNota,    
			TglNota =  (CASE WHEN (TglTerima IS NOT NULL) THEN TglTerima ELSE @TglNota END ),      
			NoSuratJalan = @NoSuratJalan,    
			TglSuratJalan = @TglSuratJalan, 
			KodeToko = @KodeToko,
			KodeSales = @KodeSales,   
			TglTerima = (CASE WHEN (TglTerima IS NOT NULL) THEN TglTerima ELSE @TglTerima END ),    
			TglSerahTerimaChecker = @TglSerahTerimaChecker,    
			TglExpedisi = @TglExpedisi,    
			AlamatKirim = @AlamatKirim,    
			Kota = @Kota,    
			isClosed = @isClosed,    
			Catatan1 = @Catatan1,    
			Catatan2 = @Catatan2,    
			Catatan3 = @Catatan3,    
			Catatan4 = @Catatan4,    
			Catatan5 = @Catatan5,    
			SyncFlag = @SyncFlag,    
			LinkID = (CASE WHEN (LinkID='') THEN @LinkID ELSE LinkID END ),    
			NPrint = @NPrint,    
			TransactionType = @TransactionType, 
			HariKredit = @HariKredit,
			HariKirim = @HariKirim,
			HariSales = @HariSales,   
			Checker1 = @Checker1,    
			Checker2 = @Checker2,    
			LastUpdatedBy = @LastUpdatedBy,    
			LastUpdatedTime = @LastUpdatedTime    
		  WHERE    
		   HtrID = @HtrID   
		 ELSE    
		  INSERT INTO NotaPenjualan    WITH (ROWLOCK)
		  (RowID, HtrID, RecordID, DOID, Cabang1, Cabang2, Cabang3, NoNota, TglNota, NoSuratJalan, TglSuratJalan, KodeToko, KodeSales, TglTerima, TglSerahTerimaChecker, TglExpedisi, AlamatKirim, Kota, isClosed, Catatan1, Catatan2, Catatan3, Catatan4, Catatan5, SyncFlag, LinkID, NPrint, TransactionType, HariKredit, HariKirim, HariSales, Checker1, Checker2, LastUpdatedBy, LastUpdatedTime)
		  VALUES (    
			 @RowID,    
			 @HtrID,    
			 @RecordID,    
			 @DOID, 
			 @Cabang1,
			 @Cabang2,
			 @Cabang3,   
			 @NoNota,    
			 @TglNota,    
			 @NoSuratJalan,    
			 @TglSuratJalan, 
			 @KodeToko,
			 @KodeSales,    
			 @TglTerima,    
			 @TglSerahTerimaChecker,    
			 @TglExpedisi,    
			 @AlamatKirim,    
			 @Kota,    
			 @isClosed,    
			 @Catatan1,    
			 @Catatan2,    
			 @Catatan3,    
			 @Catatan4,    
			 @Catatan5,    
			 @SyncFlag,    
			 @LinkID,    
			 @NPrint,    
			 @TransactionType,   
			 @HariKredit,
			 @HariKirim,
			 @HariSales,  
			 @Checker1,    
			 @Checker2,    
			 @LastUpdatedBy,    
			 @LastUpdatedTime    
			)  
		FETCH NEXT FROM data_cursor INTO
		@RowID, @HtrID, @RecordID, @DOID, @Cabang1, @Cabang2, @Cabang3, @NoNota, @TglNota, @NoSuratJalan, @TglSuratJalan, @KodeToko, @KodeSales, @TglTerima, @TglSerahTerimaChecker, @TglExpedisi, @AlamatKirim, @Kota, @isClosed, @Catatan1, @Catatan2, @Catatan3, @Catatan4, @Catatan5, @SyncFlag, @LinkID, @NPrint, @TransactionType, @HariKredit, @HariKirim, @HariSales, @Checker1, @Checker2, @LastUpdatedBy, @LastUpdatedTime

	END  
	
	CLOSE data_cursor	
	DEALLOCATE data_cursor
			

	
END    

 
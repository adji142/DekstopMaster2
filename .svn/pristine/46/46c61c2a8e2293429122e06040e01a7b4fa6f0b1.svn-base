USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_NotaPenjualanDetail]    Script Date: 10/11/2011 13:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Nobon
-- Create date: 20 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_NotaPenjualanDetail '<root><row RowID="F0EA040B-54D0-495F-95D2-4DDF2759CCA0" HeaderID="B5463EC3-6D8D-49E9-BEF2-880C794C7FB0" DODetailID="D182D136-8396-4CD0-AC57-4B14DC7CE116" RecordID="C092004040310:44:45YT05" HtrID="C092004040310:44:43YTN" KodeGudang="0901" QtySuratJalan="3" QtyNota="3" QtyKoli="0" KoliAwal="1" KoliAkhir="0" NoKoli="01             " Catatan="                       " SyncFlag="1" KetKoli="                    " NPackingListPrint="1" LastUpdatedBy="Admin" LastUpdatedTime="2011-05-16T10:26:25.450"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_NotaPenjualanDetail] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @HeaderID UNIQUEIDENTIFIER
	DECLARE @DOID UNIQUEIDENTIFIER
	DECLARE @DODetailID UNIQUEIDENTIFIER
	DECLARE @RecordID VARCHAR(23)
	DECLARE @HtrID VARCHAR(23)
	DECLARE @KodeGudang VARCHAR(4)
	DECLARE @BarangID VARCHAR(23)
	DECLARE @QtySuratJalan INT
	DECLARE @QtyNota INT
	DECLARE @HrgJual MONEY 
	DECLARE @Disc1 DECIMAL(5,2)
	DECLARE @Disc2 DECIMAL(5,2)
	DECLARE @Disc3 DECIMAL(5,2)
	DECLARE @Pot MONEY
	DECLARE @DiscFormula VARCHAR(7)
	DECLARE @QtyKoli INT
	DECLARE @KoliAwal INT
	DECLARE @KoliAkhir INT
	DECLARE @NoKoli VARCHAR(15)
	DECLARE @Catatan VARCHAR(23)
	DECLARE @SyncFlag BIT
	DECLARE @KetKoli VARCHAR(20)
	DECLARE @NPackingListPrint VARCHAR(1)
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
		DOID UNIQUEIDENTIFIER,
		DODetailID UNIQUEIDENTIFIER,
		RecordID VARCHAR(23),
		HtrID VARCHAR(23),
		KodeGudang VARCHAR(4),
		BarangID VARCHAR(23),
		QtySuratJalan INT,
		QtyNota INT,
		HrgJual MONEY ,
		Disc1 DECIMAL(5,2),
		Disc2 DECIMAL(5,2),
		Disc3 DECIMAL(5,2),
		Pot MONEY,
		DiscFormula VARCHAR(7),
		QtyKoli INT,
		KoliAwal INT,
		KoliAkhir INT,
		NoKoli VARCHAR(15),
		Catatan VARCHAR(23),
		SyncFlag BIT,
		KetKoli VARCHAR(20),
		NPackingListPrint VARCHAR(1),
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)

		exec sp_xml_preparedocument @hdoc OUTPUT, @doc

	INSERT INTO @Temp
	(
		RowID, HeaderID, DOID, DODetailID, RecordID, HtrID, KodeGudang, BarangID, QtySuratJalan, QtyNota, HrgJual, Disc1, Disc2, Disc3, Pot, DiscFormula, QtyKoli, KoliAwal, KoliAkhir, NoKoli, Catatan, SyncFlag, KetKoli, NPackingListPrint, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID,
		HeaderID, 
		DOID, 
		DODetailID, 
		RecordID, 
		HtrID, 
		KodeGudang, 
		BarangID, 
		QtySuratJalan, 
		QtyNota, 
		HrgJual, 
		Disc1, 
		Disc2, 
		Disc3, 
		Pot, 
		DiscFormula, 
		QtyKoli, 
		KoliAwal, 
		KoliAkhir, 
		NoKoli, 
		Catatan, 
		SyncFlag, 
		KetKoli, 
		NPackingListPrint, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		HeaderID UNIQUEIDENTIFIER '@HeaderID',
		DOID UNIQUEIDENTIFIER '@DOID',
		DODetailID UNIQUEIDENTIFIER '@DODetailID',
		RecordID VARCHAR(23) '@RecordID',
		HtrID VARCHAR(23) '@HtrID',
		KodeGudang VARCHAR(4) '@KodeGudang',
		BarangID VARCHAR(23) '@BarangID ',
		QtySuratJalan INT '@QtySuratJalan',
		QtyNota INT '@QtyNota',
		HrgJual MONEY '@HrgJual',
		Disc1 DECIMAL(5,2) '@Disc1',
		Disc2 DECIMAL(5,2) '@Disc2',
		Disc3 DECIMAL(5,2) '@Disc3',
		Pot MONEY '@Pot',
		DiscFormula VARCHAR(7) '@DiscFormula',
		QtyKoli INT '@QtyKoli',
		KoliAwal INT '@KoliAwal',
		KoliAkhir INT '@KoliAkhir',
		NoKoli VARCHAR(15) '@NoKoli',
		Catatan VARCHAR(23) '@Catatan',
		SyncFlag BIT '@SyncFlag',
		KetKoli VARCHAR(20) '@KetKoli',
		NPackingListPrint VARCHAR(1) '@NPackingListPrint',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy',
		LastUpdatedTime DATETIME '@LastUpdatedTime'
	)

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID,
		HeaderID, 
		DOID, 
		DODetailID, 
		RecordID, 
		HtrID, 
		KodeGudang, 
		BarangID, 
		QtySuratJalan, 
		QtyNota, 
		HrgJual, 
		Disc1, 
		Disc2, 
		Disc3, 
		Pot, 
		DiscFormula, 
		QtyKoli, 
		KoliAwal, 
		KoliAkhir, 
		NoKoli, 
		Catatan, 
		SyncFlag, 
		KetKoli, 
		NPackingListPrint, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @HeaderID, @DOID, @DODetailID, @RecordID, @HtrID, @KodeGudang, @BarangID, @QtySuratJalan, @QtyNota, @HrgJual, @Disc1, @Disc2, @Disc3, @Pot, @DiscFormula, @QtyKoli, @KoliAwal, @KoliAkhir, @NoKoli, @Catatan, @SyncFlag, @KetKoli, @NPackingListPrint, @LastUpdatedBy, @LastUpdatedTime

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		 SET @SyncFlag = 1
		IF EXISTS (SELECT TOP 1 RowID FROM dbo.NotaPenjualanDetail (NOLOCK) WHERE HtrID = @HtrID)
			UPDATE NotaPenjualanDetail WITH (ROWLOCK)
			SET
				RecordID = @RecordID,
				HtrID = @HtrID,
				DOID = @DOID,
				KodeGudang = @KodeGudang,
				BarangID = @BarangID,
				QtySuratJalan = @QtySuratJalan,
				QtyNota = @QtyNota,
				HrgJual =@HrgJual,
				Disc1 = @Disc1,
				Disc2 = @Disc2,
				Disc3 = @Disc3,
				Pot = @Pot,
				DiscFormula = @DiscFormula,
				QtyKoli = @QtyKoli,
				KoliAwal = @KoliAwal,
				KoliAkhir = @KoliAkhir,
				NoKoli = @NoKoli,
				Catatan = @Catatan,
				SyncFlag = @SyncFlag,
				KetKoli = @KetKoli,
				NPackingListPrint = @NPackingListPrint,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			IF EXISTS (SELECT RowID FROM dbo.NotaPenjualan (NOLOCK) WHERE RowID=@HeaderID)
			BEGIN 
				INSERT INTO NotaPenjualanDetail WITH (ROWLOCK)
				(RowID, HeaderID, DOID, DODetailID, RecordID, HtrID, KodeGudang, BarangID, QtySuratJalan, QtyNota, HrgJual, Disc1, Disc2, Disc3, Pot, DiscFormula, QtyKoli, KoliAwal, KoliAkhir, NoKoli, Catatan, SyncFlag, KetKoli, NPackingListPrint, LastUpdatedBy, LastUpdatedTime)
				VALUES	(
							@RowID,
							@HeaderID,
							@DOID,
							@DODetailID,
							@RecordID,
							@HtrID,
							@KodeGudang,
							@BarangID,
							@QtySuratJalan,
							@QtyNota,
							@HrgJual,
							@Disc1,
							@Disc2,
							@Disc3,
							@Pot,
							@DiscFormula,
							@QtyKoli,
							@KoliAwal,
							@KoliAkhir,
							@NoKoli,
							@Catatan,
							@SyncFlag,
							@KetKoli,
							@NPackingListPrint,
							@LastUpdatedBy,
							@LastUpdatedTime
						)
			END
		FETCH NEXT FROM data_cursor INTO
		@RowID, @HeaderID, @DOID, @DODetailID, @RecordID, @HtrID, @KodeGudang, @BarangID, @QtySuratJalan, @QtyNota, @HrgJual, @Disc1, @Disc2, @Disc3, @Pot, @DiscFormula, @QtyKoli, @KoliAwal, @KoliAkhir, @NoKoli, @Catatan, @SyncFlag, @KetKoli, @NPackingListPrint, @LastUpdatedBy, @LastUpdatedTime

	END
	
	CLOSE data_cursor	
	DEALLOCATE data_cursor
			

	
END


 
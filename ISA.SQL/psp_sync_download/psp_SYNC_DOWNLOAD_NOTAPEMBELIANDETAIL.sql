USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_NotaPembelianDetail]    Script Date: 10/11/2011 13:47:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nobon
-- Create date: 20 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_NotaPembelianDetail '<root><row RowID="2E992694-A28B-4F69-A53C-4ECD77502D54" HeaderID="1407FEEA-8966-495B-B62B-78C500EED378" RecordID="2008122012:31:45_BO_  1" HeaderRecID="JKT2008122012:31:45REN1" BarangID="FE4WCF1055BG" QtyRequest="102" QtyDO="102" QtySuratJalan="108" QtyNota="108" Catatan="" TglTerima="2008-12-27T00:00:00" HrgPokok="0.0000" HPPSolo="0.0000" Pot="0.0000" Disc1="0.00" Disc2="0.00" Disc3="0.00" DiscFormula="" PPN="0" KodeGudang="0901" KoreksiID="" SyncFlag="1" LastUpdatedBy="Admin" LastUpdatedTime="2011-04-04T09:23:46.373"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_NotaPembelianDetail] 
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
	DECLARE @QtyRequest INT
	DECLARE @QtyDO INT
	DECLARE @QtySuratJalan INT
	DECLARE @QtyNota INT
	DECLARE @Catatan VARCHAR(23)
	DECLARE @TglTerima DATETIME
	DECLARE @HrgBeli MONEY
	DECLARE @HrgPokok MONEY
	DECLARE @HPPSolo MONEY
	DECLARE @Pot MONEY
	DECLARE @Disc1 NUMERIC(5, 2)
	DECLARE @Disc2 NUMERIC(5, 2)
	DECLARE @Disc3 NUMERIC(5, 2)
	DECLARE @DiscFormula VARCHAR(7)
	DECLARE @PPN NUMERIC(3, 0)
	DECLARE @KodeGudang VARCHAR(4)
	DECLARE @KoreksiID VARCHAR(19)
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
		RecordID VARCHAR(23),
		HeaderRecID VARCHAR(23),
		BarangID VARCHAR(23),
		QtyRequest INT,
		QtyDO INT,
		QtySuratJalan INT,
		QtyNota INT,
		Catatan VARCHAR(23),
		TglTerima DATETIME,
		HrgBeli MONEY,
		HrgPokok MONEY,
		HPPSolo MONEY,
		Pot MONEY,
		Disc1 NUMERIC(5, 2),
		Disc2 NUMERIC(5, 2),
		Disc3 NUMERIC(5, 2),
		DiscFormula VARCHAR(7),
		PPN NUMERIC(3, 0),
		KodeGudang VARCHAR(4),
		KoreksiID VARCHAR(19),
		SyncFlag BIT,
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)

		exec sp_xml_preparedocument @hdoc OUTPUT, @doc

	INSERT INTO @Temp
	(
		RowID, HeaderID, RecordID, HeaderRecID, BarangID, QtyRequest, QtyDO, QtySuratJalan, QtyNota, Catatan, TglTerima, HrgBeli, HrgPokok, HPPSolo, Pot, Disc1, Disc2, Disc3, DiscFormula, PPN, KodeGudang, KoreksiID, SyncFlag, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		HeaderID, 
		RecordID, 
		HeaderRecID, 
		BarangID, 
		QtyRequest, 
		QtyDO, 
		QtySuratJalan, 
		QtyNota, 
		Catatan, 
		TglTerima, 
		HrgBeli, 
		HrgPokok, 
		HPPSolo, 
		Pot, 
		Disc1, 
		Disc2, 
		Disc3, 
		DiscFormula, 
		PPN, 
		KodeGudang, 
		KoreksiID, 
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
		QtyRequest INT '@QtyRequest',
		QtyDO INT '@QtyDO',
		QtySuratJalan INT '@QtySuratJalan',
		QtyNota INT '@QtyNota',
		Catatan VARCHAR(23) '@Catatan',
		TglTerima DATETIME '@TglTerima',
		HrgBeli MONEY '@HrgBeli',
		HrgPokok MONEY '@HrgPokok',
		HPPSolo MONEY '@HPPSolo',
		Pot MONEY '@Pot',
		Disc1 NUMERIC(5, 2) '@Disc1',
		Disc2 NUMERIC(5, 2) '@Disc2',
		Disc3 NUMERIC(5, 2) '@Disc3',
		DiscFormula VARCHAR(7) '@DiscFormula',
		PPN NUMERIC(3, 0) '@PPN',
		KodeGudang VARCHAR(4) '@KodeGudang',
		KoreksiID VARCHAR(19) '@KoreksiID',
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
		QtyRequest, 
		QtyDO, 
		QtySuratJalan, 
		QtyNota, 
		Catatan, 
		TglTerima, 
		HrgBeli, 
		HrgPokok, 
		HPPSolo, 
		Pot, 
		Disc1, 
		Disc2, 
		Disc3, 
		DiscFormula, 
		PPN, 
		KodeGudang, 
		KoreksiID, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @HeaderID, @RecordID, @HeaderRecID, @BarangID, @QtyRequest, @QtyDO, @QtySuratJalan, @QtyNota, @Catatan, @TglTerima, @HrgBeli, @HrgPokok, @HPPSolo, @Pot, @Disc1, @Disc2, @Disc3, @DiscFormula, @PPN, @KodeGudang, @KoreksiID, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.NotaPembelianDetail (NOLOCK) WHERE RowID = @RowID)
			UPDATE NotaPembelianDetail WITH (ROWLOCK)
			SET
				RowID = @RowID,
				HeaderID = @HeaderID,
				RecordID = @RecordID,
				HeaderRecID = @HeaderRecID,
				BarangID = @BarangID,
				QtyRequest = @QtyRequest,
				QtyDO = @QtyDO,
				QtySuratJalan = @QtySuratJalan,
				QtyNota = @QtyNota,
				Catatan = @Catatan,
				TglTerima = @TglTerima,
				HrgBeli = @HrgBeli,
				HrgPokok = @HrgPokok,
				HPPSolo = @HPPSolo,
				Pot = @Pot,
				Disc1 = @Disc1,
				Disc2 = @Disc2,
				Disc3 = @Disc3,
				DiscFormula = @DiscFormula,
				PPN = @PPN,
				KodeGudang = @KodeGudang,
				KoreksiID = @KoreksiID,
				SyncFlag = @SyncFlag,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			IF EXISTS (SELECT RowID FROM dbo.NotaPembelian (NOLOCK) WHERE RowID=@HeaderID)
			BEGIN 
				INSERT INTO NotaPembelianDetail WITH (ROWLOCK)
				(RowID, HeaderID, RecordID, HeaderRecID, BarangID, QtyRequest, QtyDO, QtySuratJalan, QtyNota, Catatan, TglTerima, HrgBeli, HrgPokok, HPPSolo, Pot, Disc1, Disc2, Disc3, DiscFormula, PPN, KodeGudang, KoreksiID, SyncFlag, LastUpdatedBy, LastUpdatedTime)
				VALUES	(
							@RowID,
							@HeaderID,
							@RecordID,
							@HeaderRecID,
							@BarangID,
							@QtyRequest,
							@QtyDO,
							@QtySuratJalan,
							@QtyNota,
							@Catatan,
							@TglTerima,
							@HrgBeli,
							@HrgPokok,
							@HPPSolo,
							@Pot,
							@Disc1,
							@Disc2,
							@Disc3,
							@DiscFormula,
							@PPN,
							@KodeGudang,
							@KoreksiID,
							@SyncFlag,
							@LastUpdatedBy,
							@LastUpdatedTime
						)
			END
		FETCH NEXT FROM data_cursor INTO
		@RowID, @HeaderID, @RecordID, @HeaderRecID, @BarangID, @QtyRequest, @QtyDO, @QtySuratJalan, @QtyNota, @Catatan, @TglTerima, @HrgBeli, @HrgPokok, @HPPSolo, @Pot, @Disc1, @Disc2, @Disc3, @DiscFormula, @PPN, @KodeGudang, @KoreksiID, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	END

	CLOSE data_cursor	
	DEALLOCATE data_cursor
			

	
END



 
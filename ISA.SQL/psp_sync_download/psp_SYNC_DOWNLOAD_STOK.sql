 USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_Stok]    Script Date: 10/11/2011 13:49:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Nobon
-- Create date: 23 May 2011
-- Description:	<Description,,>
-- exec dbo.psp_SYNC_DOWNLOAD_Stok '<root><row RowID="FFAABE02-2D5A-4EA1-B71B-C81F9E6827D2" BarangID="                    FB4" RecordID="" Bundle="" NamaStok="XXX" KodeSolo="   " Kendaraan="" NamaTertera="" PartNo="" Merek="" Dibungkus="" SumberDr="" ProsesID="" SatSolo="" Material="" SatJual="" KodeRak="" KodeRak1="" KodeRak2="" JB="" StatusPasif="0" SyncFlag="0" PrediksiLamaKirim="0" HariRataRata="0" StokMin="0" StokMax="0" IsiKoli="0" LastUpdatedBy="admin" LastUpdatedTime="2011-05-19T15:23:22.357"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_Stok]
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @BarangID VARCHAR(23)
	DECLARE @RecordID VARCHAR(23)
	DECLARE @Bundle VARCHAR(3)
	DECLARE @NamaStok VARCHAR(73)
	--DECLARE @KodeSolo VARCHAR(3)
	DECLARE @Kendaraan VARCHAR(43)
	DECLARE @NamaTertera VARCHAR(43)
	DECLARE @PartNo VARCHAR(21)
	DECLARE @Merek VARCHAR(23)
	DECLARE @Dibungkus VARCHAR(1)
	DECLARE @SumberDr VARCHAR(3)
	DECLARE @ProsesID VARCHAR(1)
	DECLARE @SatSolo VARCHAR(3)
	DECLARE @Material VARCHAR(19)
	DECLARE @SatJual VARCHAR(3)
	DECLARE @KodeRak VARCHAR(7)
	DECLARE @KodeRak1 VARCHAR(7)
	DECLARE @KodeRak2 VARCHAR(7)
	DECLARE @JB VARCHAR(2)
	DECLARE @StatusPasif BIT
	DECLARE @SyncFlag BIT
	DECLARE @PrediksiLamaKirim INT
	DECLARE @HariRataRata INT
	DECLARE @StokMin INT
	DECLARE @StokMax INT
	DECLARE @IsiKoli INT
	DECLARE @LastUpdatedBy VARCHAR(250)
	DECLARE @LastUpdatedTime DATETIME

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- INTerfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	
	DECLARE @Temp TABLE
	(
		RowID UNIQUEIDENTIFIER,
		BarangID VARCHAR(23),
		RecordID VARCHAR(23),
		Bundle VARCHAR(3),
		NamaStok VARCHAR(73),
		--KodeSolo VARCHAR(3)
		Kendaraan VARCHAR(43),
		NamaTertera VARCHAR(43),
		PartNo VARCHAR(21),
		Merek VARCHAR(23),
		Dibungkus VARCHAR(1),
		SumberDr VARCHAR(3),
		ProsesID VARCHAR(1),
		SatSolo VARCHAR(3),
		Material VARCHAR(19),
		SatJual VARCHAR(3),
		KodeRak VARCHAR(7),
		KodeRak1 VARCHAR(7),
		KodeRak2 VARCHAR(7),
		JB VARCHAR(2),
		StatusPasif BIT,
		SyncFlag BIT,
		PrediksiLamaKirim INT,
		HariRataRata INT,
		StokMin INT,
		StokMax INT,
		IsiKoli INT,
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc
	
	INSERT INTO @Temp
	(
		RowID, BarangID, RecordID, Bundle, NamaStok, Kendaraan, NamaTertera, PartNo, Merek, Dibungkus, SumberDr, ProsesID, SatSolo, Material, SatJual, KodeRak, KodeRak1, KodeRak2, JB, StatusPasif, SyncFlag, PrediksiLamaKirim, HariRataRata, StokMin, StokMax, IsiKoli, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		BarangID, 
		RecordID, 
		Bundle, 
		NamaStok, 
		Kendaraan, 
		NamaTertera, 
		PartNo, 
		Merek, 
		Dibungkus, 
		SumberDr, 
		ProsesID, 
		SatSolo, 
		Material, 
		SatJual, 
		KodeRak, 
		KodeRak1, 
		KodeRak2, 
		JB, 
		StatusPasif, 
		SyncFlag, 
		PrediksiLamaKirim, 
		HariRataRata, 
		StokMin, 
		StokMax, 
		IsiKoli, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		BarangID VARCHAR(23) '@BarangID',
		RecordID VARCHAR(23) '@RecordID',
		Bundle VARCHAR(3) '@Bundle',
		NamaStok VARCHAR(73) '@NamaStok',
		Kendaraan VARCHAR(43) '@Kendaraan',
		NamaTertera VARCHAR(43) '@NamaTertera',
		PartNo VARCHAR(21) '@PartNo',
		Merek VARCHAR(23) '@Merek',
		Dibungkus VARCHAR(1) '@Dibungkus',
		SumberDr VARCHAR(3) '@SumberDr',
		ProsesID VARCHAR(1) '@ProsesID',
		SatSolo VARCHAR(3) '@SatSolo',
		Material VARCHAR(19) '@Material',
		SatJual VARCHAR(3) '@SatJual',
		KodeRak VARCHAR(7) '@KodeRak',
		KodeRak1 VARCHAR(7) '@KodeRak1',
		KodeRak2 VARCHAR(7) '@KodeRak2',
		JB VARCHAR(2) '@JB',
		StatusPasif BIT '@StatusPasif',
		SyncFlag BIT '@SyncFlag',
		PrediksiLamaKirim INT '@PrediksiLamaKirim',
		HariRataRata INT '@HariRataRata',
		StokMin INT '@StokMin',
		StokMax INT '@StokMax',
		IsiKoli INT '@IsiKoli',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy',
		LastUpdatedTime DATETIME '@LastUpdatedTime'
	)

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR
	SELECT 
		RowID, 
		BarangID, 
		RecordID, 
		Bundle, 
		NamaStok, 
		Kendaraan, 
		NamaTertera, 
		PartNo, 
		Merek, 
		Dibungkus, 
		SumberDr, 
		ProsesID, 
		SatSolo, 
		Material, 
		SatJual, 
		KodeRak, 
		KodeRak1, 
		KodeRak2, 
		JB, 
		StatusPasif, 
		SyncFlag, 
		PrediksiLamaKirim, 
		HariRataRata, 
		StokMin, 
		StokMax, 
		IsiKoli, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @BarangID, @RecordID, @Bundle, @NamaStok, @Kendaraan, @NamaTertera, @PartNo, @Merek, @Dibungkus, @SumberDr, @ProsesID, @SatSolo, @Material, @SatJual, @KodeRak, @KodeRak1, @KodeRak2, @JB, @StatusPasif, @SyncFlag, @PrediksiLamaKirim, @HariRataRata, @StokMin, @StokMax, @IsiKoli, @LastUpdatedBy, @LastUpdatedTime

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.Stok (NOLOCK) WHERE RowID = @RowID)
			UPDATE Stok WITH (ROWLOCK)
			SET
				RowID = @RowID,
				BarangID = @BarangID,
				RecordID = @RecordID,
				Bundle = @Bundle,
				NamaStok = @NamaStok,
				Kendaraan = @Kendaraan,
				NamaTertera = @NamaTertera,
				PartNo = @PartNo,
				Merek = @Merek,
				Dibungkus = @Dibungkus,
				SumberDr = @SumberDr,
				ProsesID = @ProsesID,
				SatSolo = @SatSolo,
				Material = @Material,
				SatJual = @SatJual,
				KodeRak = @KodeRak,
				KodeRak1 = @KodeRak1,
				KodeRak2 = @KodeRak2,
				JB = @JB,
				StatusPasif = @StatusPasif,
				SyncFlag = @SyncFlag,
				PrediksiLamaKirim = @PrediksiLamaKirim,
				HariRataRata = @HariRataRata,
				StokMin = @StokMin,
				StokMax = @StokMax,
				IsiKoli = @IsiKoli,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			INSERT INTO Stok WITH (ROWLOCK)
			(RowID, BarangID, RecordID, Bundle, NamaStok, Kendaraan, NamaTertera, PartNo, Merek, Dibungkus, SumberDr, ProsesID, SatSolo, Material, SatJual, KodeRak, KodeRak1, KodeRak2, JB, StatusPasif, SyncFlag, PrediksiLamaKirim, HariRataRata, StokMin, StokMax, IsiKoli, LastUpdatedBy, LastUpdatedTime)
				VALUES	(
							@RowID,
							@BarangID,
							@RecordID,
							@Bundle,
							@NamaStok,
							@Kendaraan,
							@NamaTertera,
							@PartNo,
							@Merek,
							@Dibungkus,
							@SumberDr,
							@ProsesID,
							@SatSolo,
							@Material,
							@SatJual,
							@KodeRak,
							@KodeRak1,
							@KodeRak2,
							@JB,
							@StatusPasif,
							@SyncFlag,
							@PrediksiLamaKirim,
							@HariRataRata,
							@StokMin,
							@StokMax,
							@IsiKoli,
							@LastUpdatedBy,
							@LastUpdatedTime
						)
		FETCH NEXT FROM data_cursor INTO
		@RowID, @BarangID, @RecordID, @Bundle, @NamaStok, @Kendaraan, @NamaTertera, @PartNo, @Merek, @Dibungkus, @SumberDr, @ProsesID, @SatSolo, @Material, @SatJual, @KodeRak, @KodeRak1, @KodeRak2, @JB, @StatusPasif, @SyncFlag, @PrediksiLamaKirim, @HariRataRata, @StokMin, @StokMax, @IsiKoli, @LastUpdatedBy, @LastUpdatedTime

	END
	
	CLOSE data_cursor	
	DEALLOCATE data_cursor
			

	
END



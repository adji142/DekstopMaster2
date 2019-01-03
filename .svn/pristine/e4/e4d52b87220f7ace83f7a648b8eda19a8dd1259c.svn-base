USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_Toko]    Script Date: 10/11/2011 13:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Nobon
-- Create date: 23 May 2011
-- Description:	<Description,,>
-- exec dbo.psp_SYNC_DOWNLOAD_Toko '<root><row RowID="B5FB5DDE-CF0A-4D87-9F96-A67D075A921B" TokoID="0009047" NamaToko="DINA MOTOR" Alamat="JL. NAGARA WANGI NO.7" Kota="TASIKMALAYA" Telp="0265-334011/338722" WilID="BB-0130" PenanggungJawab="KOKO KOSASIH" KodeToko="1997102904:26:10422" PiutangB="1206000.0000" PiutangJ="0.0000" Plafon="5590666.6700" ToJual="0.0000" ToRetPot="0.0000" JangkaWaktuKredit="120" Cabang2="PT" Tgl1st="1998-04-11T00:00:00" Exist="0" ClassID="D" Catatan="0541015603/PEMILIK TJONG WAN SEN" SyncFlag="1" HariKirim="4" KodePos="TSK" Grade="B1" Plafon1st="0.0000" Flag="09" Bentrok="                    " StatusAktif="0" HariSales="60" Daerah="TASIKMALAYA" Propinsi="JABAR                         " AlamatRumah="" Pengelola="" TglLahir="1899-12-30T00:00:00" HP="" Status="" ThnBerdiri="" StatusRuko="0" JmlCabang="0" JmlSales="0" Kinerja="" BidangUsaha="" RefSales="" RefCollector="" RefSupervisor="" PlafonSurvey="0.0000" LastUpdatedBy="Admin" LastUpdatedTime="2011-05-13T16:46:21.530"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_Toko]
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @TokoID VARCHAR(7)
	DECLARE @NamaToko VARCHAR(31)
	DECLARE @Alamat VARCHAR(60)
	DECLARE @Kota VARCHAR(20)
	DECLARE @Telp VARCHAR(20)
	DECLARE @WilID VARCHAR(7)
	DECLARE @PenanggungJawab VARCHAR(20)
	DECLARE @KodeToko VARCHAR(19)
	DECLARE @PiutangB MONEY
	DECLARE @PiutangJ MONEY
	DECLARE @Plafon MONEY
	DECLARE @ToJual MONEY
	DECLARE @ToRetPot MONEY
	DECLARE @JangkaWaktuKredit INT
	DECLARE @Cabang2 VARCHAR(3)
	DECLARE @Tgl1st DATETIME
	DECLARE @Exist BIT
	DECLARE @ClassID VARCHAR(1)
	DECLARE @Catatan VARCHAR(73)
	DECLARE @SyncFlag BIT
	DECLARE @HariKirim INT
	DECLARE @KodePos VARCHAR(3)
	DECLARE @Grade VARCHAR(2)
	DECLARE @Plafon1st MONEY
	DECLARE @Flag VARCHAR(2)
	DECLARE @Bentrok VARCHAR(20)
	DECLARE @StatusAktif BIT
	DECLARE @HariSales INT
	DECLARE @Daerah VARCHAR(25)
	DECLARE @Propinsi VARCHAR(30)
	DECLARE @AlamatRumah VARCHAR(60)
	DECLARE @Pengelola VARCHAR(20)
	DECLARE @TglLahir DATETIME
	DECLARE @HP VARCHAR(30)
	DECLARE @Status VARCHAR(1)
	DECLARE @ThnBerdiri VARCHAR(4)
	DECLARE @StatusRuko BIT
	DECLARE @JmlCabang INT
	DECLARE @JmlSales INT
	DECLARE @Kinerja VARCHAR(1)
	DECLARE @BidangUsaha VARCHAR(10)
	DECLARE @RefSales VARCHAR(35)
	DECLARE @RefCollector VARCHAR(35)
	DECLARE @RefSupervisor VARCHAR(35)
	DECLARE @PlafonSurvey MONEY
	DECLARE @LastUpdatedBy VARCHAR(250)
	DECLARE @LastUpdatedTime DATETIME

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- INTerfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	
	DECLARE @Temp TABLE
	(
		RowID UNIQUEIDENTIFIER,
		TokoID VARCHAR(7),
		NamaToko VARCHAR(31),
		Alamat VARCHAR(60),
		Kota VARCHAR(20),
		Telp VARCHAR(20),
		WilID VARCHAR(7),
		PenanggungJawab VARCHAR(20),
		KodeToko VARCHAR(19),
		PiutangB MONEY,
		PiutangJ MONEY,
		Plafon MONEY,
		ToJual MONEY,
		ToRetPot MONEY,
		JangkaWaktuKredit INT,
		Cabang2 VARCHAR(3),
		Tgl1st DATETIME,
		Exist BIT,
		ClassID VARCHAR(1),
		Catatan VARCHAR(73),
		SyncFlag BIT,
		HariKirim INT,
		KodePos VARCHAR(3),
		Grade VARCHAR(2),
		Plafon1st MONEY,
		Flag VARCHAR(2),
		Bentrok VARCHAR(20),
		StatusAktif BIT,
		HariSales INT,
		Daerah VARCHAR(25),
		Propinsi VARCHAR(30),
		AlamatRumah VARCHAR(60),
		Pengelola VARCHAR(20),
		TglLahir DATETIME,
		HP VARCHAR(30),
		Status VARCHAR(1),
		ThnBerdiri VARCHAR(4),
		StatusRuko BIT,
		JmlCabang INT,
		JmlSales INT,
		Kinerja VARCHAR(1),
		BidangUsaha VARCHAR(10),
		RefSales VARCHAR(35),
		RefCollector VARCHAR(35),
		RefSupervisor VARCHAR(35),
		PlafonSurvey MONEY,
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)
	
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc
	
	INSERT INTO @Temp
	(
		RowID, TokoID, NamaToko, Alamat, Kota, Telp, WilID, PenanggungJawab, KodeToko, PiutangB, PiutangJ, Plafon, ToJual, ToRetPot, JangkaWaktuKredit, Cabang2, Tgl1st, Exist, ClassID, Catatan, SyncFlag, HariKirim, KodePos, Grade, Plafon1st, Flag, Bentrok, StatusAktif, HariSales, Daerah, Propinsi, AlamatRumah, Pengelola, TglLahir, HP, Status, ThnBerdiri, StatusRuko, JmlCabang, JmlSales, Kinerja, BidangUsaha, RefSales, RefCollector, RefSupervisor, PlafonSurvey, LastUpdatedBy, LastUpdatedTime
	)

	SELECT 
		RowID, 
		TokoID, 
		NamaToko, 
		Alamat, 
		Kota, 
		Telp, 
		WilID, 
		PenanggungJawab, 
		KodeToko, 
		PiutangB, 
		PiutangJ, 
		Plafon, 
		ToJual, 
		ToRetPot, 
		JangkaWaktuKredit, 
		Cabang2, 
		Tgl1st, 
		Exist, 
		ClassID, 
		Catatan, 
		SyncFlag, 
		HariKirim, 
		KodePos, 
		Grade, 
		Plafon1st, 
		Flag, 
		Bentrok, 
		StatusAktif, 
		HariSales, 
		Daerah, 
		Propinsi, 
		AlamatRumah, 
		Pengelola, 
		TglLahir, 
		HP, 
		Status, 
		ThnBerdiri, 
		StatusRuko, 
		JmlCabang, 
		JmlSales, 
		Kinerja, 
		BidangUsaha, 
		RefSales, 
		RefCollector, 
		RefSupervisor, 
		PlafonSurvey, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		TokoID VARCHAR(7) '@TokoID',
		NamaToko VARCHAR(31) '@NamaToko',
		Alamat VARCHAR(60) '@Alamat',
		Kota VARCHAR(20) '@Kota',
		Telp VARCHAR(20) '@Telp',
		WilID VARCHAR(7) '@WilID',
		PenanggungJawab VARCHAR(20) '@PenanggungJawab',
		KodeToko VARCHAR(19) '@KodeToko',
		PiutangB MONEY '@PiutangB',
		PiutangJ MONEY '@PiutangJ',
		Plafon MONEY '@Plafon',
		ToJual MONEY '@ToJual',
		ToRetPot MONEY '@ToRetPot',
		JangkaWaktuKredit INT '@JangkaWaktuKredit',
		Cabang2 VARCHAR(3) '@Cabang2',
		Tgl1st DATETIME '@Tgl1st',
		Exist BIT '@Exist',
		ClassID VARCHAR(1) '@ClassID',
		Catatan VARCHAR(73) '@Catatan',
		SyncFlag BIT '@SyncFlag',
		HariKirim INT '@HariKirim',
		KodePos VARCHAR(3) '@KodePos',
		Grade VARCHAR(2) '@Grade',
		Plafon1st MONEY '@Plafon1st',
		Flag VARCHAR(2) '@Flag',
		Bentrok VARCHAR(20) '@Bentrok',
		StatusAktif BIT '@StatusAktif',
		HariSales INT '@HariSales',
		Daerah VARCHAR(25) '@Daerah',
		Propinsi VARCHAR(30) '@Propinsi',
		AlamatRumah VARCHAR(60) '@AlamatRumah',
		Pengelola VARCHAR(20) '@Pengelola',
		TglLahir DATETIME '@TglLahir',
		HP VARCHAR(30) '@HP',
		Status VARCHAR(1) '@Status',
		ThnBerdiri VARCHAR(4) '@ThnBerdiri',
		StatusRuko BIT '@StatusRuko',
		JmlCabang INT '@JmlCabang',
		JmlSales INT '@JmlSales',
		Kinerja VARCHAR(1) '@Kinerja',
		BidangUsaha VARCHAR(10) '@BidangUsaha',
		RefSales VARCHAR(35) '@RefSales',
		RefCollector VARCHAR(35) '@RefCollector',
		RefSupervisor VARCHAR(35) '@RefSupervisor',
		PlafonSurvey MONEY '@PlafonSurvey',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy',
		LastUpdatedTime DATETIME '@LastUpdatedTime'
	)

			
	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR
	SELECT 
		RowID, 
		TokoID, 
		NamaToko, 
		Alamat, 
		Kota, 
		Telp, 
		WilID, 
		PenanggungJawab, 
		KodeToko, 
		PiutangB, 
		PiutangJ, 
		Plafon, 
		ToJual, 
		ToRetPot, 
		JangkaWaktuKredit, 
		Cabang2, 
		Tgl1st, 
		Exist, 
		ClassID, 
		Catatan, 
		SyncFlag, 
		HariKirim, 
		KodePos, 
		Grade, 
		Plafon1st, 
		Flag, 
		Bentrok, 
		StatusAktif, 
		HariSales, 
		Daerah, 
		Propinsi, 
		AlamatRumah, 
		Pengelola, 
		TglLahir, 
		HP, 
		Status, 
		ThnBerdiri, 
		StatusRuko, 
		JmlCabang, 
		JmlSales, 
		Kinerja, 
		BidangUsaha, 
		RefSales, 
		RefCollector, 
		RefSupervisor, 
		PlafonSurvey, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
		
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @TokoID, @NamaToko, @Alamat, @Kota, @Telp, @WilID, @PenanggungJawab, @KodeToko, @PiutangB, @PiutangJ, @Plafon, @ToJual, @ToRetPot, @JangkaWaktuKredit, @Cabang2, @Tgl1st, @Exist, @ClassID, @Catatan, @SyncFlag, @HariKirim, @KodePos, @Grade, @Plafon1st, @Flag, @Bentrok, @StatusAktif, @HariSales, @Daerah, @Propinsi, @AlamatRumah, @Pengelola, @TglLahir, @HP, @Status, @ThnBerdiri, @StatusRuko, @JmlCabang, @JmlSales, @Kinerja, @BidangUsaha, @RefSales, @RefCollector, @RefSupervisor, @PlafonSurvey, @LastUpdatedBy, @LastUpdatedTime

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.Toko (NOLOCK) WHERE RowID = @RowID)
			UPDATE Toko WITH (ROWLOCK)
			SET
				RowID = @RowID,
				TokoID = @TokoID,
				NamaToko = @NamaToko,
				Alamat = @Alamat,
				Kota = @Kota,
				Telp = @Telp,
				WilID = @WilID,
				PenanggungJawab = @PenanggungJawab,
				KodeToko = @KodeToko,
				PiutangB = @PiutangB,
				PiutangJ = @PiutangJ,
				Plafon = @Plafon,
				ToJual = @ToJual,
				ToRetPot = @ToRetPot,
				JangkaWaktuKredit = @JangkaWaktuKredit,
				Cabang2 = @Cabang2,
				Tgl1st = @Tgl1st,
				Exist = @Exist,
				ClassID = @ClassID,
				Catatan = @Catatan,
				SyncFlag = @SyncFlag,
				HariKirim = @HariKirim,
				KodePos = @KodePos,
				Grade = @Grade,
				Plafon1st = @Plafon1st,
				Flag = @Flag,
				Bentrok = @Bentrok,
				StatusAktif = @StatusAktif,
				HariSales = @HariSales,
				Daerah = @Daerah,
				Propinsi = @Propinsi,
				AlamatRumah = @AlamatRumah,
				Pengelola = @Pengelola,
				TglLahir = @TglLahir,
				HP = @HP,
				Status = @Status,
				ThnBerdiri = @ThnBerdiri,
				StatusRuko = @StatusRuko,
				JmlCabang = @JmlCabang,
				JmlSales = @JmlSales,
				Kinerja = @Kinerja,
				BidangUsaha = @BidangUsaha,
				RefSales = @RefSales,
				RefCollector = @RefCollector,
				RefSupervisor = @RefSupervisor,
				PlafonSurvey = @PlafonSurvey,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			INSERT INTO Toko WITH (ROWLOCK)
			(RowID, TokoID, NamaToko, Alamat, Kota, Telp, WilID, PenanggungJawab, KodeToko, PiutangB, PiutangJ, Plafon, ToJual, ToRetPot, JangkaWaktuKredit, Cabang2, Tgl1st, Exist, ClassID, Catatan, SyncFlag, HariKirim, KodePos, Grade, Plafon1st, Flag, Bentrok, StatusAktif, HariSales, Daerah, Propinsi, AlamatRumah, Pengelola, TglLahir, HP, Status, ThnBerdiri, StatusRuko, JmlCabang, JmlSales, Kinerja, BidangUsaha, RefSales, RefCollector, RefSupervisor, PlafonSurvey, LastUpdatedBy, LastUpdatedTime)
				VALUES	(
							@RowID,
							@TokoID,
							@NamaToko,
							@Alamat,
							@Kota,
							@Telp,
							@WilID,
							@PenanggungJawab,
							@KodeToko,
							@PiutangB,
							@PiutangJ,
							@Plafon,
							@ToJual,
							@ToRetPot,
							@JangkaWaktuKredit,
							@Cabang2,
							@Tgl1st,
							@Exist,
							@ClassID,
							@Catatan,
							@SyncFlag,
							@HariKirim,
							@KodePos,
							@Grade,
							@Plafon1st,
							@Flag,
							@Bentrok,
							@StatusAktif,
							@HariSales,
							@Daerah,
							@Propinsi,
							@AlamatRumah,
							@Pengelola,
							@TglLahir,
							@HP,
							@Status,
							@ThnBerdiri,
							@StatusRuko,
							@JmlCabang,
							@JmlSales,
							@Kinerja,
							@BidangUsaha,
							@RefSales,
							@RefCollector,
							@RefSupervisor,
							@PlafonSurvey,
							@LastUpdatedBy,
							@LastUpdatedTime
						)
		FETCH NEXT FROM data_cursor INTO
		@RowID, @TokoID, @NamaToko, @Alamat, @Kota, @Telp, @WilID, @PenanggungJawab, @KodeToko, @PiutangB, @PiutangJ, @Plafon, @ToJual, @ToRetPot, @JangkaWaktuKredit, @Cabang2, @Tgl1st, @Exist, @ClassID, @Catatan, @SyncFlag, @HariKirim, @KodePos, @Grade, @Plafon1st, @Flag, @Bentrok, @StatusAktif, @HariSales, @Daerah, @Propinsi, @AlamatRumah, @Pengelola, @TglLahir, @HP, @Status, @ThnBerdiri, @StatusRuko, @JmlCabang, @JmlSales, @Kinerja, @BidangUsaha, @RefSales, @RefCollector, @RefSupervisor, @PlafonSurvey, @LastUpdatedBy, @LastUpdatedTime

	END
	
	CLOSE data_cursor	
	DEALLOCATE data_cursor

	
END


 
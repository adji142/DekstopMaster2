USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_NotaPembelian]    Script Date: 10/11/2011 13:47:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nobon
-- Create date: 20 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_NotaPembelian '<root><row RowID="9B3F668D-04AC-434C-9EB5-3E19634D2C55" RecordID="" NoRequest="" TglRequest="1899-12-30T00:00:00" NoDO="" TglTransaksi="1899-12-30T00:00:00" NoNota="" TglNota="1899-12-30T00:00:00" NoSuratJalan="" TglSuratJalan="1899-12-30T00:00:00" Disc1="0.00" Disc2="0.00" Disc3="0.00" DiscFormula="" HariKredit="0" PPN="0" Pemasok="KP-SOLO" Expedisi="" Cabang="" Catatan="" isClosed="0" SyncFlag="1" LastUpdatedBy="Admin" LastUpdatedTime="2011-04-01T18:09:52.640"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_NotaPembelian] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @RecordID VARCHAR(23)
	DECLARE @NoRequest VARCHAR(7)
	DECLARE @TglRequest DATETIME
	DECLARE @NoDO VARCHAR(7)
	DECLARE @TglTransaksi DATETIME
	DECLARE @NoNota VARCHAR(10)
	DECLARE @TglNota DATETIME
	DECLARE @NoSuratJalan VARCHAR(10)
	DECLARE @TglSuratJalan DATETIME
	DECLARE @TglTerima DATETIME
	DECLARE @Disc1 DECIMAL(5, 2)
	DECLARE @Disc2 DECIMAL(5, 2)
	DECLARE @Disc3 DECIMAL(5, 2)
	DECLARE @DiscFormula VARCHAR(7)
	DECLARE @HariKredit INT
	DECLARE @PPN NUMERIC(3, 0)
	DECLARE @Pemasok VARCHAR(19)
	DECLARE @Expedisi VARCHAR(9)
	DECLARE @Cabang VARCHAR(2)
	DECLARE @Catatan VARCHAR(4)
	DECLARE @isClosed BIT
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
		RecordID VARCHAR(23),
		NoRequest VARCHAR(7),
		TglRequest DATETIME,
		NoDO VARCHAR(7),
		TglTransaksi DATETIME,
		NoNota VARCHAR(10),
		TglNota DATETIME,
		NoSuratJalan VARCHAR(10),
		TglSuratJalan DATETIME,
		TglTerima DATETIME,
		Disc1 DECIMAL(5, 2),
		Disc2 DECIMAL(5, 2),
		Disc3 DECIMAL(5, 2),
		DiscFormula VARCHAR(7),
		HariKredit INT,
		PPN NUMERIC(3, 0),
		Pemasok VARCHAR(19),
		Expedisi VARCHAR(9),
		Cabang VARCHAR(2),
		Catatan VARCHAR(4),
		isClosed BIT,
		SyncFlag BIT,
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc

	INSERT INTO @Temp
	(
		RowID, RecordID, NoRequest, TglRequest, NoDO, TglTransaksi, NoNota, TglNota, NoSuratJalan, TglSuratJalan, TglTerima, Disc1, Disc2, Disc3, DiscFormula, HariKredit, PPN, Pemasok, Expedisi, Cabang, Catatan, isClosed, SyncFlag, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		RecordID, 
		NoRequest, 
		TglRequest, 
		NoDO, 
		TglTransaksi, 
		NoNota, 
		TglNota, 
		NoSuratJalan, 
		TglSuratJalan, 
		TglTerima, 
		Disc1, 
		Disc2, 
		Disc3, 
		DiscFormula, 
		HariKredit, 
		PPN, 
		Pemasok, 
		Expedisi, 
		Cabang, 
		Catatan, 
		isClosed, 
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
		NoDO VARCHAR(7) '@NoDO',
		TglTransaksi DATETIME '@TglTransaksi',
		NoNota VARCHAR(10) '@NoNota',
		TglNota DATETIME '@TglNota',
		NoSuratJalan VARCHAR(10) '@NoSuratJalan',
		TglSuratJalan DATETIME '@TglSuratJalan',
		TglTerima DATETIME '@TglTerima',
		Disc1 DECIMAL(5, 2) '@Disc1',
		Disc2 DECIMAL(5, 2) '@Disc2',
		Disc3 DECIMAL(5, 2) '@Disc3',
		DiscFormula VARCHAR(7) '@DiscFormula',
		HariKredit INT '@HariKredit',
		PPN NUMERIC(3, 0) '@PPN',
		Pemasok VARCHAR(19) '@Pemasok',
		Expedisi VARCHAR(9) '@Expedisi',
		Cabang VARCHAR(2) '@Cabang',
		Catatan VARCHAR(4) '@Catatan',
		isClosed BIT '@isClosed',
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
		NoDO, 
		TglTransaksi, 
		NoNota, 
		TglNota, 
		NoSuratJalan, 
		TglSuratJalan, 
		TglTerima, 
		Disc1, 
		Disc2, 
		Disc3, 
		DiscFormula, 
		HariKredit, 
		PPN, 
		Pemasok, 
		Expedisi, 
		Cabang, 
		Catatan, 
		isClosed, 
		SyncFlag, 
		LastUpdatedBy,	
		LastUpdatedTime
	FROM @Temp
			
OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @RecordID, @NoRequest, @TglRequest, @NoDO, @TglTransaksi, @NoNota, @TglNota, @NoSuratJalan, @TglSuratJalan, @TglTerima, @Disc1, @Disc2, @Disc3, @DiscFormula, @HariKredit, @PPN, @Pemasok, @Expedisi, @Cabang, @Catatan, @isClosed, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.NotaPembelian (NOLOCK) WHERE RowID = @RowID)
			UPDATE NotaPembelian WITH (ROWLOCK)
			SET
				RowID = @RowID,
				RecordID = @RecordID,
				NoRequest = @NoRequest,
				TglRequest = @TglRequest,
				NoDO = @NoDO,
				TglTransaksi = @TglTransaksi,
				NoNota = @NoNota,
				TglNota = @TglNota,
				NoSuratJalan = @NoSuratJalan,
				TglSuratJalan = @TglSuratJalan,
				TglTerima = @TglTerima,
				Disc1 = @Disc1,
				Disc2 = @Disc2,
				Disc3 = @Disc3,
				DiscFormula = @DiscFormula,
				HariKredit = @HariKredit,
				PPN = @PPN,
				Pemasok = @Pemasok,
				Expedisi = @Expedisi,
				Cabang = @Cabang,
				Catatan = @Catatan,
				isClosed = @isClosed,
				SyncFlag = @SyncFlag,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			INSERT INTO NotaPembelian WITH (ROWLOCK)
			(RowID, RecordID, NoRequest, TglRequest, NoDO, TglTransaksi, NoNota, TglNota, NoSuratJalan, TglSuratJalan, TglTerima, Disc1, Disc2, Disc3, DiscFormula, HariKredit, PPN, Pemasok, Expedisi, Cabang, Catatan, isClosed, SyncFlag, LastUpdatedBy, LastUpdatedTime)
			VALUES	(
						@RowID,
						@RecordID,
						@NoRequest,
						@TglRequest,
						@NoDO,
						@TglTransaksi,
						@NoNota,
						@TglNota,
						@NoSuratJalan,
						@TglSuratJalan,
						@TglTerima,
						@Disc1,
						@Disc2,
						@Disc3,
						@DiscFormula,
						@HariKredit,
						@PPN,
						@Pemasok,
						@Expedisi,
						@Cabang,
						@Catatan,
						@isClosed,
						@SyncFlag,
						@LastUpdatedBy,
						@LastUpdatedTime
					)
		FETCH NEXT FROM data_cursor INTO
		@RowID, @RecordID, @NoRequest, @TglRequest, @NoDO, @TglTransaksi, @NoNota, @TglNota, @NoSuratJalan, @TglSuratJalan, @TglTerima, @Disc1, @Disc2, @Disc3, @DiscFormula, @HariKredit, @PPN, @Pemasok, @Expedisi, @Cabang, @Catatan, @isClosed, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime
	
	END

	CLOSE data_cursor	
	DEALLOCATE data_cursor
			


END



 
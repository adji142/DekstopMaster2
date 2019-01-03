USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_ReturPenjualan]    Script Date: 10/11/2011 13:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nobon
-- Create date: 23 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_ReturPenjualan '<root><row RowID="2CAF8BE2-EE96-4248-9D18-E9F9BFF29FB3" Cabang1="09" Cabang2="09" ReturID="CRB2005112908:23:11ANG" NoMPR="NP00605" NoNotaRetur="RJ25007" NoTolak="" TglMPR="2005-11-30T00:00:00" TglNotaRetur="2005-11-30T00:00:00" KodeToko="2000011514:46:04" TglTolak="1899-12-30T00:00:00" Pengambilan="" TglPengambilan="1899-12-30T00:00:00" TglGudang="2005-11-30T00:00:00" BagPenjualan="ANANG" Penerima="DALI" LinkID="2005113015:55:45EDR" SyncFlag="1" isClosed="0" NPrint="2" TglRQRetur="2005-11-29T00:00:00" LastUpdatedBy="Admin" LastUpdatedTime="2011-02-08T09:35:53.350"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_ReturPenjualan] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @Cabang1 VARCHAR(2)
	DECLARE @Cabang2 VARCHAR(2)
	DECLARE @ReturID VARCHAR(23)
	DECLARE @NoMPR VARCHAR(7)
	DECLARE @NoNotaRetur VARCHAR(7)
	DECLARE @NoTolak VARCHAR(7)
	DECLARE @TglMPR DATETIME
	DECLARE @TglNotaRetur DATETIME
	DECLARE @KodeToko VARCHAR(19)
	DECLARE @TglTolak DATETIME
	DECLARE @Pengambilan VARCHAR(17)
	DECLARE @TglPengambilan DATETIME
	DECLARE @TglGudang DATETIME
	DECLARE @BagPenjualan VARCHAR(17)
	DECLARE @Penerima VARCHAR(17)
	DECLARE @LinkID VARCHAR(19)
	DECLARE @SyncFlag BIT
	DECLARE @isClosed BIT
	DECLARE @NPrint INT
	DECLARE @TglRQRetur DATETIME
	DECLARE @LastUpdatedBy VARCHAR(250)
	DECLARE @LastUpdatedTime DATETIME

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- INTerfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
		
	DECLARE @Temp TABLE
	(
		RowID UNIQUEIDENTIFIER,
		Cabang1 VARCHAR(2),
		Cabang2 VARCHAR(2),
		ReturID VARCHAR(23),
		NoMPR VARCHAR(7),
		NoNotaRetur VARCHAR(7),
		NoTolak VARCHAR(7),
		TglMPR DATETIME,
		TglNotaRetur DATETIME,
		KodeToko VARCHAR(19),
		TglTolak DATETIME,
		Pengambilan VARCHAR(17),
		TglPengambilan DATETIME,
		TglGudang DATETIME,
		BagPenjualan VARCHAR(17),
		Penerima VARCHAR(17),
		LinkID VARCHAR(19),
		SyncFlag BIT,
		isClosed BIT,
		NPrint INT,
		TglRQRetur DATETIME,
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc

	INSERT INTO @Temp
	(
		RowID, Cabang1, Cabang2, ReturID, NoMPR, NoNotaRetur, NoTolak, TglMPR, TglNotaRetur, KodeToko, TglTolak, Pengambilan, TglPengambilan, TglGudang, BagPenjualan, Penerima, LinkID, SyncFlag, isClosed, NPrint, TglRQRetur, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		Cabang1, 
		Cabang2, 
		ReturID, 
		NoMPR, 
		NoNotaRetur, 
		NoTolak, 
		TglMPR, 
		TglNotaRetur, 
		KodeToko, 
		TglTolak, 
		Pengambilan, 
		TglPengambilan, 
		TglGudang, 
		BagPenjualan, 
		Penerima, 
		LinkID, 
		SyncFlag, 
		isClosed, 
		NPrint, 
		TglRQRetur, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		Cabang1 VARCHAR(2) '@Cabang1',
		Cabang2 VARCHAR(2) '@Cabang2',
		ReturID VARCHAR(23) '@ReturID',
		NoMPR VARCHAR(7) '@NoMPR',
		NoNotaRetur VARCHAR(7) '@NoNotaRetur',
		NoTolak VARCHAR(7) '@NoTolak',
		TglMPR DATETIME '@TglMPR',
		TglNotaRetur DATETIME '@TglNotaRetur',
		KodeToko VARCHAR(19) '@KodeToko',
		TglTolak DATETIME '@TglTolak',
		Pengambilan VARCHAR(17) '@Pengambilan',
		TglPengambilan DATETIME '@TglPengambilan',
		TglGudang DATETIME '@TglGudang',
		BagPenjualan VARCHAR(17) '@BagPenjualan',
		Penerima VARCHAR(17) '@Penerima',
		LinkID VARCHAR(19) '@LinkID',
		SyncFlag BIT '@SyncFlag',
		isClosed BIT '@isClosed',
		NPrint INT '@NPrint',
		TglRQRetur DATETIME '@TglRQRetur',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy',
		LastUpdatedTime DATETIME '@LastUpdatedTime'
	)

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID, 
		Cabang1, 
		Cabang2, 
		ReturID, 
		NoMPR, 
		NoNotaRetur, 
		NoTolak, 
		TglMPR, 
		TglNotaRetur, 
		KodeToko, 
		TglTolak, 
		Pengambilan, 
		TglPengambilan, 
		TglGudang, 
		BagPenjualan, 
		Penerima, 
		LinkID, 
		SyncFlag, 
		isClosed, 
		NPrint, 
		TglRQRetur, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
			

	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @Cabang1, @Cabang2, @ReturID, @NoMPR, @NoNotaRetur, @NoTolak, @TglMPR, @TglNotaRetur, @KodeToko, @TglTolak, @Pengambilan, @TglPengambilan, @TglGudang, @BagPenjualan, @Penerima, @LinkID, @SyncFlag, @isClosed, @NPrint, @TglRQRetur, @LastUpdatedBy, @LastUpdatedTime

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.ReturPenjualan (NOLOCK) WHERE RowID = @RowID)
			UPDATE ReturPenjualan WITH (ROWLOCK)
			SET
				RowID = @RowID,
				Cabang1 = @Cabang1,
				Cabang2 = @Cabang2,
				ReturID = @ReturID,
				NoMPR = @NoMPR,
				NoNotaRetur = @NoNotaRetur,
				NoTolak = @NoTolak,
				TglMPR = @TglMPR,
				TglNotaRetur = @TglNotaRetur,
				KodeToko = @KodeToko,
				TglTolak = @TglTolak,
				Pengambilan = @Pengambilan,
				TglPengambilan = @TglPengambilan,
				TglGudang = @TglGudang,
				BagPenjualan = @BagPenjualan,
				Penerima = @Penerima,
				LinkID = (CASE WHEN (LinkID='') THEN @LinkID ELSE LinkID END ),    
				SyncFlag = @SyncFlag,
				isClosed = @isClosed,
				NPrint = @NPrint,
				TglRQRetur = @TglRQRetur,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			INSERT INTO ReturPenjualan WITH (ROWLOCK)
			(RowID, Cabang1, Cabang2, ReturID, NoMPR, NoNotaRetur, NoTolak, TglMPR, TglNotaRetur, KodeToko, TglTolak, Pengambilan, TglPengambilan, TglGudang, BagPenjualan, Penerima, LinkID, SyncFlag, isClosed, NPrint, TglRQRetur, LastUpdatedBy, LastUpdatedTime)
				VALUES	(
							@RowID,
							@Cabang1,
							@Cabang2,
							@ReturID,
							@NoMPR,
							@NoNotaRetur,
							@NoTolak,
							@TglMPR,
							@TglNotaRetur,
							@KodeToko,
							@TglTolak,
							@Pengambilan,
							@TglPengambilan,
							@TglGudang,
							@BagPenjualan,
							@Penerima,
							@LinkID,
							@SyncFlag,
							@isClosed,
							@NPrint,
							@TglRQRetur,
							@LastUpdatedBy,
							@LastUpdatedTime
						)
		FETCH NEXT FROM data_cursor INTO
		@RowID, @Cabang1, @Cabang2, @ReturID, @NoMPR, @NoNotaRetur, @NoTolak, @TglMPR, @TglNotaRetur, @KodeToko, @TglTolak, @Pengambilan, @TglPengambilan, @TglGudang, @BagPenjualan, @Penerima, @LinkID, @SyncFlag, @isClosed, @NPrint, @TglRQRetur, @LastUpdatedBy, @LastUpdatedTime

	END
	
	CLOSE data_cursor	
	DEALLOCATE data_cursor
			
END




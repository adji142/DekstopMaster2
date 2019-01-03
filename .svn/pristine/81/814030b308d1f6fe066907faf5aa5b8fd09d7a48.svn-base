USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_PenjualanPotongan]    Script Date: 10/11/2011 13:48:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nobon
-- Create date: 23 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_PenjualanPotongan '<root><row RowID="F207BD80-F3A5-4DFF-9F93-000242461243" NotaPenjualanID="49F9D353-144A-405F-8057-DF7542F00315" TrID="C092004091514:14:13PJY" PotID="C092005010415:24:29DJL" NoPot="0013809" TglPot="2005-01-04T00:00:00" Dil="0.0000" Disc="0.00" RpNet="272500.0000" Catatan="" DilACC="0.0000" CatACC="" DiscACC="0.00" SyncFlag="1" IdLink="C092005010416:01:55WIR" StatusACC="0" LastUpdatedTime="2011-04-11T19:07:37.030" LastUpdatedBy="Upload"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_PenjualanPotongan] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @NotaPenjualanID UNIQUEIDENTIFIER
	DECLARE @TrID VARCHAR(23)
	DECLARE @PotID VARCHAR(50)
	DECLARE @NoPot VARCHAR(11)
	DECLARE @TglPot DATETIME
	DECLARE @Dil MONEY
	DECLARE @Disc NUMERIC(5, 2)
	DECLARE @RpNet MONEY
	DECLARE @Catatan VARCHAR(17)
	DECLARE @TglACC DATETIME
	DECLARE @DilACC MONEY
	DECLARE @CatACC VARCHAR(17)
	DECLARE @DiscACC DECIMAL(5, 2)
	DECLARE @SyncFlag BIT
	DECLARE @IdLink VARCHAR(23)
	DECLARE @StatusACC BIT
	DECLARE @LastUpdatedTime DATETIME
	DECLARE @LastUpdatedBy VARCHAR(250)
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- INTerfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

	DECLARE @Temp TABLE
	(
		RowID UNIQUEIDENTIFIER,
		NotaPenjualanID UNIQUEIDENTIFIER,
		TrID VARCHAR(23),
		PotID VARCHAR(50),
		NoPot VARCHAR(11),
		TglPot DATETIME,
		Dil MONEY,
		Disc NUMERIC(5, 2),
		RpNet MONEY,
		Catatan VARCHAR(17),
		TglACC DATETIME,
		DilACC MONEY,
		CatACC VARCHAR(17),
		DiscACC DECIMAL(5, 2),
		SyncFlag BIT,
		IdLink VARCHAR(23),
		StatusACC BIT,
		LastUpdatedTime DATETIME,
		LastUpdatedBy VARCHAR(250)
	)

		exec sp_xml_preparedocument @hdoc OUTPUT, @doc

	INSERT INTO	@Temp
	(
		RowID, NotaPenjualanID, TrID, PotID, NoPot, TglPot, Dil, Disc, RpNet, Catatan, TglACC, DilACC, CatACC, DiscACC, SyncFlag, IdLink, StatusACC, LastUpdatedTime, LastUpdatedBy
	)
	SELECT 
		RowID, 
		NotaPenjualanID, 
		TrID, 
		PotID, 
		NoPot, 
		TglPot, 
		Dil, 
		Disc, 
		RpNet, 
		Catatan, 
		TglACC, 
		DilACC, 
		CatACC, 
		DiscACC, 
		SyncFlag, 
		IdLink, 
		StatusACC, 
		LastUpdatedTime, 
		LastUpdatedBy
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER  '@RowID',
		NotaPenjualanID UNIQUEIDENTIFIER  '@NotaPenjualanID',
		TrID VARCHAR(23)  '@TrID',
		PotID VARCHAR(50)  '@PotID',
		NoPot VARCHAR(11)  '@NoPot',
		TglPot DATETIME  '@TglPot',
		Dil MONEY  '@Dil',
		Disc NUMERIC(5, 2)  '@Disc',
		RpNet MONEY  '@RpNet',
		Catatan VARCHAR(17)  '@Catatan',
		TglACC DATETIME  '@TglACC',
		DilACC MONEY  '@DilACC',
		CatACC VARCHAR(17)  '@CatACC',
		DiscACC DECIMAL(5, 2)  '@DiscACC',
		SyncFlag BIT  '@SyncFlag',
		IdLink VARCHAR(23)  '@IdLink',
		StatusACC BIT  '@StatusACC',
		LastUpdatedTime DATETIME  '@LastUpdatedTime',
		LastUpdatedBy VARCHAR(250)  '@LastUpdatedBy'
	)

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID, 
		NotaPenjualanID, 
		TrID, 
		PotID, 
		NoPot, 
		TglPot, 
		Dil, 
		Disc, 
		RpNet, 
		Catatan, 
		TglACC, 
		DilACC, 
		CatACC, 
		DiscACC, 
		SyncFlag, 
		IdLink, 
		StatusACC, 
		LastUpdatedTime, 
		LastUpdatedBy
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @NotaPenjualanID, @TrID, @PotID, @NoPot, @TglPot, @Dil, @Disc, @RpNet, @Catatan, @TglACC, @DilACC, @CatACC, @DiscACC, @SyncFlag, @IdLink, @StatusACC, @LastUpdatedTime, @LastUpdatedBy

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.PenjualanPotongan (NOLOCK) WHERE RowID = @RowID)
			UPDATE PenjualanPotongan WITH (ROWLOCK)
			SET
				RowID = @RowID,
				NotaPenjualanID = @NotaPenjualanID,
				TrID = @TrID,
				PotID = @PotID,
				NoPot = @NoPot,
				TglPot = @TglPot,
				Dil = @Dil,
				Disc = @Disc,
				RpNet = @RpNet,
				Catatan = @Catatan,
				TglACC = @TglACC,
				DilACC = @DilACC,
				CatACC = @CatACC,
				DiscACC = @DiscACC,
				SyncFlag = @SyncFlag,
				IdLink = @IdLink,
				StatusACC = @StatusACC,
				LastUpdatedTime = @LastUpdatedTime,
				LastUpdatedBy = @LastUpdatedBy
			WHERE
				RowID = @RowID
		ELSE
			INSERT INTO PenjualanPotongan WITH (ROWLOCK)
			(RowID, NotaPenjualanID, TrID, PotID, NoPot, TglPot, Dil, Disc, RpNet, Catatan, TglACC, DilACC, CatACC, DiscACC, SyncFlag, IdLink, StatusACC, LastUpdatedTime, LastUpdatedBy)
				VALUES	(
							@RowID,
							@NotaPenjualanID,
							@TrID,
							@PotID,
							@NoPot,
							@TglPot,
							@Dil,
							@Disc,
							@RpNet,
							@Catatan,
							@TglACC,
							@DilACC,
							@CatACC,
							@DiscACC,
							@SyncFlag,
							@IdLink,
							@StatusACC,
							@LastUpdatedTime,
							@LastUpdatedBy
					)
		FETCH NEXT FROM data_cursor INTO
		@RowID, @NotaPenjualanID, @TrID, @PotID, @NoPot, @TglPot, @Dil, @Disc, @RpNet, @Catatan, @TglACC, @DilACC, @CatACC, @DiscACC, @SyncFlag, @IdLink, @StatusACC, @LastUpdatedTime, @LastUpdatedBy

	END

	CLOSE data_cursor	
	DEALLOCATE data_cursor
			


END



 
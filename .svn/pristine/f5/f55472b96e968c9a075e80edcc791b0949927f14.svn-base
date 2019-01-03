USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_ReturPembelian]    Script Date: 10/11/2011 13:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nobon
-- Create date: 23 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_ReturPembelian '<root><row RowID="08FE6F6A-F489-45C4-AD16-0035AA96CD4B" ReturID="C092004022114:14:02SIK" NoRetur="RB00249" TglRetur="2004-02-21T00:00:00" Pemasok="KP-SOLO" Penerima="" NoMPR="RB00249" TglKeluar="2004-02-21T00:00:00" Pengirim="SIDIK" isClosed="1" NPrint="2" SyncFlag="1" LastUpdatedBy="Admin" LastUpdatedTime="2011-04-13T08:41:16.357"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_ReturPembelian] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @ReturID VARCHAR(23)
	DECLARE @NoRetur VARCHAR(7)
	DECLARE @TglRetur DATETIME
	DECLARE @Pemasok VARCHAR(19)
	DECLARE @Penerima VARCHAR(17)
	DECLARE @NoMPR VARCHAR(7)
	DECLARE @TglKeluar DATETIME
	DECLARE @Pengirim VARCHAR(17)
	DECLARE @TglKirim DATETIME
	DECLARE @isClosed BIT
	DECLARE @NPrint INT
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
		ReturID VARCHAR(23),
		NoRetur VARCHAR(7),
		TglRetur DATETIME,
		Pemasok VARCHAR(19),
		Penerima VARCHAR(17),
		NoMPR VARCHAR(7),
		TglKeluar DATETIME,
		Pengirim VARCHAR(17),
		TglKirim DATETIME,
		isClosed BIT,
		NPrint INT,
		SyncFlag BIT,
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)
	
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc
	
	INSERT INTO @Temp
	(
		RowID, ReturID, NoRetur, TglRetur, Pemasok, Penerima, NoMPR, TglKeluar, Pengirim, TglKirim, isClosed, NPrint, SyncFlag, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		ReturID, 
		NoRetur, 
		TglRetur, 
		Pemasok, 
		Penerima, 
		NoMPR, 
		TglKeluar, 
		Pengirim, 
		TglKirim, 
		isClosed, 
		NPrint, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		ReturID VARCHAR(23) '@ReturID',
		NoRetur VARCHAR(7) '@NoRetur',
		TglRetur DATETIME '@TglRetur',
		Pemasok VARCHAR(19) '@Pemasok',
		Penerima VARCHAR(17) '@Penerima',
		NoMPR VARCHAR(7) '@NoMPR',
		TglKeluar DATETIME '@TglKeluar',
		Pengirim VARCHAR(17) '@Pengirim',
		TglKirim DATETIME '@TglKirim',
		isClosed BIT '@isClosed',
		NPrint INT '@NPrint',
		SyncFlag BIT '@SyncFlag',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy',
		LastUpdatedTime DATETIME '@LastUpdatedTime'
	)

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID, 
		ReturID, 
		NoRetur, 
		TglRetur, 
		Pemasok, 
		Penerima, 
		NoMPR, 
		TglKeluar, 
		Pengirim, 
		TglKirim, 
		isClosed, 
		NPrint, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @ReturID, @NoRetur, @TglRetur, @Pemasok, @Penerima, @NoMPR, @TglKeluar, @Pengirim, @TglKirim, @isClosed, @NPrint, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.ReturPembelian (NOLOCK) WHERE RowID = @RowID)
			UPDATE ReturPembelian WITH (ROWLOCK)
			SET
				RowID = @RowID,
				ReturID = @ReturID,
				NoRetur = @NoRetur,
				TglRetur = @TglRetur,
				Pemasok = @Pemasok,
				Penerima = @Penerima,
				NoMPR = @NoMPR,
				TglKeluar = @TglKeluar,
				Pengirim = @Pengirim,
				TglKirim = @TglKirim,
				isClosed = @isClosed,
				NPrint = @NPrint,
				SyncFlag = @SyncFlag,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			INSERT INTO ReturPembelian WITH (ROWLOCK)
			(RowID, ReturID, NoRetur, TglRetur, Pemasok, Penerima, NoMPR, TglKeluar, Pengirim, TglKirim, isClosed, NPrint, SyncFlag, LastUpdatedBy, LastUpdatedTime)
				VALUES	(
							@RowID,
							@ReturID,
							@NoRetur,
							@TglRetur,
							@Pemasok,
							@Penerima,
							@NoMPR,
							@TglKeluar,
							@Pengirim,
							@TglKirim,
							@isClosed,
							@NPrint,
							@SyncFlag,
							@LastUpdatedBy,
							@LastUpdatedTime
					)
		FETCH NEXT FROM data_cursor INTO
		@RowID, @ReturID, @NoRetur, @TglRetur, @Pemasok, @Penerima, @NoMPR, @TglKeluar, @Pengirim, @TglKirim, @isClosed, @NPrint, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	END

	CLOSE data_cursor	
	DEALLOCATE data_cursor


END



 
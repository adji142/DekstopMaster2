USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_Expedisi]    Script Date: 10/11/2011 13:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Nobon
-- Create date: 20 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_Expedisi '<root><row KodeExpedisi="" NamaExpedisi="" Alamat="" Telp="" KotaTujuan="" SyncFlag="0" LastUpdatedBy="Admin" LastUpdatedTime="2011-01-07T10:43:27.800"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_Expedisi] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @KodeExpedisi varchar(3)
	DECLARE @NamaExpedisi varchar(40)
	DECLARE @Alamat varchar(60)
	DECLARE @Telp varchar(32)
	DECLARE @KotaTujuan varchar(80)
	DECLARE @SyncFlag bit
	DECLARE @LastUpdatedBy varchar(250)
	DECLARE @LastUpdatedTime datetime

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- INTerfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	
	DECLARE @Temp TABLE
	(
		KodeExpedisi varchar(3),
		NamaExpedisi varchar(40),
		Alamat varchar(60),
		Telp varchar(32),
		KotaTujuan varchar(80),
		SyncFlag bit,
		LastUpdatedBy varchar(250),
		LastUpdatedTime datetime
	)

		exec sp_xml_preparedocument @hdoc OUTPUT, @doc
	
	INSERT INTO @Temp
	(
		KodeExpedisi, NamaExpedisi, Alamat, Telp, KotaTujuan, SyncFlag, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		KodeExpedisi, 
		NamaExpedisi,
		Alamat, 
		Telp, 
		KotaTujuan, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		KodeExpedisi varchar(3) '@KodeExpedisi',
		NamaExpedisi varchar(40) '@NamaExpedisi',
		Alamat varchar(60) '@Alamat',
		Telp varchar(32) '@Telp',
		KotaTujuan varchar(80) '@KotaTujuan',
		SyncFlag bit '@SyncFlag',
		LastUpdatedBy varchar(250) '@LastUpdatedBy',
		LastUpdatedTime datetime '@LastUpdatedTime'
	)

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		KodeExpedisi, 
		NamaExpedisi,
		Alamat, 
		Telp, 
		KotaTujuan, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@KodeExpedisi, @NamaExpedisi, @Alamat, @Telp, @KotaTujuan, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
    -- Insert statements for procedure here
		SET @SyncFlag = 1
    
		IF EXISTS (SELECT KodeExpedisi FROM dbo.Expedisi (NOLOCK) WHERE KodeExpedisi = @KodeExpedisi)
			UPDATE Expedisi WITH (ROWLOCK)
			SET
				KodeExpedisi = @KodeExpedisi,
				NamaExpedisi = @NamaExpedisi,
				Alamat = @Alamat,
				Telp = @Telp,
				KotaTujuan = @KotaTujuan,
				SyncFlag = @SyncFlag,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				KodeExpedisi = @KodeExpedisi
		ELSE
			INSERT INTO Expedisi WITH (ROWLOCK)
			(KodeExpedisi, NamaExpedisi, Alamat, Telp, KotaTujuan, SyncFlag, LastUpdatedBy, LastUpdatedTime)
			VALUES	(
						@KodeExpedisi,
						@NamaExpedisi,
						@Alamat,
						@Telp,
						@KotaTujuan,
						@SyncFlag,
						@LastUpdatedBy,
						@LastUpdatedTime					
					)
		
		FETCH NEXT FROM data_cursor INTO
		@KodeExpedisi, @NamaExpedisi, @Alamat, @Telp, @KotaTujuan, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime
	
	END
	CLOSE data_cursor	
	DEALLOCATE data_cursor
			

END




 
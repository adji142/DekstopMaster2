USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_Mutasi]    Script Date: 10/11/2011 13:47:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nobon
-- Create date: 20 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_Mutasi '<root><row RowID="0AF4F11B-9807-4AD9-801D-B2600DC6A8B3" MutasiID="C092004010216:39:12" TglMutasi="2004-01-02T00:00:00" NomorMutasi="PERBAIKAN" KeteranganMutasi="PERBAIKAN BOGOR" SyncFlag="1" LAudit="1" TipeMutasi="T" LastUpdatedBy="Admin" LastUpdatedTime="2011-02-25T15:04:08.117"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_Mutasi] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @MutasiID VARCHAR(19)
	DECLARE @TglMutasi DATETIME
	DECLARE @NomorMutasi VARCHAR(50)
	DECLARE @KeteranganMutasi VARCHAR(63)
	DECLARE @SyncFlag BIT
	DECLARE @LAudit BIT
	DECLARE @TipeMutasi VARCHAR(1)
	DECLARE @LastUpdatedBy VARCHAR(250)
	DECLARE @LastUpdatedTime DATETIME

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- INTerfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	
	DECLARE @Temp TABLE
	(
		RowID UNIQUEIDENTIFIER,
		MutasiID VARCHAR(19),
		TglMutasi DATETIME,
		NomorMutasi VARCHAR(50),
		KeteranganMutasi VARCHAR(63),
		SyncFlag BIT,
		LAudit BIT,
		TipeMutasi VARCHAR(1),
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc

	INSERT INTO @Temp
	(
		RowID, MutasiID, TglMutasi, NomorMutasi, KeteranganMutasi, SyncFlag, LAudit, TipeMutasi, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		MutasiID, 
		TglMutasi, 
		NomorMutasi, 
		KeteranganMutasi, 
		SyncFlag, 
		LAudit, 
		TipeMutasi, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		MutasiID VARCHAR(19) '@MutasiID',
		TglMutasi DATETIME '@TglMutasi',
		NomorMutasi VARCHAR(50) '@NomorMutasi',
		KeteranganMutasi VARCHAR(63) '@KeteranganMutasi',
		SyncFlag BIT '@SyncFlag',
		LAudit BIT '@LAudit',
		TipeMutasi VARCHAR(1) '@TipeMutasi',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy',
		LastUpdatedTime DATETIME '@LastUpdatedTime'
	)

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID, 
		MutasiID, 
		TglMutasi, 
		NomorMutasi, 
		KeteranganMutasi, 
		SyncFlag, 
		LAudit, 
		TipeMutasi, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @MutasiID, @TglMutasi, @NomorMutasi, @KeteranganMutasi, @SyncFlag, @LAudit, @TipeMutasi, @LastUpdatedBy, @LastUpdatedTime

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.Mutasi (NOLOCK) WHERE RowID = @RowID)
			UPDATE Mutasi WITH (ROWLOCK)
			SET
				RowID = @RowID,
				MutasiID = @MutasiID,
				TglMutasi = @TglMutasi,
				NomorMutasi = @NomorMutasi,
				KeteranganMutasi = @KeteranganMutasi,
				SyncFlag = @SyncFlag,
				LAudit = @LAudit,
				TipeMutasi = @TipeMutasi,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			INSERT INTO Mutasi WITH (ROWLOCK)
			(RowID, MutasiID, TglMutasi, NomorMutasi, KeteranganMutasi, SyncFlag, LAudit, TipeMutasi, LastUpdatedBy, LastUpdatedTime)
			VALUES	(
						@RowID,
						@MutasiID,
						@TglMutasi,
						@NomorMutasi,
						@KeteranganMutasi,
						@SyncFlag,
						@LAudit,
						@TipeMutasi,
						@LastUpdatedBy,
						@LastUpdatedTime
					)
	FETCH NEXT FROM data_cursor INTO
		@RowID, @MutasiID, @TglMutasi, @NomorMutasi, @KeteranganMutasi, @SyncFlag, @LAudit, @TipeMutasi, @LastUpdatedBy, @LastUpdatedTime

	END

	CLOSE data_cursor	
	DEALLOCATE data_cursor
			


END



 
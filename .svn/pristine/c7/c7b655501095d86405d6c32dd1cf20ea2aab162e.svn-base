 USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_Sales]    Script Date: 10/11/2011 13:49:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nobon
-- Create date: 23 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_Sales '<root><row RowID="C53BF18B-1937-4A53-8290-F072100B10CD" SalesID="" NamaSales="XXX" RecID="" Alamat="" Target="0.00" BatasOD="0.00" SyncFlag="0" LastUpdatedBy="admin" LastUpdatedTime="2011-05-19T17:03:22.013"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_Sales] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @RowID UNIQUEIDENTIFIER
	DECLARE @SalesID VARCHAR(11)
	DECLARE @NamaSales VARCHAR(23)
	DECLARE @RecID VARCHAR(23)
	DECLARE @TglLahir DATETIME
	DECLARE @Alamat VARCHAR(30)
	DECLARE @Target NUMERIC(16, 2)
	DECLARE @BatasOD NUMERIC(16, 2)
	DECLARE @TglMasuk DATETIME
	DECLARE @TglKeluar DATETIME
	DECLARE @KodeGudang VARCHAR(31)
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
		SalesID VARCHAR(11),
		NamaSales VARCHAR(23),
		RecID VARCHAR(23),
		TglLahir DATETIME,
		Alamat VARCHAR(30),
		Target NUMERIC(16, 2),
		BatasOD NUMERIC(16, 2),
		TglMasuk DATETIME,
		TglKeluar DATETIME,
		KodeGudang VARCHAR(31),
		SyncFlag BIT,
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc

	INSERT INTO @Temp
	(
		RowID, SalesID, NamaSales, RecID, TglLahir, Alamat, Target, BatasOD, TglMasuk, TglKeluar, KodeGudang, SyncFlag, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		RowID, 
		SalesID, 
		NamaSales, 
		RecID, 
		TglLahir, 
		Alamat, 
		Target, 
		BatasOD, 
		TglMasuk, 
		TglKeluar, 
		KodeGudang, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		RowID UNIQUEIDENTIFIER '@RowID',
		SalesID VARCHAR(11) '@SalesID',
		NamaSales VARCHAR(23) '@NamaSales',
		RecID VARCHAR(23) '@RecID',
		TglLahir DATETIME '@TglLahir',
		Alamat VARCHAR(30) '@Alamat',
		Target NUMERIC(16, 2) '@Target',
		BatasOD NUMERIC(16, 2) '@BatasOD',
		TglMasuk DATETIME '@TglMasuk',
		TglKeluar DATETIME '@TglKeluar',
		KodeGudang VARCHAR(31) '@KodeGudang',
		SyncFlag BIT '@SyncFlag',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy',
		LastUpdatedTime DATETIME '@LastUpdatedTime'
	)

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		RowID, 
		SalesID, 
		NamaSales, 
		RecID, 
		TglLahir, 
		Alamat, 
		Target, 
		BatasOD, 
		TglMasuk, 
		TglKeluar, 
		KodeGudang, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@RowID, @SalesID, @NamaSales, @RecID, @TglLahir, @Alamat, @Target, @BatasOD, @TglMasuk, @TglKeluar, @KodeGudang, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT RowID FROM dbo.Sales (NOLOCK) WHERE RowID = @RowID)
			UPDATE Sales WITH (ROWLOCK)
			SET
				RowID = @RowID,
				SalesID = @SalesID,
				NamaSales = @NamaSales,
				RecID = @RecID,
				TglLahir = @TglLahir,
				Alamat = @Alamat,
				Target = @Target,
				BatasOD = @BatasOD,
				TglMasuk = @TglMasuk,
				TglKeluar = @TglKeluar,
				KodeGudang = @KodeGudang,
				SyncFlag = @SyncFlag,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				RowID = @RowID
		ELSE
			INSERT INTO Sales WITH (ROWLOCK)
			(RowID, SalesID, NamaSales, RecID, TglLahir, Alamat, Target, BatasOD, TglMasuk, TglKeluar, KodeGudang, SyncFlag, LastUpdatedBy, LastUpdatedTime)
				VALUES	(
							@RowID,
							@SalesID,
							@NamaSales,
							@RecID,
							@TglLahir,
							@Alamat,
							@Target,
							@BatasOD,
							@TglMasuk,
							@TglKeluar,
							@KodeGudang,
							@SyncFlag,
							@LastUpdatedBy,
							@LastUpdatedTime
						)
		FETCH NEXT FROM data_cursor INTO
		@RowID, @SalesID, @NamaSales, @RecID, @TglLahir, @Alamat, @Target, @BatasOD, @TglMasuk, @TglKeluar, @KodeGudang, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime

	END
	
	CLOSE data_cursor	
	DEALLOCATE data_cursor
			


END




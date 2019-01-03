USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_RekapKoliDetail_INSERT]    Script Date: 01/27/2011 14:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 27 Jan 11
-- Description:	Insert table RekapKolidetail
-- =============================================
CREATE PROCEDURE [dbo].[usp_RekapKoliDetail_INSERT] 
	-- Add the parameters for the stored procedure here
	 @rowID uniqueidentifier, 
	 @headerID uniqueidentifier, 
	 @notaJualID uniqueidentifier, 
	 @recordID varchar(23), 
	 @htrID varchar(23), 
	 @notaJualRecID varchar(23), 
	 @noNota varchar(7), 
	 @tunaiKredit varchar(1), 
	 @nominal money, 
	 @uraian varchar(12), 
	 @keterangan varchar(30), 
	 @noResi varchar(15), 
	 @syncFlag bit, 
	 @lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
        	
	INSERT INTO dbo.RekapKoliDetail
	(
		RowID, 
		HeaderID, 
		NotaJualID, 
		RecordID, 
		HtrID, 
		NotaJualRecID, 
		NoNota, 
		TunaiKredit, 
		Nominal, 
		Uraian, 
		Keterangan, 
		NoResi, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
	SELECT 
		@rowID, 
		@headerID, 
		@notaJualID, 
		@recordID, 
		@htrID, 
		@notaJualRecID, 
		@noNota, 
		@tunaiKredit, 
		@nominal, 
		@uraian, 
		@keterangan, 
		@noResi, 
		@syncFlag, 
		@lastUpdatedBy,
		GETDATE()

	DECLARE @tglSuratJalan datetime
	SELECT @tglSuratJalan = TglSuratJalan
	FROM dbo.RekapKoli 
	WHERE RowID = @headerID
	
	UPDATE dbo.NotaPenjualan 
	SET TglExpedisi = @tglSuratJalan,
		SyncFlag = 0
	WHERE RowID = @notaJualID
	
END






 
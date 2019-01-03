USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_RekapKoli_UPDATE]    Script Date: 01/27/2011 14:03:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 27 Jan 11
-- Description:	Update table RekapKoli
-- =============================================
CREATE PROCEDURE [dbo].[usp_RekapKoli_UPDATE] 
	-- Add the parameters for the stored procedure here	
	 @rowID uniqueidentifier, 
	 @recordID varchar(23), 
	 @tglSuratJalan datetime, 
	 @noSuratJalan varchar(7), 
	 @kodeToko varchar(19), 
	 @tglKeluar datetime, 
	 @kodeExp1 varchar(3), 
	 @kodeExp2 varchar(3), 
	 @kodeExp3 varchar(3), 
	 @shift int, 
	 @biayaExp1 money, 
	 @biayaExp2 money, 
	 @biayaExp3 money, 
	 @nPrint int, 
	 @kp varchar(3), 
	 @syncFlag bit, 
	 @lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here    
    
    UPDATE dbo.RekapKoli
    SET	
		RecordID = @recordID, 
		TglSuratJalan = @tglSuratJalan, 
		NoSuratJalan = @noSuratJalan, 
		KodeToko = @kodeToko, 
		TglKeluar = @tglKeluar, 
		KodeExp1 = @kodeExp1, 
		KodeExp2 = @kodeExp2, 
		KodeExp3 = @kodeExp3, 
		Shift = @shift, 
		BiayaExp1 = @biayaExp1, 
		BiayaExp2 = @biayaExp2, 
		BiayaExp3 = @biayaExp3, 
		NPrint = @nPrint, 
		KP = @kp, 
		SyncFlag = @syncFlag, 
		LastUpdatedBy = @lastUpdatedBy,
		LastUpdatedTime = GETDATE()
	WHERE
		RowID = @rowID	
END








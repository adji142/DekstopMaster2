USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_RekapKoli_INSERT]    Script Date: 01/27/2011 13:55:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 27 Jan 11
-- Description:	Insert table RekapKoli
-- =============================================
CREATE PROCEDURE [dbo].[usp_RekapKoli_INSERT] 
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
        	
	INSERT INTO dbo.RekapKoli
	(
		RowID, 
		RecordID, 
		TglSuratJalan, 
		NoSuratJalan, 
		KodeToko, 
		TglKeluar, 
		KodeExp1, 
		KodeExp2, 
		KodeExp3, 
		Shift, 
		BiayaExp1, 
		BiayaExp2, 
		BiayaExp3, 
		NPrint, 
		KP, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
	SELECT 
		@rowID, 
		@recordID, 
		@tglSuratJalan,
		@noSuratJalan, 
		@kodeToko, 
		@tglKeluar,
		@kodeExp1, 
		@kodeExp2, 
		@kodeExp3, 
		@shift,  
		@biayaExp1, 
		@biayaExp2, 
		@biayaExp3, 
		@nPrint, 
		@kp, 
		@syncFlag, 
		@lastUpdatedBy, 
		GETDATE()
	
END






 
USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Expedisi_UPDATE]') IS NOT NULL
DROP PROC [dbo].[usp_Expedisi_UPDATE] 
GO

/****** Object:  StoredProcedure [dbo].[usp_Expedisi_UPDATE]    Script Date: 01/07/2011 11:11:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Stephanie
-- Create date: 04 Jan 11
-- Description:	Update table Expedisi
-- =============================================
CREATE PROCEDURE [dbo].[usp_Expedisi_UPDATE] 
	-- Add the parameters for the stored procedure here	
	 @kodeExpedisi varchar(3),
	 @namaExpedisi varchar(40),
	 @alamat varchar(60),
	 @kotaTujuan varchar(80) ,
	 @lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    
    UPDATE dbo.Expedisi
    SET	
		KodeExpedisi = @kodeExpedisi,
		NamaExpedisi = @namaExpedisi,
		Alamat = @alamat,
		KotaTujuan = @kotaTujuan,
		LastUpdatedBy = @lastUpdatedBy,
		LastUpdatedTime = GETDATE()
	WHERE
		KodeExpedisi = @kodeExpedisi	
END






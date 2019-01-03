USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Expedisi_INSERT]') IS NOT NULL
DROP PROC [dbo].[usp_Expedisi_INSERT] 
GO

/****** Object:  StoredProcedure [dbo].[usp_Expedisi_INSERT]    Script Date: 01/07/2011 11:10:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Stephanie
-- Create date: 04 Jan 11
-- Description:	Insert table Expedisi
-- =============================================
CREATE PROCEDURE [dbo].[usp_Expedisi_INSERT] 
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
        	
	INSERT INTO dbo.Expedisi
	(
		KodeExpedisi, 
		NamaExpedisi, 
		Alamat, 
		Telp, 
		KotaTujuan, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
	SELECT 
		@kodeExpedisi,
		@namaExpedisi,
		@alamat,
		NULL,
		@kotaTujuan,
		0,
		@lastUpdatedBy,
		GETDATE()
	
END





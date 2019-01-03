USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Expedisi_LIST]') IS NOT NULL
DROP PROC [dbo].[usp_Expedisi_LIST] 
GO

/****** Object:  StoredProcedure [dbo].[usp_Expedisi_LIST]    Script Date: 01/07/2011 11:16:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		Stephanie
-- Create date: 04 Jan 11
-- Description:	List data on table Expedisi
-- =============================================
CREATE PROCEDURE [dbo].[usp_Expedisi_LIST] 
	-- Add the parameters for the stored procedure here
	@kodeExpedisi varchar(3) = null,
	@namaExpedisi varchar(40) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		KodeExpedisi, 
		NamaExpedisi, 
		Alamat, 
		Telp, 
		KotaTujuan, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM dbo.Expedisi  		
	WHERE
	(KodeExpedisi = @kodeExpedisi OR @kodeExpedisi IS NULL)
	AND	
	(UPPER(NamaExpedisi) LIKE UPPER('%' + @namaExpedisi + '%') OR @namaExpedisi IS NULL)
    
END







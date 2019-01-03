USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Expedisi_DELETE]') IS NOT NULL
DROP PROC [dbo].[usp_Expedisi_DELETE] 
GO

/****** Object:  StoredProcedure [dbo].[usp_Expedisi_DELETE]    Script Date: 01/07/2011 10:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Stephanie
-- Create date: 04 Jan 11
-- Description:	Delete data on table Expedisi
-- =============================================
CREATE PROCEDURE [dbo].[usp_Expedisi_DELETE] 
	-- Add the parameters for the stored procedure here
	@kodeExpedisi varchar(3)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
           
	DELETE Expedisi
	WHERE
		KodeExpedisi = @kodeExpedisi
    
END






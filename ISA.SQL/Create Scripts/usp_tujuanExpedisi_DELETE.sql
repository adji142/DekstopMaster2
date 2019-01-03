USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_TujuanExpedisi_DELETE]') IS NOT NULL
DROP PROC [dbo].[usp_TujuanExpedisi_DELETE] 
GO


/****** Object:  StoredProcedure [dbo].[usp_TujuanExpedisi_DELETE]    Script Date: 01/03/2011 16:11:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- ================================================
-- Author:		Stephanie
-- Create date: 03 Jan 11
-- Description:	Delete data on table TujuanExpedisi
-- ================================================
CREATE PROCEDURE [dbo].[usp_TujuanExpedisi_DELETE] 
	-- Add the parameters for the stored procedure here
	@tujuan varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
           
	DELETE TujuanExpedisi 		
	WHERE
		Tujuan = @tujuan
    
END





 
USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_TujuanExpedisi_INSERT]') IS NOT NULL
DROP PROC [dbo].[usp_TujuanExpedisi_INSERT] 
GO


/****** Object:  StoredProcedure [dbo].[usp_TujuanExpedisi_INSERT]    Script Date: 01/03/2011 16:25:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Stephanie
-- Create date: 03 Jan 11
-- Description:	Insert table TujuanExpedisi
-- =============================================
CREATE PROCEDURE [dbo].[usp_TujuanExpedisi_INSERT] 
	-- Add the parameters for the stored procedure here
	 @tujuan varchar(20),
	 @lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
        	
	INSERT INTO dbo.TujuanExpedisi
	(
		Tujuan,
		LastUpdatedBy,
		LastUpdatedTime
	)
	SELECT 
		@Tujuan,
		@lastUpdatedBy,
		GETDATE()
	
END




  
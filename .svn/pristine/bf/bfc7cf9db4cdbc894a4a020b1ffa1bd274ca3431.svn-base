USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_TujuanExpedisi_UPDATE]') IS NOT NULL
DROP PROC [dbo].[usp_TujuanExpedisi_UPDATE] 
GO


/****** Object:  StoredProcedure [dbo].[usp_TujuanExpedisi_UPDATE]    Script Date: 01/04/2011 14:30:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Stephanie
-- Create date: 04 Jan 11
-- Description:	Update table TujuanExpedisi
-- =============================================
CREATE PROCEDURE [dbo].[usp_TujuanExpedisi_UPDATE] 
	-- Add the parameters for the stored procedure here	
	@tujuanAwal varchar(20),
	@tujuan varchar(20),
	@lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    
    UPDATE dbo.TujuanExpedisi 
    SET	
		Tujuan = @tujuan,
		LastUpdatedBy = @lastUpdatedBy,
		LastUpdatedTime = GETDATE()
	WHERE
		Tujuan = @tujuanAwal	
END
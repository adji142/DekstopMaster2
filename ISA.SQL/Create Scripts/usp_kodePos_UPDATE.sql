USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_KodePos_UPDATE]') IS NOT NULL
DROP PROC [dbo].[usp_KodePos_UPDATE] 
GO

/****** Object:  StoredProcedure [dbo].[usp_KodePos_UPDATE]    Script Date: 01/07/2011 09:24:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Stephanie
-- Create date: 01 Dec 10
-- Description:	Update table KodePos
-- =============================================
CREATE PROCEDURE [dbo].[usp_KodePos_UPDATE] 
	-- Add the parameters for the stored procedure here	
	@kodePosAwal varchar(3),
	@kodePos varchar(3),
	@wilayah varchar(2),
	@lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    
    UPDATE dbo.KodePos
    SET	
		KodePos = @kodePos, 
		Wilayah = @wilayah, 
		LastUpdatedBy = @lastUpdatedBy,
		LastUpdatedTime = GETDATE()
	WHERE
		KodePos = @kodePosAwal
END






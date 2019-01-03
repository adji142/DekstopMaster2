 USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_KodePos_LIST]') IS NOT NULL
DROP PROC [dbo].[usp_KodePos_LIST] 
GO

/****** Object:  StoredProcedure [dbo].[usp_KodePos_LIST]    Script Date: 01/04/2011 14:47:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		Stephanie
-- Create date: 04 jan 11
-- Description:	List data on table KodePos
-- =============================================
CREATE PROCEDURE [dbo].[usp_KodePos_LIST] 
	-- Add the parameters for the stored procedure here
	@kodePos varchar(3) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		KodePos, 
		Wilayah, 
		LastUpdatedBy,
		LastUpdatedTime
	FROM dbo.KodePos		
	WHERE
	(KodePos = @kodePos OR @kodePos IS NULL)
    
END







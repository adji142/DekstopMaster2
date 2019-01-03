 USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_KodePos_INSERT]') IS NOT NULL
DROP PROC [dbo].[usp_KodePos_INSERT] 
GO

/****** Object:  StoredProcedure [dbo].[usp_KodePos_INSERT]    Script Date: 01/04/2011 14:47:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Stephanie
-- Create date: 04 Jan 11
-- Description:	Insert table KodePos
-- =============================================
CREATE PROCEDURE [dbo].[usp_KodePos_INSERT] 
	-- Add the parameters for the stored procedure here
	 @kodePos varchar(3),
	 @wilayah varchar(2),
	 @lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
        	
	INSERT INTO dbo.KodePos
	(
		KodePos, 
		Wilayah, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
	SELECT 
		@kodePos, 
		@wilayah,
		@lastUpdatedBy,
		GETDATE()
	
END





USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_ErrorLog_INSERT]') IS NOT NULL
DROP PROC [dbo].[usp_ErrorLog_INSERT] 
GO

/****** Object:  StoredProcedure [dbo].[usp_ErrorLog_INSERT]    Script Date: 01/12/2011 11:41:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









-- =============================================
-- Author:		Raymond
-- Create date: 01 Dec 10
-- Description:	Insert table Error Log
-- =============================================
CREATE PROCEDURE [dbo].[usp_ErrorLog_INSERT] 
	-- Add the parameters for the stored procedure here		
	@tglError datetime,
	@source varchar(500),
	@message varchar(3000),
	@stackTrace varchar(3000), 
	@lastUpdatedBy varchar(250)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
        	
	INSERT INTO dbo.ErrorLog
	(		
		TglError, 
		Source, 
		Message, 
		StackTrace, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
	SELECT 		 
		@tglError, 
		@source, 
		@message, 
		@stackTrace, 
		@lastUpdatedBy, 
		GETDATE()
	
	SELECT @@IDENTITY
END









GO



USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_ErrorLog_LIST]') IS NOT NULL
DROP PROC [dbo].[usp_ErrorLog_LIST] 
GO

/****** Object:  StoredProcedure [dbo].[usp_ErrorLog_LIST]    Script Date: 01/12/2011 11:40:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









-- =============================================
-- Author:		Raymond
-- Create date: 01 Dec 10
-- Description:	List data on table Error
-- Example : [usp_ErrorLog_LIST] null
--			 [usp_ErrorLog_LIST] 1
--			  [usp_ErrorLog_LIST] null, '1/1/2011','1/31/2011'
-- =============================================
CREATE PROCEDURE [dbo].[usp_ErrorLog_LIST] 
	-- Add the parameters for the stored procedure here
	@rowID int = null,
	@fromDate DateTime = null,
	@toDate DateTime = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		RowID, 
		TglError, 
		[Source], 
		[Message], 
		StackTrace, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM dbo.ErrorLog  		
	WHERE
	(RowID = @rowID OR @rowID IS NULL)
	AND (TglError >= @fromDate OR @fromDate IS NULL)
	AND (TglError <= @toDate OR @toDate IS NULL)
    
END









GO



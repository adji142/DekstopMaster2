 USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Lookup_UPDATE]') IS NOT NULL
DROP PROC [dbo].[usp_Lookup_UPDATE] 
GO

/****** Object:  StoredProcedure [dbo].[usp_Lookup_UPDATE]    Script Date: 01/06/2011 13:28:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		Stephanie
-- Create date: 06 Jan 11
-- Description:	Update table Lookup
-- =============================================
CREATE PROCEDURE [dbo].[usp_Lookup_UPDATE] 
	-- Add the parameters for the stored procedure here	
	@lookupCode varchar(50),
	@lookupType varchar(50),
	@value varchar(250),
	@additionalInfo varchar(50),
	@rowOrder int,
	@lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    
    UPDATE dbo.[Lookup]
    SET	
		LookupCode = @lookupCode,
		LookupType = @lookupType,
		Value = @value,
		AdditionalInfo = @additionalInfo,
		RowOrder = @rowOrder,
		LastUpdatedBy = @lastUpdatedBy,
		LastUpdatedTime = GETDATE()
	WHERE
		(LookupCode = @lookupCode)
		AND
		(LookupType = @lookupType)	
		
END







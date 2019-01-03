USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Lookup_LIST]') IS NOT NULL
DROP PROC [dbo].[usp_Lookup_LIST] 
GO

/****** Object:  StoredProcedure [dbo].[usp_Lookup_LIST]    Script Date: 01/06/2011 13:19:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		Stephanie
-- Create date: 06 Jan 11
-- Description:	List data on table Lookup
-- =============================================
CREATE PROCEDURE [dbo].[usp_Lookup_LIST] 
	-- Add the parameters for the stored procedure here
	@lookupCode varchar(50) = null,
	@lookupType varchar(50) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		LookupCode,
		LookupType,
		Value,
		AdditionalInfo,
		RowOrder,
		LastUpdatedBy,
		LastUpdatedTime
	FROM dbo.[Lookup]  		
	WHERE
	(LookupCode = @lookupCode OR @lookupCode IS NULL)
	AND
	(LookupType = @lookupType OR @lookupType is NULL)
    
END







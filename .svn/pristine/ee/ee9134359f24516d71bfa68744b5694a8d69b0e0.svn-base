USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Lookup_INSERT]') IS NOT NULL
DROP PROC [dbo].[usp_Lookup_INSERT] 
GO

/****** Object:  StoredProcedure [dbo].[usp_Lookup_INSERT]    Script Date: 01/06/2011 13:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Stephanie
-- Create date: 06 Jan 11
-- Description:	Insert table Lookup
-- =============================================
CREATE PROCEDURE [dbo].[usp_Lookup_INSERT] 
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
        	
	INSERT INTO dbo.[Lookup]
	(
		LookupCode, 
		LookupType, 
		[Value], 
		AdditionalInfo, 
		RowOrder,
		LastUpdatedBy,
		LastUpdatedTime
	)
	SELECT 
		@lookupCode,
		@lookupType,
		@value,
		@additionalInfo,
		@rowOrder,
		@lastUpdatedBy,
		GETDATE()
	
END





USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Lookup_DELETE]') IS NOT NULL
DROP PROC [dbo].[usp_Lookup_DELETE] 
GO


/****** Object:  StoredProcedure [dbo].[usp_Lookup_DELETE]    Script Date: 01/06/2011 13:01:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Stephanie
-- Create date: 06 Jan 11
-- Description:	Delete data on table Lookup
-- =============================================
CREATE PROCEDURE [dbo].[usp_Lookup_DELETE] 
	-- Add the parameters for the stored procedure here
	@lookupCode varchar(50),
	@lookupType varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
           
	DELETE dbo.[Lookup]  		
	WHERE
		(LookupCode = @lookupCode AND LookupType = @lookupType)
    
END





 
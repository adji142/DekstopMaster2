USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_NotaPenjualanDetail_DELETE]    Script Date: 01/24/2011 11:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =====================================================
-- Author:		Stephanie
-- Create date: 24 Jan 11
-- Description:	Delete data on table NotaPenjualanDetail
-- =====================================================
CREATE PROCEDURE [dbo].[usp_NotaPenjualanDetail_DELETE] 
	-- Add the parameters for the stored procedure here
	@headerID uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
           
	DELETE NotaPenjualanDetail		
	WHERE
		HeaderID = @headerID
    
END






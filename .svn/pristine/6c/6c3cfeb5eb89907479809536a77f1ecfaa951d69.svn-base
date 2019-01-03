USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_User_DELETE]    Script Date: 01/07/2011 14:16:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Stephanie
-- Create date: 07 Jan 11
-- Description:	Delete data on table Users
-- =============================================
CREATE PROCEDURE [dbo].[usp_User_DELETE] 
	-- Add the parameters for the stored procedure here
	@userID varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
           
	DELETE Users  		
	WHERE
		UserID = @userID
    
END





 
USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_User_LIST]    Script Date: 01/07/2011 14:38:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		Stephanie
-- Create date: 07 Jan 11
-- Description:	List data on table Users
-- =============================================
CREATE PROCEDURE [dbo].[usp_User_LIST] 
	-- Add the parameters for the stored procedure here
	@userID varchar(250) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		UserID,
		UserName,
		Password,
		RoleApplicationID,
		RoleBusinessID,
		LastUpdatedBy,
		LastUpdatedTime
	FROM dbo.Users 		
	WHERE
	(UserID = @userID OR @userID IS NULL)
    
END








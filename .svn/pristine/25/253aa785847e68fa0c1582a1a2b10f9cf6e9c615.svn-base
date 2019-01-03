USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_User_INSERT]    Script Date: 01/07/2011 14:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		Stephanie
-- Create date: 07 Jan 11
-- Description:	Insert table Users
-- =============================================
CREATE PROCEDURE [dbo].[usp_User_INSERT] 
	-- Add the parameters for the stored procedure here
	 @userID varchar(250),
	 @userName varchar(250),
	 @password varchar(250),
	 @roleApplicationID varchar(50),
	 @roleBusinessID varchar(50),
	 @lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
        	
	INSERT INTO dbo.Users
	(
		UserID,
		UserName,
		Password,
		RoleApplicationID,
		RoleBusinessID,
		LastUpdatedBy,
		LastUpdatedTime
	)
	SELECT 
		@userID, 
		@userName,
		@password, 
		@roleApplicationID, 
		@roleBusinessID, 
		@lastUpdatedBy,
		GETDATE()
	
END







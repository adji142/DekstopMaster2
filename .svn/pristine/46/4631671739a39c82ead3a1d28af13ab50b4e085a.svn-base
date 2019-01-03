 USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_User_UPDATE]    Script Date: 01/07/2011 14:30:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		Stephanie
-- Create date: 07 Jan 11
-- Description:	Update table Users
-- =============================================
CREATE PROCEDURE [dbo].[usp_User_UPDATE] 
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
    
    
    UPDATE dbo.Users 
    SET	
		UserName = @userName,
		Password = @password, 
		RoleApplicationID = @roleApplicationID, 
		RoleBusinessID = @roleBusinessID,
		LastUpdatedBy = @lastUpdatedBy,
		LastUpdatedTime = GETDATE()
	WHERE
		UserID = @userID	
END








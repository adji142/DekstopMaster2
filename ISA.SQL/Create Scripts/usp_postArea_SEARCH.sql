USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_PostArea_SEARCH]    Script Date: 03/09/2011 14:06:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 09 Mar 11
-- Description:	Search data on table PostArea
-- =============================================
ALTER PROCEDURE [dbo].[usp_PostArea_SEARCH] 
	-- Add the parameters for the stored procedure here
	@searchArg varchar(3) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		PostID,
		PostName
	FROM dbo.PostArea
	WHERE
		(PostID LIKE '%' + @searchArg + '%') OR (@searchArg IS NULL)
	ORDER BY PostID
    
END
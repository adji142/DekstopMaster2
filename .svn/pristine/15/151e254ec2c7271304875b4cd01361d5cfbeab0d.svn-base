USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Toko_DELETE]') IS NOT NULL
DROP PROC [dbo].[usp_Toko_DELETE] 
GO

/****** Object:  StoredProcedure [dbo].[usp_Toko_DELETE]    Script Date: 01/11/2011 10:41:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Stephanie
-- Create date: 11 Jan 11
-- Description:	Delete data on table Toko
-- =============================================
CREATE PROCEDURE [dbo].[usp_Toko_DELETE] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
           
	DELETE Toko		
	WHERE
		RowID = @rowID
    
END





 
USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Stok_DELETE]') IS NOT NULL
DROP PROC [dbo].[usp_Stok_DELETE] 
GO


/****** Object:  StoredProcedure [dbo].[usp_Stok_DELETE]    Script Date: 01/05/2011 14:03:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Stephanie
-- Create date: 05 Jan 11
-- Description:	Delete data on table Stok
-- =============================================
CREATE PROCEDURE [dbo].[usp_Stok_DELETE] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
           
	DELETE Stok	
	WHERE
		RowID = @rowID
    
END






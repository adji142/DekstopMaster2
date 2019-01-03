USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Sales_DELETE]') IS NOT NULL
DROP PROC [dbo].[usp_Sales_DELETE] 
GO


/****** Object:  StoredProcedure [dbo].[usp_Sales_DELETE]    Script Date: 01/13/2011 09:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		Gemma
-- Create date: 05 Januari 2011
-- Description:	Delete data on table Sales
-- =============================================
ALTER PROCEDURE [dbo].[usp_Sales_DELETE] 
	-- Add the parameters for the stored procedure here
	@RowID uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
           
	DELETE Sales	
	WHERE
		RowID = @RowID
    
END






 
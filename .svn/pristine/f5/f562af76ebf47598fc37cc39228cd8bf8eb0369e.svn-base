USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_OrderPenjualan_DELETE]') IS NOT NULL
DROP PROC [dbo].[usp_OrderPenjualan_DELETE] 
GO


/****** Object:  StoredProcedure [dbo].[usp_OrderPenjualan_DELETE]    Script Date: 01/13/2011 09:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =================================================
-- Author:		Stephanie
-- Create date: 13 Jan 11
-- Description:	Delete data on table OrderPenjualan
-- =================================================
CREATE PROCEDURE [dbo].[usp_OrderPenjualan_DELETE] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
           
	DELETE OrderPenjualan 		
	WHERE
		RowID = @rowID
    
END





 
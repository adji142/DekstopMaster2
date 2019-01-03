USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_ReturPenjualan_DELETE]') IS NOT NULL
DROP PROC [dbo].[usp_ReturPenjualan_DELETE] 
GO

/****** Object:  StoredProcedure [dbo].[usp_ReturPenjualan_DELETE]    Script Date: 02/08/2011 11:39:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =================================================
-- Author:		Stephanie
-- Create date: 08 Feb 11
-- Description:	Delete data on table ReturPenjualan
-- =================================================
CREATE PROCEDURE [dbo].[usp_ReturPenjualan_DELETE] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
           
	DELETE ReturPenjualan  		
	WHERE
		RowID = @rowID
    
END 
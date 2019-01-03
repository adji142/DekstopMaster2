 USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_OrderPenjualanDetail_DELETE]') IS NOT NULL
DROP PROC [dbo].[usp_OrderPenjualanDetail_DELETE] 
GO


/****** Object:  StoredProcedure [dbo].[usp_OrderPenjualanDetail_DELETE]    Script Date: 01/31/2011 16:40:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ======================================================
-- Author:		Stephanie
-- Create date: 13 Jan 11
-- Description:	Delete data on table OrderPenjualanDetail
-- ======================================================
ALTER PROCEDURE [dbo].[usp_OrderPenjualanDetail_DELETE] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier = NULL,
	@headerID uniqueidentifier = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
           
	IF (@rowID IS NOT NULL)
	BEGIN
	DELETE OrderPenjualanDetail		
	WHERE
		RowID = @rowID
	END
	
	ELSE
	BEGIN
		IF (@headerID IS NOT NULL)
		BEGIN
		DELETE OrderPenjualanDetail
		WHERE
			HeaderID = @headerID
		END
	END
    
END
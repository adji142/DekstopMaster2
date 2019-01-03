USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_ReturPenjualanDetail_DELETE]') IS NOT NULL
DROP PROC [dbo].[usp_ReturPenjualanDetail_DELETE] 
GO

/****** Object:  StoredProcedure [dbo].[usp_ReturPenjualanDetail_DELETE]    Script Date: 02/08/2011 11:37:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ======================================================
-- Author:		Stephanie
-- Create date: 08 Feb 11
-- Description:	Delete data on table ReturPenjualanDetail
-- ======================================================
CREATE PROCEDURE [dbo].[usp_ReturPenjualanDetail_DELETE] 
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
	DELETE ReturPenjualanDetail  		
	WHERE		
		RowID = @rowID
	END

	ELSE
	BEGIN
		IF (@headerID IS NOT NULL)
		BEGIN
		DELETE ReturPenjualanDetail
		WHERE
			HeaderID = @headerID
		END
	END
    
END






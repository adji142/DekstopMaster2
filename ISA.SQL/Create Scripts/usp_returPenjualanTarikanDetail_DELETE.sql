USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_ReturPenjualanTarikanDetail_DELETE]') IS NOT NULL
DROP PROC [dbo].[usp_ReturPenjualanTarikanDetail_DELETE] 
GO

/****** Object:  StoredProcedure [dbo].[usp_ReturPenjualanTarikanDetail_DELETE]    Script Date: 02/17/2011 10:08:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================================
-- Author:		Stephanie
-- Create date: 17 Feb 11
-- Description:	Delete data on table ReturPenjualanTarikanDetail
-- =============================================================
CREATE PROCEDURE [dbo].[usp_ReturPenjualanTarikanDetail_DELETE] 
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
	DELETE ReturPenjualanTarikanDetail  		
	WHERE		
		RowID = @rowID
	END

	ELSE
	BEGIN
		IF (@headerID IS NOT NULL)
		BEGIN
		DELETE ReturPenjualanTarikanDetail
		WHERE
			HeaderID = @headerID
		END
	END
    
END






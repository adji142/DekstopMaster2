USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_ReturPembelian_DELETE]    Script Date: 04/13/2011 13:06:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =================================================
-- Author:		Stephanie
-- Create date: 13 Apr 11
-- Description:	Delete data on table ReturPembelian
-- =================================================
CREATE PROCEDURE [dbo].[usp_ReturPembelian_DELETE] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
           
	DELETE ReturPembelian	
	WHERE
		RowID = @rowID
    
END
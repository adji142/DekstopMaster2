 USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_NotaPenjualan_DELETE]    Script Date: 01/20/2011 13:31:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- Author:		Stephanie
-- Create date: 20 Jan 11
-- Description:	Delete data on table NotaPenjualan
-- ===============================================
CREATE PROCEDURE [dbo].[usp_NotaPenjualan_DELETE] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
           
	DELETE NotaPenjualan 		
	WHERE
		RowID = @rowID
    
END



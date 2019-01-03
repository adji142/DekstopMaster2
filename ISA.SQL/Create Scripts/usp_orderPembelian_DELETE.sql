USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_OrderPembelian_DELETE]    Script Date: 04/05/2011 11:50:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =================================================
-- Author:		Stephanie
-- Create date: 05 Apr 11
-- Description:	Delete data on table OrderPembelian
-- =================================================
CREATE PROCEDURE [dbo].[usp_OrderPembelian_DELETE] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
           
	DELETE OrderPembelian 		
	WHERE
		RowID = @rowID
    
END 
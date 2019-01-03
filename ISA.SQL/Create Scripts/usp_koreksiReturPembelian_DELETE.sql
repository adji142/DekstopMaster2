USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_KoreksiReturPembelian_DELETE]    Script Date: 04/18/2011 11:41:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =======================================================
-- Author:		Stephanie
-- Create date: 18 Apr 11 
-- Description:	Delete data on table KoreksiReturPembelian
-- =======================================================
ALTER PROCEDURE [dbo].[usp_KoreksiReturPembelian_DELETE] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
   
	DELETE dbo.KoreksiReturPembelian		
	WHERE
		RowID = @rowID
    
END 
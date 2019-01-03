USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_KoreksiPembelian_DELETE]    Script Date: 04/12/2011 11:22:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==================================================
-- Author:		Stephanie
-- Create date: 12 Feb 11 
-- Description:	Delete data on table KoreksiPembelian
-- ==================================================
CREATE PROCEDURE [dbo].[usp_KoreksiPembelian_DELETE] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
	DELETE dbo.KoreksiPembelian		
	WHERE
		RowID = @rowID
    
END
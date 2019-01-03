USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_NotaPembelianDetail_DELETE]    Script Date: 04/06/2011 10:14:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =======================================================
-- Author:		Stephanie
-- Create date: 06 Apr 11
-- Description:	Delete data on table NotaPembelianDetail
-- =======================================================
CREATE PROCEDURE [dbo].[usp_NotaPembelianDetail_DELETE] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
           
	DELETE dbo.NotaPembelianDetail 		
	WHERE
		RowID = @rowID
    
END
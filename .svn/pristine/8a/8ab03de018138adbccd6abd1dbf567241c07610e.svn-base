USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_KoreksiPenjualan_DELETE]    Script Date: 03/31/2011 09:26:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==================================================
-- Author:		Stephanie
-- Create date: 02 Feb 11 
-- Description:	Delete data on table KoreksiPenjualan
-- ==================================================
CREATE PROCEDURE [dbo].[usp_KoreksiPenjualan_DELETE] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
        
	UPDATE dbo.NotaPenjualanDetail
	SET SyncFlag = 0
	FROM dbo.KoreksiPenjualan a 
		LEFT OUTER JOIN	dbo.NotaPenjualanDetail b ON a.NotaJualDetailID = b.RowID
	WHERE a.RowID = @rowID

	UPDATE dbo.NotaPenjualan
	SET SyncFlag = 0
	FROM dbo.KoreksiPenjualan a 
		LEFT OUTER JOIN	dbo.NotaPenjualanDetail b ON a.NotaJualDetailID = b.RowID
		LEFT OUTER JOIN dbo.NotaPenjualan c ON b.HeaderID = c.RowID
	WHERE a.RowID = @rowID
   
	DELETE dbo.KoreksiPenjualan 		
	WHERE
		RowID = @rowID
    
END






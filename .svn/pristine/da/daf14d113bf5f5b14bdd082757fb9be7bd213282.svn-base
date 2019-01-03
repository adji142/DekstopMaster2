USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_KoreksiReturPenjualan_DELETE]    Script Date: 03/31/2011 09:31:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =======================================================
-- Author:		Stephanie
-- Create date: 30 Mar 11 
-- Description:	Delete data on table KoreksiReturPenjualan
-- =======================================================
CREATE PROCEDURE [dbo].[usp_KoreksiReturPenjualan_DELETE] 
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
	FROM dbo.KoreksiReturPenjualan a
		LEFT OUTER JOIN dbo.ReturPenjualanDetail b ON a.ReturJualDetailID = b.RowID
		LEFT OUTER JOIN dbo.NotaPenjualanDetail c ON b.NotaJualDetailID = c.RowID
	WHERE a.RowID = @rowID

	UPDATE dbo.NotaPenjualan
	SET SyncFlag = 0
	FROM dbo.KoreksiReturPenjualan a
		LEFT OUTER JOIN dbo.ReturPenjualanDetail b ON a.ReturJualDetailID = b.RowID
		LEFT OUTER JOIN dbo.NotaPenjualanDetail c ON b.NotaJualDetailID = c.RowID
		LEFT OUTER JOIN dbo.NotaPenjualan d ON c.HeaderID = d.RowID
	WHERE a.RowID = @rowID

	DELETE dbo.KoreksiReturPenjualan 		
	WHERE
		RowID = @rowID
    
END






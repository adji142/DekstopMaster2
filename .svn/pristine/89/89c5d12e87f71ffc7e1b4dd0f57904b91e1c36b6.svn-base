USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_ReturPenjualanDetail_UPDATE]') IS NOT NULL
DROP PROC [dbo].[usp_ReturPenjualanDetail_UPDATE] 
GO


/****** Object:  StoredProcedure [dbo].[usp_ReturPenjualanDetail_UPDATE]    Script Date: 02/17/2011 10:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ================================================
-- Author:		Stephanie
-- Create date: 08 Feb 11
-- Description:	Update table ReturPenjualanDetail
-- ================================================
CREATE PROCEDURE [dbo].[usp_ReturPenjualanDetail_UPDATE] 
	-- Add the parameters for the stored procedure here	
	 @rowID uniqueidentifier, 
	 @headerID uniqueidentifier,  
	 @notaJualDetailID uniqueidentifier, 
	 @recordID varchar(23),
	 @returID varchar(23), 
	 @notaJualDetailRecID varchar(23), 
	 @kodeRetur varchar(1), 
	 @qtyMemo int, 
	 @qtyTarik int, 
	 @qtyTerima int, 
	 @qtyGudang int, 
	 @qtyTolak int,  
	 @catatan1 varchar(30), 
	 @catatan2 varchar(30), 
	 @syncFlag bit, 
	 @kategori varchar(1), 
	 @kodeGudang varchar(4), 
	 @noACC varchar(6), 
	 @lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    
    UPDATE dbo.ReturPenjualanDetail
    SET	
		HeaderID = @headerID, 
		NotaJualDetailID = @notaJualDetailID, 
		RecordID = @recordID,
		ReturID = @returID, 
		NotaJualDetailRecID = @notaJualDetailRecID, 
		KodeRetur = @kodeRetur, 
		QtyMemo = @qtyMemo, 
		QtyTarik = @qtyTarik, 
		QtyTerima = @qtyTerima, 
		QtyGudang = @qtyGudang, 
		QtyTolak = @qtyTolak,
		Catatan1 = @catatan1, 
		Catatan2 = @catatan2,  
		SyncFlag = @syncFlag, 
		Kategori = @kategori, 
		KodeGudang = @kodeGudang, 
		NoACC = @noACC, 
		LastUpdatedBy = @lastUpdatedBy, 
		LastUpdatedTime = GETDATE()
	WHERE
		RowID = @rowID
END





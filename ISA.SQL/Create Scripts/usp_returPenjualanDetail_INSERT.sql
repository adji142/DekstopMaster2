USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_ReturPenjualanDetail_INSERT]') IS NOT NULL
DROP PROC [dbo].[usp_ReturPenjualanDetail_INSERT] 
GO

/****** Object:  StoredProcedure [dbo].[usp_ReturPenjualanDetail_INSERT]    Script Date: 02/17/2011 10:11:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==============================================
-- Author:		Stephanie
-- Create date: 08 Feb 11
-- Description:	Insert table ReturPenjualanDetail
-- ==============================================
CREATE PROCEDURE [dbo].[usp_ReturPenjualanDetail_INSERT] 
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
        	
	INSERT INTO dbo.ReturPenjualanDetail
	(
		RowID, 
		HeaderID, 
		NotaJualDetailID, 
		RecordID,
		ReturID, 
		NotaJualDetailRecID, 
		KodeRetur, 
		QtyMemo, 
		QtyTarik, 
		QtyTerima, 
		QtyGudang, 
		QtyTolak, 
		Catatan1, 
		Catatan2,  
		SyncFlag, 
		Kategori, 
		KodeGudang, 
		NoACC, 
		LastUpdatedBy, 
		LastUpdatedTime	
	)
	SELECT 
		@rowID, 
		@headerID, 
		@notaJualDetailID, 
		@recordID,
		@returID, 
		@notaJualDetailRecID, 
		@kodeRetur, 
		@qtyMemo, 
		@qtyTarik, 
		@qtyTerima, 
		@qtyGudang, 
		@qtyTolak, 
		@catatan1, 
		@catatan2, 
		@syncFlag, 
		@kategori, 
		@kodeGudang, 
		@noACC, 
		@lastUpdatedBy, 
		GETDATE()
	
END
USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_ReturPenjualanTarikanDetail_UPDATE]') IS NOT NULL
DROP PROC [dbo].[usp_ReturPenjualanTarikanDetail_UPDATE] 
GO

/****** Object:  StoredProcedure [dbo].[usp_ReturPenjualanTarikanDetail_UPDATE]    Script Date: 02/17/2011 10:26:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =====================================================
-- Author:		Stephanie
-- Create date: 17 Feb 11
-- Description:	Update table ReturPenjualanTarikanDetail
-- =====================================================
CREATE PROCEDURE [dbo].[usp_ReturPenjualanTarikanDetail_UPDATE] 
	-- Add the parameters for the stored procedure here	
	 @rowID uniqueidentifier, 
	 @headerID uniqueidentifier, 
	 @recordID varchar(23),
	 @returID varchar(23), 
	 @notaAsal varchar(7), 
	 @kodeRetur varchar(1),
	 @barangID varchar(23), 
	 @kodeSales varchar(11), 
	 @qtyMemo int, 
	 @qtyTarik int, 
	 @qtyTerima int, 
	 @qtyGudang int, 
	 @qtyTolak int,  
	 @hrgJual money,	
	 @pot money,
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
    
    
    UPDATE dbo.ReturPenjualanTarikanDetail
    SET	
		HeaderID = @headerID, 
		RecordID = @recordID,
		ReturID = @returID, 
		NotaAsal = @notaAsal, 
		KodeRetur = @kodeRetur,
		BarangID = @barangID, 
		KodeSales = @kodeSales, 
		QtyMemo = @qtyMemo, 
		QtyTarik = @qtyTarik, 
		QtyTerima = @qtyTerima, 
		QtyGudang = @qtyGudang, 
		QtyTolak = @qtyTolak, 
		HrgJual = @hrgJual,
		Pot = @pot,
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






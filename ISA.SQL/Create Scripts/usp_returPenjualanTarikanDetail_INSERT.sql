USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_ReturPenjualanTarikanDetail_INSERT]') IS NOT NULL
DROP PROC [dbo].[usp_ReturPenjualanTarikanDetail_INSERT] 
GO

/****** Object:  StoredProcedure [dbo].[usp_ReturPenjualanTarikanDetail_INSERT]    Script Date: 02/17/2011 10:12:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =====================================================
-- Author:		Stephanie
-- Create date: 17 Feb 11
-- Description:	Insert table ReturPenjualanTarikanDetail
-- =====================================================
CREATE PROCEDURE [dbo].[usp_ReturPenjualanTarikanDetail_INSERT] 
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
        	
	INSERT INTO dbo.ReturPenjualanTarikanDetail
	(
		RowID, 
		HeaderID,  
		RecordID,
		ReturID, 
		NotaAsal,
		KodeRetur, 
		BarangID,
		KodeSales, 
		QtyMemo, 
		QtyTarik, 
		QtyTerima, 
		QtyGudang, 
		QtyTolak, 
		HrgJual,
		Pot,
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
		@recordID,
		@returID, 
		@notaAsal, 
		@kodeRetur, 
		@barangID,
		@kodeSales,
		@qtyMemo, 
		@qtyTarik, 
		@qtyTerima, 
		@qtyGudang, 
		@qtyTolak, 
		@hrgJual,
		@pot,
		@catatan1, 
		@catatan2, 
		@syncFlag, 
		@kategori, 
		@kodeGudang, 
		@noACC, 
		@lastUpdatedBy, 
		GETDATE()
	
END
USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_OrderPembelianDetail_INSERT]    Script Date: 04/05/2011 17:38:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =================================================
-- Author:		Stephanie
-- Create date: 05 Apr 11
-- Description:	Insert table Order Pembelian Detail
-- =================================================
CREATE PROCEDURE [dbo].[usp_OrderPembelianDetail_INSERT] 
	-- Add the parameters for the stored procedure here
	 @rowID uniqueidentifier, 
	 @headerID uniqueidentifier, 
	 @recordID varchar(23), 
	 @headerRecID varchar(23), 
	 @barangID varchar(23), 
	 @qtyDO int, 
	 @qtyBO int, 
	 @qtyTambahan int, 
	 @qtyJual int, 
	 @qtyAkhir int, 
	 @keterangan varchar(40), 
	 @kodeGudang varchar(4), 
	 @catatan varchar(90), 
	 @syncFlag bit, 
	 @lastUpdatedBy varchar(250)
	 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
        	
	INSERT INTO dbo.OrderPembelianDetail
	(
		RowID, 
		HeaderID, 
		RecordID, 
		HeaderRecID, 
		BarangID, 
		QtyDO, 
		QtyBO, 
		QtyTambahan, 
		QtyJual, 
		QtyAkhir, 
		Keterangan, 
		KodeGudang, 
		Catatan, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
	SELECT 		
		@rowID, 
		@headerID, 
		@recordID, 
		@headerRecID, 
		@barangID, 
		@qtyDO, 
		@qtyBO, 
		@qtyTambahan, 
		@qtyJual, 
		@qtyAkhir, 
		@keterangan, 
		@kodeGudang, 
		@catatan, 
		@syncFlag, 
		@lastUpdatedBy, 
		GETDATE()
	
END







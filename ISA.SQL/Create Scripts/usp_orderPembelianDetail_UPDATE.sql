USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_OrderPembelianDetail_UPDATE]    Script Date: 04/05/2011 17:39:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- Author:		Stephanie
-- Create date: 05 Apr 11
-- Description:	Update table OrderPembelianDetail
-- ===============================================
CREATE PROCEDURE [dbo].[usp_OrderPembelianDetail_UPDATE] 
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
        	
	UPDATE dbo.OrderPembelianDetail
	SET
		HeaderID = @headerID, 
		RecordID = @recordID, 
		HeaderRecID = @headerRecID, 
		BarangID = @barangID, 
		QtyDO = @qtyDO, 
		QtyBO = @qtyBO, 
		QtyTambahan = @qtyTambahan, 
		QtyJual = @qtyJual, 
		QtyAkhir = @qtyAkhir, 
		Keterangan = @keterangan, 
		KodeGudang = @kodeGudang, 
		Catatan = @catatan, 
		SyncFlag = @syncFlag, 
		LastUpdatedBy = @lastUpdatedBy, 
		LastUpdatedTime = GETDATE()
	WHERE 
		RowID = @RowID
	
END






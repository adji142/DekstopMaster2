USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_OrderPenjualanDetail_INSERT]') IS NOT NULL
DROP PROC [dbo].[usp_OrderPenjualanDetail_INSERT] 
GO

/****** Object:  StoredProcedure [dbo].[usp_OrderPenjualanDetail_INSERT]    Script Date: 01/26/2011 08:54:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =================================================
-- Author:		Stephanie
-- Create date: 17 Jan 11
-- Description:	Insert table Order Penjualan Detail
-- =================================================
ALTER PROCEDURE [dbo].[usp_OrderPenjualanDetail_INSERT] 
	-- Add the parameters for the stored procedure here
	 @rowID uniqueidentifier,
	 @headerID uniqueidentifier,
	 @recordID varchar(23),
	 @htrID varchar(23),
	 @barangID varchar(23),
	 @qtyRequest int,
	 @qtyDO int,
	 @hrgJual money,
	 @kodeToko varchar(19),
	 @tglSuratJalan datetime,
	 @disc1 decimal (5, 2),
	 @disc2 decimal (5, 2),
	 @disc3 decimal (5, 2),
	 @pot money,
	 @discFormula varchar(7),
	 @noDOBO varchar(7),
	 @noACC varchar(7),
	 @catatan varchar(23),
	 @syncFlag bit,
	 @lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
        	
	INSERT INTO dbo.OrderPenjualanDetail
	(
		RowID, 
		HeaderID, 
		RecordID, 
		HtrID, 
		BarangID, 
		QtyRequest, 
		QtyDO, 
		HrgJual, 
		KodeToko, 
		TglSuratJalan, 
		Disc1, 
		Disc2, 
		Disc3, 
		Pot, --0
		DiscFormula, 
		NoDOBO, 
		NoACC, 
		Catatan, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
	SELECT 		
		@rowID, 
		@headerID, 
		@recordID, 
		@htrID, 
		@barangID, 
		@qtyRequest, 
		@QtyDO, 
		@hrgJual,  
		@kodeToko, 
		@tglSuratJalan, 
		@disc1, 
		@disc2, 
		@disc3, 
		@pot, 
		@discFormula, 
		@noDOBO, 
		@noACC, 
		@catatan, 
		@syncFlag, 
		@lastUpdatedBy,
		GETDATE()
	
END













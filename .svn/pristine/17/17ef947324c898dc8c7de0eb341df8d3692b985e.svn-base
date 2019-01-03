USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_OrderPenjualanDetail_UPDATE]') IS NOT NULL
DROP PROC [dbo].[usp_OrderPenjualanDetail_UPDATE] 
GO

/****** Object:  StoredProcedure [dbo].[usp_OrderPenjualanDetail_UPDATE]    Script Date: 01/25/2011 16:58:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==============================================
-- Author:		Stephanie
-- Create date: 18 Jan 11
-- Description:	Update table OrderPenjualanDetail
-- ==============================================
CREATE PROCEDURE [dbo].[usp_OrderPenjualanDetail_UPDATE] 
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
    
    
    UPDATE dbo.OrderPenjualanDetail 
    SET	
		HeaderID = @headerID,
		RecordID = @recordID,
		HtrID = @htrID,
		BarangID = @barangID,
		QtyRequest = @qtyRequest,
		QtyDO = @qtyDO,
		HrgJual = @hrgJual,
		KodeToko =@kodeToko,
		TglSuratJalan = @tglSuratJalan,
		Disc1 = @disc1,
		Disc2 = @disc2,
		Disc3 = @disc3,
		Pot = @pot,
		DiscFormula = @discFormula,
		NoDOBO = @noDOBO,
		NOACC = @noACC,
		Catatan = @catatan,
		SyncFlag = @syncFlag,
		LastUpdatedBy = @lastUpdatedBy,
		LastUpdatedTime = GETDATE()
	WHERE
		RowID = @rowID	
END









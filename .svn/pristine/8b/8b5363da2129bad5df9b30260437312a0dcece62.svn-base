USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_OrderPembelian_UPDATE]    Script Date: 04/05/2011 11:50:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- Author:		Stephanie
-- Create date: 05 Apr 11
-- Description:	Update table OrderPembelian
-- ===============================================
CREATE PROCEDURE [dbo].[usp_OrderPembelian_UPDATE] 
	-- Add the parameters for the stored procedure here
	 @rowID uniqueidentifier, 
	 @recordID varchar(23), 
	 @noRequest varchar(7), 
	 @tglRequest datetime, 
	 @pemasok varchar(19), 
	 @cabang1 varchar(2), 
	 @cabang2 varchar(2), 
	 @estHrgJual money, 
	 @estHPP money, 
	 @noACC varchar(5), 
	 @catatan varchar(50), 
	 @syncFlag bit, 
	 @lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
        	
	UPDATE dbo.OrderPembelian
	SET
		RecordID = @recordID, 
		NoRequest = @noRequest, 
		TglRequest = @tglRequest, 
		Pemasok = @pemasok, 
		Cabang1 = @cabang1, 
		Cabang2 = @cabang2, 
		EstHrgJual = @estHrgJual, 
		EstHPP = @estHPP, 
		NoACC = @noACC, 
		Catatan = @catatan, 
		SyncFlag = @syncFlag, 
		LastUpdatedBy = @lastUpdatedBy, 
		LastUpdatedTime = GETDATE()
	WHERE 
		RowID = @RowID
	
END
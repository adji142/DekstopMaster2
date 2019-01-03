USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_OrderPembelian_INSERT]    Script Date: 04/05/2011 11:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =================================================
-- Author:		Stephanie
-- Create date: 05 Apr 11
-- Description:	Insert table Order Pembelian 
-- =================================================
CREATE PROCEDURE [dbo].[usp_OrderPembelian_INSERT] 
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
        	
	INSERT INTO dbo.OrderPembelian
	(
		RowID, 
		RecordID, 
		NoRequest, 
		TglRequest, 
		Pemasok, 
		Cabang1, 
		Cabang2, 
		EstHrgJual, 
		EstHPP, 
		NoACC, 
		Catatan, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
	SELECT 		
		@rowID, 
		@recordID, 
		@noRequest, 
		@tglRequest, 
		@pemasok, 
		@cabang1, 
		@cabang2, 
		@estHrgJual, 
		@estHPP, 
		@noACC, 
		@catatan, 
		@syncFlag, 
		@lastUpdatedBy, 
		GETDATE()
	
END







USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_NotaPenjualanDetail_INSERT]') IS NOT NULL
DROP PROC [dbo].[usp_NotaPenjualanDetail_INSERT] 
GO


/****** Object:  StoredProcedure [dbo].[usp_NotaPenjualanDetail_INSERT]    Script Date: 01/26/2011 15:07:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- Author:		Stephanie
-- Create date: 21 Jan 11
-- Description:	Insert table NotaPenjualanDetail
-- ===============================================
ALTER PROCEDURE [dbo].[usp_NotaPenjualanDetail_INSERT] 
	-- Add the parameters for the stored procedure here
	 @rowID uniqueIdentifier, -- newid
	 @headerID uniqueidentifier, --NotaPenj RowID
	 @doDetailID uniqueidentifier, --OrderPenjDetail RowID
	 @recID varchar(23), --new fingerprint
	 @htrID varchar(23), --NotaPenj RecID
	 @kodeGudang varchar(4),
	 @qtySJ int, -- QtyNota 
	 @qtyNota int,
	 @qtyKoli int,
	 @koliAwal int,
	 @koliAkhir int,
	 @noKoli varchar(15),
	 @catatan varchar(23),
	 @syncFlag bit,
	 @ketKoli varchar(20),
	 @lastUpdatedBy varchar(250) --lastUpdatedBy
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
        	
	INSERT INTO dbo.NotaPenjualanDetail 
	(
		RowID, 
		HeaderID, 
		DODetailID, 
		RecordID, 
		HtrID, 
		KodeGudang,
		QtySuratJalan, 
		QtyNota, 
		QtyKoli, 
		KoliAwal, 
		KoliAkhir, 
		NoKoli, 
		Catatan, 
		SyncFlag, 
		KetKoli, 
		LastUpdatedBy, 
		LastUpdatedTime 
	)
	SELECT 
		@rowID,
		@headerID,
		@doDetailID,
		@recID,
		@htrID,
		@kodeGudang,
		@qtySJ,
		@qtyNota,
		@qtyKoli,
		@koliAwal,
		@koliAkhir,
		@noKoli,
		@catatan,
		@syncFlag,
		@ketKoli,
		@lastUpdatedBy,
		GETDATE()
	
END




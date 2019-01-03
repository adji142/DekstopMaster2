USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_NotaPenjualanDetail_UPDATE]') IS NOT NULL
DROP PROC [dbo].[usp_NotaPenjualanDetail_UPDATE]
GO


/****** Object:  StoredProcedure [dbo].[usp_NotaPenjualanDetail_UPDATE]    Script Date: 03/30/2011 08:02:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- Author:		Gemma
-- Create date: 27 Jan 11
-- Description:	Update table NotaPenjualanDetail
-- ===============================================
ALTER PROCEDURE [dbo].[usp_NotaPenjualanDetail_UPDATE] 
	-- Add the parameters for the stored procedure here
	 @rowID uniqueIdentifier, 
	 @headerID uniqueidentifier, 
	 @doDetailID uniqueidentifier, 
	 @recID varchar(23), 
	 @htrID varchar(23),
	 @kodeGudang varchar(4),
	 @qtySJ int, 
	 @qtyNota int,
	 @qtyKoli int,
	 @koliAwal int,
	 @koliAkhir int,
	 @noKoli varchar(15),
	 @catatan varchar(23),
	 @syncFlag bit,
	 @ketKoli varchar(20),
	 @lastUpdatedBy varchar(250) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
        	
	UPDATE dbo.NotaPenjualanDetail 
	SET	 
		HeaderID = @headerID, 
		DODetailID = @doDetailID, 
		RecordID = @recID, 
		HtrID = @htrID, 
		KodeGudang = @kodeGudang,
		QtySuratJalan = @qtySJ, 
		QtyNota = @qtyNota, 
		QtyKoli = @qtyKoli,
		KoliAwal = @koliAwal,
		KoliAkhir = @koliAkhir,
		NoKoli = @noKoli,
		Catatan = @catatan, 
		SyncFlag = @syncFlag, 
		KetKoli = @ketKoli,
		LastUpdatedBy = @lastUpdatedBy,
		LastUpdatedTime = getdate() 
	WHERE RowID = @rowID
END







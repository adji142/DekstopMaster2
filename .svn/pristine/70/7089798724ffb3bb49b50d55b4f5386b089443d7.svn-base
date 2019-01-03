USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_NotaPembelianDetail_UPDATE]    Script Date: 04/06/2011 16:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- Author:		Stephanie
-- Create date: 06 Apr 11
-- Description:	Update table Nota Pembelian Detail
-- ===============================================
CREATE PROCEDURE [dbo].[usp_NotaPembelianDetail_UPDATE] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier, 
	@headerID uniqueidentifier, 
	@recordID varchar(23),
	@headerRecID varchar(23), 
	@barangID varchar(23),		 
	@qtyRequest int, 
	@qtyDO int, 
	@qtySuratJalan int, 
	@qtyNota int, 
	@catatan varchar(23), 
	@tglTerima datetime, 
	@hrgPokok money, 
	@hppSolo money, 
	@pot money, 
	@disc1 numeric(5,2), 
	@disc2 numeric(5,2), 
	@disc3 numeric(5,2), 
	@discFormula varchar(7), 
	@ppn numeric(3,0), 
	@kodeGudang varchar(4),  
	@syncFlag bit, 
	@lastUpdatedBy varchar(250)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
        	
	UPDATE dbo.NotaPembelianDetail
	SET
		HeaderID = @headerID, 
		RecordID = @recordID, 
		HeaderRecID = @headerRecID, 
		BarangID = @barangID, 
		QtyRequest = @qtyRequest, 
		QtyDO = @qtyDO, 
		QtySuratJalan = @qtySuratJalan, 
		QtyNota = @qtyNota, 
		Catatan = @catatan, 
		TglTerima = @tglTerima, 
		HrgPokok = @hrgPokok, 
		HPPSolo = @hppSolo, 
		Pot = @pot, 
		Disc1 = @disc1, 
		Disc2 = @disc2, 
		Disc3 = @disc3, 
		DiscFormula = @discFormula, 
		PPN = @ppn, 
		KodeGudang = @kodeGudang, 
		SyncFlag = @syncFlag, 
		LastUpdatedBy = @lastUpdatedBy, 
		LastUpdatedTime = GETDATE()
	WHERE 
		RowID = @RowID
	
END
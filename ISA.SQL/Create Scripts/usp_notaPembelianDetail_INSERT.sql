USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_NotaPembelianDetail_INSERT]    Script Date: 04/06/2011 16:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =================================================
-- Author:		Stephanie
-- Create date: 06 Apr 11
-- Description:	Insert table Nota Pembelian Detail
-- =================================================
CREATE PROCEDURE [dbo].[usp_NotaPembelianDetail_INSERT] 
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
        	
	INSERT INTO dbo.NotaPembelianDetail
	(
		RowID, 
		HeaderID, 
		RecordID, 
		HeaderRecID, 
		BarangID, 
		QtyRequest, 
		QtyDO, 
		QtySuratJalan, 
		QtyNota, 
		Catatan, 
		TglTerima, 
		HrgPokok, 
		HPPSolo, 
		Pot, 
		Disc1, 
		Disc2, 
		Disc3, 
		DiscFormula, 
		PPN, 
		KodeGudang, 
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
		@qtyRequest, 
		@qtyDO, 
		@qtySuratJalan, 
		@qtyNota, 
		@catatan, 
		@tglTerima, 
		@hrgPokok, 
		@hppSolo, 
		@pot, 
		@disc1, 
		@disc2, 
		@disc3, 
		@discFormula, 
		@ppn, 
		@kodeGudang, 
		@syncFlag, 
		@lastUpdatedBy,
		GETDATE()
	
END







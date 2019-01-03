 USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_NotaPembelian_UPDATE]    Script Date: 04/08/2011 17:48:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- Author:		Stephanie
-- Create date: 08 Apr 11
-- Description:	Update table Nota Pembelian
-- ===============================================
CREATE PROCEDURE [dbo].[usp_NotaPembelian_UPDATE] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier, 
	@recordID varchar(23), 
	@noRequest varchar(7), 
	@tglRequest datetime, 
	@noDO varchar(7), 
	@tglTransaksi datetime, 
	@noNota varchar(10), 
	@tglNota datetime, 
	@noSuratJalan varchar(10), 
	@tglSuratJalan datetime, 
	@tglTerima datetime, 
	@disc1 numeric(5,2), 
	@disc2 numeric(5,2), 
	@disc3  numeric(5,2), 
	@discFormula varchar(7), 
	@hariKredit int, 
	@ppn numeric(3,0), 
	@pemasok varchar(19), 
	@expedisi varchar(9), 
	@cabang varchar(20), 
	@catatan varchar(4), 
	@isClosed bit, 
	@syncFlag bit, 
	@lastUpdatedBy varchar(250)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
        	
	UPDATE dbo.NotaPembelian
	SET
		RecordID = @recordID, 
		NoRequest = @noRequest, 
		TglRequest = @tglRequest, 
		NoDO = @noDO, 
		TglTransaksi = @tglTransaksi, 
		NoNota = @noNota, 
		TglNota = @tglNota, 
		NoSuratJalan = @noSuratJalan, 
		TglSuratJalan = @tglSuratJalan, 
		TglTerima = @tglTerima, 
		Disc1 = @disc1, 
		Disc2 = @disc2, 
		Disc3 = @disc3, 
		DiscFormula = @discFormula, 
		HariKredit = @hariKredit, 
		PPN = @ppn, 
		Pemasok = @pemasok, 
		Expedisi = @expedisi, 
		Cabang = @cabang, 
		Catatan = @expedisi, 
		isClosed = @isClosed, 
		SyncFlag = @syncFlag, 
		LastUpdatedBy = @lastUpdatedBy, 
		LastUpdatedTime =  GETDATE()
	WHERE 
		RowID = @RowID
	
END
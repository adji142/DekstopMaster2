USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_ReturPembelianDetail_UPDATE]    Script Date: 04/14/2011 09:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==================================================
-- Author:		Stephanie
-- Create date: 14 Apr 11
-- Description:	Update table ReturPembelianDetail
--				atau table ReturPembelianManualDetail
--				tergantung kode returnya
-- ==================================================
ALTER PROCEDURE [dbo].[usp_ReturPembelianDetail_UPDATE] 
	-- Add the parameters for the stored procedure here	
	@rowID uniqueidentifier, 
	@headerID uniqueidentifier, 
	@notaBeliDetailID uniqueidentifier,		-- Untuk retur Manual diisi NULL saja
	@recordID varchar(23), 
	@returID varchar(23), 
	@notaBeliDetailRecID varchar(23),	-- Untuk retur Manual diisi '' saja
	@barangID varchar(23),				-- Untuk retur Histori diisi '' saja
	@KodeRetur varchar(1), 
	@qtyGudang int, 
	@qtyTerima int, 
	@hrgBeli money, 
	@hrgNet money, 
	@hrgPokok money, 
	@hppSolo money, 
	@catatan varchar(23), 
	@TglKeluar datetime, 
	@kodeGudang varchar(4), 
	@SyncFlag bit,
	@lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
	IF @kodeRetur = '1'
	BEGIN
		UPDATE dbo.ReturPembelianDetail
		SET	HeaderID = @headerID, 
			NotaBeliDetailID = @notaBeliDetailID, 
			RecordID = @recordID, 
			ReturID = @returID, 
			NotaBeliDetailRecID = @notaBeliDetailRecID , 
			KodeRetur = @kodeRetur, 
			QtyGudang = @qtyGudang, 
			QtyTerima = @qtyTerima, 
			HrgBeli = @hrgBeli, 
			HrgNet = @hrgNet, 
			HrgPokok = @hrgPokok, 
			HPPSolo = @hppSolo, 
			Catatan = @catatan, 
			TglKeluar = @tglKeluar, 
			KodeGudang = @kodeGudang, 
			SyncFlag = @SyncFlag,
			LastUpdatedBy = @lastUpdatedBy, 
			LastUpdatedTime = GETDATE()
		WHERE
			RowID = @rowID
	END

	ELSE -- IF @kodeRetur = '2'
	BEGIN
		UPDATE dbo.ReturPembelianManualDetail
		SET	HeaderID = @headerID, 
			RecordID = @recordID, 
			ReturID = @returID, 
			BarangID = @barangID, 
			KodeRetur = @kodeRetur, 
			QtyGudang = @qtyGudang, 
			QtyTerima = @qtyTerima, 
			HrgBeli = @hrgBeli, 
			HrgNet = @hrgNet, 
			HrgPokok = @hrgPokok, 
			HPPSolo = @hppSolo, 
			Catatan = @catatan, 
			TglKeluar = @tglKeluar, 
			KodeGudang = @kodeGudang, 
			LastUpdatedBy = @lastUpdatedBy, 
			LastUpdatedTime = GETDATE()
		WHERE
			RowID = @rowID
	END    

END
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


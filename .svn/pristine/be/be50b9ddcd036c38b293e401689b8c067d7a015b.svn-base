 USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Stok_UPDATE]') IS NOT NULL
DROP PROC [dbo].[usp_Stok_UPDATE] 
GO



/****** Object:  StoredProcedure [dbo].[usp_Stok_UPDATE]    Script Date: 01/05/2011 14:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		Stephanie
-- Create date: 05 Jan 11
-- Description:	Update table Cabang
-- =============================================
CREATE PROCEDURE [dbo].[usp_Stok_UPDATE] 
	-- Add the parameters for the stored procedure here	
	 @rowID uniqueidentifier,
	 @barangID varchar(23),
	 @namaStok varchar(23),
	 @kodeRak varchar(7),
	 @kodeRak1 varchar(7),
	 @kodeRak2 varchar(7),
	 @satJual varchar(3),
	 @satSolo varchar(3),
	 @statusPasif bit,
	 @prediksiLamaKirim int,
	 @hariRataRata int,
	 @bundle varchar(3),
	 @kendaraan varchar(43),
	 @lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    
    UPDATE dbo.Stok 
    SET	
		RowID = @rowID, 
		BarangID = @barangID, 
		NamaStok = @namaStok,
		KodeRak = @kodeRak,
		KodeRak1 = @kodeRak1,
		KodeRak2 = @kodeRak2,
		SatJual = @satJual,
		SatSolo = @satSolo,
		StatusPasif = @statusPasif,
		PrediksiLamaKirim = @prediksiLamaKirim,
		HariRataRata = @hariRataRata,
		Bundle = @bundle,
		Kendaraan = @kendaraan,
		LastUpdatedBy = @lastUpdatedBy, 
		LastUpdatedTime = GETDATE()
	WHERE
		RowID = @rowID	

END







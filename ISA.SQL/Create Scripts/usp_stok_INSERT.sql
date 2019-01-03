 USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Stok_INSERT]') IS NOT NULL
DROP PROC [dbo].[usp_Stok_INSERT] 
GO



/****** Object:  StoredProcedure [dbo].[usp_Stok_INSERT]    Script Date: 01/05/2011 14:15:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Stephanie
-- Create date: 05 Jan 11
-- Description:	Insert table Stok
-- =============================================
CREATE PROCEDURE [dbo].[usp_Stok_INSERT] 
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
        	
	INSERT INTO dbo.Stok 
	(
		RowID, 
		BarangID, 
		NamaStok,
		KodeRak,
		KodeRak1,
		KodeRak2,
		SatJual,
		SatSolo,
		StatusPasif,
		PrediksiLamaKirim,
		HariRataRata,
		Bundle,
		Kendaraan,
		LastUpdatedBy, 
		LastUpdatedTime
	)
	SELECT 
		@rowID,
		@barangID,
		@namaStok,
		@kodeRak,
		@kodeRak1,
		@kodeRak2,
		@satJual,
		@satSolo,
		@statusPasif,
		@prediksiLamaKirim,
		@hariRataRata,
		@bundle,
		@kendaraan,
		@lastUpdatedBy,
		GETDATE()
	
END





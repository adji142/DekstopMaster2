USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Stok_SEARCH]') IS NOT NULL
DROP PROC [dbo].[usp_Stok_SEARCH] 
GO

/****** Object:  StoredProcedure [dbo].[usp_Stok_SEARCH]    Script Date: 01/12/2011 11:35:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








-- =============================================
-- Author:		Raymond
-- Create date: 11 Jan 11
-- Description:	Search data on table Stok
-- =============================================
CREATE PROCEDURE [dbo].[usp_Stok_SEARCH] 
	-- Add the parameters for the stored procedure here
	@searchArg varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		RowID,	
		BarangID, 
		RecordID, 
		Bundle, 
		NamaStok, 
		KodeSolo, 
		Kendaraan, 
		NamaTertera, 
		PartNo, 
		Merek, 
		Dibungkus, 
		SumberDr, 
		ProsesID, 
		SatSolo, 
		Material, 
		SatJual, 
		KodeRak, 
		KodeRak1, 
		KodeRak2, 
		JB, 
		StatusPasif, 
		SyncFlag, 
		PrediksiLamaKirim, 
		HariRataRata, 
		StokMin, 
		StokMax, 
		IsiKoli, 
		LastUpdatedBy, 
		LastUpdatedTime	
		
	FROM dbo.Stok  		
	WHERE
	BarangID LIKE @searchArg + '%'
	OR NamaStok LIKE '%' + @searchArg + '%'	    
END








GO



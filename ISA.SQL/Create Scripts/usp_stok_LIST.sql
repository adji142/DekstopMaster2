USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Stok_LIST]') IS NOT NULL
DROP PROC [dbo].[usp_Stok_LIST] 
GO


/****** Object:  StoredProcedure [dbo].[usp_Stok_LIST]    Script Date: 01/05/2011 14:15:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		Stephanie
-- Create date: 05 Jan 11
-- Description:	List data on table Stok
-- =============================================
CREATE PROCEDURE [dbo].[usp_Stok_LIST] 
	-- Add the parameters for the stored procedure here
	@namaStok varchar(23) = null
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
	(upper(NamaStok) Like upper('%' + @namaStok + '%') OR @namaStok IS NULL)
    
END
USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_StokGudang_LIST]    Script Date: 03/28/2011 12:08:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 28 Mar 11
-- Description:	List data on Stok Gudang View
-- =============================================
CREATE PROCEDURE [dbo].[usp_StokGudang_LIST] 
	-- Add the parameters for the stored procedure here
	@barangID varchar(23) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    -- Insert statements for procedure here
	SELECT 
		BarangID, 
		KodeGudang, 
		TglAwal, 
		QtyAwal, 
		QtyJual, 
		QtyBeli, 
		QtyRetJual, 
		QtyRetBeli, 
		QtyOrderJual, 
		QtyOrderBeli, 
		QtyMutasi, 
		QtyKorJual, 
		QtyKorRetJual, 
		QtyKorBeli, 
		QtyKorRetBeli, 
		(QtyKorBeli - QtyKorJual  - QtyKorRetBeli + QtyKorRetJual) AS QtyKoreksi,
		QtySelisih, 
		QtyAntarGudangKirim, 
		QtyAntarGudangTerima,
		(QtyAntarGudangTerima - QtyAntarGudangKirim) AS QtyAntarGudang,
		dbo.fnHitungSisaStok(@barangID) AS Stok
	FROM dbo.vwStokGudang (NOLOCK)		
	WHERE
		(BarangID = @barangID OR @barangID IS NULL)
    
END




USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_ReturPenjualanDetail_LIST]') IS NOT NULL
DROP PROC [dbo].[usp_ReturPenjualanDetail_LIST] 
GO

/****** Object:  StoredProcedure [dbo].[usp_ReturPenjualanDetail_LIST]    Script Date: 04/01/2011 13:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =====================================================
-- Author:		Stephanie
-- Create date: 08 Feb 11
-- Description:	List data on vwReturPenjualanDetail
--				Contains ReturPenjualanDetail
--				and ReturPenjualanTarikanDetail
-- =====================================================
CREATE PROCEDURE [dbo].[usp_ReturPenjualanDetail_LIST] 
	-- Add the parameters for the stored procedure here
	 @rowID uniqueidentifier = NULL,
	 @headerID uniqueidentifier = NULL,
	 @notaJualDetailID uniqueidentifier = NULL
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    -- Insert statements for procedure here

	SELECT 
		RowID, 
		HeaderID, 
		NotaJualDetailID, 
		RecordID,
		ReturID, 
		NotaJualDetailRecID, 
		NotaAsal, 
		TglNota,
		TglTerima, 
		KodeRetur, 
		BarangID,
		NamaStok,
		Satuan,
		KodeSales,
		LEFT(NamaSales, 11) AS NamaSales,
		KodeToko, 
		QtyMemo, 
		QtyTarik, 
		QtyTerima, 
		QtyGudang, 
		QtyTolak, 
		Pot,
		HrgJual,
		Catatan1, 
		Catatan2, 
		TglGudang,
		SyncFlag, 
		Kategori, 
		KodeGudang, 
		NoACC, 
		LastUpdatedBy, 
		LastUpdatedTime,
		Disc1,
		Disc2,
		Disc3,
		DiscFormula,
		Cabang1,
		Expedisi,
		QtySuratJalan,
		QtyRetur,
		HrgNetto,
		HrgNetto1, 
		HrgNetto2, 
		HrgNetto3
	FROM dbo.vwReturPenjualanDetail

	WHERE
		(RowID = @rowID OR @rowID IS NULL)
		AND 
		(HeaderID = @headerID OR @headerID IS NULL)
		AND 
		(NotaJualDetailID = @notaJualDetailID OR @notaJualDetailID IS NULL)
	
END


 
USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_ReturPembelianDetail_LIST]    Script Date: 04/18/2011 13:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ====================================================
-- Author:		Stephanie
-- Create date: 13 Apr 11
-- Description:	List data on vwReturPembelianDetail
--				Contains ReturPembelianDetail
--				and ReturPembelianManualDetail
-- ====================================================
CREATE PROCEDURE [dbo].[usp_ReturPembelianDetail_LIST] 
	-- Add the parameters for the stored procedure here
	 @rowID uniqueidentifier = NULL,
	 @headerID uniqueidentifier = NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    -- Insert statements for procedure here

	SELECT 
		v.RowID, 
		v.HeaderID, 
		v.NotaBeliDetailID, 
		v.RecordID, 
		v.ReturID, 
		v.NotaBeliDetailRecID,
		v.BarangID, 
		s.NamaStok AS NamaBarang,
		s.SatSolo AS Satuan,
		v.KodeRetur, 
		v.QtyGudang, 
		v.QtyTerima, 
		v.HrgBeli, 
		(v.QtyGudang * v.HrgBeli) AS JmlHrgRetur,
		v.HrgNet, 
		v.HrgPokok, 
		v.HPPSolo, 
		v.Catatan, 
		v.TglKeluar, 
		v.KodeGudang, 
		v.LastUpdatedBy, 
		v.LastUpdatedTime,
		v.Pot,
		v.Disc1,
		v.Disc2,
		v.Disc3,
		v.DiscFormula,
		r.NoRetur,
		r.TglRetur,
		r.Pemasok
	FROM dbo.vwReturPembelianDetail v
		LEFT OUTER JOIN dbo.ReturPembelian r ON v.HeaderID = r.RowID
		LEFT OUTER JOIN dbo.Stok s ON v.BarangID = s.BarangID

	WHERE
		(v.RowID = @rowID OR @rowID IS NULL)
		AND
		(v.HeaderID = @headerID OR @headerID IS NULL)

	ORDER BY s.NamaStok ASC		

END
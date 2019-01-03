USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_NotaPenjualanDetail_LIST]') IS NOT NULL
DROP PROC [dbo].[usp_NotaPenjualanDetail_LIST] 
GO

/****** Object:  StoredProcedure [dbo].[usp_NotaPenjualanDetail_LIST]    Script Date: 02/28/2011 08:54:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===================================================
-- Author:		Stephanie
-- Create date: 19 Jan 11
-- Description:	List data on table NotaPenjualanDetail
-- ===================================================
ALTER PROCEDURE [dbo].[usp_NotaPenjualanDetail_LIST] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier = null,
	@headerID uniqueidentifier = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

SELECT 
		a.RowID, 
		b.BarangID, 
		c.NamaStok As NamaBarang,
		c.SatSolo AS Satuan,
		LEFT(b.BarangID, 3) AS KelBarangID,
		a.HeaderID, 
		a.DODetailID,
		a.RecordID, 
		a.HtrID, 
		a.KodeGudang,
		b.QtyDO,
		a.QtySuratJalan, 
		a.QtyNota, 
		ISNULL((SELECT SUM(r.QtyGudang) FROM dbo.ReturPenjualanDetail r WHERE a.RowID = r.NotaJualDetailID), 0) AS QtyRetur,
		a.QtyKoli, 
		a.KoliAwal, 
		a.KoliAkhir, 
		a.NoKoli, 
		a.KetKoli, 
		b.HrgJual,
		a.Catatan, 
		a.SyncFlag, 
		b.Pot,
		/* index 2 untuk  NotaJual index 3 untuk PJ3 */
		ISNULL((a.QtySuratJalan * b.HrgJual), 0) AS JmlHrg2,
		ISNULL((dbo.fnHitungNet3Disc( (a.QtySuratJalan * b.HrgJual), b.Disc1, b.Disc2, b.Disc3, b.DiscFormula)
			- (a.QtySuratJalan * b.Pot) ), 0) AS HrgNet2,
		ISNULL((a.QtySuratJalan * b.Pot), 0) AS JmlPot2,
		ISNULL((a.QtyNota * b.HrgJual), 0) AS JmlHrg3,
		ISNULL((dbo.fnHitungNet3Disc( (a.QtyNota * b.HrgJual), b.Disc1, b.Disc2, b.Disc3, b.DiscFormula)
			- (a.QtyNota * b.Pot) ), 0) AS HrgNet3,
		ISNULL((a.QtyNota * b.Pot), 0) AS JmlPot3,
		b.Disc1,
		b.Disc2,
		b.Disc3,
		b.DiscFormula,
		b.HPPSolo,
		(a.QtySuratJalan * b.HPPSolo) AS JmlHPPSolo,

		/* Dipakai untuk pembuatan KoreksiPenjualan */
--		(SELECT SUM(c.QtyRetur) FROM dbo.ReturPenjualan c WHERE c.NotaDetailID = a.RowID) AS QtyRetur,
--		(SELECT TOP 1 c.RowID FROM dbo.KoreksiPenjualan c 
--			WHERE c.DetailID = a.RowID ORDER BY c.TglKoreksi DESC) AS KoreksiID,

		a.LastUpdatedBy, 
		a.LastUpdatedTime
	FROM dbo.NotaPenjualanDetail a 
		LEFT OUTER JOIN dbo.vwNotaPenjualanDetail b	ON b.RowID = a.RowID AND b.DODetailID = a.DODetailID
		LEFT OUTER JOIN dbo.Stok c ON c.BarangID = b.BarangID
		
	WHERE
		(a.RowID = @rowID OR @rowID IS NULL)
		AND
		(a.HeaderID = @headerID or @headerID IS NULL)

	ORDER BY c.NamaStok ASC

END





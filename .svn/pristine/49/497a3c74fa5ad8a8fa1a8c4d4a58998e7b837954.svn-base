USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_OrderPenjualanDetail_LIST]    Script Date: 03/04/2011 10:13:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ====================================================
-- Author:		Stephanie
-- Create date: 12 Jan 11
-- Description:	List data on table OrderPenjualanDetail
-- ====================================================
CREATE PROCEDURE [dbo].[usp_OrderPenjualanDetail_LIST] 
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
		a.RowID,  
		a.HeaderID,
		a.RecordID, 
		a.HtrID, 
		a.BarangID, 
		LEFT(a.BarangID, 3) AS Klp,
		b.NamaStok,
		a.QtyRequest, 
		a.QtyDO, 
		(SELECT SUM(f.QtySuratJalan) FROM dbo.NotaPenjualanDetail f WHERE f.DODetailID = a.RowID) AS QtySJ,
		/* Hitung Qty BO Bila TglSuratJalan DO NULL atau dengan arti lain blm ada nota
		 * maka QtyBoO = 0 Bila Sudah ada nota QtyBO = QtySuratJalan - QtyDO */
		(CASE WHEN (SELECT TOP 1 n.TglSuratJalan FROM dbo.NotaPenjualan n 
			WHERE a.HeaderID = n.DOID ORDER BY n.TglSuratJalan DESC) IS NULL THEN 0 
			ELSE ISNULL((SELECT SUM(f.QtySuratJalan) FROM dbo.NotaPenjualanDetail f 
			WHERE f.DODetailID = a.RowID), 0) - a.QtyDO END) AS QtyBO, 
		/* Hitung QtySisa (SisaDO) dari QtyDO - QtySuratJalan */
		(ISNULL(a.QtyDO, 0) - 
			ISNULL((SELECT SUM(f.QtySuratJalan) FROM dbo.NotaPenjualanDetail f 
			WHERE f.DODetailID = a.RowID), 0)) AS QtySisa,
		dbo.fnHitungHrgJual(c.TglDo, a.BarangID, d.Status, a.QtyDO, a.KodeToko, c.Cabang1) AS HrgBMK,
		a.HrgJual, 
		dbo.fnGetHPPA(a.BarangID, c.TglDO) AS HPPA, 
		dbo.fnGetHPP(a.BarangID, c.TglDO) AS HPPSolo, 
		a.KodeToko, 
		a.TglSuratJalan, 
		a.Disc1, 
		a.Disc2, 
		a.Disc3, 
		a.Pot, 
		a.DiscFormula, 
		a.NoDOBO,  
		a.NoACC, 
		a.Catatan, 
		a.SyncFlag, 
		ISNULL((a.QtyDO * a.HrgJual), 0) AS JmlHrg,
		ISNULL(dbo.fnHitungNet3Disc((a.QtyDO * a.HrgJual), a.Disc1, a.Disc2, a.Disc3, a.DiscFormula) 
			- (a.QtyDO * a.Pot), 0) AS HrgNet,
		ISNULL((a.Pot * a.QtyDO), 0) AS JmlPot,
		a.QtyDO * dbo.fnGetHPP(a.BarangID, c.TglDO) AS JmlHPP,
		b.SatSolo,
		ISNULL(e.DiscKompensasi, 0) AS DiscKompensasi,
		a.LastUpdatedBy, 
		a.LastUpdatedTime
	FROM dbo.OrderPenjualanDetail a
		LEFT OUTER JOIN dbo.Stok b	ON a.BarangID = b.BarangID
		LEFT OUTER JOIN dbo.OrderPenjualan c ON a.HeaderID = c.RowID
		LEFT OUTER JOIN dbo.Toko d ON a.KodeToko = d.KodeToko	
		LEFT OUTER JOIN dbo.Kompensasi e ON a.RowID = e.RowID

	WHERE
		(a.RowID = @rowID OR @rowID IS NULL)
		AND
		(a.HeaderID = @headerID OR @headerID IS NULL)

	ORDER BY b.NamaStok ASC
    
END






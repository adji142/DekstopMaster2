USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Laporan_Toko_ACCHargaDitolak]    Script Date: 05/06/2011 14:05:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- Author		: Stephanie
-- Create date	: 27 Apr 2011
-- Description	: Laporan > Toko > ACC Harga ditolak
-- Example		: [dbo].[rsp_Laporan_Toko_ACCHargaDitolak] '2010/04/01',  '2010/04/02'
-- ============================================================
ALTER PROCEDURE [dbo].[rsp_Laporan_Toko_ACCHargaDitolak] 
	-- Add the parameters for the stored procedure here
	 @fromDate datetime,
	 @toDate datetime,
	 @cabang1 varchar(2) = NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	
	SELECT 
		t.NamaToko,
		t.Alamat,
		t.Kota,
		dbo.fnGetStatusToko(h.TglDO, h.KodeToko, h.Cabang1) AS StsToko,
		h.TglDO,
		h.NoDO,
		h.KodeSales,
		s.NamaStok AS NamaBarang,
		d.HrgJual,
		dbo.fnHitungHrgJual(h.TglDO, d.BarangID, NULL, d.QtyDO, h.KodeToko, h.Cabang1) AS HrgBMK,
		d.QtyRequest,
		d.Catatan
	
	FROM dbo.OrderPenjualan h
		INNER JOIN dbo.OrderPenjualanDetail d ON h.RowID = d.HeaderID
		LEFT OUTER JOIN dbo.Stok s ON d.BarangID = s.BarangID
		LEFT OUTER JOIN dbo.Toko t ON h.KodeToko = t.KodeToko
	
	WHERE
		h.TglDO BETWEEN @fromDate AND @toDate
		AND
		(h.Cabang1 = @cabang1 OR @cabang1 IS NULL)
		AND 
		d.QtyDO = 0

	ORDER BY h.TglDO, h.NoDO ASC
		
	
END
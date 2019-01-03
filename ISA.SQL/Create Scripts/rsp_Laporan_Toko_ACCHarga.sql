USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Laporan_Toko_ACCHarga]    Script Date: 04/29/2011 08:20:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- Author		: Stephanie
-- Create date	: 27 Apr 2011
-- Description	: Laporan > Toko > ACC Harga
-- Example		: [dbo].[rsp_Laporan_Toko_ACCHarga] 
--					'2010/04/01',  '2010/04/02'
-- ============================================================
CREATE PROCEDURE [dbo].[rsp_Laporan_Toko_ACCHarga] 
	-- Add the parameters for the stored procedure here
	 @fromDate datetime,
	 @toDate datetime	

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	
	SELECT 
		h.TglDO,
		h.NoDO,
		h.KodeSales,
		t.NamaToko,
		t.Alamat,
		t.Kota,
		d.BarangID,
		s.NamaStok AS NamaBarang,
		d.QtyDO,
		d.HrgJual,
		(d.QtyDO * d.HrgJual) AS JmlHrg,
		h.NoACCPusat		
	
	FROM dbo.OrderPenjualan h
		INNER JOIN dbo.OrderPenjualanDetail d ON h.RowID = d.HeaderID
		LEFT OUTER JOIN dbo.Stok s ON d.BarangID = s.BarangID
		LEFT OUTER JOIN dbo.Toko t ON h.KodeToko = t.KodeToko
	
	WHERE
		(h.TglDO BETWEEN @fromDate AND @toDate)
		AND
		(
			d.HrgJual 
			< dbo.fnHitungHrgJual(h.TglDO, d.BarangID, NULL, d.QtyDO, h.KodeToko, h.Cabang1)
			OR
			d.HrgJual 
			< dbo.fnGetHargaBeli (d.BarangID, h.TglDO, NULL)
		)

	ORDER BY h.TglDO, h.NoDO, t.NamaToko, s.NamaStok ASC


	
END
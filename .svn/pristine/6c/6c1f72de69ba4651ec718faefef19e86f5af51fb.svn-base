USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Laporan_Toko_PengirimanGudang]    Script Date: 04/29/2011 09:38:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- Author		: Stephanie
-- Create date	: 28 Apr 2011
-- Description	: Laporan > Toko > Pengiriman Gudang
-- Example		: [dbo].[rsp_Laporan_Toko_PengirimanGudang]  
--					'2010/04/01'
-- ============================================================
CREATE PROCEDURE [dbo].[rsp_Laporan_Toko_PengirimanGudang] 
	-- Add the parameters for the stored procedure here
	 @tanggal datetime

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	
	DECLARE @initCab varchar(2)
	SELECT TOP 1
		@initCab = InitCabang
	FROM dbo.Perusahaan


	SELECT 
		t.NamaToko,
		doh.Kota,
		t.WilID,
		nh.NoSuratJalan,
		nh.RecordID,
		s.NamaSales,
		doh.Expedisi,
		SUM( (CASE WHEN doh.HariKredit + doh.HariKirim = 0 
				THEN dbo.fnHitungNet3Disc((nd.QtySuratJalan * dod.HrgJual), 
						dod.Disc1, dod.Disc2, dod.Disc3, dod.DiscFormula) 
						- (nd.QtySuratJalan * dod.Pot)
				ELSE 0 END ) ) AS Tunai,
		SUM( (CASE WHEN doh.HariKredit + doh.HariKirim > 0 
				THEN dbo.fnHitungNet3Disc((nd.QtySuratJalan * dod.HrgJual), 
						dod.Disc1, dod.Disc2, dod.Disc3, dod.DiscFormula) 
						- (nd.QtySuratJalan * dod.Pot)
				ELSE 0 END ) ) AS Kredit
	
	FROM dbo.NotaPenjualan nh
		INNER JOIN dbo.NotaPenjualanDetail nd ON nh.RowID = nd.HeaderID
		INNER JOIN dbo.OrderPenjualan doh ON nh.DOID = doh.RowID
		INNER JOIN dbo.OrderPenjualanDetail dod ON nd.DoDetailID = dod.RowID
		INNER JOIN dbo.Toko t ON doh.KodeToko = t.KodeToko
		INNER JOIN dbo.Sales s ON doh.KodeSales = s.SalesID
	
	WHERE
		nh.TglSuratJalan = @tanggal
		AND
		doh.Cabang1 = @initCab
		
	GROUP BY 
		t.NamaToko,
		doh.Kota,
		t.WilID,
		nh.NoSuratJalan,
		nh.RecordID,
		s.NamaSales,
		doh.Expedisi,
		nh.RowID

	ORDER BY t.NamaToko, nh.NoSuratJalan  ASC
	
END
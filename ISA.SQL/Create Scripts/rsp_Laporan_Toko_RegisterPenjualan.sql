USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Laporan_Toko_RegisterPenjualan]    Script Date: 05/06/2011 14:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- Author		: Stephanie
-- Create date	: 28 Apr 2011
-- Description	: Laporan > Toko > Register Penjualan
-- Example		: [dbo].[rsp_Laporan_Toko_RegisterPenjualan]   
--					'2010/04/01', '2010/04/05', 'SJ', 'BR'
-- ============================================================
CREATE PROCEDURE [dbo].[rsp_Laporan_Toko_RegisterPenjualan] 
	-- Add the parameters for the stored procedure here
	 @fromDate datetime,
	 @toDate datetime,
	 @tipeTgl varchar(2), -- 'SJ' = TglSuratJalan, 'TR' = TglTerima
	 @tipeHarga varchar(2) -- 'BR' = HrgBruto, 'NT' = HargaNetto

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

	DECLARE @nota TABLE
	(
		TglSuratJalan datetime,
		WilID varchar(7),
		NamaToko varchar(31),
		AlamatKirim varchar(60),
		Kota varchar(20),
		NoSuratJalan varchar(7),
		KodeSales varchar(11),
		KLP varchar(3),
		Unit int,
		Nilai money
	)

	INSERT INTO @nota
	SELECT 
		nh.TglSuratJalan,
		t.WilID,
		t.NamaToko,
		doh.AlamatKirim,
		doh.Kota,
		nh.NoSuratJalan,
		doh.KodeSales,
		LEFT(dod.BarangID, 3) AS KLP,
		SUM(nd.QtySuratJalan - ISNULL(retur.QtyRetur, 0)) AS Unit,
		SUM(((dbo.fnHitungNet3Disc(dod.HrgJual, dod.Disc1, dod.Disc2, dod.Disc3, '')-dod.Pot)
				* nd.QtySuratJalan) - ISNULL(retur.NilaiRetur, 0)) AS Nilai	
	FROM dbo.NotaPenjualan nh
		INNER JOIN dbo.NotaPenjualanDetail nd ON nh.RowID = nd.HeaderID
		INNER JOIN dbo.OrderPenjualan doh ON nh.DOID = doh.RowID
		INNER JOIN dbo.OrderPenjualanDetail dod ON nd.DoDetailID = dod.RowID
		INNER JOIN dbo.Toko t ON doh.KodeToko = t.KodeToko
		OUTER APPLY
		(
			SELECT 
				SUM( CASE WHEN @tipeHarga = 'NT' THEN v.QtyGudang ELSE 0 END) AS QtyRetur,
				SUM( CASE WHEN @tipeHarga = 'NT' THEN (dbo.fnHitungNet3Disc(v.HrgJual, v.Disc1, v.Disc2, v.Disc3, '')-v.Pot)
				* v.QtyGudang ELSE 0 END) AS NilaiRetur
			FROM dbo.vwReturPenjualanDetail v
				INNER JOIN dbo.NotaPenjualanDetail d ON v.NotaJualDetailID = d.RowID			
			WHERE
				(v.TglGudang BETWEEN @fromDate AND @toDate)			
				AND 
				d.RowID = nd.RowID 			
		) retur	
	WHERE
		((@tipeTgl = 'SJ' AND (nh.TglSuratJalan BETWEEN @fromDate AND @toDate))
			OR
		(@tipeTgl = 'TR' AND (nh.TglTerima BETWEEN @fromDate AND @toDate)))
		AND
		doh.Cabang1 = @initCab 
		AND
		nh.NPrint >= 3

	GROUP BY 
		nh.TglSuratJalan,
		t.WilID,
		t.NamaToko,
		doh.AlamatKirim,
		doh.Kota,
		nh.NoSuratJalan,
		doh.KodeSales,
		LEFT(dod.BarangID, 3)
	ORDER BY nh.tglSuratJalan, nh.NoSuratJalan ASC


	SELECT
		k.Keterangan,
		k.KelompokBrgID AS KLP,
		n.TglSuratJalan ,
		n.WilID ,
		n.NamaToko ,
		n.AlamatKirim AS Alamat,
		n.Kota ,
		n.NoSuratJalan ,
		n.KodeSales ,
		n.Unit ,
		n.Nilai 
	FROM dbo.KelompokBarang k
		LEFT OUTER JOIN @nota n ON k.KelompokBrgID = n.KLP	
	ORDER BY n.TglSuratJalan, n.NoSuratJalan ASC

END
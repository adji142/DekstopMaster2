 USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Laporan_Toko_AnalisaKunjunganSales]    Script Date: 05/10/2011 08:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ================================================================
-- Author		: Stephanie
-- Create date	: 09 May 2010
-- Description	: Laporan > Toko > Analisa Kunjungan Sales
-- Example		: [dbo].[rsp_Laporan_Toko_AnalisaKunjunganSales] 
--					@fromDate1='2010/04/01', @toDate1='2010/04/02',
--					@fromDate2='2010/05/01', @toDate2='2010/05/02',
--					@tipeTgl='DO', @urut='Toko'
-- ================================================================
CREATE PROCEDURE [dbo].[rsp_Laporan_Toko_AnalisaKunjunganSales] 
	-- Add the parameters for the stored procedure here
	 @fromDate1 datetime,
	 @toDate1 datetime,
	 @fromDate2 datetime,
	 @toDate2 datetime,
	 @tipeTgl varchar(2), -- 'DO'= Pakai TglDO, 'SJ'= Pakai TglSJ
	 @tipeNominal varchar(2) = NULL, -- 'BR'= Brutto, 'NT'= Netto
	 @urut varchar(5), -- 'TOKO'=Toko, 'SALES'=Salesman, 'KOTA'=Kota

	 @kodeSales varchar(11) = NULL,
	 @kota varchar(20) = NULL,
	 @kodePos varchar(3) = NULL,
	 @wilayah varchar(2) = NULL

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

	DECLARE @data TABLE
	(
		Tgl datetime,
		TglSts datetime,
		KodeToko varchar(19),
		KodeSales varchar(11),
		BarangID varchar(23),
		RpNet money
	)

	IF @tipeTgl = 'DO'
	BEGIN
		INSERT INTO @data
		SELECT
			h.TglDO,
			h.TglDO,
			h.KodeToko,
			h.KodeSales,
			d.BarangID,
			dbo.fnHitungNet3Disc(d.HrgJual*d.QtyDO, d.Disc1, d.Disc2, d.Disc3, d.DiscFormula)
		FROM dbo.OrderPenjualan h
			INNER JOIN dbo.OrderPenjualanDetail d ON h.RowID = d.HeaderID
			LEFT OUTER JOIN dbo.Toko t ON h.KodeToko = t.KodeToko
			LEFT OUTER JOIN dbo.KodePos kp ON t.KodePos = kp.KodePos
		WHERE
			(h.TglDO BETWEEN @fromDate1 AND @toDate2)
			AND h.Cabang1 = @initCab 
			AND t.StatusAktif = 0
			AND (h.KodeSales = @kodeSales OR @kodeSales IS NULL)
			AND (h.Kota LIKE '%'+@kota+'%' OR @kota IS NULL)
			AND (t.KodePos = @kodePos OR @kodePos IS NULL)
			AND (kp.Wilayah = @wilayah OR @wilayah IS NULL)
	END


	ELSE -- @tipeTgl = 'SJ'
	BEGIN
		INSERT INTO @data
		SELECT
			nh.TglSuratJalan,
			nh.TglSuratJalan,
			doh.KodeToko,
			doh.KodeSales,
			dod.BarangID,
			dbo.fnHitungNet3Disc(dod.HrgJual*nd.QtySuratJalan, dod.Disc1, dod.Disc2, dod.Disc3, dod.DiscFormula)
		FROM dbo.NotaPenjualan nh 
			LEFT OUTER JOIN dbo.NotaPenjualanDetail nd ON nh.RowID = nd.HeaderID
			LEFT OUTER JOIN dbo.OrderPenjualan doh ON nh.DOID = doh.RowID
			INNER JOIN dbo.OrderPenjualanDetail dod ON nd.DODetailID = dod.RowID
			LEFT OUTER JOIN dbo.Toko t ON doh.KodeToko = t.KodeToko
			LEFT OUTER JOIN dbo.KodePos kp ON t.KodePos = kp.KodePos
		WHERE
			(nh.TglSuratJalan BETWEEN @fromDate1 AND @toDate2)
			AND doh.Cabang1 = @initCab
			AND t.StatusAktif = 0
			AND (doh.KodeSales = @kodeSales OR @kodeSales IS NULL)
			AND (doh.Kota LIKE '%'+@kota+'%' OR @kota IS NULL)
			AND (t.KodePos = @kodePos OR @kodePos IS NULL)
			AND (kp.Wilayah = @wilayah OR @wilayah IS NULL)
		

		IF (@tipeNominal = 'NT')
		BEGIN
			INSERT INTO @data
			
			SELECT
				rh.TglGudang,
				rh.TglGudang,
				doh.KodeToko,
				doh.KodeSales,
				dod.BarangID,
				-1*dbo.fnHitungNet3Disc(dod.HrgJual*rd.QtyGudang, dod.Disc1, dod.Disc2, dod.Disc3, dod.DiscFormula)
			FROM dbo.ReturPenjualan rh 
				INNER JOIN dbo.ReturPenjualanDetail rd ON rh.RowID = rd.HeaderID
				INNER JOIN dbo.NotaPenjualanDetail nd ON rd.NotaJualDetailID = nd.RowID
				INNER JOIN dbo.OrderPenjualanDetail dod ON nd.DODetailID = dod.RowID
				INNER JOIN dbo.OrderPenjualan doh ON dod.HeaderID = doh.RowID
				LEFT OUTER JOIN dbo.Toko t ON doh.KodeToko = t.KodeToko
			LEFT OUTER JOIN dbo.KodePos kp ON t.KodePos = kp.KodePos
			WHERE				
				(rh.TglGudang BETWEEN @fromDate1 AND @toDate2)
					OR
				(rh.TglGudang BETWEEN @fromDate2 AND @toDate2)
				AND doh.Cabang1 = @initCab
				AND t.StatusAktif = 0
				AND (doh.KodeSales = @kodeSales OR @kodeSales IS NULL)
				AND (doh.Kota LIKE '%'+@kota+'%' OR @kota IS NULL)
				AND (t.KodePos = @kodePos OR @kodePos IS NULL)
				AND (kp.Wilayah = @wilayah OR @wilayah IS NULL)

			UNION ALL
		
			SELECT
				k.TglKoreksi,
				nh.TglSuratJalan,
				doh.KodeToko,
				doh.KodeSales,
				dod.BarangID,
				-1*(dbo.fnHitungNet3Disc(dod.HrgJual*nd.QtySuratJalan, dod.Disc1, dod.Disc2, dod.Disc3, dod.DiscFormula)
				- dbo.fnHitungNet3Disc(dod.HrgJual*k.QtyNotaBaru, dod.Disc1, dod.Disc2, dod.Disc3, dod.DiscFormula))
			FROM dbo.KoreksiPenjualan k
				INNER JOIN dbo.NotaPenjualanDetail nd ON k.NotaJualDetailID = nd.RowID
				LEFT OUTER JOIN dbo.NotaPenjualan nh ON nd.HeaderID = nh.RowID
				INNER JOIN dbo.OrderPenjualanDetail dod ON nd.DODetailID = dod.RowID
				INNER JOIN dbo.OrderPenjualan doh ON dod.HeaderID = doh.RowID
				LEFT OUTER JOIN dbo.Toko t ON doh.KodeToko = t.KodeToko
			LEFT OUTER JOIN dbo.KodePos kp ON t.KodePos = kp.KodePos
			WHERE
				(k.TglKoreksi BETWEEN @fromDate1 AND @toDate1)
					OR
				(k.TglKoreksi BETWEEN @fromDate2 AND @toDate2)
				AND doh.Cabang1 = @initCab
				AND t.StatusAktif = 0
				AND (doh.KodeSales = @kodeSales OR @kodeSales IS NULL)
				AND (doh.Kota LIKE '%'+@kota+'%' OR @kota IS NULL)
				AND (t.KodePos = @kodePos OR @kodePos IS NULL)
				AND (kp.Wilayah = @wilayah OR @wilayah IS NULL)

			UNION ALL
		
			SELECT
				k.TglKoreksi,
				rh.TglGudang,
				doh.KodeToko,
				doh.KodeSales,
				dod.BarangID,
				-1*(dbo.fnHitungNet3Disc(dod.HrgJual*k.QtyNotaBaru, dod.Disc1, dod.Disc2, dod.Disc3, dod.DiscFormula)
				- dbo.fnHitungNet3Disc(dod.HrgJual*rd.QtyGudang, dod.Disc1, dod.Disc2, dod.Disc3, dod.DiscFormula))
			FROM dbo.KoreksiReturPenjualan k
				INNER JOIN dbo.ReturPenjualanDetail rd ON k.ReturJualDetailID = rd.RowID
				LEFT OUTER JOIN dbo.ReturPenjualan rh ON rd.HeaderID = rh.RowID
				INNER JOIN dbo.NotaPenjualanDetail nd ON rd.NotaJualDetailID = nd.RowID
				INNER JOIN dbo.OrderPenjualanDetail dod ON nd.DODetailID = dod.RowID
				INNER JOIN dbo.OrderPenjualan doh ON dod.HeaderID = doh.RowID
				LEFT OUTER JOIN dbo.Toko t ON doh.KodeToko = t.KodeToko
				LEFT OUTER JOIN dbo.KodePos kp ON t.KodePos = kp.KodePos
			WHERE
				(k.TglKoreksi BETWEEN @fromDate1 AND @toDate1)
					OR
				(k.TglKoreksi BETWEEN @fromDate2 AND @toDate2)
				AND doh.Cabang1 = @initCab
				AND t.StatusAktif = 0
				AND (doh.KodeSales = @kodeSales OR @kodeSales IS NULL)
				AND (doh.Kota LIKE '%'+@kota+'%' OR @kota IS NULL)
				AND (t.KodePos = @kodePos OR @kodePos IS NULL)
				AND (kp.Wilayah = @wilayah OR @wilayah IS NULL)
		END

	END

	/* Final query untuk report Analisa Kunjungan Sales */
	SELECT
		t.NamaToko,
		RIGHT(t.Propinsi, 2) AS Stb,
		t.Grade,
		t.WilID,
		(CASE WHEN ISNULL(t.KodePos, '') != '' THEN kp.Wilayah+'-'+t.KodePos ELSE '' END) AS KodePos,
		t.Alamat,
		t.Kota,
		dbo.fnGetStatusToko(d.TglStsToko, d.KodeToko, @initCab) AS [Status],
		d.KodeSales,
		d.Nilai_BrgA_1,
		d.Nilai_BrgB2_1,
		d.Nilai_BrgB4_1,
		d.Nilai_BrgBL_1 AS Nilai_BrgB_1,
		d.Nilai_BrgE_1, 
		d.Nilai_BrgA_2,
		d.Nilai_BrgB2_2,
		d.Nilai_BrgB4_2,
		d.Nilai_BrgBL_2 AS Nilai_BrgB_2,
		d.Nilai_BrgE_2,

		(d.Nilai_BrgA_1 + d.Nilai_BrgB2_1 + d.Nilai_BrgB4_1 + d.Nilai_BrgBL_1 
		+ d.Nilai_BrgE_1) AS Total1,
		(d.Nilai_BrgA_2 + d.Nilai_BrgB2_2 + d.Nilai_BrgB4_2 + d.Nilai_BrgBL_2 
		+ d.Nilai_BrgE_2) AS Total2,
		
		(d.Nilai_BrgA_2 + d.Nilai_BrgB2_2 + d.Nilai_BrgB4_2 + d.Nilai_BrgBL_2 
		+ d.Nilai_BrgE_2) - 
		(d.Nilai_BrgA_1 + d.Nilai_BrgB2_1 + d.Nilai_BrgB4_1 + d.Nilai_BrgBL_1 
		+ d.Nilai_BrgE_1) AS Selisih

	FROM
	(
		SELECT
			KodeToko,
			MIN(TglSts) TglStsToko,
			KodeSales,
			SUM(CASE WHEN SUBSTRING(BarangID, 2, 1) = 'A' AND (Tgl BETWEEN @fromDate1 AND @toDate1)
					THEN RpNet ELSE 0 END) AS Nilai_BrgA_1,
			SUM(CASE WHEN SUBSTRING(BarangID, 2, 2) = 'B2' AND Tgl BETWEEN @fromDate1 AND @toDate1
					THEN RpNet ELSE 0 END) AS Nilai_BrgB2_1,
			SUM(CASE WHEN SUBSTRING(BarangID, 2, 2) = 'B4' AND Tgl BETWEEN @fromDate1 AND @toDate1
					THEN RpNet ELSE 0 END) AS Nilai_BrgB4_1,
			SUM(CASE WHEN SUBSTRING(BarangID, 2, 1) = 'B' 
					AND SUBSTRING(BarangID, 3, 1) <> '2' AND SUBSTRING(BarangID, 3, 1) <> '4' 
					AND Tgl BETWEEN @fromDate1 AND @toDate1
					THEN RpNet ELSE 0 END) AS Nilai_BrgBL_1,
			SUM(CASE WHEN SUBSTRING(BarangID, 2, 1) = 'E' AND Tgl BETWEEN @fromDate1 AND @toDate1 
					THEN RpNet ELSE 0 END) AS Nilai_BrgE_1, 
			
			SUM(CASE WHEN SUBSTRING(BarangID, 2, 1) = 'A' AND Tgl BETWEEN @fromDate2 AND @toDate2 
					THEN RpNet ELSE 0 END) AS Nilai_BrgA_2,
			SUM(CASE WHEN SUBSTRING(BarangID, 2, 2) = 'B2' AND Tgl BETWEEN @fromDate2 AND @toDate2 
					THEN RpNet ELSE 0 END) AS Nilai_BrgB2_2,
			SUM(CASE WHEN SUBSTRING(BarangID, 2, 2) = 'B4' AND Tgl BETWEEN @fromDate2 AND @toDate2 
					THEN RpNet ELSE 0 END) AS Nilai_BrgB4_2,
			SUM(CASE WHEN SUBSTRING(BarangID, 2, 1) = 'B' 
					AND SUBSTRING(BarangID, 3, 2) <> '2' AND SUBSTRING(BarangID, 3, 1) <> '4' 
					AND Tgl BETWEEN @fromDate2 AND @toDate2 
					THEN RpNet ELSE 0 END) AS Nilai_BrgBL_2,
			SUM(CASE WHEN SUBSTRING(BarangID, 2, 1) = 'E' AND Tgl BETWEEN @fromDate2 AND @toDate2 
					THEN RpNet ELSE 0 END) AS Nilai_BrgE_2
		FROM @data
		GROUP BY KodeToko, KodeSales
	) d
	LEFT OUTER JOIN dbo.Toko t ON d.KodeToko = t.KodeToko
	LEFT OUTER JOIN dbo.KodePos kp on t.KodePos = kp.KodePos

	ORDER BY 
		(CASE 
			WHEN @urut = 'TOKO' THEN t.NamaToko
			WHEN @urut = 'SALES' THEN d.KodeSales
			WHEN @urut = 'KOTA' THEN t.Kota
		END)

END
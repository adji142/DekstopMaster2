USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Laporan_Toko_OmzetTertinggiToko]    Script Date: 05/06/2011 07:46:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==============================================================
-- Author		: Stephanie
-- Create date	: 05 May 2011
-- Description	: Laporan > Toko > Omzet Tertinggi Toko
-- Example		: [dbo].[rsp_Laporan_Toko_OmzetTertinggiToko] 
--					@fromDate='2010/05/25', @toDate='2010/06/05'
-- ==============================================================
CREATE PROCEDURE [dbo].[rsp_Laporan_Toko_OmzetTertinggiToko] 
	-- Add the parameters for the stored procedure here
	 @fromDate datetime,
	 @toDate datetime,
	 @kodeSales varchar(11) = NULL,
	 @wilID varchar(7) = NULL,
	 @wilayah varchar(2) = NULL,
	 @kota varchar(20) = NULL,
	 @c1 varchar(2) = NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	

	/* Populate Months in Range between @fromDate and @toDate */
	DECLARE @tgl datetime
	DECLARE @tglAkhir datetime
	DECLARE @periode TABLE (Periode varchar(10), TglAwal datetime)
	
	SET @tgl = DATEADD(DAY, -1*(DATEPART(DAY, @fromDate)-1) ,@fromDate)
	SET @tglAkhir = DATEADD(MONTH, 1, DATEADD(DAY, -1*(DATEPART(DAY, @toDate)+1) ,@toDate))
	
	WHILE @tgl <= @tglAkhir
	BEGIN
		INSERT INTO @periode
		SELECT
			LEFT(DATENAME(MONTH, @tgl), 3) + ' ' + CONVERT(varchar, DATEPART(YEAR, @tgl)),
			@tgl	

		SET @tgl = DATEADD(MONTH, 1, @tgl)
	END

	INSERT INTO @periode
	SELECT 'Tertinggi', @tgl


	/***************************Query untuk Laporan Omzet Tertinggi Toko***************************/

	/* Query untuk populate Omzet toko per bulan */
	SELECT 
		x.KodeToko,
		x.NamaToko,
		x.KodePos,
		x.Alamat,
		x.Kota,
		x.WilID,
		x.Omzet,
		x.Periode,
		p.TglAwal
	FROM 
	(
		SELECT
			t.KodeToko,
			t.NamaToko,
			(CASE WHEN ISNULL(kp.KodePos, '') != '' THEN kp.Wilayah+'-'+kp.KodePos
				ELSE '' END) AS KodePos,
			t.Alamat,
			t.Kota,
			t.WilID,
			SUM(dbo.fnHitungNet3Disc(dod.HrgJual, dod.Disc1, dod.Disc2, dod.Disc3, '')
				* nd.QtySuratJalan) AS Omzet,
			LEFT(DATENAME(MONTH, nh.TglSuratJalan), 3) + ' ' 
				+ CONVERT(varchar, DATEPART(YEAR, nh.TglSuratJalan)) AS Periode
		FROM dbo.NotaPenjualan nh
			INNER JOIN dbo.OrderPenjualan doh ON nh.DOID = doh.RowID
			INNER JOIN dbo.Toko t ON doh.KodeToko = t.KodeToko
			LEFT OUTER JOIN dbo.NotaPenjualanDetail nd ON nh.RowID = nd.HeaderID
			LEFT OUTER JOIN dbo.OrderPenjualanDetail dod ON nd.DODetailID = dod.RowID
			LEFT OUTER JOIN dbo.KodePos kp ON kp.KodePos = t.KodePos
		WHERE
			nh.TglSuratJalan BETWEEN @fromDate AND @toDate
			AND
			(doh.KodeSales = @kodeSales OR @kodeSales IS NULL)
			AND
			(doh.Cabang1 = @c1 OR @c1 IS NULL)
			AND
			(kp.Wilayah = @wilayah OR @wilayah IS NULL)
			AND
			(t.WilID LIKE '%'+@wilID+'%' OR @wilID IS NULL)
			AND
			(t.Kota LIKE '%'+@kota+'%' OR @kota IS NULL)
			
		GROUP BY 
			t.KodeToko,
			t.NamaToko,
			(CASE WHEN ISNULL(kp.KodePos, '') != '' THEN kp.Wilayah+'-'+kp.KodePos
				ELSE '' END),
			t.Alamat,
			t.Kota,
			t.WilID,
			LEFT(DATENAME(MONTH, nh.TglSuratJalan), 3) + ' ' 
				+ CONVERT(varchar, DATEPART(YEAR, nh.TglSuratJalan))

		UNION ALL 

		/* Query Empty Record Toko untuk mengurutkan Periode */
		SELECT
			NULL AS KodeToko,
			NULL AS NamaToko,
			NULL AS Alamat,
			NULL AS KodePos,
			NULL AS Kota,
			NULL AS WilID,
			0 AS Omzet,
			Periode
		FROM @periode
	) x
	LEFT OUTER JOIN @periode p ON x.Periode = p.Periode
	

	/* Gabung record Omzet per bulan toko dengan Omzet bulanan Tertingginya */
	UNION ALL
	/************************************************************************/

	/* Query Rerord Toko dan Omzet Tertingginya*/
	SELECT 
		mx.KodeToko,
		mx.NamaToko,
		mx.KodePos,
		mx.Alamat,
		mx.Kota,
		mx.WilID,
		MAX(mx.Omzet) AS Omzet,
		'Tertinggi' AS Periode,
		@tgl AS TglAwal
	FROM
	(
		SELECT
			t.KodeToko,
			t.NamaToko,
			(CASE WHEN ISNULL(kp.KodePos, '') != '' THEN kp.Wilayah+'-'+kp.KodePos
				ELSE '' END) AS KodePos,
			t.Alamat,
			t.Kota,
			t.WilID,
			SUM(dbo.fnHitungNet3Disc(dod.HrgJual, dod.Disc1, dod.Disc2, dod.Disc3, '')
				* nd.QtySuratJalan) AS Omzet,
			LEFT(DATENAME(MONTH, nh.TglSuratJalan), 3) + ' ' 
				+ CONVERT(varchar, DATEPART(YEAR, nh.TglSuratJalan)) AS Periode
		FROM dbo.NotaPenjualan nh
			INNER JOIN dbo.OrderPenjualan doh ON nh.DOID = doh.RowID
			INNER JOIN dbo.Toko t ON doh.KodeToko = t.KodeToko
			LEFT OUTER JOIN dbo.NotaPenjualanDetail nd ON nh.RowID = nd.HeaderID
			LEFT OUTER JOIN dbo.OrderPenjualanDetail dod ON nd.DODetailID = dod.RowID
			LEFT OUTER JOIN dbo.KodePos kp ON kp.KodePos = t.KodePos
		WHERE
			nh.TglSuratJalan BETWEEN @fromDate AND @toDate
			AND
			(doh.KodeSales = @kodeSales OR @kodeSales IS NULL)
			AND
			(doh.Cabang1 = @c1 OR @c1 IS NULL)
			AND
			(kp.Wilayah = @wilayah OR @wilayah IS NULL)
			AND
			(t.WilID LIKE '%'+@wilID+'%' OR @wilID IS NULL)
			AND
			(t.Kota LIKE '%'+@kota+'%' OR @kota IS NULL)
		GROUP BY 
			t.KodeToko,
			t.NamaToko,
			(CASE WHEN ISNULL(kp.KodePos, '') != '' THEN kp.Wilayah+'-'+kp.KodePos
				ELSE '' END),
			t.Alamat,
			t.Kota,
			t.WilID,
			LEFT(DATENAME(MONTH, nh.TglSuratJalan), 3) + ' ' 
				+ CONVERT(varchar, DATEPART(YEAR, nh.TglSuratJalan))
	) mx
	GROUP BY 
		mx.KodeToko,
		mx.NamaToko,
		mx.KodePos,
		mx.Alamat,
		mx.Kota,
		mx.WilID
	
	ORDER BY NamaToko, TglAwal ASC 
			
END
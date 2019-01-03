USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Laporan_Toko_AnalisaPer3Bulan]    Script Date: 05/05/2011 07:12:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- Author		: Stephanie
-- Create date	: 05 May 2011
-- Description	: Laporan > Toko > Analisa per 3 Bulan
-- Example		: [dbo].[rsp_Laporan_Toko_AnalisaPer3Bulan] 
--					@fromDate = '2009/11/15', 
--					@toDate = '2010/02/15'
--					@kodeToko = '1997102904:26:10044'
-- ============================================================
CREATE PROCEDURE [dbo].[rsp_Laporan_Toko_AnalisaPer3Bulan] 
	-- Add the parameters for the stored procedure here
	 @fromDate datetime,
	 @toDate datetime,
	 @kodeToko varchar(19) = NULL,
	 @kodeSales varchar(11) = NULL,
	 @kota varchar(20) = NULL

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

	DECLARE @fromDate1 datetime
	DECLARE @fromDate2 datetime
	DECLARE @fromDate3 datetime
	DECLARE @toDate1 datetime
	DECLARE @toDate2 datetime
	DECLARE @toDate3 datetime
	----------------------------
	SET @fromDate1 = @fromDate
	SET @fromDate2 = DATEADD(MONTH, 1, DATEADD(DAY, -1*(DATEPART(DAY, @fromDate)-1) , @fromDate))
	SET @fromDate3 = DATEADD(DAY, -1*(DATEPART(DAY, @toDate)-1), @toDate)
	SET @toDate1 = DATEADD(DAY, -1, @fromDate2)
	SET @toDate2 = DATEADD(DAY, -1, @fromDate3)
	SET @toDate3 = @toDate

	SELECT
		t.KodeToko,
		t.NamaToko,
		t.Alamat,
		x.Kota,
		st.Status,
		st.Roda,
		x.KodeSales,

		SUM(CASE WHEN x.TglSuratJalan BETWEEN @fromDate1 AND @toDate1 
			THEN x.NilaiBrgA ELSE 0 END) AS Nilai_BrgA_1,
		SUM(CASE WHEN x.TglSuratJalan BETWEEN @fromDate2 AND @toDate2 
			THEN x.NilaiBrgA ELSE 0 END) AS Nilai_BrgA_2,
		SUM(CASE WHEN x.TglSuratJalan BETWEEN @fromDate3 AND @toDate3 
			THEN x.NilaiBrgA ELSE 0 END) AS Nilai_BrgA_3,

		SUM(CASE WHEN x.TglSuratJalan BETWEEN @fromDate1 AND @toDate1 
			THEN x.NilaiBrgB ELSE 0 END) AS Nilai_BrgB_1,
		SUM(CASE WHEN x.TglSuratJalan BETWEEN @fromDate2 AND @toDate2 
			THEN x.NilaiBrgB ELSE 0 END) AS Nilai_BrgB_2,
		SUM(CASE WHEN x.TglSuratJalan BETWEEN @fromDate3 AND @toDate3 
			THEN x.NilaiBrgB ELSE 0 END) AS Nilai_BrgB_3,

		SUM(CASE WHEN x.TglSuratJalan BETWEEN @fromDate1 AND @toDate1 
			THEN x.NilaiBrgE ELSE 0 END) AS Nilai_BrgE_1,
		SUM(CASE WHEN x.TglSuratJalan BETWEEN @fromDate2 AND @toDate2 
			THEN x.NilaiBrgE ELSE 0 END) AS Nilai_BrgE_2,
		SUM(CASE WHEN x.TglSuratJalan BETWEEN @fromDate3 AND @toDate3 
			THEN x.NilaiBrgE ELSE 0 END) AS Nilai_BrgE_3
	FROM
	(
		SELECT
			doh.KodeToko,
			nh.Kota,
			doh.KodeSales,
			dod.BarangID,
			nh.TglSuratJalan,
			CASE WHEN 'FC2FC4FALFA0FABFA2FA4FAT' LIKE '%'+LEFT(dod.BarangID, 3)+'%' 
				THEN dbo.fnHitungNet3Disc(dod.HrgJual*nd.QtySuratJalan, 
						dod.Disc1, dod.Disc2, dod.Disc3, dod.DiscFormula) 
						- (dod.Pot*nd.QtySuratJalan)
				ELSE 0 END AS NilaiBrgA,
			CASE WHEN 'FB2FB4FBL' LIKE '%'+LEFT(dod.BarangID, 3)+'%' 
				THEN dbo.fnHitungNet3Disc(dod.HrgJual*nd.QtySuratJalan, 
						dod.Disc1, dod.Disc2, dod.Disc3, dod.DiscFormula) 
						- (dod.Pot*nd.QtySuratJalan) 
				ELSE 0 END AS NilaiBrgB,
			CASE WHEN 'FE2FE4' LIKE '%'+LEFT(dod.BarangID, 3)+'%' 
				THEN dbo.fnHitungNet3Disc(dod.HrgJual*nd.QtySuratJalan, 
						dod.Disc1, dod.Disc2, dod.Disc3, dod.DiscFormula) 
						- (dod.Pot*nd.QtySuratJalan)
				ELSE 0 END AS NilaiBrgE		

		FROM dbo.NotaPenjualan nh
			INNER JOIN dbo.NotaPenjualanDetail nd ON nh.RowID = nd.HeaderID
			LEFT OUTER JOIN dbo.OrderPenjualan doh ON nh.DOID = doh.RowID
			LEFT OUTER JOIN dbo.OrderPenjualanDetail dod ON nd.DODetailID = dod.RowID

		WHERE
			nh.TglSuratJalan BETWEEN @fromDate AND @toDate
			AND
			(doh.KodeToko = @kodeToko OR @kodeToko IS NULL)
			AND
			(doh.KodeSales = @kodeSales OR @kodeSales IS NULL)
			AND
			(nh.Kota = @kota OR @kota IS NULL)
	) x
	LEFT OUTER JOIN dbo.Toko t ON x.KodeToko = t.KodeToko
	OUTER APPLY
	(
		SELECT TOP 1
			statusToko.Status,
			statusToko.Roda
		FROM dbo.StatusToko statusToko 
		WHERE 
			statusToko.KodeToko = x.KodeToko
			AND
			statusToko.CabangID = @initCab
		ORDER BY statusToko.TglAktif DESC
	) st
	
	GROUP BY 
		t.KodeToko,
		t.NamaToko,
		t.Alamat,
		x.Kota,
		st.Status,
		st.Roda,
		x.KodeSales
	
	ORDER BY t.NamaToko, x.KodeSales ASC
	
END
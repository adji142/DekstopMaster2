USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Laporan_Toko_EvaluasiPenyelesaianOrder]    Script Date: 05/09/2011 08:45:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==================================================================
-- Author		: Stephanie
-- Create date	: 06 May 2011
-- Description	: Laporan > Toko > Evaluasi Penyelesaian Order
-- Example		:  [dbo].[rsp_Laporan_Toko_EvaluasiPenyelesaianOrder] 
--					@fromDate = '2010/04/01', @toDate = '2010/04/05',
--					@tipeTgl='RQ'
-- ==================================================================
CREATE PROCEDURE [dbo].[rsp_Laporan_Toko_EvaluasiPenyelesaianOrder] 
	-- Add the parameters for the stored procedure here
	 @fromDate datetime,
	 @toDate datetime,
	 @tipeTgl varchar(2), -- 'RQ'=TglRQ, 'DO'=TglDO, 'SJ'=TglSJ, 'NT'=TglNota, 'TR'=TglTerima
	 @postID varchar(2) = NULL,
	 @cabang2 varchar(2) = NULL,
	 @kodeSales varchar(11) = NULL,
	 @kodeToko varchar(19) = NULL,
	 @initPrs varchar(3) = NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

	DECLARE @do TABLE
	(
		RowID uniqueidentifier,
		InitPrs varchar(3),
		NamaToko varchar(31),
		Kota varchar(20),
		Cabang1 varchar(2),
		Cabang2 varchar(2),
		KodeSales varchar(11),
		NoRequest varchar(7),
		TglRequest datetime,
		NoDO varchar(7),
		TglDO datetime,
		NilaiBO money,
		ACC varchar(1)
	)

	/* Populating and filtering DO */
	INSERT INTO @do
	SELECT
		h.RowID,
		LEFT(h.HtrID, 3),
		t.NamaToko,
		t.Kota,
		h.Cabang1,
		h.Cabang2,
		h.KodeSales,
		h.NoRequest,
		h.TglRequest,
		h.NoDO,
		h.TglDO,
		SUM(CASE WHEN d.QtyDO > sj.QtySJ 
				THEN dbo.fnHitungNet3Disc( (d.QtyDO - sj.QtySJ) *d.HrgJual,
						d.Disc1, d.Disc2, d.Disc3, d.DiscFormula)
						- (d.QtyDO * d.Pot)  
				ELSE 0 END) AS NilaiBO,
		ACC.Tag
	FROM dbo.OrderPenjualan h
		LEFT OUTER JOIN dbo.OrderPenjualanDetail d ON h.RowID = d.HeaderID
		LEFT OUTER JOIN dbo.NotaPenjualan n ON h.RowID = n.DOID
		LEFT OUTER JOIN dbo.Toko t ON h.KodeToko = t.KodeToko
		LEFT OUTER JOIN dbo.Stok b ON d.BarangID = b.BarangID
		LEFT OUTER JOIN dbo.PostKota pk ON (t.Kota = pk.Kota AND t.Propinsi = pk.Propinsi)
		LEFT OUTER JOIN dbo.PostArea pa ON pk.PostRecID = pa.RecordID
		OUTER APPLY
		(
			SELECT
				ISNULL(SUM(nd.QtySuratJalan), 0) AS QtySJ
			FROM dbo.NotaPenjualanDetail nd
			WHERE d.RowID = nd.DODetailID
		)sj
		OUTER APPLY
		(
			SELECT
				(CASE WHEN EXISTS 
					(SELECT b.RowID FROM dbo.OrderPenjualanDetail b
						WHERE (dbo.fnHitungNet3Disc(b.HrgJual, b.Disc1, b.Disc2, b.Disc3, b.DiscFormula)-b.Pot
							< dbo.fnHitungHrgJual(a.TglDO, b.BarangID, NULL, b.QtyDO, a.KodeToko, a.Cabang1)
							OR
							dbo.fnHitungNet3Disc(b.HrgJual, b.Disc1, b.Disc2, b.Disc3, b.DiscFormula)-b.Pot
							< 
							dbo.fnGetHPP(b.BarangID, a.TglDO))
						AND RTRIM(b.NoACC) <> '' AND b.HeaderID = a.RowID)
					THEN 'V'
					ELSE (CASE WHEN EXISTS 
							(SELECT b.RowID FROM dbo.OrderPenjualanDetail b
								WHERE (dbo.fnHitungNet3Disc(b.HrgJual, b.Disc1, b.Disc2, b.Disc3, b.DiscFormula)-b.Pot
									< dbo.fnHitungHrgJual(a.TglDO, b.BarangID, NULL, b.QtyDO, a.KodeToko, a.Cabang1)
									OR
									dbo.fnHitungNet3Disc(b.HrgJual, b.Disc1, b.Disc2, b.Disc3, b.DiscFormula)-b.Pot
									< 
									dbo.fnGetHPP(b.BarangID, a.TglDO))
								AND RTRIM(b.NoACC) = '' AND b.HeaderID = a.RowID)
							THEN '?'
							ELSE 'X' END)
					END) AS Tag
			FROM dbo.OrderPenjualan a 
			WHERE h.RowID = a.RowID			
		) ACC
	WHERE
		(
			(@tipeTgl = 'RQ' AND h.TglRequest BETWEEN @fromDate AND @toDate)
			OR
			(@tipeTgl = 'DO' AND h.TglDO BETWEEN @fromDate AND @toDate)
			OR
			(@tipeTgl = 'SJ' AND n.TglSuratJalan BETWEEN @fromDate AND @toDate)
			OR
			(@tipeTgl = 'NT' AND n.TglNota BETWEEN @fromDate AND @toDate)
			OR
			(@tipeTgl = 'TR' AND n.TglTerima BETWEEN @fromDate AND @toDate)
		)
		AND
		LEFT(h.NoACCPiutang, 1) = 'F'
		AND
		(pa.PostID = @postID OR @postID IS NULL)
		AND
		(h.Cabang2 = @cabang2 OR @cabang2 IS NULL)
		AND
		(h.KodeSales = @kodeSales OR @kodeSales IS NULL)	
		AND
		(h.KodeToko = @kodeToko OR @kodeToko IS NULL)
		AND
		(LEFT(h.HtrID, 3) = @initPrs OR @initPrs IS NULL)

	GROUP BY
		h.RowID,
		LEFT(h.HtrID, 3),
		t.NamaToko,
		t.Kota,
		h.Cabang1,
		h.Cabang2,
		h.KodeSales,
		h.NoRequest,
		h.TglRequest,
		h.NoDO,
		h.TglDO,
		ACC.Tag


	/* Query untuk Report EvaluasiPenyelesaianOrder */
	
	SELECT
		do.RowID,
		do.NamaToko,
		do.Kota,
		do.Cabang1,
		do.Cabang2,
		do.KodeSales,
		do.NoRequest,
		do.TglRequest,
		(CASE WHEN do.TglDO IS NOT NULL AND do.TglRequest IS NOT NULL
			THEN DATEDIFF(DAY, do.TglRequest, do.TglDO) + 1
			ELSE 0 END) AS JarakWaktu1,
		do.NoDO,
		do.TglDO,
		dod.RpNet,
		do.ACC,		
		(CASE WHEN nota.TglSuratJalan IS NOT NULL AND do.TglDO IS NOT NULL
			THEN DATEDIFF(DAY, do.TglDO, nota.TglSuratJalan) + 1
			ELSE 0 END) AS JarakWaktu2,	
		nota.NoSuratJalan,
		nota.TglSuratJalan,
		notaSUM.RpNet2,
		do.NilaiBO,
		(CASE WHEN nota.TglSerahTerimaChecker IS NOT NULL AND nota.TglSuratJalan IS NOT NULL
			THEN DATEDIFF(DAY, nota.TglSuratJalan, nota.TglSerahTerimaChecker) + 1
			ELSE 0 END) AS JarakWaktu3,
		nota.TglSerahTerimaChecker,
		(CASE WHEN nota.TglExpedisi IS NOT NULL AND nota.TglSerahTerimaChecker IS NOT NULL
			THEN DATEDIFF(DAY, nota.TglSerahTerimaChecker, nota.TglExpedisi) + 1
			ELSE 0 END) AS JarakWaktu4,
		nota.TglExpedisi,
		(CASE WHEN nota.TglExpedisi IS NOT NULL AND nota.TglTerima IS NOT NULL
			THEN DATEDIFF(DAY, nota.TglExpedisi, nota.TglTerima) + 1
			ELSE 0 END) AS JarakWaktu5,
		nota.NoNota,
		nota.TglTerima,
		notaSUM.RpNet3,
		(CASE WHEN do.TglRequest IS NOT NULL AND nota.TglTerima IS NOT NULL
			THEN DATEDIFF(DAY, do.TglRequest, nota.TglTerima) + 1
			ELSE 0 END) AS JarakWaktuSelesai,
		/*  Hitung Jumlah hari minggu yang ada BETWEEN range TglRequest AND TglTerima */
		FLOOR(hitWeek.Jarak / 7) + 
			(CASE WHEN (hitWeek.HrAwal + (hitWeek.Jarak % 7)) >= 7 
			THEN 1 ELSE 0 END) - 
			(CASE WHEN hitWeek.HrAkhir = 7 THEN 1 ELSE 0 END)
			AS JmlMinggu,
		do.InitPrs

	FROM @do do
		LEFT OUTER JOIN dbo.NotaPenjualan nota ON do.RowID = nota.DOID
		CROSS APPLY
		(
			SELECT 
				ISNULL(SUM (dbo.fnHitungNet3Disc(d.QtyDO*d.HrgJual, d.Disc1, d.Disc2, d.Disc3, d.DiscFormula)
					- (d.QtyDO * d.Pot)), 0) AS RpNet
			FROM dbo.OrderPenjualanDetail d
				LEFT OUTER JOIN dbo.Stok b ON d.BarangID = b.BarangID
			WHERE
				d.HeaderID = do.RowID
		)dod
		OUTER APPLY
		(
			SELECT
				ISNULL(SUM (dbo.fnHitungNet3Disc(nd.QtySuratJalan*dod.HrgJual, dod.Disc1, dod.Disc2, dod.Disc3, dod.DiscFormula)
					- (nd.QtySuratJalan * dod.Pot)), 0) AS RpNet2,
				ISNULL(SUM (dbo.fnHitungNet3Disc(nd.QtyNota*dod.HrgJual, dod.Disc1, dod.Disc2, dod.Disc3, dod.DiscFormula)
					- (nd.QtyNota * dod.Pot)), 0)  AS RpNet3
			FROM dbo.NotaPenjualanDetail nd
				LEFT OUTER JOIN dbo.OrderPenjualanDetail dod ON nd.DODetailID = dod.RowID
				LEFT OUTER JOIN dbo.Stok b ON dod.BarangID = b.BarangID
			WHERE
				nd.HeaderID = nota.RowID
		)notaSUM
		OUTER APPLY
		(
			SELECT
				(CASE WHEN do.TglRequest IS NOT NULL AND nota.TglTerima IS NOT NULL
					THEN DATEDIFF(DAY, do.TglRequest, nota.TglTerima) 
					ELSE 0 END) AS Jarak,
				DATEPART(dw, do.TglRequest) AS HrAwal,
				DATEPART(dw, nota.TglTerima) AS HrAkhir
		)hitWeek

	WHERE
		(@tipeTgl = 'RQ' OR @tipeTgl = 'DO')
		OR
		(@tipeTgl = 'SJ' AND nota.TglSuratJalan BETWEEN @fromDate AND @toDate)
		OR
		(@tipeTgl = 'NT' AND nota.TglNota BETWEEN @fromDate AND @toDate)
		OR
		(@tipeTgl = 'TR' AND nota.TglTerima BETWEEN @fromDate AND @toDate)

	ORDER BY do.TglDO, do.NoDO, nota.TglSuratJalan, nota.NoSuratJalan ASC

	
END
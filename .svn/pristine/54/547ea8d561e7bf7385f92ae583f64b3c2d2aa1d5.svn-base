USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Laporan_Toko_PenyelesaianDO]    Script Date: 05/04/2011 15:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==================================================================
-- Author		: Stephanie
-- Create date	: 02 May 2011
-- Description	: Laporan > Toko > Penyelesaian DO
-- Example		:  [dbo].[rsp_Laporan_Toko_PenyelesaianDO]
--					 @fromDate = '2010/04/01', @toDate = '2010/05/10'
--					, @KLP = 'FAB'
-- ==================================================================
CREATE PROCEDURE [dbo].[rsp_Laporan_Toko_PenyelesaianDO] 
	-- Add the parameters for the stored procedure here
	 @fromDate datetime,
	 @toDate datetime,
	 @cabang1 varchar(2) = NULL,
	 @cabang2 varchar(2) = NULL,
	 @kodeSales varchar(11) = NULL,
	 @kodeToko varchar(19) = NULL,
	 @wilID varchar(7) = NULL,
	 @barangID varchar(23) = NULL,
	 @namaBarang varchar(73) = NULL,
	 @KLP varchar(3) = NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

	DECLARE @do TABLE
	(
		RowID uniqueidentifier,
		NamaToko varchar(31),
		Kota varchar(20),
		WilID varchar(7),
		Cabang1 varchar(2),
		Cabang2 varchar(2),
		NamaSales varchar(23),
		NoRequest varchar(7),
		TglRequest datetime,
		NoDO varchar(7),
		TglDO datetime,
		TransactionType varchar(2),
		NilaiBO money
	)

	/* Populating and filtering DO */
	INSERT INTO @do
	SELECT
		h.RowID,
		t.NamaToko,
		t.Kota,
		t.WilID,
		h.Cabang1,
		h.Cabang2,
		s.NamaSales,
		h.NoRequest,
		h.TglRequest,
		h.NoDO,
		h.TglDO,
		h.TransactionType,
		SUM(CASE WHEN d.QtyDO > sj.QtySJ 
				THEN dbo.fnHitungNet3Disc( (d.QtyDO - sj.QtySJ) *d.HrgJual,
						d.Disc1, d.Disc2, d.Disc3, d.DiscFormula)
						- (d.QtyDO * d.Pot)  
				ELSE 0 END) AS NilaiBO
	FROM dbo.OrderPenjualan h
		LEFT OUTER JOIN dbo.OrderPenjualanDetail d ON h.RowID = d.HeaderID
		LEFT OUTER JOIN dbo.Toko t ON h.KodeToko = t.KodeToko
		LEFT OUTER JOIN dbo.Sales s ON h.KodeSales = s.SalesID
		LEFT OUTER JOIN dbo.Stok b ON d.BarangID = b.BarangID
		OUTER APPLY
		(
			SELECT
				ISNULL(SUM(nd.QtySuratJalan), 0) AS QtySJ
			FROM dbo.NotaPenjualanDetail nd
			WHERE d.RowID = nd.DODetailID
		)sj
	WHERE
		h.TglDO BETWEEN @fromDate AND @toDate
		AND
		(h.Cabang1 = @cabang1 OR @cabang1 IS NULL)
		AND
		(h.Cabang2 = @cabang2 OR @cabang2 IS NULL)
		AND
		(h.KodeToko = @kodeToko OR @kodeToko IS NULL)
		AND
		(h.KodeSales = @kodeSales OR @kodeSales IS NULL)
		AND 
		(t.WilID LIKE '%'+@wilID+'%' OR @wilID IS NULL)
		AND
		(
			d.BarangID = @barangID 
				OR
			(	
				@barangID IS NULL
					AND
				( b.NamaStok LIKE '%' + @namaBarang + '%' OR @namaBarang IS NULL )
			)
		)
		AND
		(LEFT(d.BarangID, 3) = @KLP OR @KLP IS NULL)			

	GROUP BY
		h.RowID,
		t.NamaToko,
		t.Kota,
		t.WilID,
		h.Cabang1,
		h.Cabang2,
		s.NamaSales,
		h.NoRequest,
		h.TglRequest,
		h.NoDO,
		h.TglDO,
		h.TransactionType


	/************************************************Query untuk Report Penyelesaian DO************************************************/
	
	SELECT
		do.RowID,
		do.NamaToko,
		do.Kota,
		do.WilID,
		do.Cabang1,
		do.Cabang2,
		do.NamaSales,
		do.NoRequest,
		do.TglRequest,
		(CASE WHEN do.TglDO IS NOT NULL AND do.TglRequest IS NOT NULL
			THEN DATEDIFF(DAY, do.TglRequest, do.TglDO) + 1
			ELSE 0 END) AS JarakWaktu1,
		do.NoDO,
		do.TglDO,
		dod.RpNet,
		(CASE WHEN nota.TglSuratJalan IS NOT NULL AND do.TglDO IS NOT NULL
			THEN DATEDIFF(DAY, do.TglDO, nota.TglSuratJalan) + 1
			ELSE 0 END) AS JarakWaktu2,	
		nota.NoSuratJalan,
		nota.TglSuratJalan,
		notaSUM.RpNet2,
		do.NilaiBO,
		(CASE WHEN nota.TglNota IS NOT NULL AND nota.TglTerima IS NOT NULL
			THEN DATEDIFF(DAY, nota.TglNota, nota.TglTerima) + 1
			ELSE 0 END) AS JarakWaktu3,
		nota.NoNota,
		nota.TglTerima,
		notaSUM.RpNet3,
		(CASE WHEN do.TglRequest IS NOT NULL AND nota.TglTerima IS NOT NULL
			THEN DATEDIFF(DAY, do.TglRequest, nota.TglTerima) + 1
			ELSE 0 END) AS JarakWaktuSelesai,
		do.TransactionType
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
				AND
				(
					d.BarangID = @barangID 
						OR
					(	
						@barangID IS NULL
							AND
						( b.NamaStok LIKE '%'+@namaBarang+'%' OR @namaBarang IS NULL )
					)
				)
				AND
				( LEFT(d.BarangID, 3) = @KLP OR @KLP IS NULL )
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
				AND
				(
					dod.BarangID = @barangID 
						OR
					(	
						@barangID IS NULL
							AND
						( b.NamaStok LIKE '%' + @namaBarang + '%' OR @namaBarang IS NULL )
					)
				)
				AND
				( LEFT(dod.BarangID, 3) = @KLP OR @KLP IS NULL )
		)notaSUM
	ORDER BY do.TglDO, do.NoDO ASC

	/********************************************Query untuk Report Penyelesaian DO Selesai********************************************/	

			

	/************************************************Untuk Report Rekap Penyelesaian SO************************************************/
	
	/* Populate hari, dari belum selesai = 0 sampai 31 */
	DECLARE @JangkaWkt TABLE (nHari int)
	DECLARE @n int
	SET @n = 0
	WHILE (@n <= 31)
	BEGIN
		INSERT INTO @JangkaWkt
		SELECT @n
		SET @n = @n + 1 
	END

	/* Pengelompokan barang dari RIGHT(TransactionType, 3) */
	-- 'A', 'Accu'
	-- 'H', 'Oli SMO HP'
	-- 'L', 'Oli Top 1'
	-- 'V', 'Van Belt'
	-- 'B', 'Busi'
	-- 'T', 'OliTotal'
	-- 'O', 'Onderdil'
	-- 'C', 'Produksi'
		
	/* Query untuk Report Rekap Penyelesaian SO */
	SELECT
		JarakWaktuSelesai,
		SUM(A_SUM) AS A_SUM,
		COUNT(A_COUNT) AS A_COUNT,
		SUM(H_SUM) AS H_SUM,
		COUNT(H_COUNT) AS H_COUNT,
		SUM(L_SUM) AS L_SUM,
		COUNT(L_COUNT) AS L_COUNT,
		SUM(V_SUM) AS V_SUM,
		COUNT(V_COUNT) AS V_COUNT,
		SUM(B_SUM) AS B_SUM,
		COUNT(B_COUNT) AS B_COUNT,
		SUM(T_SUM) AS T_SUM,
		COUNT(T_COUNT) AS T_COUNT,
		SUM(O_SUM) AS O_SUM,
		COUNT(O_COUNT) AS O_COUNT,
		SUM(C_SUM) AS C_SUM,
		COUNT(C_COUNT) AS C_COUNT

	FROM
	(
		SELECT 
			jkw.nHari AS JarakWaktuSelesai,		
			CASE WHEN KodeTransaksi = 'A' THEN dataDO.RpNet3 ELSE 0 END  AS A_SUM,
			CASE WHEN KodeTransaksi = 'A' THEN 1 ELSE 0 END  AS A_COUNT,	
			CASE WHEN KodeTransaksi = 'H' THEN dataDO.RpNet3 ELSE 0 END  AS H_SUM,
			CASE WHEN KodeTransaksi = 'H' THEN 1 ELSE 0 END  AS H_COUNT,
			CASE WHEN KodeTransaksi = 'L' THEN dataDO.RpNet3 ELSE 0 END  AS L_SUM,
			CASE WHEN KodeTransaksi = 'L' THEN 1 ELSE 0 END  AS L_COUNT,		
			CASE WHEN KodeTransaksi = 'V' THEN dataDO.RpNet3 ELSE 0 END  AS V_SUM,
			CASE WHEN KodeTransaksi = 'V' THEN 1 ELSE 0 END  AS V_COUNT,
			CASE WHEN KodeTransaksi = 'B' THEN dataDO.RpNet3 ELSE 0 END  AS B_SUM,
			CASE WHEN KodeTransaksi = 'B' THEN 1 ELSE 0 END  AS B_COUNT,	
			CASE WHEN KodeTransaksi = 'T' THEN dataDO.RpNet3 ELSE 0 END  AS T_SUM,
			CASE WHEN KodeTransaksi = 'T' THEN 1 ELSE 0 END  AS T_COUNT,		
			CASE WHEN KodeTransaksi = 'O' THEN dataDO.RpNet3 ELSE 0 END  AS O_SUM,
			CASE WHEN KodeTransaksi = 'O' THEN 1 ELSE 0 END  AS O_COUNT,	
			CASE WHEN KodeTransaksi = 'C' THEN dataDO.RpNet3 ELSE 0 END  AS C_SUM,
			CASE WHEN KodeTransaksi = 'C' THEN 1 ELSE 0 END  AS C_COUNT

		FROM  
			(
				SELECT 
					RIGHT(do.TransactionType, 1) AS KodeTransaksi,
					(CASE WHEN nota.TglTerima IS NOT NULL THEN
						(CASE WHEN (DATEDIFF(DAY, do.TglRequest, nota.TglTerima) + 1) >= 30
						THEN 31 ELSE (DATEDIFF(DAY, do.TglRequest, nota.TglTerima) + 1) END)
					ELSE 0 END) AS JangkaWaktu,
					notaSUM.RpNet3,
					nota.RowID -- Digunakan untuk penghitungan lembar nota
				FROM @do do 
					LEFT OUTER JOIN dbo.NotaPenjualan nota ON do.RowID = nota.DOID
					OUTER APPLY
					(
						SELECT
							ISNULL(SUM (dbo.fnHitungNet3Disc(nd.QtyNota*dod.HrgJual, dod.Disc1, dod.Disc2, dod.Disc3, dod.DiscFormula)
								- (nd.QtyNota * dod.Pot)), 0)  AS RpNet3
						FROM dbo.NotaPenjualanDetail nd
							LEFT OUTER JOIN dbo.OrderPenjualanDetail dod ON nd.DODetailID = dod.RowID
							LEFT OUTER JOIN dbo.Stok b ON dod.BarangID = b.BarangID
						WHERE
							nd.HeaderID = nota.RowID
							AND
							(
								dod.BarangID = @barangID 
									OR
								(	
									@barangID IS NULL
										AND
									( b.NamaStok LIKE '%' + @namaBarang + '%' OR @namaBarang IS NULL )
								)
							)
							AND
							( LEFT(dod.BarangID, 3) = @KLP OR @KLP IS NULL )
					)notaSUM
			) dataDO 
			FULL OUTER JOIN @JangkaWkt jkw ON dataDO.JangkaWaktu = jkw.nHari
	) data

	GROUP BY JarakWaktuSelesai 
	ORDER BY JarakWaktuSelesai DESC

	/*****************************************Query untuk Report Rekap Penyelesaian SO Selesai*****************************************/	

END
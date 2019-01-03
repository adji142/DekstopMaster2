 USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_AnalisaAuditDOACC]    Script Date: 03/14/2011 09:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- Author:		Stephanie
-- Create date: 10 Mar 2011
-- Description:	VACCDO > Laporan > Analisa Audit DO ACC
-- ============================================================
ALTER PROCEDURE [dbo].[rsp_AnalisaAuditDOACC] 
	-- Add the parameters for the stored procedure here
	 @fromDate datetime,
	 @toDate datetime,
	 @c1 varchar(2),
	 @postID varchar(3)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	
	DECLARE @toko TABLE(
		KodeToko varchar(19), 
		NamaToko varchar(31), 
		WilID varchar(7),
		HariSales int,
		Plafon money,
		Nota1 money,
		Nota2 money,
		Giro1 money,
		Giro2 money,
		GiroTolak1 money,
		GiroTolak2 money,
		BelumJT1 money,
		BelumJT2 money,
		Rata2Bayar money
	)
	
	INSERT INTO @toko (
		KodeToko,
		NamaToko,
		WilID,
		HariSales
	)
	SELECT 
		DISTINCT(a.KodeToko) AS KodeToko, 
		b.NamaToko,		
		b.WilID, 
		b.HariSales
	FROM dbo.OrderPenjualan a LEFT OUTER JOIN dbo.Toko b ON a.KodeToko = b.KodeToko
	WHERE 
		(TglDO BETWEEN @fromDate AND @toDate)
		AND b.KodeToko IS NOT NULL
		AND ISNULL(a.NoACCPiutang, '') = ''
		AND (@c1 = '' OR a.Cabang1 = @c1)
		AND (a.TglDO BETWEEN @fromDate AND @toDate)
		AND (@postID = 'ALL' OR @postID = '' OR
				(SELECT TOP 1 p.PostID FROM dbo.PostKota k 
				LEFT OUTER JOIN dbo.PostArea p ON k.PostRecID = p.RecordID
				WHERE a.Kota = k.Kota) = @postID)
	ORDER BY b.NamaToko ASC

	DECLARE @kodeToko varchar(19)
	DECLARE @nota1 money
	DECLARE @nota2 money
	DECLARE @giro1 money
	DECLARE @giro2 money
	DECLARE @giroTolak1 money
	DECLARE @giroTolak2 money
	DECLARE @belumJT1 money
	DECLARE @belumJT2 money  
	DECLARE @rata2Bayar money

	DECLARE TokoCurs CURSOR 
	FOR	
	SELECT 
		KodeToko
	FROM @toko
	FOR
	UPDATE OF Plafon, Nota1, Nota2, Giro1, Giro2, GiroTolak1, GiroTolak2, BelumJT1, BelumJt2, Rata2Bayar
		
	OPEN TokoCurs

	FETCH NEXT FROM TokoCurs
	INTO @kodeToko

	WHILE @@FETCH_STATUS = 0
	BEGIN
		SELECT
			@nota1 = Nota1,
			@nota2 = Nota2,
			@giro1 = Giro1,
			@giro2 = Giro2,
			@belumJT1 = BelumJT1,
			@belumJT2 = BelumJT2,
			@rata2Bayar = Rata2Bayar
		FROM dbo.fnCekSaldo(@fromDate, @kodeToko)
		
		SELECT
			@giroTolak1 = GiroTolak1,
			@giroTolak2 = GiroTolak2
		FROM dbo.fnCekGiroTolak(@kodeToko, @fromDate, @toDate)

		UPDATE @toko SET
			Plafon = dbo.fnCekPlafon_1(@kodeToko, @fromDate),
			Nota1 = @nota1,
			Nota2 = @nota2,
			Giro1 = @giro1,
			Giro2 = @giro2,
			GiroTolak1 = @giroTolak1,
			GiroTolak2 = @giroTolak2,
			BelumJT1 = @belumJT1,
			BelumJT2 = @belumJT2,
			Rata2Bayar = @rata2Bayar
		WHERE CURRENT OF TokoCurs

		FETCH NEXT FROM TokoCurs
		INTO @kodeToko
	END

	CLOSE TokoCurs
	DEALLOCATE TokoCurs

    -- Insert statements for procedure here	

	SELECT
		t.KodeToko,
		t.NamaToko,
		t.WilID,
		t.HariSales,
		t.Plafon,
		t.Nota1,
		t.Nota2,
		t.Giro1,
		t.Giro2,
		t.GiroTolak1,
		t.GiroTolak2,
		t.BelumJT1,
		t.BelumJT2,
		(SELECT ISNULL(SUM(dbo.fnHitungNet3Disc((b.QtyDO * b.HrgJual), b.Disc1, b.Disc2, b.Disc3, b.DiscFormula) 
			- (b.QtyDO * b.Pot)), 0) FROM dbo.OrderPenjualan a 
			LEFT OUTER JOIN dbo.OrderPenjualanDetail b ON a.RowID = b.HeaderID
			WHERE (a.TglDO BETWEEN @fromDate AND @toDate) AND a.KodeToko = t.KodeToko) AS RpNet, -- TotalDO yang diajukan
		(SELECT ISNULL(SUM(dbo.fnHitungNet3Disc((d.QtyNota * b.HrgJual), b.Disc1, b.Disc2, b.Disc3, b.DiscFormula) 
			- (d.QtyNota * b.Pot)), 0) FROM dbo.OrderPenjualan a 
			LEFT OUTER JOIN dbo.OrderPenjualanDetail b ON a.RowID = b.HeaderID
			LEFT OUTER JOIN dbo.NotaPenjualanDetail d ON b.RowID = d.DODetailID
			WHERE (a.TglDO BETWEEN @fromDate AND @toDate) AND a.KodeToko = t.KodeToko) AS RpNet3, -- TotalDO yang diACC
		(SELECT ISNULL(SUM(dbo.fnHitungNet3Disc((d.QtySuratJalan * b.HrgJual), b.Disc1, b.Disc2, b.Disc3, b.DiscFormula) 
			- (d.QtySuratJalan * b.Pot)), 0) FROM dbo.OrderPenjualanDetail b 
			LEFT OUTER JOIN dbo.OrderPenjualan a ON a.RowID = b.HeaderID
			LEFT OUTER JOIN dbo.NotaPenjualan c ON a.RowID = c.DOID
			LEFT OUTER JOIN dbo.NotaPenjualanDetail d ON b.RowID = d.DODetailID
			WHERE (a.TglDO BETWEEN @fromDate AND @toDate) AND a.KodeToko = t.KodeToko
			AND c.NoSuratJalan NOT LIKE '%BATAL%') AS RpNet2, -- Total Nota
		(t.Rata2Bayar / 3) AS Rata2Bayar
	FROM @toko t 
	ORDER By t.NamaToko ASC
				
END

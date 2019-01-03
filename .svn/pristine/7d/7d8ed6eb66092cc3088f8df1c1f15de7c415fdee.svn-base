USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Laporan_Toko_RegisterPenjualanTunai]    Script Date: 04/29/2011 10:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==============================================================
-- Author		: Stephanie
-- Create date	: 28 Apr 2011
-- Description	: Laporan > Toko > Register Penjualan Tunai
-- Example		: [dbo].[rsp_Laporan_Toko_RegisterPenjualanTunai] 
--					'2004/04/01', '2004/04/05'
-- ==============================================================
CREATE PROCEDURE [dbo].[rsp_Laporan_Toko_RegisterPenjualanTunai] 
	-- Add the parameters for the stored procedure here
	 @fromDate datetime,
	 @toDate datetime

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
		nh.TransactionType,
		t.WilID,
		doh.KodeSales,
		nh.NoSuratJalan,
		nh.TglSuratJalan,
		DATEADD(DAY, doh.HariKirim ,nh.TglSuratJalan) AS TglJatuhTempo,
		jml.JmlHrg AS JmlHrg

	FROM dbo.NotaPenjualan nh
		LEFT OUTER JOIN dbo.OrderPenjualan doh ON nh.DOID = doh.RowID
		LEFT OUTER JOIN dbo.Toko t ON doh.KodeToko = t.KodeToko
		OUTER APPLY
		(
			SELECT
				SUM(dbo.fnHitungNet3Disc(do.HrgJual, do.Disc1, do.Disc2, do.Disc3, do.DiscFormula)
					* n.QtySuratJalan) AS JmlHrg
			FROM dbo.NotaPenjualanDetail n
				LEFT OUTER JOIN dbo.OrderPenjualanDetail do ON n.DODetailID = do.RowID
			WHERE n.HeaderID = nh.RowID
		) jml
	
	WHERE
		(nh.TglSuratJalan BETWEEN @fromDate AND @toDate)
		AND
		doh.Cabang1 = @initCab
		AND
		nh.NPrint >= 2
		AND 
		LEFT(nh.TransactionType, 1) = 'T' 
	
	ORDER BY t.NamaToko ASC

END
USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Laporan_Toko_NotaBelumAdaSJ]    Script Date: 04/29/2011 15:33:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- Author		: Stephanie
-- Create date	: 29 Apr 2011
-- Description	: Laporan > Toko > Nota Belum dibikinkan SJ
-- Example		: [dbo].[rsp_Laporan_Toko_NotaBelumAdaSJ] 
--					'2004/04/01', '2004/04/10'
-- ============================================================
CREATE PROCEDURE [dbo].[rsp_Laporan_Toko_NotaBelumAdaSJ] 
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
		n.NoSuratJalan,
		n.TglSuratJalan,
		do.NoDO,
		do.TglDO,
		t.NamaToko,
		do.AlamatKirim AS Alamat,
		do.Kota,
		t.WilID

	FROM dbo.NotaPenjualan n
		INNER JOIN dbo.OrderPenjualan do ON n.DOID = do.RowID
		LEFT OUTER JOIN dbo.Toko t ON do.KodeToko = t.KodeToko
		
	WHERE
		(n.TglSuratJalan BETWEEN @fromDate AND @toDate)
		AND
		n.TglExpedisi IS NULL

	ORDER BY n.TglSuratJalan, n.NoSuratJalan ASC
	
END
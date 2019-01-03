USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Laporan_Toko_NotaSudahAdaSJ]    Script Date: 04/29/2011 15:33:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- Author		: Stephanie
-- Create date	: 29 Apr 2011
-- Description	: Laporan > Toko > Nota Sudah dibikinkan SJ
-- Example		: [dbo].[rsp_Laporan_Toko_NotaSudahAdaSJ] 
--					'2004/04/01', '2004/04/05'
-- ============================================================
CREATE PROCEDURE [dbo].[rsp_Laporan_Toko_NotaSudahAdaSJ] 
	-- Add the parameters for the stored procedure here
	 @fromDate datetime,
	 @toDate datetime

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

	DECLARE @initPrs varchar(3)
	SELECT TOP 1
		@initPrs = InitPerusahaan
	FROM dbo.Perusahaan		

	SELECT 
		n.NoNota,
		n.TglNota,
		do.NoDO,
		do.TglDO,
		t.NamaToko,
		do.AlamatKirim AS Alamat,
		do.Kota,
		t.WilID,
		rh.NoSuratJalan,
		rh.TglSuratJalan,
		rh.TglKeluar

	FROM dbo.NotaPenjualan n
		INNER JOIN dbo.OrderPenjualan do ON n.DOID = do.RowID
		LEFT OUTER JOIN dbo.Toko t ON do.KodeToko = t.KodeToko
		LEFT OUTER JOIN dbo.RekapKoliDetail rd ON n.RowID = rd.NotaJualID
		LEFT OUTER JOIN dbo.Rekapkoli rh ON rd.HeaderID = rh.RowID
		
	WHERE
		(n.TglSuratJalan BETWEEN @fromDate AND @toDate)
		AND
		n.TglExpedisi IS NOT NULL 
		AND
		LEFT(n.RecordID, 3) = @initPrs

	ORDER BY n.TglSuratJalan, n.NoSuratJalan ASC
	
END
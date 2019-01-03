USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Laporan_Toko_JWJS]    Script Date: 04/29/2011 10:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- Author		: Stephanie
-- Create date	: 27 Apr 2011
-- Description	: Laporan > Toko > JW / JS
-- Example		: [dbo].[rsp_Laporan_Toko_JWJS]   
--					'2004/04/01', '2004/04/10', 'KA', '09'
-- ============================================================
CREATE PROCEDURE [dbo].[rsp_Laporan_Toko_JWJS] 
	-- Add the parameters for the stored procedure here
	 @fromDate datetime,
	 @toDate datetime,
	 @transactionType varchar(2),
	 @cabang varchar(2) 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	
	SELECT
		v.NoSuratJalan,
		v.TglSuratJalan,
		t.NamaToko,
		v.TransactionType,
		v.HariKredit,
		v.HariSales,
		s.NamaStok AS NamaBarang,
		v.QtyNota,
		v.HrgJual
	FROM dbo.vwNotaPenjualanDetail v
		LEFT OUTER JOIN dbo.Toko t ON v.KodeToko = t.KodeToko 
		LEFT OUTER JOIN dbo.Stok s ON v.BarangID = s.BarangID

	WHERE
		(v.TglSuratJalan BETWEEN @fromDate AND @toDate)
		AND
		v.Cabang1 = @cabang
		AND
		v.TransactionType = @transactionType

	ORDER BY v.NoSuratJalan ASC
	
END 
USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Pembelian_BrgBlmTerpenuhiDari11]    Script Date: 04/20/2011 06:42:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =====================================================================
-- Author:		Stephanie
-- Create date: 19 Apr 2011
-- Description:	Pembelian > Laporan > Pembelian > Barang Belum Terpenuhi
-- Example : exec [rsp_Pembelian_BrgBlmTerpenuhiDari11] 
--			 @fromDate = '2010/04/01', @toDate = '2010/04/10'
-- =====================================================================
CREATE PROCEDURE [dbo].[rsp_Pembelian_BrgBlmTerpenuhiDari11] 
	-- Add the parameters for the stored procedure here
	 @fromDate datetime,
	 @toDate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
		
    -- Insert statements for procedure here	

		SELECT 
			doD.KodeGudang,
			doH.NoRequest,
			doH.TglRequest,
			s.NamaStok AS NamaBarang,
			doD.BarangID,
			doD.QtyBO,
			doD.QtyTambahan,
			(doD.QtyBO + doD.QtyTambahan) AS QtyRequest,
			(CASE WHEN nota.RowID IS NULL THEN '' ELSE nota.NoNota END) AS NoNota,
			(CASE WHEN nota.RowID IS NULL THEN NULL ELSE nota.TglNota END) AS TglNota,
			(CASE WHEN nota.RowID IS NULL THEN NULL ELSE nota.TglTerima END) AS TglTerima,
			(CASE WHEN nota.RowID IS NULL THEN 0 ELSE nota.QtyNota END) AS QtyNota,
			(CASE WHEN nota.RowID IS NULL THEN 0 ELSE notaSUM.QtySuratJalan END) AS QtySuratJalan,
			((doD.QtyBO + doD.QtyTambahan)- ISNULL(notaSUM.QtySuratJalan, 0)) AS QtyKurangKirim,
			ISNULL(nota.HrgBeli, 0) AS HrgBeli,		
			ISNULL(((doD.QtyBO + doD.QtyTambahan) - ISNULL(notaSUM.QtySuratJalan, 0)) * nota.HrgBeli, 0) AS JmlHrg,	
			doD.QtyJual,
			(CASE WHEN nota.RowID IS NULL THEN 0 ELSE doD.QtyAkhir END) AS QtyAkhir

		FROM dbo.OrderPembelian doH
			INNER JOIN dbo.OrderPembelianDetail doD ON doH.RowID = doD.HeaderID
			INNER JOIN dbo.Stok s ON doD.BarangID = s.BarangID
			OUTER APPLY
			(
				SELECT
					nH.RowID,
					nH.NoNota,
					nH.TglNota,
					nH.TglTerima,
					nd.KodeGudang,
					nd.BarangID,
					dbo.fnGetHargaBeli (nd.BarangID, nH.TglNota, NULL) AS HrgBeli,
					nD.QtyNota
				FROM dbo.NotaPembelian nH
				LEFT OUTER JOIN dbo.NotaPembelianDetail nD ON nH.RowID = nD.HeaderID
				
				WHERE
					doH.NoRequest = nh.NoRequest
					AND doD.KodeGudang = nD.KodeGudang
					AND doD.BarangID = nD.BarangID
			) nota

			OUTER APPLY
			(
				SELECT					
					SUM(nD.QtySuratJalan) AS QtySuratJalan
				FROM dbo.NotaPembelian nH
				LEFT OUTER JOIN dbo.NotaPembelianDetail nD ON nH.RowID = nD.HeaderID
				
				WHERE
					doH.NoRequest = nh.NoRequest
					AND doD.KodeGudang = nD.KodeGudang
					AND doD.BarangID = nD.BarangID
			) notaSUM
				
		WHERE 
			doH.TglRequest BETWEEN @fromDate AND @toDate
			AND ((doD.QtyBO + doD.QtyTambahan)> ISNULL(notaSUM.QtySuratJalan, 0))

		ORDER BY doH.TglRequest, doH.NoRequest, doD.KodeGudang, s.NamaStok, nota.NoNota ASC	
							
END

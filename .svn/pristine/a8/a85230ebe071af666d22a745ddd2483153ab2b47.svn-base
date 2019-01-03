USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Pembelian_RekapPembelian]    Script Date: 04/20/2011 13:47:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =================================================================
-- Author:		Stephanie
-- Create date: 19 Apr 2011
-- Description:	Pembelian > Laporan > Pembelian > Rekap Pembelian
-- =================================================================
CREATE PROCEDURE [dbo].[rsp_Pembelian_RekapPembelian] 
	-- Add the parameters for the stored procedure here
	 @fromDate datetime,
	 @toDate datetime,
	 @tipeTgl varchar(2), -- 'SJ' = TglSuratJalan OR 'TR' = TglTerima
	 @tipeHPP varchar(10) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
		
    -- Insert statements for procedure here
	
	SELECT
		h.TglTerima,
		h.TglSuratJalan,
		h.NoSuratJalan,
		h.Pemasok,
		detailSUM.NilaiNota,
		detailSUM.NilaiHPP,
		(CASE WHEN flag.Flag > 0 AND detailSUM.NilaiNota > 0 THEN '!' ELSE '' END) AS Flag,
		(detailSUM.NilaiHPP - detailSUM.NilaiNota) AS Selisih
	FROM dbo.NotaPembelian h

		OUTER APPLY
		(
			SELECT 
				SUM( (CASE WHEN ISNULL(b.QtySuratJalan, 0) = 0 THEN 1 ELSE 0 END) ) AS Flag
			FROM dbo.NotaPembelian a
				LEFT OUTER JOIN dbo.NotaPembelianDetail b ON a.RowID = b.HeaderID
			WHERE
				h.RowID = a.RowID
		) flag

		OUTER APPLY
		(
			SELECT
				ISNULL(SUM(b.QtyNota * dbo.fnGetHargaBeli (b.BarangID, a.TglNota, NULL)), 0) AS NilaiNota,
				ISNULL(SUM(b.QtySuratJalan * dbo.fnGetHargaBeli (b.BarangID, a.TglNota, @tipeHPP)), 0) AS NilaiHPP						
			FROM dbo.NotaPembelian a
				LEFT OUTER JOIN dbo.NotaPembelianDetail b ON a.RowID = b.HeaderID
			WHERE 
				a.RowID = h.RowID
			GROUP BY a.RowID
		) detailSUM

	WHERE
		( @tipeTgl = 'SJ'	AND	(h.TglSuratJalan BETWEEN @fromDate AND @toDate) )
		OR
		( @tipeTgl = 'TR'	AND	(h.TglTerima BETWEEN @fromDate AND @toDate) )

	
				
END
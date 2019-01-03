 USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Pembelian_PembelianPerBarang]    Script Date: 04/21/2011 16:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===================================================================
-- Author:		Stephanie
-- Create date: 21 Apr 2011
-- Description:	Pembelian > Laporan > Pembelian > Pembelian Per Barang
-- ===================================================================
CREATE PROCEDURE [dbo].[rsp_Pembelian_PembelianPerBarang] 
	-- Add the parameters for the stored procedure here
	 @fromDate datetime,
	 @toDate datetime,
	 @kodeGudang varchar(4) = NULL,
	 @tipeHPP varchar(10) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
		
    -- Insert statements for procedure here
	
	SELECT
		h.Pemasok,
		h.TglTerima,
		h.TglNota,	
		h.NoNota,
		s.NamaStok AS NamaBarang,
		d.QtyNota,
		d.QtySuratJalan,
		dbo.fnGetHargaBeli(d.BarangID, h.TglNota, NULL) AS HrgBeli,
		dbo.fnGetHargaBeli(d.BarangID, h.TglNota, @tipeHPP) AS HPP,
		(d.QtyNota * dbo.fnGetHargaBeli(d.BarangID, h.TglNota, NULL)) AS JmlHrg,		
		(d.QtySuratJalan * dbo.fnGetHargaBeli(d.BarangID, h.TglNota, @tipeHPP)) AS JmlHPP
	FROM dbo.NotaPembelian h
		INNER JOIN dbo.NotaPembelianDetail d ON h.RowID = d.HeaderID
		INNER JOIn dbo.Stok s ON d.BarangID = s.BarangID
	
	WHERE
		h.TglTerima BETWEEN @fromDate AND @toDate
		AND
		(d.KodeGudang = @kodeGudang OR @kodeGudang IS NULL) 
		AND
		LEFT(d.BarangID, 3) != 'FXB'

	ORDER BY h.TglTerima, h.NoNota
				
END


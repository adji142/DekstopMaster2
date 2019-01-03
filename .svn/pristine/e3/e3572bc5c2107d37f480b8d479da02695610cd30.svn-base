USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_CetakPackingList]    Script Date: 03/23/2011 11:54:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =======================================================================
-- Author:		Gemma 
--				(Updated by Stephanie)
-- Create date: 14 Mar 2011
-- Description:	Ekspedisi > Transaksi > Packing List > Cetak Packing List
-- =======================================================================
ALTER PROCEDURE [dbo].[rsp_CetakPackingList] 
	-- Add the parameters for the stored procedure here
	@kodeToko varchar(19),
	@expedisi varchar(3),
	@date datetime,
	@bayar varchar(1),
	@shift varchar(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    -- Insert statements for procedure here

	SELECT
		a.TglSuratJalan,
		a.NoSuratJalan,
		e.NamaStok AS NamaBarang,
		b.QtySuratJalan,
		e.SatSolo AS Satuan,
		b.QtyKoli AS JmlKoli,
		b.NoKoli,
		b.KetKoli,
		f.NamaToko,
		a.AlamatKirim AS Alamat,
		a.Kota,
		c.Expedisi
	FROM dbo.NotaPenjualan a 
		LEFT OUTER JOIN dbo.NotaPenjualanDetail b ON b.HeaderID = a.RowID 
		LEFT OUTER JOIN dbo.OrderPenjualan c ON a.DOID = c.RowID
		LEFT OUTER JOIN dbo.OrderPenjualanDetail d ON d.HeaderID=c.RowID
		LEFT OUTER JOIN dbo.Stok e ON e.BarangID = d.BarangID	
		LEFT OUTER JOIN dbo.Toko f ON c.KodeToko = f.KodeToko	
	WHERE 
		RTRIM(c.KodeToko) = @kodeToko
		AND c.Expedisi = @expedisi
		AND a.TglSuratJalan = @date
		AND RTRIM(a.HtrID) NOT LIKE '%!'
		AND ( (CASE WHEN (c.HariKredit + c.HariKirim + c.HariSales) > 0 THEN 'K' ELSE 'T' END) = @bayar )
		AND c.Shift = @shift
		AND ISNULL(b.Nokoli, '') <> ''
		AND b.QtySuratJalan > 0

	
	/* Update table setelah cetak */
	UPDATE ISAdb.dbo.NotaPenjualanDetail
	SET NPackingListPrint = 1
	FROM dbo.NotaPenjualan a 
		LEFT OUTER JOIN dbo.NotaPenjualanDetail b ON b.HeaderID = a.RowID 
		LEFT OUTER JOIN dbo.OrderPenjualan c ON a.DOID = c.RowID
	WHERE 
		RTRIM(c.KodeToko) = @kodeToko
		AND c.Expedisi = @expedisi
		AND a.TglSuratJalan = @date
		AND RTRIM(a.HtrID) NOT LIKE '%!'
		AND ( (CASE WHEN (c.HariKredit + c.HariKirim + c.HariSales) > 0 THEN 'K' ELSE 'T' END) = @bayar )
		AND c.Shift = @shift
		AND ISNULL(b.Nokoli, '') <> ''
		AND b.QtySuratJalan > 0	

END
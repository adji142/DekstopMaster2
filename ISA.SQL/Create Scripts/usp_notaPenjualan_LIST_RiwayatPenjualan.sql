USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_NotaPenjualan_LIST_RiwayatJual]    Script Date: 03/31/2011 15:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ======================================================
-- Author:		Stephanie
-- Create date: 31 Mar 11
-- Description:	List data on table NotaPenjualan
--				Untuk menampilkan Riwayat Jual per Barang
-- ======================================================
CREATE PROCEDURE [dbo].[usp_NotaPenjualan_LIST_RiwayatJual] 
	-- Add the parameters for the stored procedure here
	@barangID varchar(23) = NULL,
	@fromDate datetime = NULL,
	@toDate datetime = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED ;

    -- Insert statements for procedure here

SELECT 
		b.Cabang1,
		a.RowID,
		b.NoRequest,
		b.TglRequest,
		a.NoSuratJalan,
		a.TglSuratJalan,
		a.TglTerima,
		b.KodeSales,
		c.NamaToko,
		c.Kota,
		c.Alamat,		
		ISNULL( (SELECT SUM(e.QtyDO * e.HrgJual) FROM dbo.OrderPenjualanDetail e WHERE b.RowID = e.HeaderID) , 0 )
			AS RpJual,
		ISNULL((SELECT SUM(
			ISNULL(dbo.fnHitungNet3Disc((e.QtyDO * e.HrgJual), e.Disc1, e.Disc2, e.Disc3, e.DiscFormula), 0) 
			- (e.QtyDO * e.Pot)) FROM dbo.OrderPenjualanDetail e WHERE b.RowID = e.HeaderID), 0)
			AS  RpNet -- Perhitungan nilai jual untuk DO menggunakan QtyDO	
		
	FROM dbo.NotaPenjualan a 
		LEFT OUTER JOIN dbo.OrderPenjualan b ON a.DOID = b.RowID
		LEFT OUTER JOIN dbo.Toko c ON c.KodeToko = b.KodeToko 

	WHERE
		((a.TglSuratJalan >= @fromDate OR @fromDate IS NULL)
		AND (a.TglSuratJalan <= @toDate OR @toDate IS NULL))
		AND ((@barangID IS NULL)
			OR (a.RowID IN (SELECT v.HeaderID FROM dbo.vwNotaPenjualanDetail v WHERE v.BarangID = @barangID)))
	ORDER BY
		c.NamaToko
END






 
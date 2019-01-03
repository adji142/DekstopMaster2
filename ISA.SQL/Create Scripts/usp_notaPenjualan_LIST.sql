USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_NotaPenjualan_LIST]') IS NOT NULL
DROP PROC [dbo].[usp_NotaPenjualan_LIST] 
GO

/****** Object:  StoredProcedure [dbo].[usp_NotaPenjualan_LIST]    Script Date: 03/03/2011 09:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==============================================
-- Author:		Stephanie
-- Create date: 19 Jan 11
-- Description:	List data on table NotaPenjualan
-- ==============================================
ALTER PROCEDURE [dbo].[usp_NotaPenjualan_LIST] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier = NULL,
	@doID uniqueidentifier = NULL,
	@barangID varchar(23) = NULL,
	@kodeToko varchar(19) = NULL,
	@fromDate datetime = NULL,
	@toDate datetime = NULL,

	/* Params. untuk pengecekan apakah nota sudah PJ3 atau Ditolak */
	@cekPJ3 varchar(1) = NULL,
	@cekTolak varchar(1) = NULL,
	@cekBatal varchar(1) = NULL
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

SELECT 
		a.RowID, 
		a.HtrID, 
		a.RecordID,
		a.DOID,
		b.NoRequest,
		b.TglRequest,
		b.NoDO,
		b.TglDO,
		a.NoNota, 
		a.TglNota, 
		a.NoSuratJalan, 
		a.TglSuratJalan, 
		a.TglTerima, 
		dbo.fnHitTglJatuhTempo(a.TransactionType, a.TglTerima, b.HariKredit, 
			b.HariKirim, b.HariSales) AS TglJatuhTempo,
		a.TransactionType,
		a.Checker1, 
		a.Checker2,
		b.KodeToko,
		a.AlamatKirim, 
		a.Kota,	
		c.WilID,
		a.isClosed, 
		a.Catatan1 AS Cat1, 
		a.Catatan2 AS Cat2, 
		a.Catatan3 AS Cat3, 
		a.Catatan4 AS Cat4, 
		a.Catatan5 AS Cat5, 
		a.SyncFlag, 
		a.LinkID, 
		a.NPrint, 
		a.LastUpdatedBy, 
		a.LastUpdatedTime,
		b.NoDO,
		b.TglDO,	
		b.NoRequest,
		b.TglRequest,
		b.Disc1,
		b.Disc2,
		b.Disc3,
		b.DiscFormula,
		b.HariKredit,
		b.HariKirim,
		b.HariSales,
		b.Catatan1,
		b.Catatan2,
		b.Catatan3,
		b.Catatan4,
		b.StatusBatal,
		b.RowID,
		b.Cabang1,
		b.Cabang2,
		b.Expedisi,
		b.KodeSales,
		d.NamaSales,
		c.NamaToko, 
		c.KodeToko,
		/* Jumlah HrgJual, JumlahNetto dan JumlahPotongan untuk NotaPenjualan */
		ISNULL((SELECT SUM(v.QtySuratJalan * v.HrgJual) FROM dbo.vwNotaPenjualanDetail v WHERE v.HeaderID = a.RowID ), 0)
			AS RpJual2,
		ISNULL((SELECT SUM( dbo.fnHitungNet3Disc((v.QtySuratJalan * v.HrgJual), v.Disc1, v.Disc2, v.Disc3, v.DiscFormula) 
			- (v.QtySuratJalan * v.Pot)) FROM dbo.vwNotaPenjualanDetail v WHERE v.HeaderID = a.RowID), 0) 
			AS RpNet2,
		(SELECT SUM(v.Pot * v.QtySuratJalan) FROM dbo.vwNotaPenjualanDetail v WHERE v.HeaderID = a.RowID) AS RpPot2,
		/* Jumlah HrgJual, JumlahNetto dan JumlahPotongan untuk PJ3 */
		ISNULL((SELECT SUM(v.QtyNota * v.HrgJual) FROM dbo.vwNotaPenjualanDetail v WHERE v.HeaderID = a.RowID ), 0)
			AS RpJual3,
		ISNULL((SELECT SUM( dbo.fnHitungNet3Disc((v.QtyNota * v.HrgJual), v.Disc1, v.Disc2, v.Disc3, v.DiscFormula) 
			- (v.QtyNota * v.Pot)) FROM dbo.vwNotaPenjualanDetail v WHERE v.HeaderID = a.RowID), 0) 
			AS RpNet3,
		(SELECT SUM(v.Pot * v.QtyNota) FROM dbo.vwNotaPenjualanDetail v WHERE v.HeaderID = a.RowID) AS RpPot3
		
	FROM dbo.NotaPenjualan a 
		LEFT OUTER JOIN dbo.OrderPenjualan b ON a.DOID = b.RowID
		LEFT OUTER JOIN dbo.Toko c ON c.KodeToko = b.KodeToko 
		LEFT OUTER JOIN dbo.Sales d ON d.SalesID = b.KodeSales 

	WHERE
		(a.RowID = @rowID OR @rowID IS NULL)
		AND (a.DOID = @doID or @doID IS NULL)
		AND (a.TglNota >= @fromDate OR @fromDate IS NULL)
		AND (a.TglNota <= @toDate OR @toDate IS NULL)
		AND ((@barangID IS NULL)
			OR (a.RowID IN (SELECT HeaderID FROM dbo.vwNotaPenjualanDetail WHERE BarangID = @barangID)))
		AND (b.KodeToko = @kodeToko OR @kodeToko IS NULL)	
		AND (@cekPJ3 IS NULL OR (CASE WHEN a.TglNota IS NOT NULL THEN 'T' ELSE 'F' END) = @cekPJ3)
		AND (@cekTolak IS NULL OR (CASE WHEN a.NoNota LIKE '%T%' THEN 'T' ELSE 'F' END) = @cekTolak)
		AND (@cekBatal IS NULL OR (CASE WHEN a.NoSuratJalan LIKE '%BATAL%' THEN 'T' ELSE 'F' END) = @cekBatal)
END


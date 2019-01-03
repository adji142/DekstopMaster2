USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_HistoryPenjualan_LIST]    Script Date: 03/07/2011 12:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==================================================================
-- Author:		Stephanie
-- Create date: 07 Mar 11
-- Description:	List History Penjualan 
-- ==================================================================
ALTER PROCEDURE [dbo].[usp_HistoryPenjualan_LIST] 
	-- Add the parameters for the stored procedure here
	@kodeToko varchar(19) = NULL,
	@barangID varchar(23) = NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
		
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT
		a.RowID,
		b.RowID,
		a.Cabang1,
		a.Cabang2,
		dbo.fnGetStatusToko(a.TglDO, a.KodeToko, a.Cabang1) AS StsToko,
		c.NoSuratJalan,
		c.TglSuratJalan,
		f.NamaSales,
		d.QtySuratJalan,
		ISNULL(b.HrgJual, 0) AS HrgJual,
		e.NamaStok AS NamaBarang,
		g.NamaToko,
		g.Alamat			
	FROM dbo.OrderPenjualan a
		LEFT OUTER JOIN dbo.OrderPenjualanDetail b ON a.RowID = b.HeaderID
		LEFT OUTER JOIN dbo.NotaPenjualan c ON a.RowID = c.DOID
		LEFT OUTER JOIN dbo.NotaPenjualanDetail d ON b.RowID = d.DoDetailID
		LEFT OUTER JOIN dbo.Stok e ON b.BarangID = e.BarangID	
		LEFT OUTER JOIN dbo.Sales f ON a.KodeSales = f.SalesID
		LEFT OUTER JOIN dbo.Toko g ON a.KodeToko = g.KodeToko

	WHERE
		(a.KodeToko = @kodeToko OR @kodeToko IS NULL)
		AND
		(b.BarangID = @barangID OR @barangID IS NULL)
		AND
		d.RowID IS NOT NULL
		
	ORDER BY c.TglNota DESC

	
END









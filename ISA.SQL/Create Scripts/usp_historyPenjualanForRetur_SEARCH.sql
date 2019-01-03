USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_HistoryPenjualanForRetur_SEARCH]') IS NOT NULL
DROP PROC [dbo].[usp_HistoryPenjualanForRetur_SEARCH] 
GO

/****** Object:  StoredProcedure [dbo].[usp_HistoryPenjualanForRetur_SEARCH]    Script Date: 05/06/2011 13:03:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==================================================================
-- Author:		Stephanie
-- Create date: 10 Feb 11
-- Description:	List History Penjualan Barang For Retur Murni
-- ==================================================================
CREATE PROCEDURE [dbo].[usp_HistoryPenjualanForRetur_SEARCH] 
	-- Add the parameters for the stored procedure here
	@kodeToko varchar(19),
	@barangID varchar(23),
	@cabang1 varchar(2), -- Di supply dari Retur Penjualan Header
	@tglMemo datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
		
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    -- Insert statements for procedure here

	SELECT
		c.RowID AS NotaJID,
		d.RowID AS NotaJualDetailID,
		c.RecordID AS NotaJualRecID,
		d.RecordID As NotaJualDetailRecID,
		c.TglTerima,
		c.NoNota,
		c.TglTerima AS TglNota,
		a.KodeSales,
		h.NamaSales,
		a.Expedisi,
		@barangID,
		f.NamaStok,
		(CASE WHEN e.RecordID IS NULL THEN d.QtyNota ELSE e.QtyNotaBaru END) AS QtyNota,	
		(CASE WHEN e.RecordID IS NULL THEN b.HrgJual ELSE e.HrgJualBaru END) As HrgJual,	
		/* Sum QtyGudang from all ReturPenjualanDetail under the same NotaPenjualanDetail */
		r.QtyRetur AS QtyRetur,
		f.SatSolo AS Satuan,
		b.Disc1,
		b.Disc2,
		b.Disc3,
		b.DiscFormula,
		b.Pot,
		dbo.fnGetHPPA(@barangID, a.TglDO) AS HPPA, --- HargaPokok 
		e.RecordID AS KoreksiID,
		a.Cabang1,
		a.Cabang2
			
	FROM dbo.OrderPenjualan a
	LEFT OUTER JOIN dbo.OrderPenjualanDetail b ON a.RowID = b.HeaderID
	LEFT OUTER JOIN dbo.NotaPenjualan c ON a.RowID = c.DOID
	LEFT OUTER JOIN dbo.NotaPenjualanDetail d ON b.RowID =  d.DODetailID
	LEFT OUTER JOIN dbo.KoreksiPenjualan e ON d.RowID = e.NotaJualDetailID
	LEFT OUTER JOIN dbo.Stok f ON f.BarangID = @barangID
	LEFT OUTER JOIN dbo.Sales h ON a.KodeSales = h.SalesID
	OUTER APPLY
	(
		SELECT
			ISNULL(SUM(g.QtyGudang), 0) AS QtyRetur
		FROM dbo.ReturPenjualanDetail g 
		WHERE g.NotaJualDetailID = d.RowID
	)r
		
	WHERE	
		/* Cari yang tokonya sama */
		(a.KodeToko = @kodeToko)

		/* Cari yang cabang1 dari retur header sama dengan cabang1 dari order penjualan header */
		AND (@cabang1 = a.Cabang1)
		
		/* Cari yang barangnya sama */
		AND (b.BarangID = @barangID)

		/* Cari yang sudah di terima sebelum pembuatan memo retur */
		AND (c.TglTerima <= @tglMemo)

		/* Cari yang masih dalam garansi 1 tahun */
		AND (c.TglTerima >= DATEADD(DAY, -((DATEPART(DAY, @tglMemo))), DATEADD(YEAR ,-1, @tglMemo)))

		/* Cari yang quantity notanya belum habis di retur */
		AND ((CASE WHEN e.RecordID IS NULL THEN d.QtyNota ELSE e.QtyNotaBaru END) > r.QtyRetur)

		/* Cari nota tanpa koreksi atau bila ada koreksi,
		   gunakan koreksi terbaru */
		AND 
		(
			e.RowID IS NULL
				OR
			e.RowID = dbo.fnGetKoreksiID(d.RowID, 'NPJ', NULL)
		)

	ORDER BY a.HtrID DESC

	
END
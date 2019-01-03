USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_KoreksiReturPenjualan_LIST]    Script Date: 03/30/2011 14:49:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =====================================================
-- Author:		Stephanie
-- Create date: 30 Mar 11
-- Description:	List data on table KoreksiReturPenjualan
-- =====================================================
CREATE PROCEDURE [dbo].[usp_KoreksiReturPenjualan_LIST] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier = NULL,
	@returJualDetailID uniqueidentifier = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    -- Insert statements for procedure here

	SELECT 
		a.RowID, 
		a.RecordID, 
		a.ReturJualDetailID, 
		a.ReturJualDetailRecID, 
		a.TglKoreksi, 
		a.NoKoreksi, 
		a.QtyNotaBaru, 
		a.HrgJualBaru, 
		a.Catatan, 
		a.KodeToko, 
		a.Sumber, 
		a.LinkID, 
		a.HrgJualKoreksi, 
		a.QtyNotaKoreksi, 
		a.SyncFlag, 
		a.LastUpdatedBy, 
		a.LastUpdatedTime,
		d.Pot,
		d.Disc1,
		d.Disc2,
		d.Disc3,
		d.BarangID,
		e.NamaStok AS NamaBarang,
		e.SatSolo AS Satuan
	FROM dbo.KoreksiReturPenjualan a 
		LEFT OUTER JOIN dbo.ReturPenjualanDetail b ON a.ReturJualDetailID = b.RowID
		LEFT OUTER JOIN dbo.NotaPenjualanDetail c ON b.NotaJualDetailID = c.RowID
		LEFT OUTER JOIN dbo.OrderPenjualanDetail d ON c.DODetailID = d.RowID
		LEFT OUTER JOIN dbo.Stok e ON d.BarangID = e.BarangID
	WHERE
		(a.RowID = @rowID OR @rowID IS NULL)
		AND (a.ReturJualDetailID = @returJualDetailID OR @returJualDetailID IS NULL)
		AND b.RowID IS NOT NULL

	UNION ALL

	SELECT 
		a.RowID, 
		a.RecordID, 
		a.ReturJualDetailID, 
		a.ReturJualDetailRecID, 
		a.TglKoreksi, 
		a.NoKoreksi, 
		a.QtyNotaBaru, 
		a.HrgJualBaru, 
		a.Catatan, 
		a.KodeToko, 
		a.Sumber, 
		a.LinkID, 
		a.HrgJualKoreksi, 
		a.QtyNotaKoreksi, 
		a.SyncFlag, 
		a.LastUpdatedBy, 
		a.LastUpdatedTime,
		b.Pot,
		0 AS Disc1,
		0 AS Disc2,
		0 AS Disc3,
		b.BarangID,
		c.NamaStok AS NamaBarang,
		c.SatSolo AS Satuan
	FROM dbo.KoreksiReturPenjualan a 
		LEFT OUTER JOIN dbo.ReturPenjualanTarikanDetail b ON a.ReturJualDetailID = b.RowID
		LEFT OUTER JOIN dbo.Stok c ON b.BarangID = c.BarangID
	WHERE
		(a.RowID = @rowID OR @rowID IS NULL)
		AND (a.ReturJualDetailID = @returJualDetailID OR @returJualDetailID IS NULL)
		AND b.RowID IS NOT NULL
  
END








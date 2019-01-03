USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_KoreksiReturPembelian_LIST]    Script Date: 04/18/2011 11:30:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =====================================================
-- Author:		Stephanie
-- Create date: 18 Apr 11
-- Description:	List data on table KoreksiReturPembelian
-- =====================================================
CREATE PROCEDURE [dbo].[usp_KoreksiReturPembelian_LIST] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier = NULL,
	@returBeliDetailID uniqueidentifier = NULL
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
		a.ReturBeliDetailID, 
		a.returBeliDetailRecID, 
		a.TglKoreksi, 
		a.NoKoreksi, 
		a.QtyNotaBaru, 
		a.HrgBeliBaru, 
		a.Catatan, 
		a.Pemasok, 
		a.Sumber, 
		a.LinkID, 
		a.HrgBeliKoreksi, 
		a.QtyNotaKoreksi, 
		a.SyncFlag, 
		a.LastUpdatedBy, 
		a.LastUpdatedTime,
		c.Pot,
		c.Disc1,
		c.Disc2,
		c.Disc3,
		c.BarangID,
		d.NamaStok AS NamaBarang,
		d.SatSolo AS Satuan
	FROM dbo.KoreksiReturPembelian a
		LEFT OUTER JOIN dbo.ReturPembelianDetail b ON a.ReturBeliDetailID = b.RowID
		LEFT OUTER JOIN dbo.NotaPembelianDetail c ON b.NotaBeliDetailID = c.RowID
		LEFT OUTER JOIN dbo.Stok d ON c.BarangID = d.BarangID
	WHERE
		(a.RowID = @rowID OR @rowID IS NULL)
		AND (a.ReturBeliDetailID = @returBeliDetailID OR @returBeliDetailID IS NULL)
	ORDER BY d.NamaStok ASC
  
END








USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_KoreksiPembelian_LIST]    Script Date: 04/12/2011 11:18:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ================================================
-- Author:		Stephanie
-- Create date: 12 Mar 11
-- Description:	List data on table KoreksiPembelian
-- ================================================
CREATE PROCEDURE [dbo].[usp_KoreksiPembelian_LIST] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier = NULL,
	@notaBeliDetailID uniqueidentifier = NULL
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
		a.NotaBeliDetailID, 
		a.NotaBeliDetailRecID, 
		a.TglKoreksi, 
		a.NoKoreksi, 
		a.QtyNotaBaru, 
		a.HrgJualBaru, 
		a.Catatan, 
		a.Pemasok, 
		a.Sumber, 
		a.LinkID, 
		a.HrgJualKoreksi, 
		a.QtyNotaKoreksi, 
		a.SyncFlag, 
		a.LastUpdatedBy, 
		a.LastUpdatedTime,
		b.Pot,
		b.Disc1,
		b.Disc2,
		b.Disc3,
		b.BarangID,
		c.NamaStok AS NamaBarang,
		c.SatSolo AS Satuan
	FROM dbo.KoreksiPembelian a 
		LEFT OUTER JOIN dbo.NotaPembelianDetail b ON a.NotaBeliDetailID = b.RowID
		LEFT OUTER JOIN dbo.Stok c ON b.BarangID = c.BarangID
	WHERE
		(a.RowID = @rowID OR @rowID IS NULL)
		AND (a.NotaBeliDetailID = @notaBeliDetailID OR @notaBeliDetailID IS NULL)
	ORDER BY c.NamaStok ASC
  
END
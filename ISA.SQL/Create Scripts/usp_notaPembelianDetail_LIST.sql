USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_NotaPembelianDetail_LIST]    Script Date: 04/06/2011 11:18:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===================================================
-- Author:		Stephanie
-- Create date: 05 Apr 11
-- Description:	List data on table NotaPembelianDetail
-- ===================================================
CREATE PROCEDURE [dbo].[usp_NotaPembelianDetail_LIST] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier = NULL,
	@headerID uniqueidentifier = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    -- Insert statements for procedure here

	SELECT 
		a.RowID, 
		a.HeaderID, 
		a.RecordID, 
		a.HeaderRecID, 
		a.BarangID, 
		b.NamaStok AS NamaBarang,
		b.SatSolo AS Satuan,
		a.QtyRequest, 
		a.QtyDO, 
		a.QtySuratJalan, 
		a.QtyNota, 
		a.Catatan, 
		a.TglTerima, 
		dbo.fnGetHargaBeli(a.BarangID, c.TglNota, NULL) AS HrgBeli, 
		(a.QtyNota * dbo.fnGetHargaBeli(a.BarangID, c.TglNota, NULL)) AS JmlHrgBeli,
		dbo.fnHitungNet3Disc((a.QtyNota * dbo.fnGetHargaBeli(a.BarangID, c.TglNota, NULL)),
			a.Disc1, a.Disc2, a.Disc3, '') AS JmlHrgNet,
		a.HrgPokok, 
		a.HPPSolo, 
		a.Pot, 
		a.Disc1, 
		a.Disc2, 
		a.Disc3, 
		a.DiscFormula, 
		a.PPN, 
		a.KodeGudang,  
		a.SyncFlag, 
		a.LastUpdatedBy, 
		a.LastUpdatedTime,
		c.NoNota,
		c.TglNota,
		c.Pemasok
	FROM dbo.NotaPembelianDetail a 
		LEFT OUTER JOIN dbo.Stok b ON a.BarangID = b.BarangID
		LEFT OUTER JOIN dbo.NotaPembelian c ON a.HeaderID = c.RowID

	WHERE
		(a.RowID = @rowID OR @rowID IS NULL)	
		AND (a.HeaderID = @headerID OR @headerID IS NULL)

	ORDER BY b.NamaStok ASC
    
END
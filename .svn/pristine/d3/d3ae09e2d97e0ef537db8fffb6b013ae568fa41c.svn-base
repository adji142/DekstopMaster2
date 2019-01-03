USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_NotaPembelian_LIST]    Script Date: 04/06/2011 11:18:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- Author:		Stephanie
-- Create date: 05 Apr 11
-- Description:	List data on table NotaPembelian
-- ===============================================
CREATE PROCEDURE [dbo].[usp_NotaPembelian_LIST] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier = NULL,
	@fromDate datetime = NULL,
	@toDate datetime = NULL,
	@barangID varchar(23) = NULL
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
		a.NoRequest, 
		a.TglRequest, 
		a.NoDO, 
		a.TglTransaksi, 
		a.NoNota, 
		a.TglNota, 
		a.NoSuratJalan, 
		a.TglSuratJalan, 
		a.TglTerima, 
		/*Perhitungan RpNet dan RpBeli masih asumsi, belum pasti*/
		(SELECT SUM(b.QtyNota * dbo.fnGetHargaBeli(b.BarangID, c.TglNota, NULL)) FROM dbo.NotaPembelianDetail b
			LEFT OUTER JOIN dbo.NotaPembelian c ON b.HeaderID = c.RowID WHERE a.RowID = b.HeaderID) AS RpBeli,
		(SELECT SUM(b.QtyNota * dbo.fnGetHargaBeli(b.BarangID, c.TglNota, NULL)) FROM dbo.NotaPembelianDetail b
			LEFT OUTER JOIN dbo.NotaPembelian c ON b.HeaderID = c.RowID WHERE a.RowID = b.HeaderID) AS RpNet,
		/*******************************************************/
		LEFT(a.RecordID, 3) AS Gudang,
		a.Disc1, 
		a.Disc2, 
		a.Disc3, 
		a.DiscFormula, 
		a.HariKredit, 
		a.PPN, 
		a.Pemasok, 
		a.Expedisi, 
		a.Cabang, 
		a.Catatan, 
		a.isClosed, 
		a.SyncFlag, 
		a.LastUpdatedBy, 
		a.LastUpdatedTime

	FROM dbo.NotaPembelian a

	WHERE
		(a.RowID = @rowID OR @rowID IS NULL)	
		AND (a.TglNota >= @fromDate OR @fromDate IS NULL)
		AND (a.TglNota <= @toDate OR @toDate IS NULL)
		AND (@barangID IS NULL 
				OR @barangID IN (SELECT b.BarangID FROM dbo.NotaPembelianDetail b
					WHERE a.RowID = b.HeaderID))
    
END
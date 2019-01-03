USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_OrderPembelianDetail_LIST]    Script Date: 04/05/2011 17:39:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ====================================================
-- Author:		Stephanie
-- Create date: 04 Apr 11
-- Description:	List data on table OrderPembelianDetail
-- ====================================================
CREATE PROCEDURE [dbo].[usp_OrderPembelianDetail_LIST] 
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
		b.IsiKoli,
		a.QtyDO, 
		a.QtyBO, 
		a.QtyTambahan, 
		(a.QtyBO + a.QtyTambahan) AS QtyRequest,
		a.QtyJual, 
		a.QtyAkhir, 
		a.Keterangan, 
		a.KodeGudang, 
		a.Catatan, 
		a.SyncFlag, 
		a.LastUpdatedBy, 
		a.LastUpdatedTime,
		dbo.fnGetHargaBeli(a.BarangID, c.TglRequest, 'AVG')  AS HPPSolo,
		(dbo.fnGetHargaBeli(a.BarangID, c.TglRequest, 'AVG')  * a.QtyBO) AS JmlHPPDO

--		0 AS HrgJual,
--		(HrgJual * QtyBO) AS HrgPokok,
--		(HPPSolo * QtyTerima) AS JmlHPPTrm, 
--		(HrgJual * QtyTerima) AS RpJualHPP		

	FROM dbo.OrderPembelianDetail a
		LEFT OUTER JOIN dbo.Stok b ON a.BarangID = b.BarangID
		LEFT OUTER JOIN dbo.OrderPembelian c ON a.HeaderID = c.RowID

	WHERE
		(a.RowID = @rowID OR @rowID IS NULL)	
		AND
		(a.HeaderID = @headerID OR @headerID IS NULL)	

	ORDER BY b.NamaStok ASC
END












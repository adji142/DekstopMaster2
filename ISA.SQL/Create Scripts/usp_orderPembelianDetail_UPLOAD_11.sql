USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_OrderPembelianDetail_UPLOAD_11]    Script Date: 04/11/2011 17:37:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ====================================================
-- Author:		Stephanie
-- Create date: 11 Apr 11
-- Description:	List data on table OrderPembelianDetail
--				For Uploading Purchasing Order Data
-- ====================================================
CREATE PROCEDURE [dbo].[usp_OrderPembelianDetail_UPLOAD_11] 
	-- Add the parameters for the stored procedure here
	@headerID uniqueidentifier = NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    -- Insert statements for procedure here

	SELECT 
		c.TglRequest,
		c.NoRequest,
		b.NamaStok,
		a.BarangID,
		(a.QtyBO + a.QtyTambahan) AS QtyRequest,
		(SELECT TOP 1 p.InitGudang FROM dbo.Perusahaan p) AS C2,
		a.RecordID,
		a.QtyBO,
		a.QtyTambahan,
		a.QtyAkhir,
		a.QtyJual,
		c.Catatan

	FROM dbo.OrderPembelianDetail a
		LEFT OUTER JOIN dbo.Stok b ON a.BarangID = b.BarangID
		LEFT OUTER JOIN dbo.OrderPembelian c ON a.HeaderID = c.RowID

	WHERE
		a.HeaderID = @headerID 

	ORDER BY b.NamaStok ASC
END












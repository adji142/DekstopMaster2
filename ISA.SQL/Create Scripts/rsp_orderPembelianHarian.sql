USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_OrderPembelianHarian]    Script Date: 04/11/2011 14:18:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===================================================================
-- Author:		Stephanie
-- Create date: 11 April 2011
-- Description:	Pembelian > Transaksi > Order Pembelian > Order Harian
-- ===================================================================
CREATE PROCEDURE [dbo].[rsp_OrderPembelianHarian] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
		
    -- Insert statements for procedure here
	
	SELECT 
		a.Cabang1,
		a.Cabang2,
		a.NoRequest,
		a.TglRequest,
		c.NamaStok,
		c.SatSolo AS Satuan,
		b.QtyBO,
		b.QtyTambahan,
		/* OS artinya OrderSheet (dari pusat 11) */
		(CASE WHEN a.NoRequest LIKE '%OS%' THEN QtyTambahan 
			ELSE (QtyBO + QtyTambahan) END) AS QtyTotal,
		QtyAkhir,
		QtyJual
	FROM dbo.OrderPembelian a
		LEFT OUTER JOIN dbo.OrderPembelianDetail b ON a.RowID = b.HeaderID
		LEFT OUTER JOIN dbo.Stok c ON b.BarangID = c.BarangID

	WHERE
		a.RowID = @rowID
		AND b.RowID IS NOT NULL
	
	ORDER BY c.NamaStok ASC

END

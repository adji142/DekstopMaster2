USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Pembelian_ReturBeliPerBarang]    Script Date: 04/25/2011 10:52:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ====================================================
-- Author:		Stephanie
-- Create date: 25 Apr 2011
-- Description:	Pembelian > Laporan > Retur Pembelian 
--				> Retur Beli per Barang
-- ====================================================
CREATE PROCEDURE [dbo].[rsp_Pembelian_ReturBeliPerBarang] 
	-- Add the parameters for the stored procedure here
	 @fromDate datetime,
	 @toDate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
		
    -- Insert statements for procedure here
	
	SELECT		
		r.Pemasok,
		r.TglRetur,
		r.NoRetur,
		s.NamaStok AS NamaBarang,
		v.QtyGudang,
		v.HrgBeli,
		(v.QtyGudang * v.HrgBeli) AS JmlHrg,
		v.Catatan
		
	FROM dbo.ReturPembelian r
		INNER JOIN dbo.vwReturPembelianDetail v ON r.RowID = v.HeaderID
		LEFT OUTER JOIN dbo.Stok s ON v.BarangID = s.BarangID
	
	WHERE 
		r.TglRetur BETWEEN @fromDate AND @toDate

	ORDER BY r.TglRetur ASC
				
END
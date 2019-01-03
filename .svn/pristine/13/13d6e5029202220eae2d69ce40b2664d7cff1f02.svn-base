USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Pembelian_RekapReturBeli]    Script Date: 04/25/2011 09:41:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =====================================================================
-- Author:		Stephanie
-- Create date: 25 Apr 2011
-- Description:	Pembelian > Laporan > Retur Pembelian > Rekap Retur Beli
-- =====================================================================
CREATE PROCEDURE [dbo].[rsp_Pembelian_RekapReturBeli] 
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
		h.TglKeluar,
		h.TglRetur,
		h.NoRetur,
		h.Pemasok,
		ISNULL((SELECT SUM(d.QtyGudang * d.HrgBeli) FROM dbo.ReturPembelianDetail d
			WHERE h.RowID = d.HeaderID), 0) AS NilaiRetur

	FROM dbo.ReturPembelian h
	
	WHERE
		h.TglRetur BETWEEN @fromDate AND @toDate

	ORDER BY h.TglRetur ASC
				
END
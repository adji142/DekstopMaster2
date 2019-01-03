USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_ReturBeli_RegisterKoreksiReturBeli]    Script Date: 04/26/2011 15:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ======================================================
-- Author:		Stephanie
-- Create date: 26 Apr 2011
-- Description:	Pembelian > Laporan > Retur Beli
--				> Register Koreksi Retur Beli
-- ======================================================
CREATE PROCEDURE [dbo].[rsp_ReturBeli_RegisterKoreksiReturBeli] 
	-- Add the parameters for the stored procedure here
	 @fromDate datetime,
	 @toDate datetime,
	 @kodeGudang varchar(4) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
		
    -- Insert statements for procedure here
	
	SELECT 
		k.Keterangan,
		k.KelompokBrgID AS KLP,
		retur.KodeGudang,
		retur.TglRetur,
		retur.NoRetur,
		retur.TglKoreksi,
		retur.NoKoreksi,
		retur.Unit,
		retur.Nilai

	FROM dbo.KelompokBarang k

		LEFT OUTER JOIN
		(
			SELECT
				v.KodeGudang,
				r.TglRetur,
				r.NoRetur,
				k.TglKoreksi,
				k.NoKoreksi,
				LEFT(v.BarangID, 3) AS KLP,
				SUM( v.QtyGudang - k.QtyNotaBaru) AS Unit,
				SUM(
					( (dbo.fnHitungNet3Disc( v.HrgBeli, v.Disc1, v.Disc2, v.Disc3, '' ) - v.Pot)
					* v.QtyGudang ) - 
					( (dbo.fnHitungNet3Disc( k.HrgBeliBaru, v.Disc1, v.Disc2, v.Disc3, '' ) - v.Pot)
					* k.QtyNotaBaru )
					) AS Nilai

			FROM dbo.KoreksiReturPembelian k
				INNER JOIN dbo.vwReturPembelianDetail v ON k.ReturBeliDetailID = v.RowID
				INNER JOIN dbo.ReturPembelian r ON v.HeaderID = r.RowID
			
			WHERE		
				k.TglKoreksi BETWEEN @fromDate AND @toDate
				AND 
				(v.KodeGudang = @kodeGudang OR @kodeGudang IS NULL)

			GROUP BY 
				v.KodeGudang,
				r.TglRetur,
				r.NoRetur,
				k.TglKoreksi,
				k.NoKoreksi,
				LEFT(v.BarangID, 3) 

		) retur ON k.KelompokBrgID = retur.KLP

	ORDER BY retur.TglRetur, retur.NoRetur ASC
	
				
END
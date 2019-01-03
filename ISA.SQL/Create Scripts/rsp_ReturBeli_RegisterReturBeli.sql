USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_ReturBeli_RegisterReturBeli]    Script Date: 04/26/2011 15:50:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ======================================================
-- Author:		Stephanie
-- Create date: 26 Apr 2011
-- Description:	Pembelian > Laporan > Retur Beli
--				> Register Retur Beli
-- Example:			[dbo].[rsp_ReturBeli_RegisterReturBeli] 
--					'2007/01/01', '2007/01/30', 'RT'
-- ======================================================
CREATE PROCEDURE [dbo].[rsp_ReturBeli_RegisterReturBeli] 
	-- Add the parameters for the stored procedure here
	 @fromDate datetime,
	 @toDate datetime,
	 @tipeTgl varchar(2), -- 'RT' -- TglRetur, 'KL' = TglKeluar
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
		retur.TglKeluar,
		retur.NoMPR,
		retur.TglRetur,
		retur.NoRetur,
		retur.Unit,
		retur.Nilai

	FROM dbo.KelompokBarang k

		LEFT OUTER JOIN
		(
			SELECT
				v.KodeGudang,
				r.TglKeluar,
				r.NoMPR,
				r.TglRetur,
				r.NoRetur,
				LEFT(v.BarangID, 3) AS KLP,
				SUM( v.QtyGudang ) AS Unit,
				SUM( (dbo.fnHitungNet3Disc( v.HrgBeli, v.Disc1, v.Disc2, v.Disc3, '' ) - v.Pot)
					* v.QtyGudang ) AS Nilai

			FROM dbo.ReturPembelian r 
				INNER JOIN dbo.vwReturPembelianDetail v ON r.RowID = v.HeaderID
			
			WHERE		
				( (@tipeTgl = 'RT' AND (r.TglRetur BETWEEN @fromDate AND @toDate) )
					OR	
				(@tipeTgl = 'KL' AND (r.TglKeluar BETWEEN @fromDate AND @toDate) ) )
				AND 
				(v.KodeGudang = @kodeGudang OR @kodeGudang IS NULL)

			GROUP BY 
				v.KodeGudang,
				r.TglKeluar,
				r.NoMPR,
				r.TglRetur,
				r.NoRetur,
				LEFT(v.BarangID, 3) 

		) retur ON k.KelompokBrgID = retur.KLP

	ORDER BY retur.TglKeluar, retur.NoMPR ASC
	
				
END
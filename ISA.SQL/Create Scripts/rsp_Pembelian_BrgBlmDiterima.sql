USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Pembelian_BrgBlmDiterima]    Script Date: 04/26/2011 08:39:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =======================================================
-- Author:		Stephanie
-- Create date: 26 Apr 2011
-- Description:	Pembelian > Laporan > Pembelian 
--				> Barang Belum Diterima
-- =======================================================
CREATE PROCEDURE [dbo].[rsp_Pembelian_BrgBlmDiterima] 
	-- Add the parameters for the stored procedure here
	 @tgl datetime
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
		nota.TglSuratJalan,
		nota.TglTerima,
		nota.NoNota,
		nota.KodeGudang,
		nota.Unit,
		nota.Nilai

	FROM dbo.KelompokBarang k

		LEFT OUTER JOIN
		(
			SELECT
				nh.TglSuratJalan,
				nh.TglTerima,
				nh.NoNota,
				nd.KodeGudang,
				LEFT(nd.BarangID, 3) AS KLP,
				SUM(nd.QtyNota) AS Unit,
				SUM( (dbo.fnHitungNet3Disc( dbo.fnGetHargaBeli(nd.BarangID, nh.TglNota, NULL),
						nd.Disc1, nd.Disc2, nd.Disc3, '' ) - nd.Pot)
					* nd.QtyNota ) AS Nilai
			FROM dbo.NotaPembelian nh
				INNER JOIN dbo.NotaPembelianDetail nd ON nh.RowID = nd.HeaderID
			
			WHERE		
				nh.TglNota <= @tgl
				AND
				(nh.TglTerima > @tgl OR nh.TglTerima IS NULL)
				AND
				LEFT(nd.BarangID, 3) != 'fxb'

			GROUP BY 
				nd.KodeGudang, 
				nh.TglSuratJalan, 
				nh.TglTerima, 
				nh.NoNota, 
				LEFT(nd.BarangID, 3)

		) nota ON k.KelompokBrgID = nota.KLP

	ORDER BY nota.TglTerima, nota.NoNota ASC	
				
END 
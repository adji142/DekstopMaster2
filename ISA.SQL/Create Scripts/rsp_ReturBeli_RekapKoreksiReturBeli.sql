USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Pembelian_RekapKoreksiReturBeli]    Script Date: 04/25/2011 10:09:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ====================================================
-- Author:		Stephanie
-- Create date: 25 Apr 2011
-- Description:	Pembelian > Laporan > Retur Pembelian 
--				> Rekap Koreksi Retur Beli
-- ====================================================
CREATE PROCEDURE [dbo].[rsp_Pembelian_RekapKoreksiReturBeli] 
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
		0 AS Tag,
		k.ReturBeliDetailID AS ReturDetailID,
		k.TglKoreksi,
		k.TglKoreksi AS Tanggal,
		k.NoKoreksi AS NoNota,
		s.NamaStok AS NamaBarang,
		k.QtyNotaBaru AS QtyGudang,
		k.HrgBeliBaru AS HrgBeli,
		v.Disc1,
		v.Pot,
		dbo.fnHitungNet3Disc((k.QtyNotaBaru*k.HrgBeliBaru),v.Disc1,v.Disc2,v.Disc3,'') - v.Pot AS HrgNet,
		0 AS NilaiKoreksi 

	FROM dbo.KoreksiReturPembelian k
		INNER JOIN dbo.vwReturPembelianDetail v ON k.ReturBeliDetailID = v.RowID
		LEFT OUTER JOIN dbo.Stok s ON v.BarangID = s.BarangID
	
	WHERE
		k.TglKoreksi BETWEEN @fromDate AND @toDate
	

	UNION ALL


	SELECT
		1 AS Tag,
		k.ReturBeliDetailID AS ReturDetailID,
		k.TglKoreksi,
		r.Tglretur AS Tanggal,
		r.NoRetur AS NoNota,
		s.NamaStok AS NamaBarang,
		v.QtyGudang,
		v.HrgBeli,
		v.Disc1,
		v.Pot,
		dbo.fnHitungNet3Disc((v.QtyGudang*v.HrgBeli),v.Disc1,v.Disc2,v.Disc3,'') - v.Pot AS HrgNet,
		(dbo.fnHitungNet3Disc((k.QtyNotaBaru*k.HrgBeliBaru),v.Disc1,v.Disc2,v.Disc3,'') - v.Pot)
			- (dbo.fnHitungNet3Disc((v.QtyGudang*v.HrgBeli),v.Disc1,v.Disc2,v.Disc3,'') - v.Pot)
		AS NilaiKoreksi

	FROM dbo.KoreksiReturPembelian k
		INNER JOIN dbo.vwReturPembelianDetail v ON k.ReturBeliDetailID = v.RowID
		INNER JOIN dbo.ReturPembelian r ON v.HeaderID = r.RowID
		LEFT OUTER JOIN dbo.Stok s ON v.BarangID = s.BarangID
	
	WHERE
		k.TglKoreksi BETWEEN @fromDate AND @toDate
		
	
	ORDER BY NamaBarang, TglKoreksi, ReturDetailID, Tag	ASC
				
END 
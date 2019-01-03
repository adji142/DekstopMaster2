USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Laporan_Toko_RegisterKoreksiPenjualan]    Script Date: 05/02/2011 08:36:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ================================================================
-- Author		: Stephanie
-- Create date	: 02 May 2011
-- Description	: Laporan > Toko > Register Koreksi Penjualan
-- Example		: [dbo].[rsp_Laporan_Toko_RegisterKoreksiPenjualan]  
--					'2004/04/01', '2004/04/30'
-- ================================================================
CREATE PROCEDURE [dbo].[rsp_Laporan_Toko_RegisterKoreksiPenjualan] 
	-- Add the parameters for the stored procedure here
	 @fromDate datetime,
	 @toDate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	
	DECLARE @initCab varchar(2)
	SELECT TOP 1
		@initCab = InitCabang
	FROM dbo.Perusahaan

	DECLARE @koreksi TABLE
	(
		RowID uniqueidentifier,
		NotaJualDetailID uniqueidentifier,
		RecordID varchar(23),
		NoKoreksi varchar(11),
		TglKoreksi datetime,
		BarangID varchar(23),
		QtyNota int,
		HrgJual money,
		isChanged bit	-- 1 = koreksi dengan merubah barang, 
						-- 0 = koreksi tanpa rubah barang
	)

	/* Populate data koreksi */
	INSERT INTO @koreksi
	SELECT
		k.RowID,
		k.NotaJualDetailID,
		k.RecordID,
		k.NoKoreksi,
		k.TglKoreksi,
		k.BarangID,
		k.QtyNotaBaru,
		k.HrgJualBaru,
		0
	FROM KoreksiPenjualan k
		INNER JOIN dbo.vwNotaPenjualanDetail v ON k.NotaJualDetailID = v.RowID
	WHERE
		k.TglKoreksi BETWEEN @fromDate AND @toDate
		AND
		v.Cabang1 = @initCab

	/* Cek bila record ini adalah koreksi dengan perubahan BarangID */
	UPDATE @koreksi
	SET isChanged = 1
	FROM @Koreksi k
	WHERE k.RecordID IN 
		(
			SELECT kor.RecordID 
			FROM @koreksi kor
			WHERE	
				kor.TglKoreksi > k.TglKoreksi 
				AND kor.BarangID <> k.BarangID
				AND kor.RowID <> k.RowID
		)


	/* List Data Register Koreksi Penjualan */

	SELECT
		kel.Keterangan,
		kel.KelompokBrgID,
		kor.NoKoreksi,
		kor.TglKoreksi,		
		v.NoNota,
		v.TglNota,
		v.KodeSales,
		t.NamaToko,
		t.Kota,
		(CASE WHEN kor.isChanged = 1 THEN kor.QtyNota
			ELSE kor.QtyNota - v.QtyNota END) AS Unit,
		(CASE WHEN kor.isChanged = 1 
			THEN (kor.QtyNota 
				* (dbo.fnHitungNet3Disc(kor.HrgJual, v.Disc1, v.Disc2, v.Disc3, v.DiscFormula) 
				- v.Pot))			
			ELSE (kor.QtyNota 
				* (dbo.fnHitungNet3Disc(kor.HrgJual, v.Disc1, v.Disc2, v.Disc3, v.DiscFormula) 
				- v.Pot))	
				- 
				(v.QtyNota 
				* (dbo.fnHitungNet3Disc(v.HrgJual, v.Disc1, v.Disc2, v.Disc3, v.DiscFormula) 
				- v.Pot)) 
		 END ) AS Nilai

	FROM dbo.KelompokBarang kel
		LEFT OUTER JOIN @koreksi kor ON kel.KelompokBrgID = LEFT(kor.barangID, 3)
		LEFT OUTER JOIN dbo.vwNotaPenjualanDetail v ON kor.NotaJualDetailID = v.RowID
		LEFT JOIN dbo.Toko t ON v.KodeToko = t.KodeToko

	ORDER BY kor.TglKoreksi, v.TglNota		


END
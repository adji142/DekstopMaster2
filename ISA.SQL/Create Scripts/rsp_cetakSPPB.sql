 USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_CetakSPPB]    Script Date: 03/24/2011 09:39:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- Author:		Stephanie
-- Create date: 24 Mar 2011
-- Description:	Penjualan > MPR > Cetak SPPB
-- ============================================================
ALTER PROCEDURE [dbo].[rsp_CetakSPPB] 
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
		a.NoMPR,
		a.TglMPR,
		LEFT(a.BagPenjualan, 19) AS BagPenjualan,
		f.NamaToko,
		f.Alamat,
		f.Kota,
		f.WilID,
		e.NamaStok AS NamaBarang,
		c.NoNota AS NotaAsal,
		b.QtyTarik,
		LEFT(d.NamaSales, 15) AS NamaSales,
		b.Catatan1		
	FROM dbo.ReturPenjualan a 
		LEFT OUTER JOIN dbo.ReturPenjualanDetail b ON a.ReturID = b.ReturID
		LEFT OUTER JOIN dbo.vwNotaPenjualanDetail c ON b.NotaJualDetailID = c.RowID
		LEFT OUTER JOIN dbo.Sales d ON c.KodeSales = d.SalesID 
		LEFT OUTER JOIN dbo.Stok e ON c.BarangID = e.BarangID
		LEFT OUTER JOIN dbo.Toko f ON a.KodeToko = f.KodeToko
	WHERE 
		a.RowID = @rowID

	UNION ALL

	SELECT
		a.NoMPR,
		a.TglMPR,
		LEFT(a.BagPenjualan, 19) AS BagPenjualan,
		e.NamaToko,
		e.Alamat,
		e.Kota,
		e.WilID,
		d.NamaStok AS NamaBarang,
		b.NotaAsal,
		b.QtyTarik,
		LEFT(c.NamaSales, 15) AS NamaSales,
		b.Catatan1			
	FROM dbo.ReturPenjualan a
		LEFT OUTER JOIN dbo.ReturPenjualanTarikanDetail b ON a.ReturID = b.ReturID
		LEFT OUTER JOIN dbo.Sales c ON b.KodeSales = c.SalesID 
		LEFT OUTER JOIN dbo.Stok d ON b.BarangID = d.BarangID 
		LEFT OUTER JOIN dbo.Toko e ON a.KodeToko = e.KodeToko	
	WHERE 
		a.RowID = @rowID

	ORDER BY NamaBarang ASC

				
END

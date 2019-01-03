USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[rsp_DOTolakACCDetail]') IS NOT NULL
DROP PROC [dbo].[rsp_DOTolakACCDetail] 
GO


/****** Object:  StoredProcedure [dbo].[rsp_DOTolakACCDetail]    Script Date: 03/09/2011 16:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- Author:		Stephanie
-- Create date: 08 Mar 2011
-- Description:	VACCDO > Laporan > DO Tolak ACC (Detail)
-- ============================================================
ALTER PROCEDURE [dbo].[rsp_DOTolakACCDetail] 
	-- Add the parameters for the stored procedure here
	 @fromDate datetime,
	 @toDate datetime,
	 @c1 varchar(2),
	 @postID varchar(3)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		
    -- Insert statements for procedure here
	SELECT
		a.RowID,
		a.TglDO,
		a.NoDO,
		a.TransactionType,
		a.KodeSales,
		LEFT(t.NamaToko, 30) AS NamaToko,
		LEFT(t.Alamat, 30) AS Alamat,
		LEFT(t.Kota, 15) AS Kota,
		s.NamaStok AS NamaBarang,
		b.QtyRequest,
		b.QtyDO,
		(CASE WHEN LEFT(a.NoACCPiutang,1) = 'S' 
			THEN (b.QtyRequest - b.QtyDO) ELSE b.QtyDO END) AS QtyTolak,
		ISNULL(dbo.fnHitungNet3Disc((b.HrgJual), b.Disc1, b.Disc2, b.Disc3, b.DiscFormula) 
			- b.Pot, 0) AS HrgJual,
		a.NoACCPiutang,
		LEFT(a.ACCPiutangID, 7) AS ACCPiutangID,
		LEFT(a.Catatan5, 25) As Catatan5
	FROM dbo.OrderPenjualan a
		LEFT OUTER JOIN dbo.OrderPenjualanDetail b ON a.RowID = b.HeaderID
		LEFT OUTER JOIN dbo.Toko t ON a.KodeToko = t.KodeToko	
		LEFT OUTER JOIN dbo.Stok s ON b.BarangID = s.BarangID
	WHERE 
		(a.TglDO BETWEEN @fromDate AND @toDate)
		AND ISNULL(a.NoACCPiutang, '') != '' AND LEFT(a.NoACCPiutang,1) != 'F' 		
		AND (@c1 = '' OR a.Cabang1 = @c1)	
		AND (@postID = 'ALL'  OR @postID = '' OR
				(SELECT TOP 1 p.PostID FROM dbo.PostKota k 
				LEFT OUTER JOIN dbo.PostArea p ON k.PostRecID = p.RecordID
				WHERE a.Kota = k.Kota) = @postID)
	ORDER By a.TglDO ASC
				
END

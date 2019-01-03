USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[rsp_DOFullACC]') IS NOT NULL
DROP PROC [dbo].[rsp_DOFullACC] 
GO

/****** Object:  StoredProcedure [dbo].[rsp_DOFullACC]    Script Date: 03/09/2011 08:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- Author:		Stephanie
-- Create date: 08 Mar 2011
-- Description:	VACCDO > Laporan > DO ACC Semua
-- ============================================================
ALTER PROCEDURE [dbo].[rsp_DOFullACC] 
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
		a.TglDO,
		a.NoDO,
		a.TransactionType,
		a.KodeSales,
		LEFT(b.NamaToko, 30) AS NamaToko,
		LEFT(b.Alamat, 30)  AS Alamat,
		LEFT(b.Kota, 15) AS Kota,
		ISNULL((SELECT SUM(
			ISNULL(dbo.fnHitungNet3Disc((d.QtyDO * d.HrgJual), e.Disc1, e.Disc2, e.Disc3, e.DiscFormula), 0) 
			- (d.QtyDO * d.Pot)) FROM dbo.OrderPenjualanDetail d 
			LEFT OUTER JOIN dbo.OrderPenjualan e ON d.HeaderID = e.RowID WHERE a.RowID = d.HeaderID), 0)
			AS  RpNet, -- Perhitungan nilai jual untuk DO menggunakan QtyDO	
		ISNULL((SELECT SUM( dbo.fnHitungNet3Disc((n.QtyNota * o.HrgJual), o.Disc1, o.Disc2, o.Disc3, o.DiscFormula) 
			- (n.QtyNota * o.Pot)) FROM dbo.OrderPenjualanDetail o LEFT OUTER JOIN
			dbo.NotaPenjualanDetail n ON o.RowID = n.DODetailID WHERE o.HeaderID = a.RowID), 0) 
			AS RpNet3,
		a.NoACCPiutang,
		a.Plafon,
		a.Overdue,
		a.SaldoPiutang,
		LEFT(a.ACCPiutangID, 7) AS ACCPiutangID,
		LEFT(a.Catatan5, 25) AS Catatan5
	FROM dbo.OrderPenjualan a
		LEFT OUTER JOIN dbo.Toko b ON a.KodeToko = b.KodeToko	
	WHERE 
		(a.TglDO BETWEEN @fromDate AND @toDate)
		AND LEFT(a.NoACCPiutang,1) = 'F'
		AND (@c1 = '' OR a.Cabang1 = @c1)
		AND (@postID = 'ALL'  OR @postID = '' OR
				(SELECT TOP 1 p.PostID FROM dbo.PostKota k 
				LEFT OUTER JOIN dbo.PostArea p ON k.PostRecID = p.RecordID
				WHERE a.Kota = k.Kota) = @postID)
	ORDER By a.TglDO ASC
				
END

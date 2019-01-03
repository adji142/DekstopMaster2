USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[rsp_DOBelumACC]') IS NOT NULL
DROP PROC [dbo].[rsp_DOBelumACC] 
GO

/****** Object:  StoredProcedure [dbo].[rsp_DOBelumACC]    Script Date: 03/09/2011 09:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- Author:		Stephanie
-- Create date: 08 Mar 2011
-- Description:	VACCDO > Laporan > DO Belum ACC
-- ============================================================
ALTER PROCEDURE [dbo].[rsp_DOBelumACC] 
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
			AS  RpNet
	FROM dbo.OrderPenjualan a
		LEFT OUTER JOIN dbo.Toko b ON a.KodeToko = b.KodeToko	
	WHERE 
		(a.TglDO BETWEEN @fromDate AND @toDate)
		AND ISNULL(a.NoACCPiutang, '') = ''
		AND (@c1 = '' OR a.Cabang1 = @c1)
		AND (@postID = 'ALL'  OR @postID = '' OR
				(SELECT TOP 1 p.PostID FROM dbo.PostKota k 
				LEFT OUTER JOIN dbo.PostArea p ON k.PostRecID = p.RecordID
				WHERE a.Kota = k.Kota) = @postID)
	ORDER By a.TglDO ASC
				
END
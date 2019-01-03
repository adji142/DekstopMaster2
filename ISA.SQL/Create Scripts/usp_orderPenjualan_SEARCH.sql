USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_OrderPenjualan_SEARCH]    Script Date: 01/26/2011 16:56:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- ================================================
-- Author:		Stephanie
-- Create date: 26 Jan 11
-- Description:	Search data on table OrderPenjualan
-- ================================================
ALTER PROCEDURE [dbo].[usp_OrderPenjualan_SEARCH] 
	-- Add the parameters for the stored procedure here
	@searchArg varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		a.RowID, 
		a.HtrID, 
		a.Cabang1, 
		a.Cabang2, 
		a.Cabang3, 
		a.NoRequest, 
		a.TglRequest, 
		a.NoDO, 
		a.TglDO, 
		a.NoACCPusat, 
		a.ACCPiutangID, 
		a.NoACCPiutang, 
		a.TglACCPiutang, 
		a.RpACCPiutang,
		a.RpPlafonToko,
		a.RpPiutangTerakhir,
		a.RpGiroTolakTerakhir,
		a.RpOverdue,
		a.StatusBatal, 
		a.HariKredit, 
		a.KodeToko,
		b.TokoID,
		a.KodeSales, 
		c.NamaSales,
		b.NamaToko,
		a.AlamatKirim, 
		a.Kota, 
		a.DiscFormula, 
		a.Disc1, 
		a.Disc2, 
		a.Disc3, 
		a.Plafon, 
		a.SaldoPiutang, 
		a.QtyTolak, 
		a.Overdue, 
		a.isClosed, 
		a.Catatan1, 
		a.Catatan2, 
		a.Catatan3, 
		a.Catatan4, 
		a.Catatan5, 
		a.NoDOBO, 
		a.TglReorder, 
		a.StatusBO, 
		a.SyncFlag, 
		a.LinkID, 
		a.TransactionType, 
		a.Expedisi,
		a.HariKirim, 
		a.HariSales, 
		a.NPrint,
		a.LastUpdatedBy, 
		a.LastUpdatedTime
	FROM dbo.OrderPenjualan a 
	LEFT OUTER JOIN dbo.Toko b ON a.KodeToko = b.KodeToko
	LEFT OUTER JOIN dbo.Sales c ON a.KodeSales = c.SalesID	
	WHERE
		UPPER(a.NoDO) LIKE UPPER(@searchArg + '%')   
    
END



 
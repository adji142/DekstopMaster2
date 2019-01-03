USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_NotaPenjualan_SEARCH]    Script Date: 01/27/2011 12:46:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ================================================
-- Author:		Stephanie
-- Create date: 27 Jan 11
-- Description:	Search data on table NotaPenjualan
-- ================================================
ALTER PROCEDURE [dbo].[usp_NotaPenjualan_SEARCH] 
	-- Add the parameters for the stored procedure here
	@searchArg varchar(7)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		a.RowID, 
		a.DOID, 
		a.NoNota, 
		b.NoDO,
		b.KodeSales,
		(SELECT c.NamaSales FROM dbo.Sales c WHERE c.SalesID = b.KodeSales) As NamaSales,
		(SELECT c.NamaToko FROM dbo.Toko c WHERE c.KodeToko = b.KodeToko) AS NamaToko,
		a.AlamatKirim, 
		--------------
		a.HtrID, 
		a.RecordID, 
		a.TglNota, 
		a.NoSuratJalan, 
		a.TglSuratJalan, 
		a.TglTerima, 
		a.Kota, 
		a.isClosed, 
		a.Catatan1, 
		a.Catatan2, 
		a.Catatan3, 
		a.Catatan4, 
		a.Catatan5, 
		a.SyncFlag, 
		a.LinkID, 
		a.NPrint, 
		a.Checker1, 
		a.Checker2, 
		a.LastUpdatedBy, 
		a.LastUpdatedTime
	FROM dbo.NotaPenjualan a 
	LEFT OUTER JOIN dbo.OrderPenjualan b ON b.RowID = a.DOID
	WHERE
		UPPER(a.NoNota) LIKE UPPER('%' + @searchArg + '%') 
		OR
		UPPER(b.NoDO) LIKE UPPER('%' + @searchArg + '%') 
	ORDER BY b.NoDO DESC
    
END



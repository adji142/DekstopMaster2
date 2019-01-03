USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[rsp_ExpedisiLuarKota]') IS NOT NULL
DROP PROC [dbo].[rsp_ExpedisiLuarKota] 
GO


/****** Object:  StoredProcedure [dbo].[rsp_ExpedisiLuarKota]    Script Date: 02/22/2011 07:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================================
-- Author:		Stephanie
-- Create date: 21 Feb 2011
-- Description:	Expedisi > Laporan > RekapKoli > ExpedisiLuarKota
-- ===============================================================
ALTER PROCEDURE [dbo].[rsp_ExpedisiLuarKota] 
	-- Add the parameters for the stored procedure here
	@fromDate datetime,
	@toDate datetime,
	@shift int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		a.TglSuratJalan,
		c.NamaToko,
		c.Kota,
		a.KodeExp1 + (CASE a.KodeExp2 WHEN '' THEN '' ELSE ', ' + a.KodeExp2 END)
			+ (CASE a.KodeExp3 WHEN '' THEN '' ELSE ', ' + a.KodeExp3 END) AS KodeExpedisi,	
		a.NoSuratJalan,
		(CASE b.TunaiKredit WHEN 'K' THEN 'KREDIT' ELSE 'TUNAI' END) AS TunaiKredit,
		b.NoNota,
		b.NoResi,
		f.NamaSales,
		(SELECT SUM(ISNULL(g.Jumlah, 0)) FROM dbo.RekapKoliSubDetail g WHERE b.RowID = g.HeaderID) AS Jumlah,
		a.TglKeluar,
		b.Keterangan
	FROM dbo.RekapKoli a
		LEFT OUTER JOIN dbo.RekapKoliDetail b ON a.RowID = b.HeaderID
		LEFT OUTER JOIN dbo.Toko c ON a.KodeToko = c.KodeToko
		LEFT OUTER JOIN dbo.NotaPenjualan d ON b.NotaJualID = d.RowID
		LEFT OUTER JOIN dbo.OrderPenjualan e ON d.DOID = e.RowID
		LEFT OUTER JOIN dbo.Sales f ON e.KodeSales = f.SalesID
	
	WHERE
		a.TglSuratJalan >= @fromDate
		AND
		a.TglSuratJalan <= @toDate
		AND
		(a.Shift = @shift OR @shift IS NULL)
		AND
		(a.KodeExp1 != 'SAS')
			
	ORDER BY c.NamaToko DESC 

END

USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[rsp_PenjualanTunaiKredit]') IS NOT NULL
DROP PROC [dbo].[rsp_PenjualanTunaiKredit] 
GO


/****** Object:  StoredProcedure [dbo].[rsp_PenjualanTunaiKredit]    Script Date: 02/22/2011 09:25:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===================================================================
-- Author:		Stephanie
-- Create date: 21 Feb 2011
-- Description:	Expedisi > Laporan > RekapKoli > PenjualanTunaiKredit
-- ===================================================================
CREATE PROCEDURE [dbo].[rsp_PenjualanTunaiKredit] 
	-- Add the parameters for the stored procedure here
	@fromDate datetime,
	@toDate datetime,
	@tunaiKredit varchar(1) = NULL,
	@shift int = NULL 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		a.NoSuratJalan,
		c.NamaToko,
		c.Alamat,
		c.Kota,
		f.NamaSales,
		d.NoNota,
		a.TglSuratJalan,
		b.Nominal,
		b.Uraian,
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
		(b.TunaiKredit = @tunaiKredit OR @tunaiKredit IS NULL)

	ORDER BY a.NoSuratJalan DESC

END

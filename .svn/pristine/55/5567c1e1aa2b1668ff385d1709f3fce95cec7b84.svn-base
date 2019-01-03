USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[rsp_RekapKoli]') IS NOT NULL
DROP PROC [dbo].[rsp_RekapKoli] 
GO

/****** Object:  StoredProcedure [dbo].[rsp_RekapKoli]    Script Date: 02/22/2011 09:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =======================================================
-- Author:		Stephanie
-- Create date: 21 Feb 2011
-- Description:	Expedisi > Laporan > RekapKoli > RekapKoli
-- =======================================================
ALTER PROCEDURE [dbo].[rsp_RekapKoli] 
	-- Add the parameters for the stored procedure here
	@fromDate datetime,
	@toDate datetime,
	@shift int = NULL,
	@status varchar(1) = NULL -- Status muat atau pending dicek dari tgl keluar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		a.TglSuratJalan,
		a.NoSuratJalan,
		b.NamaToko,
		b.Kota,
		b.WIlID,
		a.KodeExp1 + (CASE a.KodeExp2 WHEN '' THEN '' ELSE ', ' + a.KodeExp2 END)
			+ (CASE a.KodeExp3 WHEN '' THEN '' ELSE ', ' + a.KodeExp3 END) AS KodeExpedisi,
		(SELECT COUNT(DISTINCT c.NoNota) FROM dbo.RekapKoliDetail c WHERE c.HeaderID = a.RowID) AS JmlNota,
		(SELECT SUM(ISNULL(d.Jumlah, 0)) FROM dbo.RekapKoliDetail c LEFT OUTER JOIN dbo.RekapKoliSubDetail d
				ON c.RowID = d.HeaderID WHERE a.RowID = c.HeaderID) AS Jumlah,
		a.TglKeluar		
	FROM dbo.RekapKoli a
		LEFT OUTER JOIN dbo.Toko b ON a.KodeToko = b.KodeToko
	
	WHERE
		a.TglSuratJalan >= @fromDate
		AND
		a.TglSuratJalan <= @toDate
		AND
		(a.Shift = @shift OR @shift IS NULL)
		AND
		((CASE WHEN a.TglKeluar IS NULL THEN 'P' ELSE 'M' END) = @status OR @status IS NULL)

	ORDER BY a.TglSuratJalan DESC
	
END


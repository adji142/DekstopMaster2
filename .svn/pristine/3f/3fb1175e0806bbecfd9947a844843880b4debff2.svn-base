USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[rsp_ExpedisiDalamKota]') IS NOT NULL
DROP PROC [dbo].[rsp_ExpedisiDalamKota] 
GO


/****** Object:  StoredProcedure [dbo].[rsp_ExpedisiDalamKota]    Script Date: 02/22/2011 07:36:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================================
-- Author:		Stephanie
-- Create date: 22 Feb 2011
-- Description:	Expedisi > Laporan > RekapKoli > ExpedisiDalamKota
-- ===============================================================
ALTER PROCEDURE [dbo].[rsp_ExpedisiDalamKota] 
	-- Add the parameters for the stored procedure here
	@fromDate DATETIME,
	@toDate DATETIME,
	@shift INT = NULL,
	@via VARCHAR(1) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		
    -- Insert statements for procedure here
	SELECT
		c.NamaToko,
		c.Alamat,
		c.WilID,
		a.NoSuratJalan,
		(CASE b.TunaiKredit WHEN 'K' THEN 'KREDIT' ELSE 'TUNAI' END) AS TunaiKredit,
		b.NoNota,
		(SELECT SUM(ISNULL(d.Jumlah,0)) FROM dbo.RekapKoliSubDetail d WHERE b.RowID = d.HeaderID) AS Jumlah,
		a.TglKeluar,
		b.Keterangan
	FROM dbo.RekapKoli a 
		LEFT OUTER JOIN dbo.RekapKoliDetail b ON a.RowID = b.HeaderID
		LEFT OUTER JOIN dbo.Toko c ON a.KodeToko = c.KodeToko
	
	WHERE
		a.TglSuratJalan >= @fromDate
		AND
		a.TglSuratJalan <= @toDate
		AND
		(a.Shift = @shift OR @shift IS NULL)
		AND
		(a.KodeExp1 = 'SAS')
		AND 
		((CASE WHEN a.KP IS NULL THEN 'G' ELSE 'K' END) = @via OR @via IS NULL)
	
	ORDER BY c.NamaToko DESC
			
END

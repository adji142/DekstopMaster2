USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[rsp_RekapExpedisi]') IS NOT NULL
DROP PROC [dbo].[rsp_RekapExpedisi] 
GO


/****** Object:  StoredProcedure [dbo].[rsp_RekapExpedisi]    Script Date: 02/21/2011 13:55:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- Author:		Stephanie
-- Create date: 21 Feb 2011
-- Description:	Expedisi > Laporan > RekapKoli > RekapExpedisi
-- ============================================================
CREATE PROCEDURE [dbo].[rsp_RekapExpedisi] 
	-- Add the parameters for the stored procedure here
	@fromDate datetime,
	@toDate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @result TABLE(tgl DATETIME)
	DECLARE @date DATETIME
	SET @date = @fromDate
	WHILE @date <= @toDate
	BEGIN
		INSERT INTO @result (tgl) SELECT @date
		SET @date = DATEADD(d, 1, @date)
	END
		
    -- Insert statements for procedure here
	SELECT
		DISTINCT a.Tgl AS TglSuratJalan,
		(SELECT COUNT(*) FROM dbo.RekapKoli b WHERE b.Shift = 1 AND b.TglSuratJalan = a.Tgl) AS JmlSJ1,
		(SELECT COUNT(*) FROM dbo.RekapKoli b WHERE b.Shift != 1 AND b.TglSuratJalan = a.Tgl) AS JmlSJ2,
		(SELECT SUM(ISNULL(d.Jumlah, 0)) FROM dbo.RekapKoli b 
				LEFT OUTER JOIN dbo.RekapKoliDetail c ON b.RowID = c.HeaderID
				LEFT OUTER JOIN dbo.RekapKoliSubDetail d ON c.RowID = d.HeaderID 
				WHERE b.Shift = 1 AND b.TglSuratJalan = a.Tgl) AS JmlKoli1,
		(SELECT SUM(ISNULL(d.Jumlah, 0)) FROM dbo.RekapKoli b 
				LEFT OUTER JOIN dbo.RekapKoliDetail c ON b.RowID = c.HeaderID
				LEFT OUTER JOIN dbo.RekapKoliSubDetail d ON c.RowID = d.HeaderID 
				WHERE b.Shift != 1 AND b.TglSuratJalan = a.Tgl) AS JmlKoli2,
		(SELECT COUNT(DISTINCT c.NoNota) FROM dbo.RekapKoli b LEFT OUTER JOIN dbo.RekapKoliDetail c
			ON b.RowID = c.HeaderID WHERE b.Shift = 1 AND b.TglSuratJalan = a.Tgl) AS JmlNota1,
		(SELECT COUNT(DISTINCT c.NoNota) FROM dbo.RekapKoli b LEFT OUTER JOIN dbo.RekapKoliDetail c
			ON b.RowID = c.HeaderID WHERE b.Shift != 1 AND b.TglSuratJalan = a.Tgl) AS JmlNota2,
		(SELECT COUNT(*) FROM dbo.RekapKoli b LEFT OUTER JOIN dbo.RekapKoliDetail c
			ON b.RowID = c.HeaderID WHERE b.Shift = 1 AND b.TglSuratJalan = a.Tgl AND c.TunaiKredit = 'T') AS JmlTunai1,
		(SELECT COUNT(*) FROM dbo.RekapKoli b LEFT OUTER JOIN dbo.RekapKoliDetail c
			ON b.RowID = c.HeaderID WHERE b.Shift != 1 AND b.TglSuratJalan = a.Tgl AND c.TunaiKredit = 'T') AS JmlTunai2,
		(SELECT COUNT(*) FROM dbo.RekapKoli b WHERE b.TglKeluar IS NULL AND TglSuratJalan = a.Tgl) AS JmlPending

	FROM @result a 	LEFT OUTER JOIN dbo.RekapKoli r ON a.tgl = r.TglSuratJalan

	WHERE r.TglSuratJalan IS NOT NULL 	
				
END

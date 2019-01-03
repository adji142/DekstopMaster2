USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_RekapKoli_LIST]    Script Date: 01/25/2011 15:41:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 25 Jan 11
-- Description:	List data on table RekapKoli
-- =============================================
CREATE PROCEDURE [dbo].[usp_RekapKoli_LIST] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier = NULL,
	@fromDate datetime = NULL,
	@toDate datetime = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		a.RowID, 
		a.RecordID, 
		a.TglSuratJalan, 
		a.NoSuratJalan, 
		a.KodeToko, 
		b.WilID,
		b.NamaToko,
		b.Alamat,
		b.Kota,
		a.TglKeluar, 
		a.KodeExpedisi1, 
		a.KodeExpedisi2, 
		a.KodeExpedisi3, 
		a.Shift, 
		(SELECT SUM(ISNULL(d.Jumlah, 0)) FROM dbo.RekapKoliDetail c LEFT OUTER JOIN dbo.RekapKoliSubDetail d
				ON c.RowID = d.HeaderID WHERE a.RowID = c.HeaderID) AS Jumlah, 
		a.BiayaExp1, 
		a.BiayaExp2, 
		a.BiayaExp3, 
		a.NPrint, 
		a.KP, 
		a.SyncFlag, 
		a.LastUpdatedBy, 
		a.LastUpdatedTime
	FROM dbo.RekapKoli a		
	LEFT OUTER JOIN dbo.Toko b ON a.KodeToko = b.KodeToko
	WHERE
	(a.RowID = @rowID OR @rowID IS NULL)
    AND
	(a.TglSuratJalan >= @fromDate OR @fromDate IS NULL)
	AND
	(a.TglSuratJalan <= @toDate OR @toDate IS NULL)

END 
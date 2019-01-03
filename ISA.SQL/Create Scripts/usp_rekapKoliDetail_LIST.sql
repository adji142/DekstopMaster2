 USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_RekapKoliDetail_LIST]    Script Date: 01/25/2011 15:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ================================================
-- Author:		Stephanie
-- Create date: 25 Jan 11
-- Description:	List data on table RekapKoliDetail
-- ================================================
CREATE PROCEDURE [dbo].[usp_RekapKoliDetail_LIST] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier = NULL,
	@headerID uniqueidentifier = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		a.RowID, 
		a.HeaderID, 
		a.NotaJualID, 
		a.RecordID, 
		a.HtrID, 
		a.NotaJualRecID, 
		a.NoNota, 
		a.TunaiKredit, 
		(CASE a.TunaiKredit WHEN 'T' THEN a.Nominal ELSE 0 END) AS Nominal , 
		a.Uraian, 
		a.Keterangan, 
		a.NoResi, 
		a.SyncFlag, 
		c.NoDO,
		(SELECT SUM(d.Jumlah) FROM dbo.RekapKoliSubDetail d WHERE d.HeaderID = a.RowID) Jumlah,
		(SELECT NamaSales FROM dbo.Sales d WHERE c.KodeSales = d.SalesID) AS NamaSales,
		a.LastUpdatedBy, 
		a.LastUpdatedTime
	FROM dbo.RekapKoliDetail a
	LEFT OUTER JOIN dbo.NotaPenjualan b ON a.NotaJualID = b.RowID
	LEFT OUTER JOIN dbo.OrderPenjualan c ON b.DOID = c.RowID
	
	WHERE
		(a.RowID = @rowID OR @rowID IS NULL)
		AND
		(a.HeaderID = @headerID OR @headerID IS NULL)

END








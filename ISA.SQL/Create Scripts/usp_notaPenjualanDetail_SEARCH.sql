USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_NotaPenjualanDetail_SEARCH]    Script Date: 02/09/2011 13:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===================================================
-- Author:		Stephanie
-- Create date: 08 Feb 11
-- Description:	List data on table NotaPenjualanDetail
-- ===================================================
ALTER PROCEDURE [dbo].[usp_NotaPenjualanDetail_SEARCH] 
	-- Add the parameters for the stored procedure here
	@kodeToko varchar(19) = NULL,
	@barangID varchar(23) = NULL,
	@noNota varchar(7) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		d.RowID, 
		d.QtySuratJalan, 
		d.QtyNota, 
		c.NoNota,
		c.TglNota,
		a.KodeToko,
		b.BarangID
	FROM dbo.OrderPenjualan a
	LEFT OUTER JOIN dbo.OrderPenjualanDetail b ON a.RowID = b.HeaderID
	LEFT OUTER JOIN dbo.NotaPenjualan c ON a.RowID = c.DOID
	LEFT OUTER JOIN dbo.NotaPenjualanDetail d ON c.RowID = d.HeaderID

		
WHERE
	(a.KodeToko = @kodeToko OR @kodeToko IS NULL)
	AND
	(b.BarangID = @barangID OR @barangID IS NULL)
    AND
	(c.NoNota = @noNota OR @noNota IS NULL)
END









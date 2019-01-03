USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_ReturPembelian_LIST]    Script Date: 05/06/2011 10:15:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==============================================
-- Author:		Stephanie
-- Create date: 13 Apr 11
-- Description:	List data on table ReturPembelian
-- ==============================================
CREATE PROCEDURE [dbo].[usp_ReturPembelian_LIST] 
	-- Add the parameters for the stored procedure here
	 @rowID uniqueidentifier = NULL,
	 @fromDate datetime = NULL,			-- TglKeluar
	 @toDate datetime = NULL			-- TglKeluar

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    -- Insert statements for procedure here

	SELECT 
		r.RowID, 
		r.ReturID, 
		r.NoRetur, 
		r.TglRetur, 
		r.Pemasok, 
		r.Penerima, 
		r.NoMPR, 
		r.TglKeluar, 
		r.Pengirim, 
		r.TglKirim, 
		r.isClosed, 
		r.NPrint, 
		r.SyncFlag, 
		r.LastUpdatedBy, 
		r.LastUpdatedTime,
		(SELECT SUM(v.QtyGudang * v.HrgBeli) FROM dbo.vwReturPembelianDetail v
			WHERE r.RowID = v.HeaderID) AS NilaiRetur
	FROM dbo.ReturPembelian r 

	WHERE
		(RowID = @rowID OR @rowID IS NULL)
		AND
		(TglKeluar >= @fromDate OR @fromDate IS NULL)
		AND
		(TglKeluar <= @toDate OR @toDate IS NULL)

	ORDER BY r.TglKeluar ASC

END




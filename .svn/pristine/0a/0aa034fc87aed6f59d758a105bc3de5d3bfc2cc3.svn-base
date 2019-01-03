USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_ReturPenjualan_LIST]') IS NOT NULL
DROP PROC [dbo].[usp_ReturPenjualan_LIST] 
GO

/****** Object:  StoredProcedure [dbo].[usp_ReturPenjualan_LIST]    Script Date: 05/06/2011 09:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==============================================
-- Author:		Stephanie
-- Create date: 08 Feb 11
-- Description:	List data on table ReturPenjualan
-- ==============================================
CREATE PROCEDURE [dbo].[usp_ReturPenjualan_LIST] 
	-- Add the parameters for the stored procedure here
	 @fromDate datetime = NULL,			-- TglMPR
	 @toDate datetime = NULL,			-- TglMPR
	 @fromTglGudang datetime = NULL,	-- TglGudang
	 @toTglGudang datetime = NULL,		-- TglGudang
	 @rowID uniqueidentifier = NULL,
	 @barangID varchar(23) = NULL
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    -- Insert statements for procedure here

	SELECT 
		a.RowID, 
		a.Cabang1, 
		a.Cabang2, 
		a.ReturID, 
		a.NoMPR, 
		a.NoNotaRetur, 
		a.NoTolak, 
		a.KodeToko,
		b.NamaToko,
		b.Alamat AS AlamatKirim,
		b.WilID,
		b.Kota,
		a.TglMPR, 
		a.TglNotaRetur, 
		a.TglTolak, 
		a.Pengambilan, 
		a.TglPengambilan, 
		a.TglGudang, 
		a.BagPenjualan, 
		a.Penerima, 
		a.LinkID, 
		a.SyncFlag, 
		a.isClosed, 
		a.NPrint, 
		a.TglRQRetur, 
		d.NilaiRetur,	-- Perhitungan nilai retur untuk RJ3
		d.NilaiRetur1,	-- Perhitungan nilai retur untuk MPR
		d.NilaiRetur2,	-- Perhitungan nilai retur untuk NotaRetur
		d.NilaiRetur3,
		a.LastUpdatedBy, 
		a.LastUpdatedTime	

	FROM dbo.ReturPenjualan a 
	LEFT OUTER JOIN dbo.Toko b ON a.KodeToko = b.KodeToko
	OUTER APPLY
	(
		SELECT 
			SUM(detail.HrgNetto) AS NilaiRetur,
			SUM(detail.HrgNetto1) AS NilaiRetur1,
			SUM(detail.HrgNetto2) AS NilaiRetur2,
			SUM(detail.HrgNetto3) AS NilaiRetur3
		FROM dbo.vwReturPenjualanDetail detail
		WHERE a.RowID = detail.HeaderID
	) AS d 

	WHERE
		(a.RowID = @rowID OR @rowID IS NULL)
		AND
		(a.TglMPR >= @fromDate OR @fromDate IS NULL)
		AND
		(a.TglMPR <= @toDate OR @toDate IS NULL)
		AND
		(a.TglGudang >= @fromTglGudang OR @fromTglGudang IS NULL)
		AND
		(a.TglGudang <= @toTglGudang OR @toTglGudang IS NULL)
		AND 
		(@barangID IS NULL OR 
			(@barangID IN (SELECT v.BarangID FROM dbo.vwReturPenjualanDetail v 
			WHERE v.HeaderID = a.RowID )))

	ORDER BY TglMPR ASC

	

END
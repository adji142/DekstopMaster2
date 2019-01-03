USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[rsp_CetakDO]') IS NOT NULL
DROP PROC [dbo].[rsp_CetakDO] 
GO

/****** Object:  StoredProcedure [dbo].[rsp_CetakDO]    Script Date: 03/23/2011 14:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- Author:		Stephanie
-- Create date: 02 Mar 2011
-- Description:	Penjualan > DO > Cetak DO
-- ============================================================
CREATE PROCEDURE [dbo].[rsp_CetakDO] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier,
	@lastUpdatedBy varchar(250)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
		
    -- Insert statements for procedure here
	SELECT
		a.RowID,
		a.NoDO,
		a.TglDO,
		a.NoRequest,
		a.TglRequest,
		a.Expedisi,	
		f.NamaExpedisi,
		c.NamaToko,
		c.Alamat,
		c.Kota,
		c.WilID,
		c.Daerah,
		dbo.fnGetStatusToko(a.TglDO, a.KodeToko, a.Cabang1) AS StsToko,
		c.Plafon,
		c.Grade,
		d.NamaSales,
		LEFT(e.NamaStok, 73) AS NamaBarang,
		e.SatSolo AS Satuan,
		e.KodeRak,
		b.QtyDO,
		a.HariKredit,
		b.HrgJual,
		ISNULL(dbo.fnHitungNet3Disc((b.QtyDO * b.HrgJual), b.Disc1, b.Disc2, b.Disc3, b.DiscFormula) 
			- (b.QtyDO * b.Pot), 0) AS HrgNet,		
		(ISNULL((b.QtyDO * b.HrgJual), 0) 
			- ISNULL(dbo.fnHitungNet3Disc((b.QtyDO * b.HrgJual), 
					b.Disc1, b.Disc2, b.Disc3, b.DiscFormula) - (b.QtyDO * b.Pot), 0))
			AS JmlDisc,
		dbo.fnHitungSisaStok(b.BarangID) AS QtySisa
	FROM dbo.OrderPenjualan a 
		LEFT OUTER JOIN dbo.OrderPenjualanDetail b ON a.RowID = b.HeaderID
		LEFT OUTER JOIN dbo.Toko c ON a.KodeToko = c.KodeToko
		LEFT OUTER JOIN dbo.Sales d ON a.KodeSales = d.SalesID
		LEFT OUTER JOIN dbo.Stok e ON b.BarangID = e.BarangID
		LEFT OUTER JOIN dbo.Expedisi f ON a.Expedisi = f.KodeExpedisi
	WHERE 
		a.RowID = @rowID
	ORDER BY e.NamaStok ASC

	/* Hitung TotalNet dan Jumlah SubDetail */
	DECLARE @jmlNet money
	DECLARE @jmlSub int
	DECLARE @kodeToko varchar(19)
	DECLARE @classIDToko varchar(1)
	DECLARE @doHtrID varchar(23)
	DECLARE @tglDO datetime
	DECLARE @c1 varchar(2)

	SELECT
		@kodeToko = MAX(a.KodeToko),
		@classIDToko = MAX(c.ClassID),
		@doHtrID = MAX(a.HtrID),
		@tglDO = MAX(a.TglDO),
		@c1 = MAX(a.Cabang1),
		@jmlSub = COUNT(*),
		@jmlNet = SUM( ISNULL(dbo.fnHitungNet3Disc((b.QtyDO * b.HrgJual), b.Disc1, b.Disc2, b.Disc3, b.DiscFormula) 
					- (b.QtyDO * b.Pot), 0) )
	FROM dbo.OrderPenjualan a 
		LEFT OUTER JOIN dbo.OrderPenjualanDetail b ON a.RowID = b.HeaderID
		LEFT OUTER JOIN dbo.Toko c ON a.KodeToko = c.KodeToko
	WHERE 
		a.RowID = @rowID	

	/* Get RodaToko dan Status Otomatis*/
	DECLARE @stsAwal varchar(2)
	DECLARE @rodaToko varchar(1)
	DECLARE @stsOmset varchar(2)
	SET @stsAwal = dbo.fnGetStatusToko(@tglDO, @kodeToko, @c1)
	SET @rodaToko = dbo.fnCekRodaToko(@tglDO, @kodeToko, @c1)
	SET @stsOmset = dbo.fnGetStatusOmset(@stsAwal, @jmlNet, @rodaToko, @classIDToko)


	/* Update setelah cetak DO */

	/* Update DO */
	UPDATE ISAdb.dbo.OrderPenjualan
	SET NPrint = 1
	WHERE RowID = @rowID

	/* Replace Status Toko */
	IF (@stsAwal != @stsOmset)
	BEGIN
		/* Declare tabel cabang untuk menyimpan cabang2 toko dari Tabel StatusToko */
		DECLARE @cabang TABLE ( C1 varchar(2) )
		INSERT INTO @cabang (C1)
		SELECT DISTINCT(CabangID) FROM dbo.StatusToko
		WHERE KodeToko = @kodeToko 

		INSERT INTO ISAdb.dbo.StatusToko
		(
			RowID, 
			CabangID, 
			KodeToko, 
			TglAktif, 
			[Status], 
			RecordID, 
			Keterangan, 
			SyncFlag, 
			KStatus, 
			Roda, 
			TglPasif, 
			LastUpdatedBy, 
			LastUpdatedTime
		)
		SELECT
			NEWID(),
			C1,
			@kodeToko,
			@tglDO,
			@stsOmset, 
			@doHtrID, 
			'Status Otomatis' + CONVERT(varchar(20), @tglDO, 105), 
			0, 
			'O', 
			@rodaToko, 
			DATEADD(DAY, -1 , (DATEADD(MONTH, 1, @tglDO))), 
			@lastUpdatedBy, 
			GETDATE()
		FROM @cabang
	END
	
				
END

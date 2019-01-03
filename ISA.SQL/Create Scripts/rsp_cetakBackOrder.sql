USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[rsp_CetakBackOrder]') IS NOT NULL
DROP PROC [dbo].[rsp_CetakBackOrder] 
GO

/****** Object:  StoredProcedure [dbo].[rsp_CetakBackOrder]    Script Date: 03/23/2011 14:44:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- Author:		Stephanie
-- Create date: 02 Mar 2011
-- Description:	Penjualan > BO > Cetak BO
-- ============================================================
ALTER PROCEDURE [dbo].[rsp_CetakBackOrder] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier,
	@lastUpdatedBy varchar(250),
	@BORecID varchar(23)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
		
    -- Insert statements for procedure here

	SELECT 
		x.RowID,
		x.NoDO,
		x.TglDO,
		x.NoRequest,
		x.TglRequest,
		x.Expedisi,	
		x.NamaExpedisi,
		x.NamaToko,
		x.Alamat,
		x.Kota,
		x.WilID,
		x.Daerah,
		x.StsToko,
		x.Plafon,
		x.Grade,
		x.NamaSales,
		x.NamaBarang,
		x.Satuan,
		x.KodeRak,
		x.QtyDO,
		x.QtySuratJalan,
		x.HariKredit,
		x.HrgJual,
		ISNULL(dbo.fnHitungNet3Disc(((x.QtyDO - x.QtySuratJalan) * x.HrgJual), x.Disc1, x.Disc2, x.Disc3, x.DiscFormula) 
			- ((x.QtyDO - x.QtySuratJalan) * x.Pot), 0) AS HrgNet,		
		(ISNULL(((x.QtyDO - x.QtySuratJalan) * x.HrgJual), 0) 
			- ISNULL(dbo.fnHitungNet3Disc(((x.QtyDO - x.QtySuratJalan) * x.HrgJual), x.Disc1, x.Disc2, x.Disc3, x.DiscFormula) 
					- ((x.QtyDO - x.QtySuratJalan) * x.Pot), 0) )
			AS JmlDisc,
		x.QtySisa
	FROM
	(
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
			(SELECT SUM(n.QtySuratJalan) FROM dbo.NotaPenjualanDetail n
				WHERE b.RowID = n.DODetailID) AS QtySuratJalan,
			a.HariKredit,
			b.HrgJual,
			b.Disc1,
			b.Disc2,
			b.Disc3,
			b.Pot,
			b.DiscFormula,
			dbo.fnHitungSisaStok(b.BarangID) AS QtySisa
		FROM dbo.OrderPenjualan a 
			LEFT OUTER JOIN dbo.OrderPenjualanDetail b ON a.RowID = b.HeaderID
			LEFT OUTER JOIN dbo.Toko c ON a.KodeToko = c.KodeToko
			LEFT OUTER JOIN dbo.Sales d ON a.KodeSales = d.SalesID
			LEFT OUTER JOIN dbo.Stok e ON b.BarangID = e.BarangID
			LEFT OUTER JOIN dbo.Expedisi f ON a.Expedisi = f.KodeExpedisi
		WHERE 
			a.RowID = @rowID
			AND 
			ISNULL(b.NoDOBO, '') != ''
	)  AS x
	ORDER BY x.NamaBarang ASC

	/* Hitung TotalNet dan Jumlah SubDetail */
	DECLARE @jmlNet money
	DECLARE @jmlSub int
	DECLARE @kodeToko varchar(19)
	DECLARE @classIDToko varchar(1)
	DECLARE @doHtrID varchar(23)
	DECLARE @tglDO datetime
	DECLARE @c1 varchar(2)

	SELECT 
		@kodeToko = MAX(x.KodeToko),
		@classIDToko = MAX(x.ClassID),
		@doHtrID = MAX(x.HtrID),
		@tglDO = MAX(x.TglDO),
		@c1 = MAX(x.Cabang1),
		@jmlSub = COUNT(*),
		@jmlNet = SUM(ISNULL(dbo.fnHitungNet3Disc(((x.QtyDO - x.QtySuratJalan) * x.HrgJual), x.Disc1, x.Disc2, x.Disc3, x.DiscFormula) 
			- ((x.QtyDO - x.QtySuratJalan) * x.Pot), 0)) 				
	FROM
	(
		SELECT
			a.KodeToko, c.ClassID,		
			a.RowID, a.HtrID, a.TglDO, a.Cabang1,
			b.HrgJual, b.Pot, 
			b.Disc1, b.Disc2, b.Disc3, b.DiscFormula,
			b.QtyDO,
			(SELECT SUM(n.QtySuratJalan) FROM dbo.NotaPenjualanDetail n
				WHERE b.RowID = n.DODetailID) AS QtySuratJalan
		FROM dbo.OrderPenjualan a 
			LEFT OUTER JOIN dbo.OrderPenjualanDetail b ON a.RowID = b.HeaderID
			LEFT OUTER JOIN dbo.Toko c ON a.KodeToko = c.KodeToko
		WHERE 
			a.RowID = @rowID
			AND 
			ISNULL(b.NoDOBO, '') != ''
	) AS x

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
	SET NPrint = 4,
		SyncFlag = 0,
		NoDOBO = ''
	WHERE RowID = @rowID

	/* Update DO Detail */
	UPDATE ISAdb.dbo.OrderPenjualanDetail
	SET NBOPrint = 4,		
		SyncFlag = 0,
		NoDOBO = ''
	FROM dbo.OrderPenjualan a 
		LEFT OUTER JOIN dbo.OrderPenjualanDetail b ON a.RowID = b.HeaderID
	WHERE 
		a.RowID = @rowID
		AND 
		ISNULL(b.NoDOBO, '') != ''		

	/* Update OR Insert BO */
	IF EXISTS (SELECT DOID FROM dbo.BackOrder WHERE DOID = @rowID)
	BEGIN
		UPDATE ISAdb.dbo.BackOrder
		SET RpNet = @jmlNet, 
			Sub = @jmlSub, 
			LastUpdatedBy = @lastUpdatedBy, 
			LastUpdatedTime = GETDATE()
		WHERE DOID = @rowID
	END
	ELSE -- IF DO belum pernah BO
	BEGIN
		INSERT INTO ISAdb.dbo.BackOrder
		(
			RowID, DOID, RecordID, DOHtrID, RpNet, Sub, 
			LastUpdatedBy, LastUpdatedTime
		)
		SELECT
			NEWID(), @rowID, @BORecID, @dOHtrID, @jmlNet, @jmlSub, 
			@lastUpdatedBy, GETDATE()			
	END


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

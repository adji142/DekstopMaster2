USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[rsp_CetakNotaPenjualanTax]') IS NOT NULL
DROP PROC [dbo].[rsp_CetakNotaPenjualanTax] 
GO

/****** Object:  StoredProcedure [dbo].[rsp_CetakNotaPenjualanTax]    Script Date: 03/23/2011 11:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- Author:		Stephanie
-- Create date: 15 Mar 2011
-- Description:	Penjualan > Nota > Cetak Nota Tax
-- =========================================================
ALTER PROCEDURE [dbo].[rsp_CetakNotaPenjualanTax] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier,
	@oli int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

	DECLARE @namaPrs varchar(30)
	DECLARE @alamatPrs varchar(60)
	DECLARE @NPWP varchar(25)
	DECLARE @tglPKP datetime

	SELECT
		@namaPrs = Nama,
		@alamatPrs = Alamat,
		@NPWP = NPWP,
		@tglPKP = TglPKP
	FROM dbo.fnCekPTTransType(@rowID)


    -- Insert statements for procedure here
	SELECT
		x.NoSuratJalan,
		x.TglSuratJalan,
		x.NamaBarang,
		x.Satuan,
		x.QtySuratJalan,
		ISNULL(x.HrgJual, 0) AS HrgJual,		
		ISNULL((dbo.fnHitungNet3Disc( (x.HrgJual * x.QtySuratjalan) - 
			(x.QtySuratJalan * x.HrgJual), x.Disc1, x.Disc2, x.Disc3, x.DiscFormula)
			), 0) AS Disc,
		X.Pot,
		@namaPrs AS NamaPrs,
		@alamatPrs AS AlamatPrs,
		@npwp AS NPWP,
		@tglPKP AS TglPKP
	FROM
		(SELECT
			a.NoSuratJalan,
			a.TglSuratJalan,
			LEFT(d.NamaStok, 75) AS NamaBarang,
			d.SatSolo AS Satuan,
			b.QtySuratJalan,
			(CASE WHEN c.HrgJual > 0
				THEN (CASE WHEN a.TransactionType = 'KB' 
					THEN (CASE WHEN c.HrgJual > dbo.fnGetHrgBMK_K(d.RecordID, a.TglSuratJalan)
						THEN c.HrgJual  
						ELSE dbo.fnGetHrgBMK_K(d.RecordID, a.TglSuratJalan)
						END)
					ELSE (CASE WHEN LEFT(c.BarangID,3) = 'FAB' 
						THEN dbo.fnGetHrgJualStd(d.RecordID, a.TglSuratJalan) 
						ELSE (CASE WHEN @oli = 2 
							THEN dbo.fnGetHrgBMK_K(d.RecordID, a.TglSuratJalan) 
							ELSE c.HrgJual
							END)
						END)
					END)
				ELSE c.HrgJual
				END) AS HrgJual,
			c.HrgJual AS HrgSatuan,
			c.Disc1,
			c.Disc2,
			c.Disc3,
			c.DiscFormula,
			(CASE WHEN LEFT(c.BarangID,3) = 'FXB' THEN c.Pot ELSE 0 END) AS Pot
		FROM dbo.NotaPenjualan a
			LEFT OUTER JOIN dbo.NotaPenjualanDetail b ON a.RowID = b.HeaderID	
			LEFT OUTER JOIN dbo.OrderPenjualanDetail c ON b.DODetailID = c.RowID
			LEFT OUTER JOIN dbo.Stok d ON c.BarangID = d.BarangID
		WHERE 
			a.RowID = @rowID
		) AS x
	ORDER BY x.NamaBarang ASC

	/* Update table NotaPenjualan setelah cetak Nota */
	UPDATE ISAdb.dbo.NotaPenjualan
	SET NPrint = 3,
		SyncFlag = 0
	WHERE RowID = @RowID
				
END
 
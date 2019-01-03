 USE [ISAdb]
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetNotaJualForRekapKoli]    Script Date: 01/28/2011 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =======================================================
-- Author:		Stephanie
-- Create date: 28 Jan 11
-- Description:	Function to Return Nota Jual for Rekap Koli
-- ========================================================
ALTER FUNCTION [dbo].[fnGetNotaJualForRekapKoli] 
(	
	-- Add the parameters for the function here
	@kodeToko varchar(19)
)
RETURNS @result 
TABLE 
(
	NotaJualID uniqueidentifier,
	NotaRecID varchar(23),
	NoNota varchar(7), -- Nomor SuratJalan dari Nota Penjualan
	TglNota datetime, -- Tgl SuratJalan dari Nota Penjualan
	NoDO varchar(7),
	NamaToko varchar(31),
	AlamatKirim varchar(60),
	NamaSales varchar(23),
	KreditTunai varchar(1),
	Nominal money, 
	QtyKoli int -- Sum qty koli dari NotaPenjualanDetail
)
AS
BEGIN
	-- Add the SELECT statement with parameter references here
	INSERT INTO @result 
	SELECT
		a.RowID,
		a.RecordID,
		a.NoSuratJalan,
		a.TglSuratJalan,
		b.NoDO,
		(SELECT c.NamaToko FROM dbo.Toko c WHERE c.KodeToko = @kodeToko),
		(SELECT c.Alamat FROM dbo.Toko c WHERE c.KodeToko = @kodeToko),
		(SELECT c.NamaSales FROM dbo.Sales c WHERE c.SalesID = b.KodeSales),
		LEFT(a.TransactionType, 1),
		(CASE LEFT(a.TransactionType, 1) 
			WHEN 'K' THEN 0 
			ELSE (SELECT SUM(c.QtySuratJalan * c.HrgJual) 
				FROM dbo.vwNotaPenjualanDetail c WHERE c.HeaderID = a.RowID )
			END),
		(SELECT SUM(c.QtyKoli) FROM dbo.NotaPenjualanDetail c WHERE c.HeaderID = a.RowID)
	FROM dbo.NotaPenjualan a 
		LEFT OUTER JOIN dbo.OrderPenjualan b ON a.DOID = b.RowID
	WHERE 
		b.KodeToko = @kodeToko
		AND UPPER(a.NoSuratJalan) != 'BATAL'
		AND a.TglSerahTerimaChecker IS NOT NULL 
		AND b.Cabang2 = (SELECT TOP 1 c.InitCabang FROM dbo.Perusahaan c)
	ORDER BY b.NoDO DESC
	RETURN
END

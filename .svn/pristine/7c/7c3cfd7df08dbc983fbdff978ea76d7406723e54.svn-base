USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[vwNotaPenjualanDetail]') IS NOT NULL
DROP VIEW [dbo].[vwNotaPenjualanDetail]
GO

/****** Object:  View [dbo].[vwNotaPenjualanDetail]    Script Date: 02/17/2011 10:40:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER VIEW [dbo].[vwNotaPenjualanDetail] 
AS 
SELECT
	a.RowID,
	a.HeaderID,
	a.DODetailID,
	c.BarangID,
	c.QtyRequest,
	a.QtySuratJalan,
	a.QtyNota,
	b.DOID,
	b.NoNota,
	b.TglNota,
	b.TglTerima
	d.KodeToko,
	d.KodeSales,
	d.Expedisi,
	c.HrgJual,
	(dbo.fnGetHPP(c.BarangID, d.TglDO)) AS HPPSolo,
	c.DiscFormula,
	c.Disc1,
	c.Disc2,
	c.Disc3,
	c.Pot
FROM dbo.NotaPenjualanDetail a 
LEFT OUTER JOIN dbo.NotaPenjualan b ON a.HeaderID = b.RowID
LEFT OUTER JOIN dbo.OrderPenjualanDetail c ON c.RowID = a.DODetailID
LEFT OUTER JOIN dbo.OrderPenjualan d ON d.RowID = b.DOID

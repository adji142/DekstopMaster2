USE [ISAdb]
GO
/****** Object:  View [dbo].[vwReturPembelianDetail]    Script Date: 04/14/2011 08:14:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwReturPembelianDetail] 
AS 
SELECT 
	r.RowID, 
	r.HeaderID, 
	r.NotaBeliDetailID, 
	r.RecordID, 
	r.ReturID, 
	r.NotaBeliDetailRecID, 
	n.BarangID,
	r.KodeRetur, 
	r.QtyGudang, 
	r.QtyTerima, 
	r.HrgBeli, 
	r.HrgNet, 
	r.HrgPokok, 
	r.HPPSolo, 
	r.Catatan, 
	r.TglKeluar, 
	r.KodeGudang, 
	r.LastUpdatedBy, 
	r.LastUpdatedTime,
	n.Pot,
	n.Disc1,
	n.Disc2,
	n.Disc3,
	n.DiscFormula
FROM  dbo.ReturPembelianDetail r (NOLOCK)
	LEFT OUTER JOIN dbo.NotaPembelianDetail n (NOLOCK) ON r.NotaBeliDetailID = n.RowID

UNION ALL

SELECT 
	RowID, 
	HeaderID, 
	NULL AS NotaBeliDetailID, 
	RecordID, 
	ReturID, 
	'' AS NotaBeliDetailRecID,
	BarangID, 
	KodeRetur, 
	QtyGudang, 
	QtyTerima, 
	HrgBeli, 
	HrgNet, 
	HrgPokok, 
	HPPSolo, 
	Catatan, 
	TglKeluar, 
	KodeGudang, 
	LastUpdatedBy, 
	LastUpdatedTime,
	0 AS Pot,
	0 AS Disc1,
	0 AS Disc2,
	0 AS Disc3,
	'' AS DiscFormula
FROM dbo.ReturPembelianManualDetail (NOLOCK)




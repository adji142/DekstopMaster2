USE [ISAdb]
GO

/****** Object:  View [dbo].[vwReturPembelianDetail]    Script Date: 09/15/2011 16:08:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


  
ALTER VIEW [dbo].[vwReturPembelianDetail]   
AS   
SELECT   
 r.RowID,   
 r.HeaderID,   
 r.NotaBeliDetailID,   
 r.RecordID,   
 r.ReturID,   
 r.NotaBeliDetailRecID,   
 r.BarangID,  
 r.KodeRetur,   
 r.QtyGudang,   
 r.QtyTerima,   
 r.HrgBeli,   
 r.HrgNet,   
-- r.HrgPokok,   
 (CASE WHEN dbo.fnGetHPPA(n.BarangID, n.TglTerima) = 1 THEN 0 ELSE  
  dbo.fnGetHPPA(n.BarangID, n.TglTerima) END) AS HrgPokok,  
 r.HPPSolo,   
 r.Catatan,   
 r.TglKeluar,   
 r.KodeGudang,
 r.SyncFlag,   
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
-- HrgPokok,   
 (CASE WHEN dbo.fnGetHPPA(BarangID, TglKeluar) = 1 THEN 0 ELSE  
  dbo.fnGetHPPA(BarangID, TglKeluar) END) AS HrgPokok,  
 HPPSolo,   
 Catatan,   
 TglKeluar,   
 KodeGudang,
 SyncFlag,
 LastUpdatedBy,   
 LastUpdatedTime,  
 0 AS Pot,  
 0 AS Disc1,  
 0 AS Disc2,  
 0 AS Disc3,  
 '' AS DiscFormula  
FROM dbo.ReturPembelianManualDetail (NOLOCK)  
  
  
  

GO



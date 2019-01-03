USE [ISAdb]
GO

/****** Object:  View [dbo].[vwReturPenjualanDetail]    Script Date: 09/15/2011 15:46:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  
ALTER VIEW [dbo].[vwReturPenjualanDetail]             
AS  
SELECT             
 a.RowID,             
 a.HeaderID,             
 a.NotaJualDetailID,             
 a.RecordID,            
 a.ReturID,             
 a.NotaJualDetailRecID,             
 c.NoNota AS NotaAsal,            
 b.NoNotaRetur ,             
 c.TglNota,            
 c.TglTerima, -- Tgl terima toko dari nota penjualan            
 c.TglDO,            
 a.KodeRetur,            
 c.BarangID,            
 e.NamaStok,            
 e.SatSolo AS Satuan,            
 c.KodeSales,            
 d.NamaSales,            
 b.KodeToko,             
 a.QtyMemo,             
 a.QtyTarik,             
 ISNULL(a.QtyTerima, 0) AS QtyTerima,             
 a.QtyGudang,             
 a.QtyTolak,             
 c.Pot,            
 a.HrgJual AS HrgJual,  
 (dbo.fnGetHPPA(c.BarangID, b.TglGudang))  AS HrgPokok,    
 (dbo.fnGetHPP(c.BarangID, b.TglGudang)) AS HPPSolo,       
 a.Catatan1,             
 a.Catatan2,             
 b.TglGudang,            
 a.SyncFlag,             
 a.Kategori,             
 a.KodeGudang,             
 a.NoACC,             
 a.LastUpdatedBy,             
 a.LastUpdatedTime,            
 c.Disc1,            
 c.Disc2,            
 c.Disc3,            
 c.DiscFormula,            
 b.Cabang1,            
 b.Cabang2,            
 c.Expedisi,            
 c.QtySuratJalan,            
 ISNULL((SELECT SUM(ISNULL(r.QtyGudang, 0)) FROM dbo.ReturPenjualanDetail r (NOLOCK) WHERE r.NotaJualDetailID = a.NotaJualDetailID AND r.BarangID = a.BarangID), 0) As QtyRetur,      
 ISNULL( a.QtyTerima *  a.HrgJual, 0) AS HrgNetto,-- Perhitungan HrgNet untuk RJ3    
 ISNULL( a.QtyTarik * a.HrgJual, 0) AS HrgNetto1, -- Perhitungan HrgNet untuk MPR     
 ISNULL( a.QtyGudang * a.HrgJual, 0) AS HrgNetto2,  -- Perhitungan HrgNet untuk NotaRetur          
 0 AS HrgNetto3,          
 b.TglNotaRetur,          
 c.HariKirim,          
 c.HariSales,          
 c.HariKredit,                    
 a.HrgJual AS HrgJualRetur           
FROM dbo.ReturPenjualanDetail a (NOLOCK)             
 LEFT OUTER JOIN dbo.ReturPenjualan b (NOLOCK) ON a.HeaderID = b.RowID            
 LEFT OUTER JOIN dbo.vwNotaPenjualanDetail c (NOLOCK) ON a.NotaJualDetailID = c.RowID            
 LEFT OUTER JOIN dbo.Sales d (NOLOCK) ON c.KodeSales = d.SalesID             
 LEFT OUTER JOIN dbo.Stok e (NOLOCK) ON c.BarangID = e.BarangID          
            
UNION ALL            
            
SELECT             
 a.RowID,             
 a.HeaderID,             
 NULL AS NotaJualDetailID,             
 a.RecordID,            
 a.ReturID,             
 NULL AS NotaJDetailRecID,             
 a.NotaAsal,             
 b.NoNotaRetur ,             
 NULL AS TglNota,            
 NULL AS TglTerima,            
 NULL,            
 a.KodeRetur,             
 a.BarangID,            
 d.NamaStok,            
 d.SatSolo AS Satuan,            
 a.KodeSales,            
 c.NamaSales,            
 b.KodeToko,             
 a.QtyMemo,             
 a.QtyTarik,             
 ISNULL(a.QtyTerima, 0) AS QtyTerima,             
 a.QtyGudang,             
 a.QtyTolak,             
 a.Pot,            
 a.HrgJual,   
 (dbo.fnGetHPPA(a.BarangID, b.TglGudang))  AS HrgPokok,    
 (dbo.fnGetHPP(a.BarangID, b.TglGudang)) AS HPPSolo,       
 a.Catatan1,             
 a.Catatan2,             
 b.TglGudang,            
 a.SyncFlag,             
 a.Kategori,             
 a.KodeGudang,             
 a.NoACC,             
 a.LastUpdatedBy,             
 a.LastUpdatedTime,            
 0 AS Disc1,            
 0 AS Disc2,            
 0 AS Disc3,            
 '' AS DiscFormula,            
 b.Cabang1,            
 b.Cabang2,            
 NULL AS Expedisi,            
 0 AS QtySuratJalan,            
 0 As QtyRetur,            
 ISNULL( ((a.QtyTerima * a.HrgJual) - (a.QtyTerima * a.Pot)) , 0)             
  AS HrgNetto, -- Perhitungan HrgNet untuk RJ3            
 ISNULL( ((a.QtyTarik * a.HrgJual) - (a.QtyTarik * a.Pot)) , 0)             
  AS HrgNetto1, -- Perhitungan HrgNet untuk MPR            
 ISNULL( ((a.QtyGudang * a.HrgJual) - (a.QtyGudang * a.Pot)) , 0)             
  AS HrgNetto2, -- Perhitungan HrgNet untuk NotaRetur            
 0 AS HrgNetto3,          
 b.TglNotaRetur,          
 0 AS HariKirim,          
 0 AS HariSales,          
 0 AS HariKredit ,                  
 HrgJual AS HrgJualRetur           
FROM dbo.ReturPenjualanTarikanDetail a (NOLOCK)             
 LEFT OUTER JOIN dbo.ReturPenjualan b (NOLOCK) ON a.HeaderID = b.RowID            
 LEFT OUTER JOIN dbo.Sales c (NOLOCK) ON a.KodeSales = c.SalesID             
 LEFT OUTER JOIN dbo.Stok d (NOLOCK) ON a.BarangID = d.BarangID  
GO



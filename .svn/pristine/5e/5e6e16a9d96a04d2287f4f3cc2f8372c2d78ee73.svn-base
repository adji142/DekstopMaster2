USE [ISAdb]
GO

/****** Object:  View [dbo].[vwNotaPenjualan]    Script Date: 09/15/2011 17:14:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  
ALTER VIEW [dbo].[vwNotaPenjualan]  
 AS  
SELECT           
  a.RowID,           
  a.HtrID,           
  a.RecordID,          
  a.DOID,          
  b.NoRequest,          
  b.TglRequest,          
  b.NoDO,          
  b.TglDO,          
  a.NoNota,           
  a.TglNota,           
  a.NoSuratJalan,           
  a.TglSuratJalan,           
  a.TglTerima,           
  dbo.fnHitTglJatuhTempo(a.TransactionType, a.TglTerima, a.HariKredit,           
   b.HariKirim, b.HariSales) AS TglJatuhTempo,          
  a.TransactionType,          
  a.Checker1,           
  a.Checker2,          
  b.KodeToko,          
  c.Alamat as AlamatKirim,           
  c.Kota,           
  c.WilID,          
  a.isClosed,           
  a.Catatan1 AS Cat1,           
  a.Catatan2 AS Cat2,           
  a.Catatan3 AS Cat3,           
  a.Catatan4 AS Cat4,           
  a.Catatan5 AS Cat5,           
  a.SyncFlag,           
  a.LinkID,           
  a.NPrint,           
  a.LastUpdatedBy,           
  a.LastUpdatedTime,                 
  b.Disc1,          
  b.Disc2,          
  b.Disc3,          
  b.DiscFormula,          
  a.HariKredit,          
  b.HariKirim,          
  b.HariSales,          
  b.Catatan1,          
  b.Catatan2,          
  b.Catatan3,          
  b.Catatan4,          
  b.StatusBatal,          
  b.Cabang1,          
  b.Cabang2,          
  b.Expedisi,          
  b.KodeSales,          
  d.NamaSales,          
  c.NamaToko,            
  a.TglSerahTerimaChecker,         
  /* Jumlah HrgJual, JumlahNetto dan JumlahPotongan untuk NotaPenjualan */          
  ISNULL((SELECT SUM(v.QtySuratJalan * od.HrgJual)), 0) AS RpJual2,          
  ISNULL((SELECT SUM( dbo.fnHitungNet3Disc((v.QtySuratJalan * od.HrgJual), od.Disc1, od.Disc2, od.Disc3, od.DiscFormula) - (v.QtySuratJalan * od.Pot))), 0) AS RpNet2,          
  ISNULL((SELECT SUM(od.Pot * v.QtySuratJalan)),0) AS RpPot2,          
   /* Jumlah HrgJual, JumlahNetto dan JumlahPotongan untuk PJ3 */          
  ISNULL((SELECT SUM(v.QtyNota * od.HrgJual)), 0) AS RpJual3,          
  ISNULL((SELECT SUM( dbo.fnHitungNet3Disc((v.QtyNota * od.HrgJual), od.Disc1, od.Disc2, od.Disc3, od.DiscFormula) - (v.QtyNota * od.Pot))), 0) AS RpNet3,          
  ISNULL((SELECT SUM(od.Pot * v.QtyNota)),0) AS RpPot3             
            
 FROM dbo.NotaPenjualan a (NOLOCK)          
  LEFT OUTER JOIN dbo.OrderPenjualan b (NOLOCK) ON a.DOID = b.RowID          
  LEFT OUTER JOIN dbo.Toko c (NOLOCK) ON c.KodeToko = b.KodeToko           
  LEFT OUTER JOIN dbo.Sales d (NOLOCK) ON d.SalesID = b.KodeSales         
  LEFT OUTER JOIN dbo.NotaPenjualanDetail v (NOLOCK) ON v.HeaderID = a.RowID    
  LEFT OUTER JOIN dbo.OrderPenjualanDetail od (NOLOCK) ON v.DODetailID = od.RowID         
         
    
 GROUP BY  
  a.RowID,           
  a.HtrID,           
  a.RecordID,          
  a.DOID,          
  b.NoRequest,          
  b.TglRequest,          
  b.NoDO,          
  b.TglDO,          
  a.NoNota,           
  a.TglNota,           
  a.NoSuratJalan,           
  a.TglSuratJalan,           
  a.TglTerima,           
  dbo.fnHitTglJatuhTempo(a.TransactionType, a.TglTerima, a.HariKredit,           
   b.HariKirim, b.HariSales),          
  a.TransactionType,          
  a.Checker1,           
  a.Checker2,          
  b.KodeToko,          
  c.Alamat,           
  c.Kota,           
  c.WilID,          
  a.isClosed,           
  a.Catatan1,           
  a.Catatan2,           
  a.Catatan3,           
  a.Catatan4,           
  a.Catatan5,           
  a.SyncFlag,           
  a.LinkID,           
  a.NPrint,           
  a.LastUpdatedBy,           
  a.LastUpdatedTime,          
  b.NoDO,          
  b.TglDO,           
  b.NoRequest,          
  b.TglRequest,          
  b.Disc1,          
  b.Disc2,          
  b.Disc3,          
  b.DiscFormula,          
  a.HariKredit,          
  b.HariKirim,          
  b.HariSales,          
  b.Catatan1,          
  b.Catatan2,          
  b.Catatan3,          
  b.Catatan4,          
  b.StatusBatal,          
  b.RowID,          
  b.Cabang1,          
  b.Cabang2,          
  b.Expedisi,          
  b.KodeSales,          
  d.NamaSales,      
  c.NamaToko,           
  c.KodeToko,       
  a.TglSerahTerimaChecker  
GO


 
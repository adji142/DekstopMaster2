 USE [ISAdb]
GO

/****** Object:  View [dbo].[vwNotaPenjualanDetail]    Script Date: 09/15/2011 16:12:01 ******/
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
 a.HtrID,        
 a.RecordID,            
 a.KodeGudang,            
 a.BarangID,            
 c.QtyRequest,            
 c.QtyDO,            
 a.QtySuratJalan,            
 a.QtyNota,            
 d.TglDO,            
 b.DOID,        
 b.RecordID AS TRID,        
 b.NoNota,            
 b.TglNota,            
 b.TglTerima,            
 b.TglSuratJalan,            
 b.NoSuratJalan,            
 b.TransactionType,            
 d.KodeToko,            
 d.KodeSales,            
 d.Expedisi,            
 a.HrgJual,            
 (dbo.fnGetHPP(a.BarangID, b.TglSuratJalan)) AS HPPSolo,           
 (dbo.fnGetHPPA(a.BarangID,b.TglSuratJalan)) AS HargaPokok,          
 a.DiscFormula,            
 a.Disc1,            
 a.Disc2,            
 a.Disc3,            
 a.Pot,            
 d.Cabang1,            
 d.Cabang2,            
 d.Cabang3,            
 b.HariKredit,            
 d.HariKirim,            
 d.HariSales,            
 d.Kota,            
 d.Shift,            
 a.QtyKoli,            
 d.NoDO,          
 b.TglSerahTerimaChecker,          
 d.NoACCPiutang,          
 d.TglRequest,        
 a.syncflag      
FROM dbo.NotaPenjualanDetail a (NOLOCK)            
LEFT OUTER JOIN dbo.NotaPenjualan b (NOLOCK) ON a.HeaderID = b.RowID            
LEFT OUTER JOIN dbo.OrderPenjualanDetail c (NOLOCK) ON c.RowID = a.DODetailID            
LEFT OUTER JOIN dbo.OrderPenjualan d (NOLOCK) ON d.RowID = b.DOID 
GO



 USE [ISAdb]
GO

/****** Object:  View [dbo].[KoreksiReturPenjualan_FOXPRO]    Script Date: 09/15/2011 17:24:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[KoreksiReturPenjualan_FOXPRO]
AS
SELECT  
 k.RecordID,   
 '' as IdTr,  
 k.ReturJualDetailRecID AS DetailID,   
 k.TglKoreksi,   
 k.NoKoreksi,   
 s.BarangID,  
 s.NamaStok AS NamaStok,  
 SUBSTRING(s.BarangID, 1, 3) AS KelompokBarang,  
 s.SatJual AS Satuan,  
 k.QtyNotaBaru,   
 k.HrgJualBaru,   
 '0' AS HrgPokok,  
 n.Disc1,  
 n.Disc2,  
 n.Disc3,  
 --n.DiscFormula AS id_disc
 n.Pot AS Potongan,  
 k.Catatan,   
 p.KodeToko,   
 p.KodeSales,  
 k.Sumber,   
 k.LinkID,   
 n.KodeGudang,  
 k.HrgJualKoreksi,   
 k.QtyNotaKoreksi,   
 k.SyncFlag  
FROM  
 dbo.KoreksiReturPenjualan k WITH (NOLOCK)  
 INNER JOIN dbo.ReturPenjualanDetail r WITH (NOLOCK)   ON r.RowID = k.ReturJualDetailID  
 INNER JOIN dbo.NotaPenjualanDetail n WITH (NOLOCK)   ON n.RowID = r.NotaJualDetailID  
 INNER JOIN dbo.NotaPenjualan nota WITH (NOLOCK)   ON nota.RowID = n.HeaderID
 --INNER JOIN dbo.OrderPenjualanDetail o WITH (NOLOCK)   ON o.RowID = n.DODetailID  
 INNER JOIN dbo.OrderPenjualan p WITH (NOLOCK)   ON p.RowID = nota.DOID
 INNER JOIN dbo.Stok s WITH (NOLOCK)  ON s.BarangID = n.BarangID  

GO



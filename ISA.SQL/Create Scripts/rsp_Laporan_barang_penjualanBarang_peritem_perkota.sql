 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================    
-- Author:  Feri    
-- Create date: 01 Mei 2011    
-- Description: Get Laporan penjualan barang perItem PerKota  
-- =============================================    
--[rsp_Laporan_barang_penjualanBarang_peritem_perkota]   @FromDate='2010/02/01',@ToDate='2010/02/23',@barangID='FB4BAPL05200',@CabangID='09'  
ALTER PROCEDURE [dbo].[rsp_Laporan_barang_penjualanBarang_peritem_perkota]     
 @FromDate datetime = null,  
 @ToDate datetime = null,  
 @cabangId varchar(12) = null,  
 @barangId varchar(12) = null  
AS
BEGIN  
SELECT   
  x.Kota,  
  x.QtySuratJalan,  
  x.Omzet,  
  (CASE (x.OMzet) WHEN '' THEN '' ELSE x.HPP END )  
  AS HPP  
FROM(  
 SELECT  
   d.Kota,  
   ISNULL((SUM(  
    (ISNULL(a.QtySuratJalan,0)*(dbo.fnHitungNet3Disc(c.HrgJual,c.Disc1,c.Disc2,c.Disc3,c.DiscFormula)-c.Pot))  
    +  
       (ISNULL(rd.QtyGudang,0)*(dbo.fnHitungNet3Disc(c.HrgJual,c.Disc1,c.Disc2,c.Disc3,c.DiscFormula)-c.Pot))  
    +  
    ISNULL(kp.HrgJualKoreksi,0)  
    +  
    ISNULL(kr.HrgJualKoreksi,0)  
    )),'')AS Omzet,  
   sum(ISNULL(a.QtySuratJalan,0) + ISNULL(rd.QtyGudang,0)+ ISNULL(kp.QtyNotaKoreksi,0 ) + ISNULL(kr.QtyNotaKoreksi,0)) as QtySuratJalan,  
   SUM(  
    (ISNULL(a.QtySuratJalan,0)*dbo.fnGetHargaBeli(c.BarangID, c.TglSuratJalan,NULL))  
    +  
    (ISNULL(rd.QtyGudang,0)*dbo.fnGetHargaBeli(c.BarangID, c.TglSuratJalan,NULL))  
    +  
    ISNULL((kp.QtyNotaKoreksi * dbo.fnGetHargaBeli(c.BarangID,kp.TglKoreksi,NULL)),0)--HargaPokok  
       +  
    ISNULL((kr.QtyNotaKoreksi * dbo.fnGetHargaBeli(c.BarangID,kr.TglKoreksi,NULL)),0)--HargaPokok  
    )AS HPP  
     
 FROM dbo.NotaPenjualan b   
 LEFT OUTER JOIN dbo.OrderPenjualan d with (nolock) ON d.RowID = b.DOID   
 LEFT OUTER JOIN dbo.OrderPenjualanDetail c with (nolock)  ON c.HeaderID = d.RowID   AND (c.BarangID = @barangId OR @barangId IS NULL)  
 LEFT OUTER JOIN dbo.NotaPenjualanDetail a with (nolock)      ON a.DODetailID = c.RowID   
 LEFT OUTER JOIN dbo.ReturPenjualanDetail rd with (nolock)  ON rd.NotaJualDetailID   = a.RowID  
 LEFT OUTER JOIN dbo.KoreksiPenjualan  kp with (nolock)      ON kp.NotaJualDetailID   = a.RowID  
 LEFT OUTER JOIN dbo.KoreksiReturPenjualan kr with (nolock)     ON kr.ReturJualDetailID  = a.RowID   
 LEFT OUTER JOIN dbo.Toko t with (nolock)      ON d.KodeToko=t.KodeToko  
    WHERE     
    (b.TglSuratJalan BETWEEN @FromDate AND @ToDate) AND (d.Cabang1 = @cabangId OR @cabangId IS NULL)  
    GROUP BY d.Kota  
 ) x  
  ORDER BY x.Kota  
END
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


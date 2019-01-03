
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================        
-- Author:  Feri        
-- Create date: 02 Mei 2011        
-- Description: Get Laporan penjualan barang perItem      
-- Example : exec [rsp_Laporan_barang_penjualanBarang_peritem] @FromDate = '2010-02-01',@ToDate='2010-02-23',@barangId='FB4BAPL05200',@kelompok = 'FB4'     
-- =============================================      
ALTER PROCEDURE [dbo].[rsp_Laporan_barang_penjualanBarang_peritem]         
@FromDate datetime = null,      
 @ToDate datetime = null,      
 @cabangId varchar(12) = null,      
 @barangId varchar(12) = null,      
 @kota     varchar(25) = null,      
 @kodeToko  varchar(31) = null,      
 @kodeSales varchar(11) = null,      
 @kodegudang varchar(4) = null,      
 @jenis varchar(10) = null,      
 @kelompok varchar(4) = null      
AS
BEGIN      
      
select      
 t.Kota,      
    np.cabang1,      
    np.barangId as BarangID,      
    t.TokoID as KodeToko,      
    t.NamaToko,      
    t.WilID,      
    np.KodeSales,      
    np.TglSuratJalan,      
    np.NoNota,      
    st.NamaStok as NamaBarang, 
    (CASE @jenis
    WHEN 'bruto'
       THEN   
       (ISNULL(np.QtySuratJalan,0)*(dbo.fnHitungNet3Disc(np.HrgJual,np.Disc1,np.Disc2,np.Disc3,np.DiscFormula)-np.Pot))      
    WHEN 'netto'
	   THEN
       (ISNULL(np.QtySuratJalan,0)*(dbo.fnHitungNet3Disc(np.HrgJual,np.Disc1,np.Disc2,np.Disc3,np.DiscFormula)-np.Pot)- isnull(vw.HrgNetto2,0))      
    END) AS JumlahBruto,
    np.NoDO,      
    st.satjual as Satuan, 
     ( CASE @jenis
		WHEN 'bruto' THEN     
        (isnull(np.QtySuratJalan,0))      
        WHEN 'netto' THEN
		(isnull(np.QtySuratJalan,0) - isnull(vw.QtyGudang,0))
		END      
   	 ) AS Quantity,
    dbo.fnGetStatusLaba(np.TglDO,st.RecordId,np.kodetoko,np.cabang1)as StatusLaba,      
    np.KodeGudang      
FROM  dbo.vwNotaPenjualanDetail as np with(nolock)       
left outer join dbo.vwReturPenjualanDetail as vw with(nolock) on vw.NotaJualDetailID = np.RowID and (vw.TglGudang between @FromDate and @ToDate)      
LEFT OUTER JOIN dbo.Toko t ON np.KodeToko= t.KodeToko       
INNER JOIN dbo.Stok st ON np.BarangID = st.BarangID      
where np.TglSuratJalan between @FromDate and @ToDate      
      and (np.BarangID = @barangId OR @barangId is null)      
      and (np.Kota = @kota  OR  @kota is null)      
      and (t.kodetoko = @kodeToko OR @kodeToko is null)      
      and (np.cabang1 = @cabangId OR @cabangId is null)      
      and (np.KodeSales = @kodeSales OR @kodeSales is null)      
      and (np.kodegudang = @kodegudang OR @kodegudang is null)      
      AND (LEFT(NP.BarangID,3) = @kelompok OR @kelompok is null)  
ORDER BY T.kota,T.Namatoko, np.TglSuratJalan ASC  
END
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

 
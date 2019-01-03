
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================  
-- Author  : FERI   
-- Create date :  9 - May - 2011  
-- Description : Report Register jual perkelompok barang  
--    :   THIS WAS GENERATED FOR REPORT REGISTER RETUR JUAL PER KELOMPOK BARANG  
-- Example  :   Exec dbo.[rsp_Laporan_register_returjual_perkelompokbarang] @STARTDATE= '2010/02/01', @ENDDATE='2010/02/03',@OPTION = '1'  
-- ===============================================  
-- [dbo].[rsp_Laporan_register_returjual_perkelompokbarang]   
ALTER PROCEDURE [dbo].[rsp_Laporan_register_returjual_perkelompokbarang]   
@STARTDATE AS DATETIME = NULL,  
@ENDDATE AS DATETIME = NULL,  
@OPTION AS VARCHAR(1) = NULL  
AS
BEGIN  
SET NOCOUNT ON  
  
DECLARE @KELOMPOK VARCHAR(3);  
DECLARE @nota TABLE    
(    
  NoNota varchar(7),  
  TglNota datetime,      
  KLP varchar(3),    
  Unit int,    
  Nilai money    
)    
 INSERT INTO @nota  
 SELECT   
    A.NONOTARETUR as NoNota,  
    CASE WHEN (@OPTION = '1') THEN  
        A.TGLNOTARETUR  
     ELSE  
  A.TGLGUDANG  
 END  
    AS TglNota,      
    SUBSTRING(BARANGID,1,3) AS KLP,   
    A.QTYGUDANG AS Unit,  
    (ISNULL(A.QtyGudang,0)*(dbo.fnHitungNet3Disc(A.HrgJual,A.Disc1,A.Disc2,A.Disc3,A.DiscFormula)-A.Pot)) AS Nilai  
    from dbo.VWRETURPENJUALANDETAIL as A with (NOLOCK)  
 INNER JOIN DBO.KELOMPOKBARANG AS KEL WITH (NOLOCK) ON KEL.KELOMPOKBRGID = LEFT(A.BARANGID,3)   
 INNER JOIN dbo.ReturPenjualan as B with (nolock) on a.ReturID = b.ReturID  
 LEFT OUTER JOIN DBO.TOKO AS T WITH (NOLOCK) ON T.KODETOKO = A.KODETOKO  
 where   
    (@OPTION = '1' AND (b.TGLNOTARETUR BETWEEN @STARTDATE AND @ENDDATE))       
     OR  
    (@OPTION = '2' AND (b.TGLGUDANG BETWEEN @STARTDATE AND @ENDDATE))     
  
SELECT    
k.Keterangan,    
k.KelompokBrgID AS KLP,    
n.TglNota,    
n.NoNota,    
n.Unit ,    
n.Nilai     
FROM dbo.KelompokBarang k with (nolock)   
LEFT OUTER JOIN @nota n ON k.KelompokBrgID = n.KLP     
ORDER BY n.TglNota, n.NoNota ASC    
  
SET NOCOUNT OFF  
END
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

 

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================      
-- Author  : FERI       
-- Create date :  6 - MaY - 2011      
-- Description : Report Retur Jual Per Nama Barang      
--      : THIS WAS GENERATED FOR REPORT RETUR JUAL PERNAMA BARANG      
-- ===============================================      
-- exec [dbo].[rsp_Laporan_returjual_pernamabarang] @CABANG = '09',@KODEGUDANG = '0901',@KODERETUR= '1',@STARTDATE= '2010/02/01',@ENDDATE ='2010/02/02'     
ALTER PROCEDURE [dbo].[rsp_Laporan_returjual_pernamabarang]       
@STARTDATE AS DATETIME = NULL,      
@ENDDATE AS DATETIME = NULL,      
@CABANG AS VARCHAR(2) = NULL,      
@KODEGUDANG AS VARCHAR(4) = NULL,      
@KODERETUR AS VARCHAR(1) = NULL,      
@KATEGORI AS VARCHAR(1) = NULL,      
@KODESALES AS VARCHAR(11) = NULL      
AS
BEGIN      
SET NOCOUNT ON      
select B.NOMPR as NoMPR,B.TGLMPR AS TglMPR,A.TGLGUDANG,A.NONOTARETUR AS NoNotaRetur,A.TGLNOTARETUR AS TglNotaRetur,    
B.TGLTOLAK as TglTolak,B.NOTOLAK as NoTolak,T.NAMATOKO as NamaToko,    
T.WILID as WilID,A.NAMASALES as NamaSales,A.NOTAASAL as NotaAsal,A.NAMASTOK as NamaBarang,    
LEFT(A.BARANGID,3) AS KelBarang,      
A.HRGJUAL as HrgJual,A.QTYTARIK as QtyMPR, A.HRGNETTO1 as HrgNetto1,    
A.QTYGUDANG as QtyGudang,A.HRGNETTO2 as HrgNetto2,    
A.QTYTOLAK as QtyTolak,A.HRGNETTO3 as HrgNetto3,    
(SELECT TOP 1 KETERANGAN FROM DBO.KATEGORI WITH (NOLOCK) WHERE KATEGORI = A.KATEGORI)  as Kategori,
A.CATATAN1 as Catatan1,      
A.CATATAN2 as Catatan2,    
A.KODEGUDANG as KodeGudang    
from dbo.VWRETURPENJUALANDETAIL as A with (NOLOCK)
INNER JOIN dbo.ReturPenjualan as b with (nolock) on a.ReturID = b.ReturID      
LEFT OUTER JOIN DBO.TOKO AS T WITH (NOLOCK) ON T.KODETOKO = A.KODETOKO       
where b.TglMPR BETWEEN @STARTDATE AND @ENDDATE      
AND(A.Cabang1 = @CABANG OR @CABANG IS NULL)         
AND(A.KodeGudang = @KODEGUDANG OR @KODEGUDANG IS NULL)      
AND(A.KodeRetur = @KODERETUR OR @KODERETUR IS NULL)      
AND(A.KATEGORI = @KATEGORI OR @KATEGORI IS NULL)      
AND(A.KODESALES = @KODESALES OR @KODESALES IS NULL)      
ORDER BY B.NOMPR,A.NONOTARETUR ASC   
SET NOCOUNT OFF      
END
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

 
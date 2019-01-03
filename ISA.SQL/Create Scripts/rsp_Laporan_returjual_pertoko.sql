
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================      
-- Author:  Feri      
-- Create date: 02 Mei 2011      
-- Description: Get Laporan penjualan barang perItem    
-- Example : exec [rsp_Laporan_returjual_pertoko] @FromDate = '2006-02-01',@ToDate='2010-09-23',@kodetoko='2005080209:50:07'    
-- =============================================    
ALTER PROCEDURE [dbo].[rsp_Laporan_returjual_pertoko]       
 @FromDate datetime = null,    
 @ToDate datetime = null,    
 @kodetoko  varchar(31) = null    
AS
BEGIN    
    

SELECT 
TglNotaRetur,NoNotaRetur,npd.NotaAsal as NotaAsal,npd.NamaStok as NamaBarang,npd.KodeSales,HrgNetto2 as HrgJual FROM DBO.vwReturPenjualanDetail AS NPD WITH (NOLOCK)    
INNER JOIN Toko AS T ON T.KODETOKO = NPD.KODETOKO       
      WHERE NPD.TglGudang BETWEEN  @FromDate AND @ToDate    
    AND NPD.KodeToko = @kodetoko     
ORDER BY TglNotaRetur desc    
    
END
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

 
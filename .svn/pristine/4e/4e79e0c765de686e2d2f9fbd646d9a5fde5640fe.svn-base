 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================        
-- Author      :   FERI         
-- Create date :   9 - May - 2011        
-- Description :   Report Rekap Retur Jual        
--      :   THIS WAS GENERATED FOR REPORT REKAP RETUR JUAL       
-- Example     :   Exec dbo.[rsp_laporan_toko_rekapreturjual] @STARTDATE= '2010/02/01', @ENDDATE='2010/02/05'      
-- ===============================================         
ALTER PROCEDURE [dbo].[rsp_laporan_toko_rekapreturjual]    
@STARTDATE AS DATETIME,    
@ENDDATE AS DATETIME    
AS
BEGIN    
 SELECT B.TGLRQRETUR as TglRQRetur,B.TglMPR,B.NoMPR,VW.TglGudang,VW.NoNotaRetur,VW.TglNotaRetur,    
 B.TGLTOLAK,B.NOTOLAK,T.NamaToko,T.Alamat,T.Kota, T.WilID, sum(ISNULL(VW.HrgNetto1,0)) as HrgNetto1,    
 SUM(ISNULL(VW.HrgNetto2,0)) as HrgNetto2,SUM(ISNULL(VW.HrgNetto,0)) as HrgNetto,SUM(ISNULL(VW.HrgNetto3,0)) as HrgNetto3,(SUM(ISNULL(VW.HrgNetto1,0)) - SUM(ISNULL(VW.HrgNetto2,0))) AS Selisih    
 FROM DBO.ReturPenjualan AS B WITH (NOLOCK)   
 LEFT OUTER JOIN DBO.VWRETURPENJUALANDETAIL AS VW WITH (NOLOCK) ON B.RETURID = VW.RETURID    
 LEFT OUTER JOIN DBO.TOKO AS T WITH (NOLOCK) ON T.KODETOKO = VW.KODETOKO     
 where B.TglMPR BETWEEN @STARTDATE AND @ENDDATE     
 GROUP BY B.TGLRQRETUR,B.TglMPR,B.NoMPR,VW.TGLGUDANG,VW.NONOTARETUR,VW.TGLNOTARETUR,    
 B.TGLTOLAK,B.NOTOLAK,T.Alamat,T.NAMATOKO,T.KOTA,T.WILID    
 ORDER BY TGLMPR,B.NoMPR ASC    
END
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Pembelian_RegisterPembelian]    Script Date: 10/20/2011 08:38:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
            
-- =====================================================================            
-- Author:  Stephanie            
-- Create date: 25 Apr 2011            
-- Description: Pembelian > Laporan > Pembelian > Register Pembelian            
-- =====================================================================            
ALTER PROCEDURE [dbo].[rsp_Pembelian_RegisterPembelian]             
 -- Add the parameters for the stored procedure here            
  @fromDate datetime,            
  @toDate datetime,            
  @tipeTgl varchar(2), -- 'NT' -- TglNota, 'TR' = TglTerima            
  @kodeGudang varchar(4) = NULL            
AS            
BEGIN            
 -- SET NOCOUNT ON added to prevent extra result sets from            
 -- interfering with SELECT statements.            
 SET NOCOUNT ON;            
 SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;            
              
    -- Insert statements for procedure here            
             
 SELECT             
  k.Keterangan,            
  k.KelompokBrgID AS KLP,            
  nota.TglSuratJalan,            
  nota.NoNota,            
  nota.Unit,            
  nota.Nilai            
            
 FROM dbo.KelompokBarang k            
            
  LEFT OUTER JOIN            
  (            
   SELECT            
    nh.TglSuratJalan,            
    nh.NoNota,            
    LEFT(nd.BarangID, 3) AS KLP,            
    SUM( (CASE WHEN @tipeTgl = 'NT' THEN nd.QtyNota ELSE nd.QtySuratJalan END) ) AS Unit,            
    SUM(           
  (          
   dbo.fnHitungNet3Disc(           
    (           
     CASE WHEN @tipeTgl = 'NT'             
      THEN       
      --dbo.fnGetHargaBeli(nd.BarangID,nh.TglNota, '')               
      nd.HrgBeli    
      ELSE           
       dbo.fnGetHPP(nd.BarangID, nh.TglNota) --nd.HPPSolo           
     END          
    ), nd.Disc1, nd.Disc2, nd.Disc3, '' ) - nd.Pot) * (CASE WHEN @tipeTgl = 'NT' THEN nd.QtyNota ELSE nd.QtySuratJalan END)           
   ) AS Nilai          
   FROM dbo.NotaPembelian nh            
    INNER JOIN dbo.NotaPembelianDetail nd ON nh.RowID = nd.HeaderID            
               
   WHERE              
    ( (@tipeTgl = 'NT' AND (nh.TglNota BETWEEN @fromDate AND @toDate) )            
     OR             
    (@tipeTgl = 'TR' AND (nh.TglTerima BETWEEN @fromDate AND @toDate) ) )            
    AND             
    (nd.KodeGudang = @kodeGudang OR @kodeGudang IS NULL)            
    --AND LEFT(nd.BarangID, 3) != 'FXB'                
           
            
   GROUP BY nh.TglSuratJalan, nh.NoNota, LEFT(nd.BarangID, 3)             
  ) nota ON k.KelompokBrgID = nota.KLP            
            
  ORDER BY k.Keterangan ASC, k.KelompokBrgID ASC, nota.TglSuratJalan ASC, nota.NoNota ASC            
END 
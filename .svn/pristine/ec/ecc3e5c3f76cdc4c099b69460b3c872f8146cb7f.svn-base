USE [ISADBDepoNonRetail]
GO
/****** Object:  StoredProcedure [dbo].[usp_OrderPenjualan_INSERT]    Script Date: 01/29/2013 13:55:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
-- =============================================          
-- Author:  Gemma          
-- Create date:  14 Januari 2011          
-- Description: Insert table OrderPenjualan          
-- =============================================          
ALTER PROCEDURE [dbo].[usp_OrderPenjualan_INSERT]           
  -- Add the parameters for the stored procedure here          
  -- CheckerID, FirstName, LastName, Alamat, Kota, Masuk, Keluar          
  @RowID uniqueidentifier,        
  @HtrID varchar(23),           
  @Cabang1 varchar(2),           
  @Cabang2 varchar(2),           
  @Cabang3 varchar(2),           
  @NoRequest varchar(7),           
  @TglRequest datetime,           
  @NoDO varchar(7),           
  @TglDO datetime,           
  @NoACCPusat varchar(7),           
  @ACCPiutangID varchar(11),           
  @NoACCPiutang varchar(7),           
  @TglACCPiutang datetime=null,           
  @StatusBatal varchar(7),           
  @HariKredit int,           
  @KodeToko varchar(19),           
  @KodeSales varchar(11),      
  @StsToko varchar(2),         
  @AlamatKirim varchar(60),           
  @Kota varchar(20),           
  @DiscFormula varchar(7),           
  @Disc1 decimal(5,2),           
  @Disc2 decimal(5,2),           
  @Disc3 decimal(5,2),         
  -- Tambahan Fefe          
  @RpACCPiutang money,        
  @RpPlafonToko money,        
  @RpPiutangTerakhir money,        
  @RpGiroTolakTerakhir money,        
  @RpOverdue money,          
  @Shift varchar(1),        
  --------------------        
  @isClosed bit,           
  @Catatan1 varchar(40),           
  @Catatan2 varchar(40),           
  @Catatan3 varchar(40),           
  @Catatan4 varchar(40),           
  @Catatan5 varchar(40),           
  @NoDOBO varchar(7),           
  @TglReorder datetime=null,           
  @StatusBO bit,           
  @SyncFlag bit,           
  @LinkID varchar(1),           
  @TransactionType varchar(2),           
  @Expedisi varchar(3),           
  @HariKirim int,           
  @HariSales int,           
  @NPrint int,    
  @Cicil int,    
  @LastUpdatedBy varchar(250)          
AS          
BEGIN          
 -- SET NOCOUNT ON added to prevent extra result sets from          
 -- interfering with SELECT statements.          
 SET NOCOUNT ON;          
 --SET XACT_ABORT ON    
          
    -- Insert statements for procedure here          
-- DECLARE @closingFromDate DATETIME    
-- DECLARE @closingToDate DATETIME     
-- DECLARE @periode VARCHAR(150)    
--    
--SELECT @closingFromDate=TglAwal,     
--@closingToDate=TglAkhir    
--FROM dbo.fnGetClosingStok('PJT',GETDATE())    
--    
--select @periode ='Periode ' + CONVERT(VARCHAR(10),@closingFromDate,105) + ' s/d '+CONVERT(VARCHAR(10),@closingToDate,105) + ' Sudah Tutup Buku'    
--    
--    
--BEGIN TRY    
--    
-- IF @TglDO<=@closingTodate    
-- BEGIN    
--  RAISERROR(@periode,12,1)    
-- END          
       
 INSERT INTO ISADBDepoRetail.dbo.OrderPenjualan          
 (          
  RowID,           
  HtrID,           
  Cabang1,           
  Cabang2,           
  Cabang3,           
  NoRequest,           
  TglRequest,           
  NoDO,           
  TglDO,           
  NoACCPusat,           
  ACCPiutangID,           
  NoACCPiutang,           
  TglACCPiutang,           
  StatusBatal,           
  HariKredit,           
  KodeToko,           
  KodeSales,      
  StsToko,         
  AlamatKirim,           
  Kota,           
  DiscFormula,           
  Disc1,           
  Disc2,           
  Disc3,           
  -- Tambahan Fefe        
  RpACCPiutang,        
  RpPlafonToko,        
  RpPiutangTerakhir,        
  RpGiroTolakTerakhir,        
  RpOverdue,         
  Shift,        
  -----------------          
  isClosed,           
  Catatan1,           
  Catatan2,           
  Catatan3,           
  Catatan4,           
  Catatan5,           
  NoDOBO,           
  TglReorder,           
  StatusBO,           
  SyncFlag,           
  LinkID,           
  TransactionType,           
  Expedisi,           
  HariKirim,           
  HariSales,           
  NPrint,     
  Cicil,          
  LastUpdatedBy,           
  LastUpdatedTime          
 )          
 SELECT           
  @RowID,           
  @HtrID,           
  @Cabang1,           
  @Cabang2,           
  @Cabang3,           
  @NoRequest,           
  @TglRequest,           
  @NoDO,           
  @TglDO,           
  '',           
  @ACCPiutangID,           
  @NoACCPiutang,           
  @TglACCPiutang,           
  @StatusBatal,           
  @HariKredit,           
  @KodeToko,           
  @KodeSales,        
  @StsToko,       
  @AlamatKirim,           
  @Kota,           
  @DiscFormula,           
  @Disc1,           
  @Disc2,            
  @Disc3,           
-- Tambahan Fefe        
  @RpACCPiutang,        
  @RpPlafonToko,        
  @RpPiutangTerakhir,        
  @RpGiroTolakTerakhir,        
  @RpOverdue,          
  @Shift,        
  -----------------          
  @isClosed,           
  @Catatan1,           
  @Catatan2,           
  @Catatan3,           
  @Catatan4,           
  @Catatan5,           
  @NoDOBO,           
  @TglReorder,           
  @StatusBO,       
  1,          
  --@SyncFlag,       
  @LinkID,           
  @TransactionType,           
  @Expedisi,           
  @HariKirim,           
  @HariSales,           
  --dbo.fnGetHariSales (@KodeToko, @TransactionType),    
  @NPrint,    
  @Cicil,           
  @LastUpdatedBy,           
  GETDATE()          
-- END TRY    
--    
--BEGIN CATCH    
--    
-- DECLARE @ErrorMessage NVARCHAR(4000);    
-- SELECT @ErrorMessage = ERROR_MESSAGE();    
-- RAISERROR (@ErrorMessage, 16, 1);    
--    
--END CATCH            
    
    
END          
          
/*    
 SET NOCOUNT ON;          
 SET XACT_ABORT ON    
          
    -- Insert statements for procedure here          
 DECLARE @closingFromDate DATETIME    
 DECLARE @closingToDate DATETIME     
 DECLARE @periode VARCHAR(150)    
    
SELECT @closingFromDate=TglAwal,     
@closingToDate=TglAkhir    
FROM dbo.fnGetClosingStok('PJT',GETDATE())    
    
select @periode ='Periode ' + CONVERT(VARCHAR(10),@closingFromDate,105) + '-'+CONVERT(VARCHAR(10),@closingToDate,105) + ' Sudah Tutup Buku'    
BEGIN TRANSACTION;    
    
BEGIN TRY    
    
IF @TglDO<=@closingTodate    
BEGIN    
     
 RAISERROR(@periode,12,1)    
--     
-- RAISERROR('Periode '+ CONVERT(VARCHAR(10),@closingFromDate,105) + '-'+     
--  CONVERT(VARCHAR(10),@closingToDate,105) + ' Sudah Tutup Buku',10,1)    
END          
  BEGIN TRAN          
 INSERT INTO dbo.OrderPenjualan          
 (          
  RowID,           
  HtrID,           
  Cabang1,           
  Cabang2,           
  Cabang3,           
  NoRequest,           
  TglRequest,           
  NoDO,           
  TglDO,           
  NoACCPusat,           
  ACCPiutangID,           
  NoACCPiutang,           
  TglACCPiutang,           
  StatusBatal,           
  HariKredit,           
  KodeToko,           
  KodeSales,      
  StsToko,         
  AlamatKirim,           
  Kota,           
  DiscFormula,           
  Disc1,           
  Disc2,           
  Disc3,           
  -- Tambahan Fefe        
  RpACCPiutang,        
  RpPlafonToko,        
  RpPiutangTerakhir,        
  RpGiroTolakTerakhir,        
  RpOverdue,         
  Shift,        
  -----------------          
  isClosed,           
  Catatan1,           
  Catatan2,           
  Catatan3,           
  Catatan4,           
  Catatan5,           
  NoDOBO,           
  TglReorder,           
  StatusBO,           
  SyncFlag,           
  LinkID,           
  TransactionType,           
  Expedisi,           
  HariKirim,           
  HariSales,           
  NPrint,           
  LastUpdatedBy,           
  LastUpdatedTime          
 )          
 SELECT           
  @RowID,           
  @HtrID,           
  @Cabang1,           
  @Cabang2,           
  @Cabang3,           
  @NoRequest,           
  @TglRequest,           
  @NoDO,           
  @TglDO,           
  '',           
  @ACCPiutangID,           
  @NoACCPiutang,           
  @TglACCPiutang,           
  @StatusBatal,           
  @HariKredit,           
  @KodeToko,           
  @KodeSales,        
  @StsToko,       
  @AlamatKirim,           
  @Kota,         
  @DiscFormula,           
  @Disc1,           
  @Disc2,            
  @Disc3,           
-- Tambahan Fefe        
  @RpACCPiutang,        
  @RpPlafonToko,        
  @RpPiutangTerakhir,        
  @RpGiroTolakTerakhir,        
  @RpOverdue,          
  @Shift,        
  -----------------          
  @isClosed,           
  @Catatan1,           
  @Catatan2,           
  @Catatan3,           
  @Catatan4,           
  @Catatan5,           
  @NoDOBO,           
  @TglReorder,           
  @StatusBO,       
  1,          
  --@SyncFlag,       
  @LinkID,           
  @TransactionType,           
  @Expedisi,           
  @HariKirim,           
  --@HariSales,           
  dbo.fnGetHariSales (@KodeToko, @TransactionType),    
  @NPrint,           
  @LastUpdatedBy,           
  GETDATE()          
  COMMIT TRAN    
 END TRY    
    
BEGIN CATCH    
    
 DECLARE @ErrorMessage NVARCHAR(4000);    
 SELECT @ErrorMessage = ERROR_MESSAGE();    
 RAISERROR (@ErrorMessage, 16, 1);    
    WHILE @@TRANCOUNT > 0    
        ROLLBACK TRANSACTION;    
END CATCH            
    
WHILE @@TRANCOUNT > 0    
    COMMIT TRANSACTION;    
    
    
    
*/

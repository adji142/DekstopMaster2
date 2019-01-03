USE [ISADBDepoNonRetail]
GO
/****** Object:  StoredProcedure [dbo].[usp_OrderPenjualanDetail_INSERT]    Script Date: 01/29/2013 13:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =================================================    
-- Author:  Stephanie    
-- Create date: 17 Jan 11    
-- Description: Insert table Order Penjualan Detail    
-- EXEC [usp_OrderPenjualanDetail_INSERT] '','','','','','',''

-- =================================================    
ALTER PROCEDURE [dbo].[usp_OrderPenjualanDetail_INSERT]     
 -- Add the parameters for the stored procedure here    
  @rowID uniqueidentifier,
  @headerID uniqueidentifier,    
  @recordID varchar(23),    
  @htrID varchar(23),    
  @barangID varchar(23),    
  @qtyRequest int,    
  @qtyDO int,    
  @hrgJual money,     
  @disc1 decimal (5, 2),    
  @disc2 decimal (5, 2),    
  @disc3 decimal (5, 2),    
  @pot money,    
  @discFormula varchar(7),    
  @noDOBO varchar(7),    
  @noACC varchar(7),    
  @catatan varchar(23),    
  -- ************************************    
  @nboPrint varchar(50), -- tambahan fefe    
  -- ************************************    
  @syncFlag bit,    
  @lastUpdatedBy varchar(250)    
AS    
BEGIN    
 -- SET NOCOUNT ON added to prevent extra result sets from    
 -- interfering with SELECT statements.    
 SET NOCOUNT ON;    
    
    -- Insert statements for procedure here    
--    DECLARE @closingFromDate DATETIME  
-- DECLARE @closingToDate DATETIME   
-- DECLARE @TglDO DATETIME  
-- DECLARE @periode VARCHAR(150)  
--  
-- SELECT @TglDO=TglDO FROM dbo.OrderPenjualan (NOLOCK)  
-- WHERE RowID=@HeaderID  
--  
-- SELECT @closingFromDate=TglAwal,   
-- @closingToDate=TglAkhir  
-- FROM dbo.fnGetClosingStok('PJT',@TglDO)  
--   
--  
--  
-- select @periode ='Periode ' + CONVERT(VARCHAR(10),@closingFromDate,105) + ' s/d '+CONVERT(VARCHAR(10),@closingToDate,105) + ' Sudah Tutup Buku'  
--  
--  
--BEGIN TRY  
--  
-- IF @TglDO<=@closingTodate  
-- BEGIN  
--  RAISERROR(@periode,12,1)  
-- END        
          
 INSERT INTO  ISADBDepoRetail.dbo.OrderPenjualanDetail 
 (    
  RowID,     
  HeaderID,     
  RecordID,     
  HtrID,     
  BarangID,     
  QtyRequest,     
  QtyDO,     
  HrgJual,       
  Disc1,     
  Disc2,     
  Disc3,     
  Pot,     
  DiscFormula,     
  NoDOBO,     
  NoACC,     
  -- ************************************    
  NBOPrint, -- tambahan fefe    
  -- ************************************    
  Catatan,     
  SyncFlag,     
  LastUpdatedBy,     
  LastUpdatedTime    
 )    
 SELECT       
 @rowID,     
  @headerID,     
  @recordID,     
  @htrID,     
  @barangID,     
  @qtyRequest,     
  @QtyDO,     
  @hrgJual,        
  @disc1,     
  @disc2,     
  @disc3,     
  @pot,     
  @discFormula,     
  @noDOBO,     
  @noACC,     
  -- ************************************    
  @nboPrint, -- tambahan fefe    
  -- ************************************    
  @catatan,   
  1,    
  --@syncFlag,     
  @lastUpdatedBy,    
  GETDATE()    
--END TRY  
--  
--BEGIN CATCH  
--  
-- DECLARE @ErrorMessage NVARCHAR(4000);  
-- SELECT @ErrorMessage = ERROR_MESSAGE();  
-- RAISERROR (@ErrorMessage, 16, 1);  
--  
--END CATCH    
exec dbo.psp_OrderPenjualan_RefreshSummary_DODetailID @rowID
END

USE [ISAdb]
GO

IF OBJECT_ID ('[dbo].[fnCekGiro]') IS NOT NULL
DROP FUNCTION [dbo].[fnCekGiro]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================    
-- Author:  Feri    
-- Create date: 4/4/2011    
-- Description: Mencari Status Laba    
-- =============================================    
ALTER FUNCTION [dbo].[fnGetStatusLaba]     
(    
 -- Add the parameters for the function here     
 @tglDo datetime,   
 @stokId varchar(23),    
 @kodetoko varchar(19),  
 @cabang1 varchar(2)  
)    
RETURNS varchar(2)    
AS
BEGIN    
 -- Declare the return variable here    
 DECLARE @statusLaba varchar(2)    
 declare @cIdc varchar(2)  
 set @cIdc = dbo.fnGetStatusToko(@tglDo,@kodetoko,@cabang1)  
 IF RIGHT(@cIdc,1) = '1'  
  SELECT TOP 1  @statusLaba = StatusLaba    
  FROM dbo.HistoryBMK with (NOLOCK)    
  WHERE     
    StokID = @stokId and   
    TglAktif <= @tglDo and   
    keterangan <> 'K'  
 ORDER BY StokID DESC    
  RETURN  @statusLaba  
END
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


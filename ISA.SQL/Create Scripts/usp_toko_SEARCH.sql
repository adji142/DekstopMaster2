USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Toko_SEARCH]') IS NOT NULL
DROP PROC [dbo].[usp_Toko_SEARCH] 
GO


/****** Object:  StoredProcedure [dbo].[usp_Sales_SEARCH]    Script Date: 01/12/2011 15:50:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Gemma
-- Create date: 05 Januari 2011
-- Description:	Search data on table Sales
-- Example : [usp_Sales_SEARCH] null
--			 [usp_Sales_SEARCH] "02"
-- =============================================
ALTER PROCEDURE [dbo].[usp_Sales_SEARCH] 
	-- Add the parameters for the stored procedure here
	@searchArg varchar(250),
	@tokoID varchar(19) = null
	--@RowID uniqueidentifier = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		 
		a.SalesID, 
		a.SalesName, 		
		--RecID, 		
		a.TglLahir, 
		a.Alamat, 
		a.Target, 
		a.BatasOD, 
		a.TglMasuk, 
		a.TglKeluar, 
		--SyncFlag, 
		a.LastUpdatedBy, 
		a.LastUpdatedTime
	FROM dbo.Sales a
	WHERE 		
		a.SalesID LIKE @searchArg + '%'
		OR a.SalesName LIKE '%' + @searchArg + '%'
	
    
END





GO






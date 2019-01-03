USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Sales_SEARCH]') IS NOT NULL
DROP PROC [dbo].[usp_Sales_SEARCH] 
GO

/****** Object:  StoredProcedure [dbo].[usp_Sales_SEARCH]    Script Date: 01/13/2011 18:02:29 ******/
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
CREATE PROCEDURE [dbo].[usp_Sales_SEARCH] 
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
		a.RowID,
		a.SalesID, 
		a.NamaSales, 		
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
		OR a.NamaSales LIKE '%' + @searchArg + '%'
	
    
END







GO



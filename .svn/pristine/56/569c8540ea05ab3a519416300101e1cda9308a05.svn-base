USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Sales_LIST]') IS NOT NULL
DROP PROC [dbo].[usp_Sales_LIST] 
GO


/****** Object:  StoredProcedure [dbo].[usp_Sales_LIST]    Script Date: 01/13/2011 09:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Gemma
-- Create date: 05 Januari 2011
-- Description:	List data on table Sales
-- Example : usp_LIST_Sales null
--			 usp_LIST_Sales "02"
-- =============================================
ALTER PROCEDURE [dbo].[usp_Sales_LIST] 
	-- Add the parameters for the stored procedure here
	@namaSales varchar(23) = null
	--@RowID uniqueidentifier = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		--RowID,
		SalesID, 
		--RecID, 
		NamaSales, 
		TglLahir, 
		Alamat, 
		Target, 
		BatasOD, 
		TglMasuk, 
		TglKeluar, 
		--SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM dbo.Sales		
	WHERE 	(NamaSales Like '%' +  @namaSales  + '%' OR @namaSales IS NULL)
    
END














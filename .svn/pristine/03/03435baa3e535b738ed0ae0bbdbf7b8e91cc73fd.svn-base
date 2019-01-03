USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Sales_INSERT]') IS NOT NULL
DROP PROC [dbo].[usp_Sales_INSERT] 
GO


/****** Object:  StoredProcedure [dbo].[usp_Sales_INSERT]    Script Date: 01/13/2011 09:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Gemma
-- Create date: 05 Januari 2011
-- Description:	Insert table Sales
-- =============================================
ALTER PROCEDURE [dbo].[usp_Sales_INSERT] 
	-- Add the parameters for the stored procedure here
	 @RowID uniqueidentifier, 
	 @SalesID varchar(11), 
	 @RecID varchar(23), 
	 @NamaSales varchar(23), 
	 @TglLahir datetime, 
	 @Alamat varchar(30), 
	 @Target numeric(16,2), 
	 @BatasOD numeric(16,2), 
	 @TglMasuk datetime, 
	 @TglKeluar datetime, 
	 @SyncFlag bit,
	 @LastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
        	
	INSERT INTO dbo.Sales
	(
		RowID, 
		SalesID, 
		RecID, 
		NamaSales, 
		TglLahir, 
		Alamat, 
		Target, 
		BatasOD, 
		TglMasuk, 
		TglKeluar, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
	SELECT 
		@RowID, 
		@SalesID, 
		@RecID, 
		@namaSales, 
		@TglLahir, 
		@Alamat, 
		@Target, 
		@BatasOD, 
		@TglMasuk, 
		@TglKeluar, 
		@SyncFlag, 
		@LastUpdatedBy, 
		GETDATE()
	
END






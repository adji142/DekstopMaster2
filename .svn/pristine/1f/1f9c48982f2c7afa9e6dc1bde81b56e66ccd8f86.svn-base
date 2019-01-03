USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_INSERT_Cabang]') IS NOT NULL
DROP PROC [dbo].[usp_INSERT_Cabang] 
GO

/****** Object:  StoredProcedure [dbo].[usp_INSERT_Cabang]    Script Date: 12/01/2010 14:19:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Raymon
-- Create date: 01 Dec 10
-- Description:	Insert table Cabang
-- =============================================
CREATE PROCEDURE [dbo].[usp_Cabang_INSERT] 
	-- Add the parameters for the stored procedure here
	 @cabangID varchar(2),
	 @nama varchar(25),
	 @telModem varchar(12),
	 @alamat1 varchar(40),
	 @alamat2 varchar(40) ,
	 @kota varchar(25),
	 @lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
        	
	INSERT INTO dbo.Cabang 
	(
		CabangID, 
		Nama, 
		TelModem, 
		Alamat1, 
		Alamat2, 
		Kota,
		LastUpdatedBy,
		LastUpdatedTime
	)
	SELECT 
		@cabangID, 
		@nama, 
		@telModem, 
		@alamat1, 
		@alamat2, 
		@kota,
		@lastUpdatedBy,
		GETDATE()
	
END


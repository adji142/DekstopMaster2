USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_KelompokBarang_INSERT]') IS NOT NULL
DROP PROC [dbo].[usp_KelompokBarang_INSERT] 
GO

/****** Object:  StoredProcedure [dbo].[usp_KelompokBarang_INSERT]    Script Date: 01/07/2011 11:40:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Stephanie
-- Create date: 04 Jan 11
-- Description:	Insert table KelompokBarang
-- =============================================
CREATE PROCEDURE [dbo].[usp_KelompokBarang_INSERT] 
	-- Add the parameters for the stored procedure here
	 @kelompokBrgID varchar(3),
	 @keterangan varchar(17),
	 @kelompok varchar(1),
	 @mainACC varchar(7),
	 @subACC varchar(10),
	 @lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
        	
	INSERT INTO dbo.KelompokBarang
	(
		KelompokBrgID, 
		Keterangan, 
		Kelompok, 
		MainACC, 
		SubACC, 
		NoPerk, 
		NopRj, 
		NopStk, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
	SELECT 
		@kelompokBrgID, 
		@keterangan, 
		@kelompok, 
		@mainACC, 
		@subACC, 
		NULL, 
		NULL, 
		NULL,
		@lastUpdatedBy,
		GETDATE()
	
END





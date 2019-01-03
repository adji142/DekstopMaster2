USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_KelompokBarang_LIST]') IS NOT NULL
DROP PROC [dbo].[usp_KelompokBarang_LIST] 
GO

/****** Object:  StoredProcedure [dbo].[usp_KelompokBarang_LIST]    Script Date: 01/07/2011 11:43:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		Stephanie
-- Create date: 04 Jan 11
-- Description:	List data on table KelompokBarang
-- =============================================
CREATE PROCEDURE [dbo].[usp_KelompokBarang_LIST] 
	-- Add the parameters for the stored procedure here
	@kelompokBrgID varchar(3) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		kelompokBrgID, 
		Keterangan, 
		Kelompok, 
		MainACC, 
		SubACC, 
		NoPerk, 
		NopRj, 
		NopStk, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM dbo.KelompokBarang		
	WHERE
	(KelompokBrgID = @kelompokBrgID OR @kelompokBrgID IS NULL)
    
END







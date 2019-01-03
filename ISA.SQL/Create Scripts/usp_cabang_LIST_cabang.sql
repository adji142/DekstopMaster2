USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_LIST_Cabang]') IS NOT NULL
DROP PROC [dbo].[usp_LIST_Cabang] 
GO

/****** Object:  StoredProcedure [dbo].[usp_LIST_Cabang]    Script Date: 12/01/2010 14:19:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Raymon
-- Create date: 01 Dec 10
-- Description:	List data on table Cabang
-- Example : usp_LIST_Cabang null
--			 usp_LIST_Cabang "02"
-- =============================================
CREATE PROCEDURE [dbo].[usp_Cabang_LIST] 
	-- Add the parameters for the stored procedure here
	@cabangID varchar(2) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		CabangID, 
		Nama, 
		TelModem, 
		Alamat1, 
		Alamat2, 
		Kota,
		LastUpdatedBy,
		LastUpdatedTime
	FROM dbo.Cabang  		
	WHERE
	(CabangID = @cabangID OR @cabangID IS NULL)
    
END

GO
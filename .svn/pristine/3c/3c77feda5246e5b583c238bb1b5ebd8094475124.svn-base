USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_GetNet3Disc]') IS NOT NULL
DROP PROC [dbo].[usp_GetNet3Disc] 
GO

/****** Object:  StoredProcedure [dbo].[usp_GetNet3Disc]    Script Date: 01/18/2011 09:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================================
-- Author:		Stephanie
-- Create date: 17 Jan 11
-- Description:	Get HrgNet3Disc from Function dbo.fnHitungNet3Disc
-- ===============================================================
ALTER PROCEDURE [dbo].[usp_GetNet3Disc] 
	-- Add the parameters for the stored procedure here
	@jmlHrg money, 
	@disc1 decimal(5,2), 
	@disc2 decimal(5,2), 
	@disc3 decimal(5,2), 
	@discFormula varchar(7)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT dbo.fnHitungNet3Disc (@jmlHrg, @disc1, @disc2, @disc3, @discFormula) AS HrgNet3Disc
END

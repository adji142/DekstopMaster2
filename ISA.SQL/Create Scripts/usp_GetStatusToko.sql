USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_GetStatusToko]') IS NOT NULL
DROP PROC [dbo].[usp_GetStatusToko] 
GO

-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Gemma
-- Create date: 17 Januari 2011
-- Description:	Get Status Toko from Function dbo.fnGetStatusToko
-- =============================================
CREATE PROCEDURE usp_GetStatusToko 
	-- Add the parameters for the stored procedure here
	@tglDO datetime,
	@kodeToko varchar(19),
	@c1 varchar(2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT dbo.fnGetStatusToko (@tglDO, @kodeToko, @c1) 
END
GO
 
USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[fnGetHPP]') IS NOT NULL
DROP FUNCTION [dbo].[fnGetHPP] 
GO

/****** Object:  UserDefinedFunction [dbo].[fnGetHPP]    Script Date: 01/18/2011 11:06:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Stephanie
-- Create date: 17/1/2011
-- Description:	Mencari HPP
-- =============================================
ALTER FUNCTION [dbo].[fnGetHPP] 
(
	-- Add the parameters for the function here	
	@barangID varchar(23),
	@tglDO datetime
)
RETURNS money
AS
BEGIN
	-- Declare the return variable here

	DECLARE @hpp money

	SET @hpp = 1

	/* Cari HPP */

	SELECT TOP 1
		@hpp = HPP
	FROM dbo.HistoryHPP
	WHERE 
		TglAktif <= @tglDO  
		AND BarangID = @barangID
	ORDER BY TglAktif DESC


	RETURN @hpp

END
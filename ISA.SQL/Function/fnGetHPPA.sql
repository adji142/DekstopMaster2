USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[fnGetHPPA]') IS NOT NULL
DROP FUNCTION [dbo].[fnGetHPPA] 
GO

/****** Object:  UserDefinedFunction [dbo].[fnGetHPPA]    Script Date: 01/18/2011 11:05:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Stephanie
-- Create date: 17/1/2011
-- Description:	Mencari HPPA
-- =============================================
ALTER FUNCTION [dbo].[fnGetHPPA] 
(
	-- Add the parameters for the function here	
	@barangID varchar(23),
	@tglDO datetime
)
RETURNS money
AS
BEGIN
	-- Declare the return variable here

	DECLARE @hppa money

	SET @hppa = 1

	/* Cari HPP */

	SELECT TOP 1
		@hppa = HPPAverage
	FROM dbo.HistoryHPPA
	WHERE 
		TglAktif <= @tglDO  
		AND BarangID = @barangID
	ORDER BY TglAktif DESC


	RETURN @hppa

END

 
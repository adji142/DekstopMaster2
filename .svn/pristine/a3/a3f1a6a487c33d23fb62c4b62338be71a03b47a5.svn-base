USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[fnGetHrgBMK]') IS NOT NULL
DROP FUNCTION [dbo].[fnGetHrgBMK] 
GO


/****** Object:  UserDefinedFunction [dbo].[fnGetHrgBMK]    Script Date: 01/24/2011 16:37:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===================================================
-- Author:		Stephanie
-- Create date: 24 Jan 11
-- Description:	Function to Return HrgB, HrgM and HrgK
-- ===================================================
ALTER FUNCTION [dbo].[fnGetHrgBMK] 
(	
	-- Add the parameters for the function here
	@barangId varchar(23),
	@tglDo datetime
)
RETURNS @result 
TABLE 
(
	BrgRecID varchar(23), 
	HargaB money, 
	HargaM money, 
	HargaK money,
	TglAktif datetime,
	TglPasif datetime
)
AS
BEGIN
	-- Add the SELECT statement with parameter references here
	INSERT INTO @result 
	SELECT TOP 1
		a.StokID,
		a.HrgJualB,
		a.HrgJualM,
		a.HrgJualK,
		a.TglAktif,
		a.TglPasif
	FROM dbo.HistoryBMK a LEFT OUTER JOIN dbo.Stok b ON a.StokID = b.RecordID
	WHERE b.BarangID = @barangID 
	AND (a.TglAktif <= @tglDO)
	AND (a.TglPasif > @tglDO OR a.TglPasif IS NULL)
	ORDER BY a.TglAktif DESC
	RETURN
END

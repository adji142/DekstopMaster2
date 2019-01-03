USE [ISAdb]
GO

IF OBJECT_ID ('[dbo].[fnCekPlafon_1]') IS NOT NULL
DROP FUNCTION [dbo].[fnCekPlafon_1]
GO

/****** Object:  UserDefinedFunction [dbo].[fnCekPlafon_1]    Script Date: 03/14/2011 08:54:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- ==================================================
-- Author:		Stephanie
-- Create date: 14 Mar 2011
-- Description:	Cek Plafon Toko dari histori Plafon
-- ==================================================
ALTER FUNCTION [dbo].[fnCekPlafon_1] 
(
	-- Add the parameters for the function here	
	@kodeToko varchar(19),
	@tgl datetime
)
RETURNS money
AS
BEGIN
	-- Declare the return variable here
	DECLARE @plafon money
	DECLARE @tglAkhir datetime
	DECLARE @tglAwal datetime

	SET @plafon = 0

	SET @tglAwal = @tgl
	SET @tglAkhir = DATEADD(DAY, -1, DATEADD(MONTH, 1, @tgl))

	SELECT TOP 1
		@plafon = (CASE WHEN PlafonAkhir > 0 THEN PlafonAkhir ELSE PlafonAwal END)
	FROM dbo.DetailPlafon
	WHERE 
		KodeToko = @kodeToko
		AND (Tanggal BETWEEN @tglAwal AND @tglAkhir) 
	ORDER BY Tanggal DESC	

	RETURN @plafon

END

/*
*-------------------------------*
FUNCTION Cek_Plf(cKd_Toko, dTgl2)
*-------------------------------*
LOCAL nPlf, cAwal, cAkhir
nPlf  = 0 
cAwal = cKd_Toko+DTOS(Firstday(dTgl2))
cAkhir= cKd_Toko+DTOS(Lastday(dTgl2))
IF SELECT("dplafon")=0
   USE dplafon IN 0 SHARED 
ENDIF 
SELECT dPlafon 
SET ORDER TO kd_tokod IN Dplafon
SET KEY TO 
SET KEY TO RANGE cAwal,cAkhir IN Dplafon 

GO TOP IN Dplafon
DO WHILE !EOF("dPlafon") AND dPlafon.Kd_Toko=ckd_Toko
   IF dplafon.tanggal >= Firstday(dTgl2) AND dplafon.tanggal <= Lastday(dTgl2)
      nPlf = IIF(dplafon.P_akhir>0, dplafon.P_akhir, dplafon.P_Awal)
      EXIT 
   ENDIF 
   SKIP IN dPlafon 
ENDDO 
USE IN dPlafon 
RETURN nPlf
*/






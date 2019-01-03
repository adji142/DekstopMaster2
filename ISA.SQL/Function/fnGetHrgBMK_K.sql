USE [ISAdb]
GO

IF OBJECT_ID ('[dbo].[fnGetHrgBMK_K]') IS NOT NULL
DROP FUNCTION [dbo].[fnGetHrgBMK_K]
GO

/****** Object:  UserDefinedFunction [dbo].[fnGetHrgBMK_K]    Script Date: 03/15/2011 15:25:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Stephanie
-- Create date: 14 Mar 2011
-- Description:	Get Harga Kecil dari BMK
-- =============================================
CREATE FUNCTION [dbo].[fnGetHrgBMK_K] 
(
	-- Add the parameters for the function here
	@stokID varchar(23),
	@tglAktif datetime
)
RETURNS money
AS
BEGIN
	DECLARE @result money
	SET @result = 0

	SELECT TOP 1
		@result = HrgJualK
	FROM dbo.HistoryBMK
	WHERE
		StokID = @stokID 
		AND
		TglAktif <= @tglAktif	
	ORDER BY TglAktif DESC
	
	RETURN @result

END

/*
PARAMETERS dTgl,cId_Stok
  LOCAL nJual
  nJual = 0
  IF !USED('Hist_bmk')
     USE Hist_bmk IN 0
  ENDIF
  SET ORDER TO Id_stok IN Hist_bmk
  SEEK cId_stok IN Hist_bmk
  IF FOUND('Hist_bmk')
     DO WHILE Hist_bmk.Id_stok = cId_stok AND !EOF('Hist_bmk')
        IF Hist_bmk.tmt > dTgl
           SKIP IN Hist_bmk
           LOOP
        ENDIF
        nJual = Hist_bmk.Hjual_k
        EXIT
      ENDDO
  ENDIF
  RETURN nJual
*/
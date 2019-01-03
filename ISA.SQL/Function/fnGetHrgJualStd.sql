USE [ISAdb]
GO

IF OBJECT_ID ('[dbo].[fnGetHrgJualStd]') IS NOT NULL
DROP FUNCTION [dbo].[fnGetHrgJualStd]
GO


/****** Object:  UserDefinedFunction [dbo].[fnGetHrgJualStd]    Script Date: 03/15/2011 15:25:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Stephanie
-- Create date: 14 Mar 2011
-- Description:	Get Harga Jual Standart
-- =============================================
CREATE FUNCTION [dbo].[fnGetHrgJualStd] 
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
		AND
		Keterangan != 'K'	
	ORDER BY TglAktif DESC
	
	RETURN @result

END

/*
**
FUNCTION V_hjstd
 LPARAMETERS dtgl, cidbrg
 LOCAL nhstd, cidrec
 nhstd = 0
 IF  .NOT. USED('Sasstok')
    USE Sasstok IN 0
 ENDIF
 SET ORDER TO Id_brg
 IF SEEK(cidbrg, 'Sasstok')
    IF  .NOT. USED('Hist_bmk')
       USE Hist_bmk IN 0
    ENDIF
    SET ORDER IN hist_bmk TO Id_stok
    SELECT hist_bmk
    SET KEY TO sasstok.idrec IN hist_bmk
    GOTO TOP IN hist_bmk
    DO WHILE  .NOT. EOF('Hist_bmk')
       IF hist_bmk.tmt<=dtgl
          IF hist_bmk.ket='K'
             SKIP IN hist_bmk
             LOOP
          ENDIF
          nhstd = hist_bmk.hjual_b
          EXIT
       ENDIF
    ENDDO
    USE
    SELECT hhtransj
 ENDIF
 RETURN nhstd
ENDFUNC
**
*/

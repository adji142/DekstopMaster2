USE [ISAdb]
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetHrgKhusus]    Script Date: 03/25/2011 14:03:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =======================================================
-- Author:		Stephanie
-- Create date: 25 Mar 11
-- Description:	Function to Return Hrg Khusus
-- ========================================================
ALTER FUNCTION [dbo].[fnGetHrgKhusus] 
(	
	-- Add the parameters for the function here
	@tglDO datetime,
	@stokID varchar(23)
)
RETURNS @result 
TABLE 
(
	HrgKhususB money,
	HrgKhususM money,
	HrgKhususK money	
)
AS
BEGIN
	-- Add the SELECT statement with parameter references here
	
	INSERT INTO @result
	SELECT TOP 1
		HrgJualB,
		HrgJualM,
		HrgJualK
	FROM dbo.HistoryBMK (NOLOCK)
	WHERE
		StokID = @stokID
		AND Keterangan != 'J'
		AND (TglPasif IS NULL OR TglPasif > @tglDO)
	ORDER BY TglAktif DESC
	
	RETURN
END

/*
   PARAMETERS dTgl,cId_Stok,nHB,nHM,nHKc
   && His_bmk2 tidak perlu... karena HKUSUS berlaku utk SMUA STATUS
   LOCAL nKhusus,cIdc
   cIdc = StsToko(Hhtransj.Tgl_do,Hhtransj.Kd_toko,Hhtransj.Cab1)
   IF !USED('Hist_bmk')
      USE Hist_bmk IN 0
   ENDIF
   SET ORDER TO Id_stok IN Hist_bmk
   SEEK cId_stok IN Hist_bmk
   DO WHILE Hist_bmk.Id_stok = cId_stok AND !EOF('Hist_bmk')
      IF Hist_bmk.Ket = 'J'
         SKIP IN Hist_bmk
         LOOP
      ENDIF
      IF !EMPTY(Hist_bmk.Tmt_pasif)
         IF Hist_bmk.tmt_pasif <= dTgl
            SKIP IN Hist_bmk
            EXIT
         ENDIF
      ENDIF
      nHB  = Hist_bmk.Hjual_b
      nHM  = Hist_bmk.Hjual_m
      nHKc = Hist_bmk.Hjual_k
      EXIT
   ENDDO
   RETURN
*/
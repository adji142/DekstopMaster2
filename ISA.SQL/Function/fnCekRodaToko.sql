 USE [ISAdb]
GO
/****** Object:  UserDefinedFunction [dbo].[fnCekRodaToko]    Script Date: 03/23/2011 15:21:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==================================================
-- Author:		Stephanie
-- Create date: 23 Mar 2011
-- Description:	Cek Roda Toko
-- ==================================================
CREATE FUNCTION [dbo].[fnCekRodaToko] 
(
	-- Add the parameters for the function here	
	@tgl datetime,
	@kodeToko varchar(19),
	@c1 varchar(2)
)
RETURNS varchar(1)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @rodaToko varchar(1)
	DECLARE @cabang varchar(2)

	SET @rodaToko = 4
	SET @cabang = @c1

	SELECT TOP 1
		@cabang = ISNULL(@c1, InitCabang)
	FROM dbo.Perusahaan

	SELECT TOP 1
		@rodaToko = Roda
	FROM dbo.StatusToko
	WHERE
		CabangID = @cabang AND KodeToko = @kodeToko
		AND (TglPasif IS NOT NULL OR TglPasif > @tgl)
	ORDER BY TglAktif DESC	

	RETURN @rodaToko

END

/*
**
FUNCTION RdToko
 LPARAMETERS dtgl, ckd_toko, cc1
 LOCAL crd, ccab
 IF  .NOT. USED('StsToko')
    USE StsToko IN 0
 ENDIF
 SET ORDER IN ststoko TO Kd_Tmt
 ccab = IIF( .NOT. EMPTY(cc1), cc1, cinitcab)
 SEEK ccab+ckd_toko IN ststoko 
 IF FOUND('StsToko')
    DO WHILE ststoko.c1+ststoko.kd_toko=ccab+ckd_toko .AND.  .NOT. EOF('StsToko')
       IF ststoko.tmt<=dtgl
          IF  .NOT. EMPTY(ststoko.tmt_pasif) .AND. ststoko.tmt_pasif<dtgl
             SKIP IN ststoko
             LOOP
          ENDIF
          crd = ststoko.rd
          EXIT
       ENDIF
       SKIP IN ststoko
    ENDDO
 ENDIF
 IF EOF('StsToko') .OR. ststoko.kd_toko<>ckd_toko
    crd = '4'
 ENDIF
 RETURN crd
ENDFUNC
**
*/






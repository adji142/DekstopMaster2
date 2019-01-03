USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[fnGetStatusToko]') IS NOT NULL
DROP FUNCTION [dbo].[fnGetStatusToko] 
GO

/****** Object:  UserDefinedFunction [dbo].[fnGetStatusToko]    Script Date: 01/18/2011 11:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 12/1/2011
-- Description:	Mencari Status Toko
-- =============================================
ALTER FUNCTION [dbo].[fnGetStatusToko] 
(
	-- Add the parameters for the function here	
	@tglDO datetime,
	@kodeToko varchar(19),
	@c1 varchar(2)
)
RETURNS varchar(2)
AS
BEGIN
	-- Declare the return variable here

	DECLARE @stsToko varchar(2)
	DECLARE @stsOtomatis varchar(2)
	DECLARE @cabang varchar(2)
			
	SET @stsOtomatis = NULL

	/* Cari Status Otomatis */

	SELECT TOP 1
		@stsOtomatis = [Status]
	FROM dbo.StatusToko
	WHERE 
		TglAktif <= @tglDO AND TglPasif > @tglDO 
		AND KStatus = 'O' 
		AND KodeToko = @kodeToko 
		AND CabangID = @c1
	ORDER BY TglAktif DESC


	/* Cari Status Toko dari status asli */

	SET @stsToko = 'K1'
	IF (NOT EXISTS (SELECT RowID FROM dbo.StatusToko WHERE KodeToko = @kodeToko 
		AND CabangID = @c1))
		SET @stsToko = 'K1'

	IF ISNULL(@cabang, '') = ''
	BEGIN
		SELECT TOP 1 
			@cabang = InitCabang 
		FROM dbo.Perusahaan	
	END

	SELECT TOP 1
		@stsToko = [Status]
	FROM dbo.StatusToko
	WHERE 
		TglAktif <= @tglDO 
		AND (TglPasif > @tglDO OR TglPasif IS NULL)
		AND KodeToko = @kodeToko 
		AND CabangID = @cabang
	ORDER BY TglAktif DESC
	
	

	/* Cari Status Toko bila status otomatis tidak sama dengan null*/

	IF (@stsOtomatis IS NOT NULL)
	BEGIN
		IF (LEFT(@stsOtomatis, 1) = 'B' AND LEFT(@stsToko, 1) = 'M')
			SET @stsToko = @stsOtomatis
		ELSE IF (LEFT(@stsOtomatis, 1) = 'M' AND LEFT(@stsToko, 1) = 'K')
			SET @stsToko = @stsOtomatis		
	END
		

	RETURN @stsToko

END

/*
 **
FUNCTION StsToko
 LPARAMETERS dtgl, ckd_toko, c1
 LOCAL csts, ccab, csotm, nselect
 csotm = ' '
 nselect = SELECT()
 IF  .NOT. USED('StsToko')
    USE StsToko ORDER Kd_Tmt IN 0
 ENDIF
 SET ORDER IN ststoko TO Kd_Tmt
 csotm = stsotm(dtgl, ckd_toko, c1)
 ccab = IIF( .NOT. EMPTY(c1), c1, cinitcab)
 SEEK ccab+ckd_toko IN ststoko 
 IF FOUND('StsToko')
    DO WHILE ststoko.c1+ststoko.kd_toko=ccab+ckd_toko .AND.  .NOT. EOF('StsToko')
       IF DTOS(ststoko.tmt)<=DTOS(dtgl)
          IF  .NOT. EMPTY(ststoko.tmt_pasif) .AND. DTOS(ststoko.tmt_pasif)<DTOS(dtgl)
             SKIP IN ststoko
             LOOP
          ENDIF
          csts = ststoko.sts
          EXIT
       ENDIF
       SKIP IN ststoko
    ENDDO
 ENDIF
 IF EOF('Ststoko') .OR. ststoko.kd_toko<>ckd_toko
    csts = 'K1'
 ENDIF
 IF  .NOT. EMPTY(csotm)
    IF LEFT(csotm, 1)='B' .AND. LEFT(csts, 1)='M'
       csts = csotm
    ELSE
       IF LEFT(csotm, 1)='M' .AND. LEFT(csts, 1)='K'
          csts = csotm
       ENDIF
    ENDIF
 ENDIF
 SELECT (nselect)
 RETURN csts
ENDFUNC
**
FUNCTION StsOtm
 LPARAMETERS dt, ckd_toko, cab1
 LOCAL cstso, ccab, nselect
 nselect = SELECT()
 ccab = IIF( .NOT. EMPTY(cab1), cab1, cinitcab)
 SELECT ststoko
 SET KEY TO
 SET KEY TO  RANGE cinitcab+ckd_toko, cinitcab+ckd_toko IN ststoko
 DO WHILE  .NOT. EOF('Ststoko')
    IF ststoko.ksts<>'O'
       SKIP IN ststoko
       LOOP
    ENDIF
    IF DTOS(ststoko.tmt)<=DTOS(dt)
       IF DTOS(ststoko.tmt_pasif)<DTOS(dt)
          SKIP IN ststoko
          LOOP
       ENDIF
       cstso = ststoko.sts
       EXIT
    ENDIF
    SKIP IN ststoko
 ENDDO
 SET KEY TO
 SELECT (nselect)
 RETURN cstso
ENDFUNC
**
*/

USE [ISAdb]
GO
/****** Object:  UserDefinedFunction [dbo].[fnHitungHrgJual]    Script Date: 04/27/2011 15:15:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Stephanie
-- Create date: 14/1/2011
-- Description:	Hitung Harga Jual
-- =============================================
CREATE FUNCTION [dbo].[fnHitungHrgJual] 
(
	-- Add the parameters for the function here	
	@tglDO datetime,
	@barangID varchar(23),
	@stsToko varchar(2) = NULL,
	@qtyDO int,
	@kodeToko varchar(19),
	@c1 varchar(2)
)
RETURNS money
AS
BEGIN
	-- Declare the return variable here

	DECLARE @rodaToko varchar(1)
	DECLARE @stokRecID varchar(23)
	DECLARE @hrgJual money
	DECLARE @hrgKhusus money
	DECLARE @cabang varchar(2)

	/* Cari status Toko */
	IF (@stsToko IS NULL)
	BEGIN
		SET @stsToko = dbo.fnGetStatusToko(@tglDO, @kodeToko, @c1)
	END

	/* Cari Harga Khusus */
	
	SET @hrgKhusus = 0
	SET	@stsToko = dbo.fnGetStatusToko(@tglDO, @kodeToko, @c1)

	SELECT TOP 1 
	@hrgKhusus = 
		CASE  
		WHEN QtyMinB != 0 AND QtyMinM != 0 
		THEN
			CASE 
				WHEN @qtyDO >= QtyMinB THEN HrgJualB
				WHEN @qtyDO < QtyMinB AND @qtyDO >= QtyMinM THEN HrgJualM
				WHEN @qtyDO < QtyMinM THEN HrgJualK
			END
		ELSE
			CASE 
				WHEN LEFT(@stsToko, 1) = 'B' THEN HrgJualB 
				WHEN LEFT(@stsToko, 1) = 'M' THEN HrgJualM
				WHEN LEFT(@stsToko, 1) = 'K' THEN HrgJualK
			END
		END				
	FROM dbo.HistoryBMK(NOLOCK)
	WHERE
		StokID = @stokRecID AND Keterangan != 'J'
		AND (TglPasif IS NOT NULL OR TglPasif > @tglDO)
	ORDER BY TglAktif DESC


	/* Cari Roda Toko */

	SET @rodaToko = dbo.fnCekRodaToko(@tglDO, @kodeToko, @c1)
	

	/* Cari Harga Jual */

	SET @hrgJual = 0
	
	SELECT	@stokRecID = RecordID
	FROM dbo.STok
	WHERE BarangID = @barangID 
		
	SET @hrgKhusus = ISNULL(@hrgKhusus, 0)	

	IF (@hrgKhusus > 0)
		SET @hrgJual = @hrgKhusus
	ELSE
	BEGIN
		SELECT TOP 1 
		@hrgJual = 
			CASE  
			WHEN (QtyMinB != 0 AND QtyMinM != 0) 
			THEN
				CASE
					WHEN @qtyDO >= QtyMinB THEN HrgJualB
					WHEN @qtyDO < QtyMinB AND @qtyDO >= QtyMinM THEN HrgJualB
					WHEN @qtyDO < QtyMinM THEN HrgJualK
				END
			ELSE
				CASE 
					WHEN LEFT(@stsToko, 1) = 'B' THEN HrgJualB 
					WHEN LEFT(@stsToko, 1) = 'M' THEN HrgJualM
					WHEN LEFT(@stsToko, 1) = 'K' THEN HrgJualK
				END
			END		
		
		FROM dbo.HistoryBMK(NOLOCK)
		WHERE
			StokID = @stokRecID AND Keterangan != 'K'
			AND (TglAktif <= @tglDO)
		ORDER BY TglAktif DESC
	END

	RETURN @hrgJual

END

/*
 **
FUNCTION H_Jual
 LPARAMETERS dtgl, cid_brg, cidc, nj_do
 LOCAL crd, cid_stok, njual, nhk, nselect
 crd = ' '
 njual = 0
 nhk = 0
 nselect = SELECT()
 IF  .NOT. USED('Sasstok')
    USE Sasstok IN 0
 ENDIF
 SET ORDER IN sasstok TO Id_brg
 SEEK cid_brg IN sasstok 
 cid_stok = sasstok.idrec
 nhk = h_kusus(dtgl, cid_stok, cidc, nj_do)
 nhk = IIF(ISNULL(nhk), 0, nhk)
 crd = rdtoko(hhtransj.tgl_do, hhtransj.kd_toko, hhtransj.cab1)
 IF nhk>0
    njual = nhk
 ELSE
    cidc = ststoko(hhtransj.tgl_do, hhtransj.kd_toko, hhtransj.cab1)
    IF  .NOT. USED('Hist_bmk')
       USE Hist_bmk IN 0
    ENDIF
    SET ORDER IN hist_bmk TO Id_stok
  
    IF RIGHT(cidc, 1)='1'
       SEEK cid_stok IN hist_bmk 
       IF FOUND('Hist_bmk')
          DO WHILE hist_bmk.id_stok=cid_stok .AND.  .NOT. EOF('Hist_bmk')
             IF hist_bmk.tmt>dtgl .OR. hist_bmk.ket='K'
                SKIP IN hist_bmk
                LOOP
             ENDIF
             IF hist_bmk.qmin_b<>0 .AND. hist_bmk.qmin_m<>0
                DO CASE
                   CASE nj_do>=hist_bmk.qmin_b
                      njual = hist_bmk.hjual_b
                   CASE nj_do<hist_bmk.qmin_b .AND. nj_do>=hist_bmk.qmin_m
                      njual = hist_bmk.hjual_m
                   CASE nj_do<hist_bmk.qmin_m
                      njual = hist_bmk.hjual_k
                ENDCASE
             ELSE
                DO CASE
                   CASE LEFT(cidc, 1)='B'
                      njual = hist_bmk.hjual_b
                   CASE LEFT(cidc, 1)='M'
                      njual = hist_bmk.hjual_m
                   OTHERWISE
                      njual = hist_bmk.hjual_k
                ENDCASE
             ENDIF
             EXIT
             SKIP IN hist_bmk
          ENDDO
       ELSE
          njual = 1
       ENDIF
    ENDIF
 ENDIF
 SELECT (nselect)
 RETURN njual
ENDFUNC
**
FUNCTION H_kusus
 LPARAMETERS dtgl, cid_stok, cidc, nj_do
 LOCAL nkhusus
 nkhusus = 0
 cidc = ststoko(hhtransj.tgl_do, hhtransj.kd_toko, hhtransj.cab1)
 IF  .NOT. USED('Hist_bmk')
    USE Hist_bmk IN 0
 ENDIF
 SET ORDER IN hist_bmk TO Id_stok
 SEEK cid_stok IN hist_bmk 
 DO WHILE hist_bmk.id_stok=cid_stok .AND.  .NOT. EOF('Hist_bmk')
    IF hist_bmk.ket='J'
       SKIP IN hist_bmk
       LOOP
    ENDIF
    IF  .NOT. EMPTY(hist_bmk.tmt_pasif)
       IF hist_bmk.tmt_pasif<=dtgl
          SKIP IN hist_bmk
          EXIT
       ENDIF
    ENDIF
    IF hist_bmk.qmin_b<>0 .AND. hist_bmk.qmin_m<>0
       DO CASE
          CASE nj_do>=hist_bmk.qmin_b
             nkhusus = hist_bmk.hjual_b
          CASE nj_do<hist_bmk.qmin_b .AND. nj_do>=hist_bmk.qmin_m
             nkhusus = hist_bmk.hjual_m
          CASE nj_do<hist_bmk.qmin_m
             nkhusus = hist_bmk.hjual_k
       ENDCASE
    ELSE
       DO CASE
          CASE LEFT(cidc, 1)='B'
             nkhusus = hist_bmk.hjual_b
          CASE LEFT(cidc, 1)='M'
             nkhusus = hist_bmk.hjual_m
          OTHERWISE
             nkhusus = hist_bmk.hjual_k
       ENDCASE
    ENDIF
    EXIT
 ENDDO
 RETURN nkhusus
ENDFUNC
**
*/

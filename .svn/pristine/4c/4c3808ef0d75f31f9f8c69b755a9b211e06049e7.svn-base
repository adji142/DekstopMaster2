USE [ISAdb]
GO

IF OBJECT_ID ('[dbo].[fnCekGiroTolak]') IS NOT NULL
DROP FUNCTION [dbo].[fnCekGiroTolak]
GO


/****** Object:  UserDefinedFunction [dbo].[fnCekGiroTolak]    Script Date: 03/14/2011 11:03:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ========================================================
-- Author:		Stephanie
-- Create date: 14 Mar 2011
-- Description:	Cek Giro Tolak Toko
-- ========================================================
CREATE FUNCTION [dbo].[fnCekGiroTolak] 
(	
	-- Add the parameters for the function here
	@kodeToko varchar(19),
	@tglAwal datetime,
	@tglAkhir datetime
)
RETURNS @result 
TABLE 
(
	GiroTolak1 money,
	GiroTolak2 money
)
AS
BEGIN
	DECLARE @giroTolak1 money
	DECLARE @giroTolak2 money

	SET @giroTolak1 = 0
	SET @giroTolak2 = 0

	DECLARE @tglGiro datetime
	DECLARE @tglBayar datetime
	DECLARE @debit money
	DECLARE @kredit money

	DECLARE GiroTolakCurs CURSOR FOR 
	SELECT 
		a.TglGiro, b.TglBayar, a.Debet, b.Kredit
	FROM dbo.BankGiroTolak a LEFT OUTER JOIN dbo.BankGiroTolakDetail b ON a.RecID = b.RecID
	WHERE 
		(a.KodeToko = @kodeToko) AND (a.TglGiro <= @tglAkhir)

	OPEN GiroTolakCurs

	FETCH NEXT FROM GiroTolakCurs
	INTO @tglGiro, @tglBayar, @debit, @kredit

	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF (@tglGiro < @tglAwal)
		BEGIN
			SET @giroTolak1 = @giroTolak1 + @debit
			SET @giroTolak2 = @giroTolak2 + @debit
		END
		ELSE -- (@tglGiro >= @tglAwal)
			SET @giroTolak2 = @giroTolak2 + @debit

		IF (@tglBayar < @tglAwal)
		BEGIN
			SET @giroTolak1 = @giroTolak1 - @kredit
			SET @giroTolak2 = @giroTolak2 - @kredit
		END
		ELSE -- (@tglBayar >= @tglAwal)
			SET @giroTolak2 = @giroTolak2 - @kredit

		FETCH NEXT FROM GiroTolakCurs
		INTO @tglGiro, @tglBayar, @debit, @kredit
	END

	CLOSE GiroTolakCurs
	DEALLOCATE GiroTolakCurs

	-- Add the SELECT statement with parameter references here
	INSERT INTO @result 
	SELECT 
		@giroTolak1,
		@giroTolak2
	RETURN
END

/*
*-----------------------------------------*
PROCEDURE cek_GiroTlk(ckd_Toko,d1,d2,n1,n2)
*-----------------------------------------*
STORE 0 TO n1,n2 
IF SEEK(cKd_toko,"HbgTolak")
   DO WHILE !EOF("HbgTolak") AND hBgtolak.kd_toko=ckd_toko
      && HBgTolak->Tgl_Giro : Tanggal terima bayar (masuk ke BKM & PIUTANG).
      && HBgTolak->Cbg_Jt   : Tanggal jatuh tempo Giro yang ditolak.

      IF HBgtolak.Tgl_Giro <= d2 
         do case
            case hbgtolak.Tgl_giro < d1  
                 n1 = n1+(hbgtolak->Debet)
                 n2 = n2+(hbgtolak->Debet)
            case hbgtolak.Tgl_Giro >= d1 .and. hbgtolak.Tgl_Giro <= d2
                 n2 = n2+(HbgTolak->Debet)
            case hbgtolak.Tgl_Giro > d2
                 SKIP IN hbgtolak
                 LOOP 
         endcase
         IF SEEK(hbgtolak.Idrec,"DbgTolak")
            DO WHILE (dBgTolak.Idrec=hBgTolak.Idrec) AND !EOF("dBGTolak")
               do case
                  case Dbgtolak.Tgl_Byr < d1  
                       n1 = n1-(Dbgtolak.Kredit)
                       n2 = n2-(Dbgtolak.Kredit)
                  case Dbgtolak.Tgl_Byr >= d1 .and. Dbgtolak.Tgl_Byr <= d2
                       n2 = n2-(DbgTolak.Kredit)
               endcase
               SKIP IN dbGtolak
            ENDDO 
         ENDIF 
      ENDIF 
      SKIP IN hBgTolak 
   ENDDO 
ENDIF 
*/
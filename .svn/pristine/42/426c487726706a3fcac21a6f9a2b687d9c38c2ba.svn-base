USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[fnCekSaldo]') IS NOT NULL
DROP FUNCTION [dbo].[fnCekSaldo] 
GO

/****** Object:  UserDefinedFunction [dbo].[fnCekSaldo]    Script Date: 03/11/2011 14:30:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ========================================================
-- Author:		Stephanie
-- Create date: 11 Mar 2011
-- Description:	Cek saldo nota, giro, belum jatuh tempo dan
--				rata2 bayar per 3 bulan
-- ========================================================
ALTER FUNCTION [dbo].[fnCekSaldo] 
(	
	-- Add the parameters for the function here
	@tglAwal datetime,
	@kodeToko varchar(19)
)
RETURNS @result 
TABLE 
(
	KodeToko varchar(19),
	Nota1 money,
	Nota2 money,
	Giro1 money,
	Giro2 money,
	BelumJT1 money,
	BelumJT2 money,
	Rata2Bayar money
)
AS
BEGIN
	DECLARE @nota1 money
	DECLARE @nota2 money
	DECLARE @giro1 money
	DECLARE @giro2 money
	DECLARE @belumJT1 money
	DECLARE @belumJT2 money  
	DECLARE @rata2Bayar money

	DECLARE @tglAwal1 datetime
	DECLARE @tglAkhir1 datetime

	DECLARE @nGiro money

	SET @nota1 = 0
	SET @nota2 = 0 
	SET @giro1 = 0
	SET @giro2 = 0
	SET @belumJT1 = 0
	SET @belumJT2 = 0
	SET @rata2Bayar = 0

	SET @tglAwal1 = DATEADD(MONTH, -3, @tglAwal)
	SET @tglAkhir1 = DATEADD(DAY, -1, @tglAwal)

	DECLARE @piutangDetailRecID varchar(23)
	DECLARE @tglTransaksi datetime
	DECLARE @kodeTransaksi varchar(10)
	DECLARE @tglJatuhTempo datetime
	DECLARE @debit money
	DECLARE @kredit money

	DECLARE PiutangCurs CURSOR FOR 
	SELECT 
		a.RecordID, a.TglTransaksi, a.KodeTransaksi, b.TglJatuhTempo, 
		a.Debet, a.Kredit
	FROM dbo.PiutangDetail a LEFT OUTER JOIN dbo.KartuPiutang b ON a.KPID = b.KPID
	WHERE a.KodeToko = @kodeToko AND b.KPID IS NOT NULL

	OPEN PiutangCurs

	FETCH NEXT FROM PiutangCurs
	INTO @piutangDetailRecID, @tglTransaksi, @kodeTransaksi, @tglJatuhTempo, @debit, @kredit

	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @nGiro = ISNULL(dbo.fnCekGiro(DATEADD(DAY, -1, @tglAwal), @piutangDetailRecID), 0)
		-- jika @nGiro = 0 artinya sudah cair 

		IF (@tglTransaksi < @tglAwal)
		BEGIN
			IF (@tglTransaksi >= @tglAwal1 AND @tglTransaksi <= @tglAkhir1) 
				AND ('BGC~KAS~TRN' LIKE '%' + @kodeTransaksi + '%')
			BEGIN
				SET @rata2Bayar = @rata2Bayar + @kredit
			END

			IF (@tglJatuhTempo < @tglAwal)
			BEGIN
				IF (@kodeTransaksi LIKE '%PJ%')
				BEGIN
					SET @nota1 = @nota1 + @debit
					SET @nota2 = @nota2 + @debit
				END
				ELSE
				BEGIN
					IF (@kodeTransaksi LIKE '%BG%')
					BEGIN
						SET @nota1 = @nota1 - (CASE WHEN @nGiro = 0 THEN @kredit ELSE @nGiro END)
						SET @nota2 = @nota2 - (CASE WHEN @nGiro = 0 THEN @kredit ELSE @nGiro END) 
						SET @giro1 = @giro1 + (CASE WHEN @nGiro = 0 THEN @nGiro ELSE @kredit END)
						SET @giro2 = @giro2 + (CASE WHEN @nGiro = 0 THEN @nGiro ELSE @kredit END)
					END
					ELSE -- IF (@kodeTransaksi NOT LIKE '%BG%' OR '%PJ%')
					BEGIN
						SET @nota1 = @nota1 + (@debit - @kredit)
						SET @nota2 = @nota2 + (@debit - @kredit)
					END
				END
			END
			ELSE -- IF (@tglJatuhTempo >= @tglAwal)
			BEGIN 
				IF (@kodeTransaksi LIKE '%PJ%')
				BEGIN
					SET @belumJT1 = @belumJT1 + @debit
				END

				ELSE
				BEGIN
					IF (@kodeTransaksi LIKE '%BG%')
					BEGIN
						SET @belumJT1 = @belumJT1 - (CASE WHEN @nGiro = 0 THEN @kredit ELSE @nGiro END)
					END
					
					ELSE -- IF (@kodeTransaksi NOT LIKE '%BG%' OR '%PJ%')
					BEGIN
						SET @belumJT1 = @belumJT1 + (@debit - @kredit)
					END
				END
			END
		END 

		ELSE -- IF (@tglTransaksi >= @tglAwal)
		BEGIN
			IF (@tglJatuhTempo < @tglAwal)
			BEGIN
				IF (@kodeTransaksi LIKE '%PJ%')
				BEGIN
					SET @nota2 = @nota2 + @debit
				END
				ELSE
				BEGIN
					IF (@kodeTransaksi LIKE '%BG%')
					BEGIN
						SET @nota2 = @nota2 - (CASE WHEN @nGiro = 0 THEN @kredit ELSE @nGiro END) 
						SET @giro2 = @giro2 + (CASE WHEN @nGiro = 0 THEN @nGiro ELSE @kredit END)
					END					
					ELSE -- IF (@kodeTransaksi NOT LIKE '%BG%' OR '%PJ%')
					BEGIN
						SET @nota1 = @nota1 + (@debit - @kredit)
					END
				END			
			END
			ELSE -- IF (@tglJatuhTempo >= @tglAwal)
			BEGIN IF (@kodeTransaksi LIKE '%PJ%')
				BEGIN
					SET @belumJT2 = @belumJT2 + @debit
				END
				ELSE
				BEGIN
					IF (@kodeTransaksi LIKE '%BG%')
					BEGIN
					SET @belumJT2 = @belumJT2 - (CASE WHEN @nGiro = 0 THEN @kredit ELSE @nGiro END)
					END					
					ELSE -- IF (@kodeTransaksi NOT LIKE '%BG%' OR '%PJ%')
					BEGIN
					SET @belumJT2 = @belumJT2 + (@debit - @kredit)
					END
				END
			END
		END

		FETCH NEXT FROM PiutangCurs
		INTO @piutangDetailRecID, @tglTransaksi, @kodeTransaksi, @tglJatuhTempo, @debit, @kredit
	END

	CLOSE PiutangCurs
	DEALLOCATE PiutangCurs

	-- Add the SELECT statement with parameter references here
	INSERT INTO @result 
	SELECT 
		@kodeToko,
		@nota1,
		@nota2,
		@giro1,
		@giro2,
		@belumJT1,
		@belumJT2,
		@rata2Bayar
	RETURN
END

/*
*--------------------------------------------*
PROCEDURE Cek_Saldo(cKd_Toko, dTglA, dTglB, nNota1, nNota2, nGiro1, nGiro2, nBJT1, nBJT2, nBayar)
*--------------------------------------------*
LOCAL dTglAwal, dTglAkhir, dDay
LOCAL nNota1, nGiro1, nNota2, nGiro2, nBJT1, nBJT2, nGiro, nBayar

STORE 0 TO nNota1, nGiro1, nNota2, nGiro2, nBJT1, nBJT2, nGiro, nBayar

dTglAkhir = firstday(dtglA)-1
dDay = dTglA
FOR i = 1 TO 3
    dDay = firstday(dDay)-1
    dTglAwal = firstday(dDay)
NEXT 

SELECT Dpiutang
SET KEY TO RANGE ckd_Toko, cKd_Toko IN Dpiutang
GO TOP IN dPiutang
DO WHILE !EOF("Dpiutang") AND dpiutang.kd_toko = cKd_toko
   IF !SEEK(Dpiutang.id_kp,"Kpiutang")
      SKIP IN dpiutang
      LOOP
   ENDIF  
   IF dpiutang.Tgl_Tr < dTglA
      IF dpiutang.Tgl_Tr >= dTglAwal AND dpiutang.Tgl_Tr <= dTglAkhir AND dPiutang.kd_trans $ "BGC~KAS~TRN~"
         nBayar = nBayar + dPiutang.Kredit
      ENDIF 
      IF Kpiutang.Tgl_JT < dTglA
         DO CASE 
            CASE 'PJ' $ dpiutang.kd_trans
                 nNota1 = nNota1 + dpiutang.Debet
                 nNota2 = nNota2 + dpiutang.Debet
            CASE 'BG' $ dpiutang.kd_trans 
                 nGiro  = cek_Giro(dTglA-1) 
                 && nGiro = 0 artinya sudah cair s/d (dTglA-1)
                 nGiro1 = nGiro1 + IIF(nGiro=0, nGiro, dPiutang.Kredit)
                 nNota1 = nNota1 - IIF(nGiro=0, dPiutang.Kredit, nGiro)
                 nGiro2 = nGiro2 + IIF(nGiro=0, nGiro, dPiutang.Kredit)
                 nNota2 = nNota2 - IIF(nGiro=0, dPiutang.Kredit, nGiro)
            OTHERWISE 
                 nNota1 = nNota1 + (dpiutang.debet - dpiutang.kredit)
                 nNota2 = nNota2 + (dpiutang.debet - dpiutang.kredit)
         ENDCASE  
      ELSE && Kpiutang.Tgl_JT >= dTglA
         DO CASE 
            CASE 'PJ' $ dpiutang.kd_trans
                 nBJT1  = nBJT1 + dpiutang.Debet
            CASE 'BG' $ dpiutang.kd_trans
                 nGiro  = cek_Giro(dTglA-1) 
                 && nGiro = 0 artinya sudah cair s/d (dTglA-1)
                 nBJT1  = nBJT1 - IIF(nGiro=0, dPiutang.Kredit, nGiro)
            OTHERWISE 
                 nBJT1  = nBJT1 + (dpiutang.debet - dpiutang.kredit)
         ENDCASE 
      ENDIF 
   ELSE && dpiutang.Tgl_Tr >= dTglA
      IF dpiutang.Tgl_Tr <= dTglB
         IF Kpiutang.Tgl_JT <= dTglB
            DO CASE 
               CASE 'PJ' $ dpiutang.kd_trans
                    nNota2 = nNota1 + dpiutang.Debet
               CASE 'BG' $ dpiutang.kd_trans
                    nGiro  = cek_Giro(dTglB) 
                    && nGiro = 0 artinya sudah cair s/d (dTglB)
                    nGiro2 = nGiro2 + IIF(nGiro=0, nGiro, dPiutang.Kredit)
                    nNota2 = nNota2 - IIF(nGiro=0, dPiutang.Kredit, nGiro)
               OTHERWISE 
                    nNota2 = nNota2 + (dpiutang.debet - dpiutang.kredit)
            ENDCASE
         ELSE && Kpiutang.Tgl_JT > dTglB
            DO CASE 
               CASE 'PJ' $ dpiutang.kd_trans
                    nBJT2  = nBJT2 + dpiutang.Debet
               CASE 'BG' $ dpiutang.kd_trans
                    nGiro  = cek_Giro(dTglB) 
                    && nGiro = 0 artinya sudah cair s/d (dTglB)
                    nBJT2  = nBJT2 - IIF(nGiro=0, dPiutang.Kredit, nGiro)
               OTHERWISE 
                    nBJT2  = nBJT2 + (dpiutang.debet - dpiutang.kredit)
            ENDCASE
         ENDIF 
      ENDIF 
   ENDIF
   
   SKIP IN Dpiutang
ENDDO 
*/

USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[fnHitTglJatuhTempo]') IS NOT NULL
DROP FUNCTION [dbo].[fnHitTglJatuhTempo] 
GO


/****** Object:  UserDefinedFunction [dbo].[fnHitTglJatuhTempo]    Script Date: 03/02/2011 18:03:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Stephanie
-- Create date: 01 03 2011
-- Description:	Menghitung TglJatuhTempo
-- =============================================
CREATE FUNCTION [dbo].[fnHitTglJatuhTempo] 
(
	-- Add the parameters for the function here	
	@transactionType varchar(2),
	@tglTerima datetime,
	@hariKredit int,
	@hariKirim int,
	@hariSales int
)
RETURNS datetime
AS
BEGIN
	-- Declare the return variable here

	DECLARE @tglJthTempo datetime

	IF (@transactionType = 'KO' OR @transactionType = 'KC' OR @transactionType = 'KJ' 
			OR @transactionType = 'KG' OR @transactionType = 'K2' OR @transactionType = 'K4')
	BEGIN
		/* TglJatuhTempo = TglTerima + HariExpedisi 
							+ (IIF(HariSelesai > 0, HariSelesai, HariKredit)) */
		SET @tglJthTempo = DATEADD(DAY, (CASE WHEN @hariSales > 0 THEN @hariSales ELSE @hariKredit END), 
							DATEADD(DAY, @hariKirim, @tglterima))
	END

	ELSE
	BEGIN
		IF (@transactionType = 'KH' OR @transactionType = 'KT')
		BEGIN
			SET @tglJthTempo = DATEADD(DAY, @hariSales, @tglTerima)
		END
		ELSE
		BEGIN
			SET @tglJthTempo = DATEADD(DAY, (CASE WHEN (@transactionType = 'KA' OR @transactionType = 'KB' 
									OR @transactionType = 'KV' OR @transactionType = 'KL' )
									THEN (@hariSales + @hariKirim) ELSE (@hariKredit + @hariKirim) END),
								@tglTerima)
		END
	END


	RETURN @tglJthTempo

END

/*
 FUNCTION Isi_tjt(cTr,dTgTrm,nJw,nJx,nJs)
	LOCAL dTgl_jt
	dTgl_jt = CTOD("")
	IF cTr = "KO" OR cTr = "KC" OR cTr=="KJ" OR cTr=="KG" OR cTr=="K2" OR cTr=="K4"
		dTgl_jt = dTgTrm + nJx + IIF(nJs > 0, nJs, nJw)
	ELSE
		IF cTr $ "KH-KT"
			dTgl_jt = dTgTrm + nJs
		ELSE
			dTgl_jt = dTgTrm + IIF(cTr=="KA" or cTr=="KB" or cTr=="KV" or cTr=="KL", (nJs+nJx), (nJw+nJx))		
		ENDIF
	ENDIF
RETURN dTgl_jt	
*/
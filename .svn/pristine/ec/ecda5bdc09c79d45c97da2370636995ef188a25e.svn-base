USE [ISAdb]
GO
/****** Object:  UserDefinedFunction [dbo].[fnHitungNet3Disc]    Script Date: 01/20/2011 09:42:57 ******/
SET ANSI_NULLS ON
GO

IF OBJECT_ID('[dbo].[fnHitungNet3Disc]') IS NOT NULL
DROP FUNCTION [dbo].[fnHitungNet3Disc] 
GO

SET QUOTED_IDENTIFIER ON
GO
-- =======================================================
-- Author:		Stephanie
-- Create date: 17/1/2011
-- Description:	Hitung Harga Netto setelah 3 kali Discount
-- =======================================================
CREATE FUNCTION [dbo].[fnHitungNet3Disc] 
(
	-- Add the parameters for the function here	
	@hrgBruto money, /* HrgBruto = Qty * HrgJual */
	@disc1 decimal(5,2), 
	@disc2 decimal(5,2), 
	@disc3 decimal(5,2), 
	@discFormula varchar(7)
)
RETURNS money
AS
BEGIN
	-- Declare the return variable here

	DECLARE @hrgNet money
	DECLARE @hrgDisc money
	DECLARE @char1 varchar(1)
	DECLARE @char2 varchar(1)
	DECLARE @char3 varchar(1)

	DECLARE @ndp1 money
	DECLARE @ndp2 money
	DECLARE @ndp3 money
	DECLARE @nDisc1 money
	DECLARE @nDisc2 money
	DECLARE @nDisc3 money

	SET @disc1 = ISNULL(@disc1,0)
	SET @disc2 = ISNULL(@disc2,0)
	SET @disc3 = ISNULL(@disc3,0)		

	SET @hrgDisc = 0
	SET @hrgNet = 0

	IF (@discFormula IS NULL OR @discFormula = '')
	BEGIN
		SET @discFormula = 'YYTBNN'
	END
	
	SET @char1 = SUBSTRING(@discFormula, 4, 1)
	SET @char2 = SUBSTRING(@discFormula, 5, 1)
	SET @char3 = SUBSTRING(@discFormula, 6, 1)

	/* nDisc1 */
	SET @ndp1 = @hrgBruto
	IF (@char1 = 'B')
	BEGIN
		SET @nDisc1 = @hrgBruto / 100 * @disc1
	END
	ELSE
	BEGIN
		SET @nDisc1 = @ndp1 / 100 * @disc1
	END

	/* nDisc2 */
	IF (@char2 = 'B')
	BEGIN
		SET @ndp2 = @hrgBruto - 0
	END
	ELSE
	BEGIN
		SET @ndp2 = @hrgBruto - @nDisc1
	END
	SET @nDisc2 = @ndp2 / 100 * @disc2

	/* nDisc3 */
	IF (@char3 = 'B')
	BEGIN
		SET @ndp3 = @ndp2 - 0
	END
	ELSE
	BEGIN
		SET @ndp3 = @ndp2 - @nDisc2
	END
	SET @nDisc3 = @ndp3 / 100 * @disc3

	SET @hrgDisc = @nDisc1 + @nDisc2 + @nDisc3
	SET @hrgNet = @hrgBruto - @hrgDisc

	RETURN @hrgNet

END

/*
**
FUNCTION HitNet3D
 LPARAMETERS nbru, nd1, nd2, nd3, cid
 LOCAL nnet, ndisc
 LOCAL cc1, cc2, cc3, ch1, ch2, ch3
 LOCAL ndp1, ndp2, ndp3, ndsc1, ndsc2, ndsc3
 ndisc = 0
 IF EMPTY(cid)
    cid = 'YYTBNN'
 ENDIF
 cc1 = SUBSTR(cid, 1, 1)
 cc2 = SUBSTR(cid, 2, 1)
 cc3 = SUBSTR(cid, 3, 1)
 ch1 = SUBSTR(cid, 4, 1)
 ch2 = SUBSTR(cid, 5, 1)
 ch3 = SUBSTR(cid, 6, 1)
 ndp1 = nbru
 ndsc1 = IIF(ch1='B', nbru/100*nd1, ndp1/100*nd1)
 ndp2 = nbru-IIF(ch2='B', 0, ndsc1)
 ndsc2 = ndp2/100*nd2
 ndp3 = ndp2-IIF(ch3='B', 0, ndsc2)
 ndsc3 = ndp3/100*nd3
 ndisc = ndsc1+ndsc2+ndsc3
 nnet = nbru-ndisc
 RETURN ROUND(nnet, 0)
ENDFUNC
**
*/

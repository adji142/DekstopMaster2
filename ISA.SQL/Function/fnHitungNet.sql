 -- ================================================
-- Template generated from Template Explorer using:
-- Create Scalar Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO

IF OBJECT_ID('[dbo].[fnHitungNet]') IS NOT NULL
DROP FUNCTION [dbo].[fnHitungNet] 
GO

SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Stephanie
-- Create date: 12/1/2011
-- Description:	Hitung harga netto
-- =============================================
CREATE FUNCTION fnHitungNet 
(
	-- Add the parameters for the function here	
	@qtyDO int,
	@BMK money, 
	@disc1 decimal(5,2), 
	@disc2 decimal(5,2), 
	@disc3 decimal(5,2), 
	@discFormula varchar(7)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here

/*
 
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
*/

	DECLARE @hrgBruto money
	DECLARE @Result money

	DECLARE @char1 varchar(1)
	DECLARE @char2 varchar(1)
	DECLARE @char3 varchar(1)

	DECLARE @ndp1 money
	DECLARE @ndp2 money
	DECLARE @ndp3 money
	DECLARE @nDisc1 money
	DECLARE @nDisc2 money
	DECLARE @nDisc3 money
	DECLARE @nDisc money
	DECLARE @nNet money
	
	SET @disc1 = ISNULL(@disc1,0)
	SET @disc2 = ISNULL(@disc2,0)
	SET @disc3 = ISNULL(@disc3,0)

	SET @nDisc = 0
	SET @hrgBruto = @qtyDO * @BMK

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

	/* nDisc */
	SET @nDisc = @nDisc1 + @nDisc2 + @nDisc3

	/* nNet */
	SET @nNet = @hrgBruto - @nDisc

	/* result */
	SET @Result =  ROUND(@nNet, 0)	

	RETURN @Result

END
GO


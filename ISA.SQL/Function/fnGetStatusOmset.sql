USE [ISAdb]
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetStatusOmset]    Script Date: 03/23/2011 15:31:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 23 Mar 11
-- Description:	Mencari Status Omset Toko
-- =============================================
ALTER FUNCTION [dbo].[fnGetStatusOmset] 
(
	-- Add the parameters for the function here	
	@stsToko varchar(2),
	@jmlOmset money,
	@rodaToko varchar(1),
	@classIDToko varchar(1)
)
RETURNS varchar(2)
AS
BEGIN
	-- Declare the return variable here

	DECLARE @stsOmset varchar(2)
	SET @stsOmset = @stsToko
	
	IF @rodaToko = '2'
	BEGIN
		IF (@jmlOmset >=  2000000 AND @jmlOmset < 5000000 AND LEFT(@stsToko,1) = 'K')
			SET @stsOmset = (CASE WHEN @classIDToko = 'D' THEN 'M1' ELSE 'M2' END)
		IF (@jmlOmset >= 5000000 AND LEFT(@stsToko,1) <> 'B')
			SET @stsOmset = (CASE WHEN @classIDToko = 'D' THEN 'B1' ELSE 'B2' END)
	END

	ELSE -- IF @rodaToko <> '2'
	BEGIN
		IF @classIDToko = 'D'
		BEGIN
			IF (@jmlOmset >= 5000000 AND @jmlOmset < 10000000 AND @stsToko = 'K1')
				SET @stsOmset = 'M1'
			IF (@jmlOmset >= 10000000 AND @stsToko <> 'B1')
				SET @stsOmset = 'B1'
		END
		
		ELSE -- IF @classIDToko <> 'D'
		BEGIN
			IF (@jmlOmset >= 3000000 AND @jmlOmset < 5000000 AND @stsToko = 'K2')
				SET @stsOmset = 'M2'
			IF (@jmlOmset >= 5000000 AND @stsToko <> 'B2')
				SET @stsOmset = 'B2'
		END
	END
	
	RETURN @stsOmset

END

/*
 FUNCTION ChkStsOmz(cStsA,nOmz,cRd,cClas)
  LOCAL cStsO
  cStsO = cStsA
  IF cRd = '2'
     DO CASE
     CASE nOmz >= 2000000 AND nOmz < 5000000 AND LEFT(cStsA,1) = 'K'
       cStsO = IIF(cClas ='D','M1','M2')
     CASE nOmz >= 5000000 AND LEFT(cStsA,1) <> 'B'
       cStsO = IIF(cClas = 'D','B1','B2')
  	 ENDCASE 
  ELSE 
     IF cClas = 'D'
	    DO CASE 
	  	CASE nOmz >= 5000000 AND nOmz < 10000000 AND cStsA = 'K1'
	  	  cStsO = 'M1'
	  	CASE nOmz >= 10000000 AND cStsA <> 'B1'
	  	  cStsO = 'B1'
  	    ENDCASE
	 ELSE
		DO CASE
	  	CASE  nOmz >= 3000000 AND nOmz < 5000000 AND cStsA = 'K2'
  	      cStsO = 'M2'
	    CASE nOmz >= 5000000 AND cStsA <> 'B2'
	      cStsO = 'B2'
	    ENDCASE
	 ENDIF
  ENDIF
  RETURN cStsO
ENDFUNC
*/


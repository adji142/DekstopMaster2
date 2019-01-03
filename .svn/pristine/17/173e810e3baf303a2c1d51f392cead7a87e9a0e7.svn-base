USE [ISAdb]
GO

IF OBJECT_ID ('[dbo].[fnCekGiro]') IS NOT NULL
DROP FUNCTION [dbo].[fnCekGiro]
GO

/****** Object:  UserDefinedFunction [dbo].[fnCekGiro]    Script Date: 03/14/2011 14:03:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Stephanie
-- Create date: 10 Mar 11
-- Description:	Cek Giro
-- =============================================
ALTER FUNCTION [dbo].[fnCekGiro] 
(
	-- Add the parameters for the function here	
	@tgl datetime,
	@piutangDetailRecID varchar(23)
)
RETURNS money
AS
BEGIN
	-- Declare the return variable here

	DECLARE @jmlGiro money
	SET @jmlGiro = 0

	SELECT
		@jmlGiro = a.Kredit
	FROM dbo.PiutangDetail a
		LEFT OUTER JOIN dbo.IndenSubDetail b ON a.RecordID = b.DetailRecID
		LEFT OUTER JOIN dbo.Tagih c ON b.ColTokoID = c.ColTokoID
		LEFT OUTER JOIN dbo.Giro d ON c.RecordID = d.GiroID
	WHERE
		a.RecordID = @piutangDetailRecID
		AND b.RecordID IS NOT NULL
		AND c.RecordID IS NOT NULL
		AND d.GiroID IS NOT NULL
		AND (d.TglCair > @tgl OR d.TglCair IS NULL)
			
	RETURN @jmlGiro

END

/*
*------------------------*
FUNCTION cek_Giro(dTgl)
*------------------------*
LOCAL nJumlBG
nJumlBG = 0
IF SEEK(dpiutang.idrec,"Ddinden") AND SEEK(ddinden.Id_ColToko,"Tagih") AND ;
   SEEK(tagih.IdRec,"Giro") AND (EMPTY(giro.Tgl_Cair) OR Giro.Tgl_Cair > dTgl)
   nJumlBG = dpiutang.Kredit
ENDIF 
RETURN nJumlBG
*/
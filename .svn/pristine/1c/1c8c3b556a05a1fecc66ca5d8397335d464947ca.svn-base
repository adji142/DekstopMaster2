 USE [ISAdb]
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetIDDO]    Script Date: 03/04/2011 13:39:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Stephanie
-- Create date: 04 Mar 2011
-- Description:	Mencari ID DO
-- =============================================
ALTER FUNCTION [dbo].[fnGetIDDO] 
(
	-- Add the parameters for the function here	
	@rowID uniqueidentifier
)
RETURNS varchar(1)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @result varchar(1)
	
	DECLARE @tglSJ datetime
	DECLARE @stsBatal varchar(7)
	DECLARE @stsBO bit
	DECLARE @tglReorder datetime
	DECLARE @htrID varchar(23)

	SELECT TOP 1 
		@tglSJ = (SELECT TOP 1 n.TglSuratJalan FROM dbo.NotaPenjualan n 
			WHERE a.RowID = n.DOID ORDER BY n.TglSuratJalan DESC),
		@stsBatal = a.StatusBatal,
		@stsBO = a.StatusBO,
		@tglReorder = a.TglReorder,
		@htrID = a.HtrID		 
	FROM dbo.OrderPenjualan a 
	WHERE a.RowID = @rowID

	IF @tglSJ IS NULL
	BEGIN
		IF @stsBatal LIKE '%BATAL%'
			SET @result = '*'
		ELSE
			SET @result = ''
	END
	ELSE
	BEGIN
		IF @stsBO = 1
		BEGIN
			IF @tglReorder IS NULL
			BEGIN
				IF (RIGHT(@htrID, 3) = '_BO' OR RIGHT(@htrID, 1) = '_')
					SET @result = 'X'
				ELSE
					SET @result = '*'
			END
			ELSE
				SET @result = 'V'
		END
		ELSE
			SET @result = '.'
	END	

	RETURN @result

END

/*
FUNCTION IdDO
  LOCAL cId_DO
  cId_DO = '.'
  IF EMPTY(Hhtransj.Tgl_Sj)
     IF 'BATAL'$Hhtransj.No_sj
        cId_DO = '*'
     ELSE
        cId_DO = '-'
     ENDIF
  ELSE
     cId_DO = IIF(Hhtransj.Lbo, IIF(EMPTY(Hhtransj.Tgl_reord),IIF(RIGHT(RTRIM(Hhtransj.idhtr),3)='_BO' OR RIGHT(Hhtransj.Idhtr,1)='_','X','*'),'V'),'.')
     * di hhtransj->idhtr ada yang akhirnya "_BO" ada yang "_" saja *
  ENDIF
  RETURN cId_DO
ENDFUNC
*/
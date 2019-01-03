 USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_fnGetNotaJualForRekapKoli]    Script Date: 01/28/2011 17:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==============================================================================
-- Author:		Stephanie
-- Create date: 28 Jan 11
-- Description:	Get NotaJual List from Table Function fnGetNotaJualForRekapKoli
-- ==============================================================================
ALTER PROCEDURE [dbo].[usp_fnGetNotaJualForRekapKoli] 
	-- Add the parameters for the stored procedure here
	@kodeToko varchar(19),
	@searchArg varchar(7) = NULL,
	@rowID  uniqueidentifier = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		NotaJualID, 
		NotaRecID, 
		NoNota,
		TglNota, 
		NoDO,
		NamaToko ,
		AlamatKirim, 
		NamaSales, 
		KreditTunai,
		Nominal, 
		QtyKoli
	FROM dbo.fnGetNotaJualForRekapKoli(@kodeToko)
	WHERE 
		(UPPER(NoDO) LIKE UPPER('%' + @searchArg + '%') OR @searchArg IS NULL)
		AND (NotaJualID = @rowID OR @rowID IS NULL)

END







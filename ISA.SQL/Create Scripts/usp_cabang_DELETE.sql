USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_DELETE_Cabang]') IS NOT NULL
DROP PROC [dbo].[usp_cabang_DELETE] 
GO

/****** Object:  StoredProcedure [dbo].[usp_cabang_DELETE]    Script Date: 12/01/2010 14:19:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Raymond
-- Create date: 01 Dec 10
-- Description:	Delete data on table Cabang
-- =============================================
CREATE PROCEDURE [dbo].[usp_cabang_DELETE] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    DECLARE @hdoc int

	DECLARE @CabangID varchar(2)
	
   	exec sp_xml_preparedocument @hdoc OUTPUT, @doc
   	
	--Get RowID
	SELECT 
		@CabangID = CabangID
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		CabangID varchar(2) '@CabangID'
	)

	exec sp_xml_removedocument @hdoc
    
	DELETE Cabang  		
	WHERE
		CabangID = @CabangID
    
END

GO



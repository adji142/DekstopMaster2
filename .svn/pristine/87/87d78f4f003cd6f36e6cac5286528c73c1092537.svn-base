 USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_KodePos_DELETE]') IS NOT NULL
DROP PROC [dbo].[usp_KodePos_DELETE] 
GO

/****** Object:  StoredProcedure [dbo].[usp_KodePos_DELETE]    Script Date: 01/04/2011 14:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Stephanie
-- Create date: 04 Jan 11
-- Description:	Delete data on table KodePos
-- =============================================
CREATE PROCEDURE [dbo].[usp_KodePos_DELETE] 
	-- Add the parameters for the stored procedure here
	@kodePos varchar(3)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
           
	DELETE KodePos  		
	WHERE
		KodePos = @kodePos
    
END






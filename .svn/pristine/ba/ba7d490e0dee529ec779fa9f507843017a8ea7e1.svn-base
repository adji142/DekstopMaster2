USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Gudang_DELETE]') IS NOT NULL
DROP PROC [dbo].[usp_Gudang_DELETE] 
GO

/****** Object:  StoredProcedure [dbo].[usp_Gudang_DELETE]    Script Date: 01/03/2011 15:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Stephanie
-- Create date: 03 Jan 11
-- Description:	Delete data on table Gudang
-- =============================================
CREATE PROCEDURE [dbo].[usp_Gudang_DELETE] 
	-- Add the parameters for the stored procedure here
	@gudangID varchar(4)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
           
	DELETE Gudang  		
	WHERE
		GudangID = @gudangID
END






USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_KelompokBarang_DELETE]') IS NOT NULL
DROP PROC [dbo].[usp_KelompokBarang_DELETE] 
GO

/****** Object:  StoredProcedure [dbo].[usp_KelompokBarang_DELETE]    Script Date: 01/07/2011 11:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Stephanie
-- Create date: 04 Jan 11
-- Description:	Delete data on table KelompokBarang
-- =============================================
CREATE PROCEDURE [dbo].[usp_KelompokBarang_DELETE] 
	-- Add the parameters for the stored procedure here
	@kelompokBrgID varchar(2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
           
	DELETE KelompokBarang  		
	WHERE
		KelompokBrgID = @kelompokBrgID
    
END






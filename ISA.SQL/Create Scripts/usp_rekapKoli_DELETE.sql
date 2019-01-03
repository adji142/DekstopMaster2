USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_RekapKoli_DELETE]    Script Date: 01/31/2011 12:10:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 31 Jan 11
-- Description:	Delete data on table RekapKoli
-- =============================================
CREATE PROCEDURE [dbo].[usp_RekapKoli_DELETE] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
           
	DELETE RekapKoli  		
	WHERE
		RowID = @rowID
    
END






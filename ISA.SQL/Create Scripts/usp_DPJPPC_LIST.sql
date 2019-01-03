USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_DPJPPC_LIST]    Script Date: 03/28/2011 10:39:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		stephanie
-- Create date: 28 Mar 11
-- Description:	List data on table DPJPPC
-- =============================================
CREATE PROCEDURE [dbo].[usp_DPJPPC_LIST] 
	-- Add the parameters for the stored procedure here
	@doHtrID varchar(23) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    -- Insert statements for procedure here

	SELECT 
		DODetailRecID, 
		DOHtrID, 
		HPCID, 
		PPCID, 
		RPPCRecID, 
		BarangID, 
		KodeToko, 
		QtyDO, 
		QtySJ
	FROM dbo.DPJPPC  		
	WHERE
	(DOHtrID = @doHtrID OR @doHtrID IS NULL)
    
END







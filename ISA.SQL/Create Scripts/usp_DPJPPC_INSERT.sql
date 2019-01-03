USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_DPJPPC_INSERT]    Script Date: 03/28/2011 10:39:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 28 Mar 11
-- Description:	Insert table DPJPPC
-- =============================================
CREATE PROCEDURE [dbo].[usp_DPJPPC_INSERT] 
	-- Add the parameters for the stored procedure here
	@doDetailRecID varchar(23), 
	@doHtrID varchar(23), 
	@HPCID varchar(23), 
	@PPCID varchar(23), 
	@RPPCRecID varchar(25), 
	@barangID varchar(23), 
	@kodeToko varchar(19), 
	@qtyDO int, 
	@qtySJ int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
        	
	INSERT INTO dbo.DPJPPC 
	(
		DODetailRecID, 
		DOHtrID, 
		HPCID, 
		PPCID, 
		RPPCRecID, 
		BarangID, 
		KodeToko, 
		QtyDO, 
		QtySJ
	)
	SELECT 
		@doDetailRecID, 
		@doHtrID, 
		@HPCID, 
		@PPCID, 
		@RPPCRecID, 
		@barangID, 
		@kodeToko, 
		@qtyDO, 
		@qtySJ
	
END




 
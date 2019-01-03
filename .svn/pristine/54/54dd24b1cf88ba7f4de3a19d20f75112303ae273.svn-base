USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_BackOrder_INSERT]    Script Date: 03/22/2011 09:14:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 22 Mar 11
-- Description:	Insert table BackOrder
-- =============================================
CREATE PROCEDURE [dbo].[usp_BackOrder_INSERT] 
	-- Add the parameters for the stored procedure here		
	 @rowID uniqueidentifier,
	 @doID uniqueidentifier,
	 @recordID varchar(23),
	 @doHtrID varchar(23),
	 @rpNet money,
	 @sub int,
	 @lastUpdatedBy varchar(250)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
        	
	INSERT INTO dbo.BackOrder
	(	
		RowID, 
		DOID, 
		RecordID, 
		DOHtrID, 
		RpNet, 
		Sub, 
		LastUpdatedBy, 
		LastUpdatedTime	
	)
	SELECT 		 
		@rowID, 
		@doID, 
		@recordID, 
		@doHtrID,
		@rpNet,
		@sub, 
		@lastUpdatedBy, 
		GETDATE()	
END
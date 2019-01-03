USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_BackOrder_UPDATE]    Script Date: 03/22/2011 09:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 22 Mar 11
-- Description:	Update table BackOrder
-- =============================================
CREATE PROCEDURE [dbo].[usp_BackOrder_UPDATE] 
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
    
    
    UPDATE dbo.BackOrder
    SET	
		DOID = @doID,
		RecordID = @recordID,
		DoHtrID = @doHtrID,
		RpNet = @rpNet,
		Sub = @sub,
		LastUpdatedBy = @lastUpdatedBy,
		LastUpdatedTime = GETDATE()
	WHERE
		RowID = @rowID
END
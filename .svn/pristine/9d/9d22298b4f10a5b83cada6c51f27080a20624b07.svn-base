USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_RekapKoliSubDetail_UPDATE]    Script Date: 01/27/2011 14:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 27 Jan 11
-- Description:	Update table RekapKoliSubDetail
-- =============================================
CREATE PROCEDURE [dbo].[usp_RekapKoliSubDetail_UPDATE] 
	-- Add the parameters for the stored procedure here	
	 @rowID uniqueidentifier, 
	 @headerID uniqueidentifier, 
	 @recordID varchar(23), 
	 @htrID varchar(23), 
	 @uraian varchar(12), 
	 @jumlah int, 
	 @satuan varchar(5), 
	 @keterangan varchar(30), 
	 @syncFlag bit, 
	 @lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here    
    
    UPDATE dbo.RekapKoliSubDetail
    SET	
		HeaderID = @headerID, 
		RecordID = @recordID, 
		HtrID = @htrID, 
		Uraian = @uraian, 
		Jumlah = @jumlah, 
		Satuan = @satuan, 
		Keterangan = @keterangan,
		SyncFlag = @syncFlag, 
		LastUpdatedBy = @lastUpdatedBy,
		LastUpdatedTime = GETDATE()
	WHERE
		RowID = @rowID	
END 
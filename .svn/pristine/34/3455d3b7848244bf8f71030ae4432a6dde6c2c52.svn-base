USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_HistoryHPP_UPDATE]    Script Date: 01/18/2011 10:58:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Raymond
-- Create date: 17 Jan 10
-- Description:	Update table HistoryHPP
-- =============================================
CREATE PROCEDURE [dbo].[usp_HistoryHPP_UPDATE] 
	-- Add the parameters for the stored procedure here	
    	@rowID uniqueidentifier ,
		@historyID varchar(23), 
		@barangID varchar(23), 
		@tglAktif datetime, 
		@HPP money, 
		@satuan varchar(3), 
		@keterangan varchar(43), 
		@syncFlag bit, 
		@lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    UPDATE dbo.HistoryHPP     
    SET	
		BarangID = @barangID, 
		TglAktif = @tglAktif, 
		HPP = @HPP, 
		Satuan = @satuan, 
		Keterangan = @keterangan, 
		SyncFlag = @syncFlag, 
		LastUpdatedBy = @lastUpdatedBy, 
		LastUpdatedTime = GETDATE()
	WHERE
		HistoryID = @HistoryID	
END









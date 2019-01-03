USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_HistoryHPP_INSERT]    Script Date: 01/18/2011 11:02:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Raymon
-- Create date: 17 Jan 11
-- Description:	Insert table HistoryHPP
-- =============================================
CREATE PROCEDURE [dbo].[usp_HistoryHPP_INSERT] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier, 
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
        	
	INSERT INTO dbo.HistoryHPP
	(
		RowID, 
		HistoryID, 
		BarangID, 
		TglAktif, 
		HPP, 
		Satuan, 
		Keterangan, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
	SELECT 
		@rowID, 
		@historyID, 
		@barangID, 
		@tglAktif, 
		@HPP, 
		@satuan, 
		@keterangan, 
		@syncFlag, 
		@lastUpdatedBy, 
		GETDATE()
	
END






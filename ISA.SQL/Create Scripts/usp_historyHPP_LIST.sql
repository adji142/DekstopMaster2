USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_HistoryHPP_LIST]') IS NOT NULL
DROP PROC [dbo].[usp_HistoryHPP_LIST] 
GO

/****** Object:  StoredProcedure [dbo].[usp_HistoryHPP_LIST]    Script Date: 01/18/2011 11:00:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		Stephanie
-- Create date: 06 Jan 11
-- Description:	List data on table HistoryHPP
-- =============================================
CREATE PROCEDURE [dbo].[usp_HistoryHPP_LIST] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier = NULL,
	@barangID varchar(23) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
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
	FROM dbo.HistoryHPP  		
	WHERE
	(rowID = @rowID OR @rowID IS NULL)
	AND (BarangID = @barangID OR @barangID IS NULL)
    
END
USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_HistoryHPPA_LIST]') IS NOT NULL
DROP PROC [dbo].[usp_HistoryHPPA_LIST] 
GO

/****** Object:  StoredProcedure [dbo].[usp_HistoryHPPA_LIST]    Script Date: 01/18/2011 10:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		Stephanie
-- Create date: 06 Jan 11
-- Description:	List data on table HistoryHPPA
-- =============================================
CREATE PROCEDURE [dbo].[usp_HistoryHPPA_LIST] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier = null,
	@barangID varchar(23) = null
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
		HPPAverage,
		LastUpdatedBy,
		LastUpdatedTime
	FROM dbo.HistoryHPPA  		
	WHERE
	(RowID = @rowID OR @rowID IS NULL)
	AND
	(BarangID = @barangID OR @barangID IS NULL)
    
END






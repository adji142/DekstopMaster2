USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_RekapKoliSubDetail_LIST]    Script Date: 01/25/2011 16:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==================================================
-- Author:		Stephanie
-- Create date: 25 Jan 11
-- Description:	List data on table RekapKoliSubDetail
-- ==================================================
CREATE PROCEDURE [dbo].[usp_RekapKoliSubDetail_LIST] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier = NULL,
	@headerID uniqueidentifier = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		RowID, 
		HeaderID, 
		RecordID, 
		HtrID, 
		Uraian, 
		Jumlah, 
		Satuan, 
		Keterangan, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM dbo.RekapKoliSubDetail
	WHERE
		(RowID = @rowID OR @rowID IS NULL)
		AND
		(HeaderID = @headerID OR @headerID IS NULL)


END

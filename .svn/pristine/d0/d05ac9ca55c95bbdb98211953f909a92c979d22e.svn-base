USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_StatusToko_LIST]    Script Date: 01/11/2011 09:55:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		Stephanie
-- Create date: 10 Jan 11
-- Description:	List data on table StatusToko
-- =============================================
CREATE PROCEDURE [dbo].[usp_StatusToko_LIST] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier = null,
	@cabangID varchar(2) = null,
	@kodeToko varchar(19) = null
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		RowID, 
		CabangID, 
		KodeToko, 
		TglAktif, 
		Status, 
		RecordID, 
		Keterangan, 
		SyncFlag, 
		KStatus, 
		Roda, 
		WilID, 
		TglPasif, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM dbo.StatusToko		
	WHERE
		(RowID = @rowID OR @rowID IS NULL)
		AND
		(CabangID = @cabangID OR @cabangID IS NULL)
		AND
		(KodeToko = @kodeToko OR @kodetoko IS NULL)
    
END








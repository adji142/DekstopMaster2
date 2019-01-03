USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_OrderPembelian_LIST]    Script Date: 04/05/2011 16:43:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- Author:		Stephanie
-- Create date: 04 Apr 11
-- Description:	List data on table OrderPembelian
-- ===============================================
CREATE PROCEDURE [dbo].[usp_OrderPembelian_LIST] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier = NULL,
	@fromDate datetime = NULL,
	@toDate datetime = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    -- Insert statements for procedure here

	SELECT 
		RowID, 
		RecordID, 
		LEFT(RecordID, 3) AS Gudang,
		NoRequest, 
		TglRequest, 
		Pemasok, 
		Cabang1, 
		Cabang2, 
		EstHrgJual, 
		EstHPP, 
		NoACC, 
		Catatan, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime

	FROM dbo.OrderPembelian 		

	WHERE
		(RowID = @rowID OR @rowID IS NULL)	
		AND (TglRequest >= @fromDate OR @fromDate IS NULL)
		AND (TglRequest <= @toDate OR @toDate IS NULL)

	ORDER BY TglRequest DESC
    
END
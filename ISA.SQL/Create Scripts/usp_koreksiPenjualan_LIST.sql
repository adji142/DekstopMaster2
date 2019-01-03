 USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_KoreksiPenjualan_LIST]    Script Date: 02/02/2011 08:30:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ================================================
-- Author:		Stephanie
-- Create date: 02 Feb 11
-- Description:	List data on table KoreksiPenjualan
-- ================================================
CREATE PROCEDURE [dbo].[usp_KoreksiPenjualan_LIST] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier = NULL,
	@headerID uniqueidentifier = NULL,
	@detailID uniqueidentifier = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		RowID, 
		RecordID, 
		HeaderID, 
		DetailID, 
		HeaderRecID, 
		DetailRecID, 
		TglKoreksi, 
		NoKoreksi, 
		QtyNotaAwal, 
		HrgJualAwal, 
		Catatan, 
		KodeToko, 
		Sumber, 
		LinkID, 
		HrgJualKoreksi, 
		QtyNotaKoreksi, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM dbo.KoreksiPenjualan 		
	WHERE
		(RowID = @rowID OR @rowID IS NULL)
		AND (HeaderID = @headerID OR @headerID IS NULL)
		AND (DetailID = @detailID OR @detailID IS NULL)
    
END








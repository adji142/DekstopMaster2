USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_KoreksiReturPembelian_INSERT]    Script Date: 04/18/2011 11:41:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ================================================
-- Author:		Stephanie
-- Create date: 18 Apr 11
-- Description:	Insert table KoreksiReturPembelian
-- ================================================
CREATE PROCEDURE [dbo].[usp_KoreksiReturPembelian_INSERT] 
	-- Add the parameters for the stored procedure here
	 @rowID uniqueidentifier,
	 @recordID varchar(19),
	 @returBeliDetailID uniqueidentifier,
	 @returBeliDetailRecID varchar(23),
	 @tglKoreksi datetime,
	 @noKoreksi varchar(11),
	 @qtyNotaBaru int,
	 @hrgBeliBaru money,
	 @catatan varchar(40),
	 @pemasok varchar(19),
	 @sumber varchar(3),
	 @linkID varchar(23),
	 @hrgBeliKoreksi money,
	 @qtyNotaKoreksi int,
	 @syncFlag bit,
	 @lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
        	
	INSERT INTO dbo.KoreksiReturPembelian
	(
		RowID, 
		RecordID, 
		ReturBeliDetailID, 
		ReturBeliDetailRecID, 
		TglKoreksi, 
		NoKoreksi, 
		QtyNotaBaru, 
		HrgBeliBaru, 
		Catatan, 
		Pemasok, 
		Sumber, 
		LinkID, 
		HrgBeliKoreksi, 
		QtyNotaKoreksi, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
	SELECT 
		@rowID,
		@recordID,
		@returBeliDetailID,
		@returBeliDetailRecID,
		@tglKoreksi,
		@noKoreksi,
		@qtyNotaBaru,
		@hrgBeliBaru,
		@catatan,
		@pemasok,
		@sumber,
		@linkID,
		@hrgBeliKoreksi,
		@qtyNotaKoreksi,
		@syncFlag,
		@lastUpdatedBy,
		GETDATE()

END 
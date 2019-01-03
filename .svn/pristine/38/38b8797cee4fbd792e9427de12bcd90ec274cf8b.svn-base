USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_KoreksiReturPenjualan_INSERT]    Script Date: 03/31/2011 09:11:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 31 Mar 11
-- Description:	Insert table KoreksiReturPenjualan
-- =============================================
CREATE PROCEDURE [dbo].[usp_KoreksiReturPenjualan_INSERT] 
	-- Add the parameters for the stored procedure here
	 @rowID uniqueidentifier,
	 @recordID varchar(19),
	 @returJualDetailID uniqueidentifier,
	 @returJualDetailRecID varchar(23),
	 @tglKoreksi datetime,
	 @noKoreksi varchar(11),
	 @qtyNotaBaru int,
	 @hrgJualBaru money,
	 @catatan varchar(40),
	 @kodeToko varchar(19),
	 @sumber varchar(3),
	 @linkID varchar(23),
	 @hrgJualKoreksi money,
	 @qtyNotaKoreksi int,
	 @syncFlag bit,
	 @lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
        	
	INSERT INTO dbo.KoreksiReturPenjualan
	(
		RowID, 
		RecordID, 
		ReturJualDetailID, 
		ReturJualDetailRecID, 
		TglKoreksi, 
		NoKoreksi, 
		QtyNotaBaru, 
		HrgJualBaru, 
		Catatan, 
		KodeToko, 
		Sumber, 
		LinkID, 
		HrgJualKoreksi, 
		QtyNotaKoreksi, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
	SELECT 
		@rowID,
		@recordID,
		@returJualDetailID,
		@returJualDetailRecID,
		@tglKoreksi,
		@noKoreksi,
		@qtyNotaBaru,
		@hrgJualBaru,
		@catatan,
		@kodeToko,
		@sumber,
		@linkID,
		@hrgJualKoreksi,
		@qtyNotaKoreksi,
		@syncFlag,
		@lastUpdatedBy,
		GETDATE()
	
END







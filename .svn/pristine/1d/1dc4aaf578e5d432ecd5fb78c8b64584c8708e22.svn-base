USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_Cabang_INSERT]    Script Date: 02/02/2011 09:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 02 Feb 11
-- Description:	Insert table KoreksiPenjualan
-- =============================================
CREATE PROCEDURE [dbo].[usp_KoreksiPenjualan_INSERT] 
	-- Add the parameters for the stored procedure here
	 @rowID uniqueidentifier,
	 @recordID varchar(19),
	 @headerID uniqueidentifier,
	 @detailID uniqueidentifier,
	 @headerRecID varchar(23),
	 @detailRecID varchar(23),
	 @tglKoreksi datetime,
	 @noKoreksi varchar(11),
	 @qtyNotaAwal int,
	 @hrgJualAwal money,
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
        	
	INSERT INTO dbo.KoreksiPenjualan
	(
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
	)
	SELECT 
		@rowID,
		@recordID,
		@headerID,
		@detailID,
		@headerRecID,
		@detailRecID,
		@tglKoreksi,
		@noKoreksi,
		@qtyNotaAwal,
		@hrgJualAwal,
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







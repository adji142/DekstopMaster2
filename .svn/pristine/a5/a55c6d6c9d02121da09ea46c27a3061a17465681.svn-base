USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_NotaPenjualan_INSERT]') IS NOT NULL
DROP PROC [dbo].[usp_NotaPenjualan_INSERT] 
GO

/****** Object:  StoredProcedure [dbo].[usp_NotaPenjualan_INSERT]    Script Date: 01/26/2011 10:32:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 21 Jan 11
-- Description:	Insert table NotaPenjualan
-- =============================================
ALTER PROCEDURE [dbo].[usp_NotaPenjualan_INSERT] 
	-- Add the parameters for the stored procedure here
	 @rowID uniqueidentifier, --newID
	 @htrID varchar(23), --OrderPenj HtrID
	 @recID varchar(23), --new finger print
	 @DOID uniqueidentifier, -- OrderPenjualan ID
	 @noNota varchar(7),
	 @tglNota datetime,
	 @noSJ varchar(7), -- ambil enumerator
	 @tglSJ datetime,
	 @tglTerima datetime,
	 @alamatKirim varchar,
	 @kota varchar(20),
	 @isClosed bit,
	 @catatan1 varchar(40), 
	 @catatan2 varchar(40), 
	 @catatan3 varchar(40), 
	 @catatan4 varchar(40), 
	 @catatan5 varchar(40), 
	 @syncFlag bit, 
	 @linkID varchar(1), 
	 @nPrint int, 
	 @transactionType varchar(2),
	 @checker1 varchar(11), 
	 @checker2 varchar(11), 
	 @lastUpdatedBy varchar(250) --lastUpdatedBy
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    -- Insert statements for procedure here
        	
	INSERT INTO dbo.NotaPenjualan 
	(
		RowID, 
		HtrID, 
		RecordID, 
		DOID, 
		NoNota, 
		TglNota, 
		NoSuratJalan, 
		TglSuratJalan, 
		TglTerima, 
		AlamatKirim, 
		Kota, 
		isClosed, 
		Catatan1, 
		Catatan2, 
		Catatan3, 
		Catatan4, 
		Catatan5, 
		SyncFlag, 
		LinkID, 
		NPrint, 
		TransactionType,
		Checker1, 
		Checker2, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
	SELECT 
		@rowID,
		@htrID,
		@recID,
		@DOID,
		@noNota,
		@tglNota,
		@noSJ,
		@tglSJ,
		@tglTerima,
		@alamatKirim,
		@kota,
		@isClosed,
		@catatan1, 
		@catatan2, 
		@catatan3, 
		@catatan4, 
		@catatan5, 
		@syncFlag, 
		@linkID, 
		@nPrint, 
		@transactionType,
		@checker1, 
		@checker2,
		@lastUpdatedBy,
		GETDATE()
	
END





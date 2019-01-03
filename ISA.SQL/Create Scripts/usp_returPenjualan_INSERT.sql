USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_ReturPenjualan_INSERT]') IS NOT NULL
DROP PROC [dbo].[usp_ReturPenjualan_INSERT] 
GO


/****** Object:  StoredProcedure [dbo].[usp_ReturPenjualan_INSERT]    Script Date: 02/08/2011 11:47:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 08 Feb 11
-- Description:	Insert table ReturPenjualan
-- =============================================
CREATE PROCEDURE [dbo].[usp_ReturPenjualan_INSERT] 
	-- Add the parameters for the stored procedure here
	 @rowID uniqueidentifier, 
	 @cabang1 varchar(2), 
	 @cabang2 varchar(2), 
	 @returID varchar(23), 
	 @noMPR varchar(7), 
	 @noNotaRetur varchar(7), 
	 @noTolak varchar(7), 
	 @kodeToko varchar(19),
	 @tglMPR datetime, 
	 @tglNotaRetur datetime, 
	 @tglTolak datetime, 
	 @pengambilan varchar(17), 
	 @tglPengambilan datetime, 
	 @tglGudang datetime,
	 @bagPenjualan varchar(17), 
	 @penerima varchar(17), 
	 @linkID varchar(19), 
	 @syncFlag bit, 
	 @isClosed bit, 
	 @nPrint int, 
	 @tglRQRetur datetime, 
	 @lastUpdatedBy varchar(250) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
        	
	INSERT INTO dbo.ReturPenjualan 
	(
		RowID,
		Cabang1, 
		Cabang2, 
		ReturID, 
		NoMPR, 
		NoNotaRetur, 
		NoTolak, 
		KodeToko,
		TglMPR, 
		TglNotaRetur, 
		TglTolak, 
		Pengambilan, 
		TglPengambilan, 
		TglGudang, 
		BagPenjualan, 
		Penerima, 
		LinkID, 
		SyncFlag, 
		isClosed, 
		NPrint, 
		TglRQRetur, 
		LastUpdatedBy, 
		LastUpdatedTime 	
	)
	SELECT 
		@rowID, 
		@cabang1, 
		@cabang2, 
		@returID, 
		@noMPR, 
		@noNotaRetur, 
		@noTolak, 
		@kodeToko,
		@tglMPR, 
		@tglNotaRetur,
		@tglTolak,
		@pengambilan, 
		@tglPengambilan,
		@tglGudang,
		@bagPenjualan, 
		@penerima, 
		@linkID, 
		@syncFlag, 
		@isClosed, 
		@nPrint, 
		@tglRQRetur, 
		@lastUpdatedBy,
		GETDATE()
	
END





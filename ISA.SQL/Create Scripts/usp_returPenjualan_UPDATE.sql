USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_ReturPenjualan_UPDATE]') IS NOT NULL
DROP PROC [dbo].[usp_ReturPenjualan_UPDATE] 
GO


/****** Object:  StoredProcedure [dbo].[usp_ReturPenjualan_UPDATE]    Script Date: 02/08/2011 11:47:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 08 Feb 11
-- Description:	Update table ReturPenjualan
-- =============================================
CREATE PROCEDURE [dbo].[usp_ReturPenjualan_UPDATE] 
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
    
    
    UPDATE dbo.ReturPenjualan
    SET	
		Cabang1 = @cabang1, 
		Cabang2 = @cabang2, 
		ReturID = @returID, 
		NoMPR = @noMPR, 
		NoNotaRetur = @noNotaRetur, 
		NoTolak = @noTolak, 
		KodeToko = @kodeToko,
		TglMPR = @tglMPR, 
		TglNotaRetur = @tglNotaRetur, 
		TglTolak = @tglTolak, 
		Pengambilan = @pengambilan, 
		TglPengambilan = @tglPengambilan, 
		TglGudang = @tglGudang, 
		BagPenjualan = @bagPenjualan, 
		Penerima = @penerima, 
		LinkID = @linkID, 
		SyncFlag = @syncFlag, 
		isClosed = @isClosed, 
		NPrint = @nPrint, 
		TglRQRetur = @tglRQRetur, 
		LastUpdatedBy = @lastUpdatedBy, 
		LastUpdatedTime = GETDATE() 
	WHERE
		RowID = @rowID
END






USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_ReturPembelian_UPDATE]    Script Date: 04/13/2011 14:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 13 Apr 11
-- Description:	Update table ReturPembelian
-- =============================================
CREATE PROCEDURE [dbo].[usp_ReturPembelian_UPDATE] 
	-- Add the parameters for the stored procedure here	
	 @rowID uniqueidentifier, 
	 @returID varchar(23), 
	 @noRetur varchar(7), 
	 @tglRetur datetime, 
	 @pemasok varchar(19), 
	 @penerima varchar(17), 
	 @noMPR varchar(7), 
	 @tglKeluar datetime, 
	 @Pengirim varchar(17), 
	 @tglKirim datetime, 
	 @isClosed bit, 
	 @nPrint int, 
	 @syncFlag bit, 
	 @lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    
    UPDATE dbo.ReturPembelian
    SET	 
		ReturID = @returID, 
		NoRetur = @noRetur, 
		TglRetur = @tglRetur, 
		Pemasok = @pemasok, 
		Penerima = @penerima, 
		NoMPR = @noMPR, 
		TglKeluar = @tglKeluar, 
		Pengirim = @pengirim, 
		TglKirim = @tglKirim, 
		isClosed = @isClosed, 
		NPrint = @nPrint, 
		SyncFlag = @syncFlag,
		LastUpdatedBy = @lastUpdatedBy, 
		LastUpdatedTime = GETDATE() 
	WHERE
		RowID = @rowID
END
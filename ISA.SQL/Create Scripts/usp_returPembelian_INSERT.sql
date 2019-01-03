USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_ReturPembelian_INSERT]    Script Date: 04/13/2011 14:42:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 13 Apr 11
-- Description:	Insert table ReturPembelian
-- =============================================
CREATE PROCEDURE [dbo].[usp_ReturPembelian_INSERT] 
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
        	
	INSERT INTO dbo.ReturPembelian 
	(
		RowID, 
		ReturID, 
		NoRetur, 
		TglRetur, 
		Pemasok, 
		Penerima, 
		NoMPR, 
		TglKeluar, 
		Pengirim, 
		TglKirim, 
		isClosed, 
		NPrint, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
	SELECT 
		@rowID, 
		@returID, 
		@noRetur, 
		@tglRetur, 
		@pemasok, 
		@penerima, 
		@noMPR, 
		@tglKeluar, 
		@Pengirim, 
		@tglKirim, 
		@isClosed, 
		@nPrint, 
		@syncFlag, 
		@lastUpdatedBy,
		GETDATE()
	
END
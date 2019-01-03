USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_RekapKoliDetail_UPDATE]    Script Date: 01/27/2011 14:15:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 27 Jan 11
-- Description:	Update table RekapKoliDetail
-- =============================================
CREATE PROCEDURE [dbo].[usp_RekapKoliDetail_UPDATE] 
	-- Add the parameters for the stored procedure here	
	 @rowID uniqueidentifier, 
	 @headerID uniqueidentifier, 
	 @notaJualID uniqueidentifier, 
	 @recordID varchar(23), 
	 @htrID varchar(23), 
	 @notaJualRecID varchar(23), 
	 @noNota varchar(7), 
	 @tunaiKredit varchar(1), 
	 @nominal money, 
	 @uraian varchar(12), 
	 @keterangan varchar(30), 
	 @noResi varchar(15), 
	 @syncFlag bit, 
	 @lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here    
    
    UPDATE dbo.RekapKoliDetail
    SET	
		HeaderID = @headerID, 
		NotaJualID = @notaJualID, 
		RecordID = @recordID, 
		HtrID = @htrID,  
		NotaJualRecID = @notaJualRecID, 
		NoNota = @noNota, 
		TunaiKredit = @tunaiKredit, 
		Nominal = @nominal, 
		Uraian = @uraian, 
		Keterangan = @keterangan,  
		NoResi = @noResi, 
		SyncFlag = @syncFlag, 
		LastUpdatedBy = @lastUpdatedBy,
		LastUpdatedTime = GETDATE()
	WHERE
		RowID = @rowID	
END







 
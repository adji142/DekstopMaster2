USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Gudang_UPDATE]') IS NOT NULL
DROP PROC [dbo].[usp_Gudang_UPDATE] 
GO

/****** Object:  StoredProcedure [dbo].[usp_Gudang_UPDATE]    Script Date: 01/03/2011 16:09:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Stephanie
-- Create date: 03 Jan 11
-- Description:	Update table Gudang
-- =============================================
CREATE PROCEDURE [dbo].[usp_Gudang_UPDATE] 
	-- Add the parameters for the stored procedure here	
	@gudangID varchar(4),
	@kodeCabang varchar(2),
	@namaGudang varchar(25),
	@alamat1 varchar(40),
	@alamat2 varchar(40),
	@alamat3 varchar(40),
	@telp varchar(15),
	@fax varchar(15),
	@modem varchar(15),
	@lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    
    UPDATE dbo.Gudang 
    SET	
		KodeCabang = @kodeCabang,
		NamaGudang = @namaGudang,
		Alamat1 = @alamat1,
		Alamat2 = @alamat2,
		Alamat3 = @alamat3,
		Telp = @telp,
		Fax = @fax,
		Modem = @modem,
		LastUpdatedBy = @lastUpdatedBy,
		LastUpdatedTime = GETDATE()
	WHERE
		GudangID = @gudangID	
END





 
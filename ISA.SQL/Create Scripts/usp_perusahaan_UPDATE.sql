 USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_Perusahaan_UPDATE]    Script Date: 01/04/2011 16:24:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Stephanie
-- Create date: 04 Jan 11
-- Description:	Update table Perusahaan
-- =============================================
CREATE PROCEDURE [dbo].[usp_Perusahaan_UPDATE] 
	-- Add the parameters for the stored procedure here	
	@rowID uniqueidentifier,
	@initPerusahaan varchar(3),
	@nama varchar(30),
	@alamat varchar(60),
	@kota varchar(25),
	@propinsi varchar(25),
	@negara varchar(25),
	@kodePos varchar(15),
	@telp varchar(25),
	@fax varchar(25),
	@email varchar(25),
	@website varchar(30),
	@npwp varchar(25),
	@lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    
    UPDATE dbo.Perusahaan
    SET	
		RowID = @rowID,
		InitPerusahaan = @initPerusahaan, 
		Nama = @nama, 
		Alamat = @alamat, 
		Kota = @kota, 
		Propinsi = @propinsi, 
		Negara = @negara, 
		KodePos = @kodePos, 
		Telp = @telp, 
		Fax = @fax, 
		Email = @email, 
		Website = @website, 
		NPWP = @npwp,  
		LastUpdatedBy = @lastUpdatedBy,
		LastUpdatedTime = GETDATE()
	WHERE
		RowID = @rowID
END






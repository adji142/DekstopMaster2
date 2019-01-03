 USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Toko_UPDATE]') IS NOT NULL
DROP PROC [dbo].[usp_Toko_UPDATE] 
GO

/****** Object:  StoredProcedure [dbo].[usp_Toko_UPDATE]    Script Date: 01/11/2011 11:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		Stephanie
-- Create date: 11 Jan 11
-- Description:	Update table Toko
-- =============================================
CREATE PROCEDURE [dbo].[usp_Toko_UPDATE] 
	-- Add the parameters for the stored procedure here	
		@rowID uniqueidentifier, 
		@namaToko varchar(31), 
		@alamat varchar(60), 
		@kota varchar(20), 
		@telp varchar(20), 
		@wilID varchar(7), 
		@penanggungJawab varchar(20),
		@plafon money,  
		@catatan varchar(73),
		@daerah varchar(25), 
		@lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    
    UPDATE dbo.Toko
    SET	
		RowID = @rowID, 
		NamaToko = @namaToko, 
		Alamat = @alamat, 
		Kota = @kota, 
		Telp = @telp, 
		WilID = @wilID, 
		PenanggungJawab = @penanggungJawab,
		Plafon = @plafon,  
		Catatan = @catatan,
		Daerah = @daerah,
		LastUpdatedBy = @lastUpdatedBy,
		LastUpdatedTime = GETDATE()
	WHERE
		RowID = @rowID	
END








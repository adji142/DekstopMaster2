USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Gudang_INSERT]') IS NOT NULL
DROP PROC [dbo].[usp_Gudang_INSERT] 
GO


/****** Object:  StoredProcedure [dbo].[usp_Gudang_INSERT]    Script Date: 01/03/2011 15:58:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Stephanie
-- Create date: 03 Jan 11
-- Description:	Insert table Gudang
-- =============================================
CREATE PROCEDURE [dbo].[usp_Gudang_INSERT] 
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
        	
	INSERT INTO dbo.Gudang 
	(
		GudangID,
		KodeCabang,
		NamaGudang,
		Alamat1,
		Alamat2,
		Alamat3,
		Telp,
		Fax,
		Modem,
		LastUpdatedBy,
		LastUpdatedTime
	)
	SELECT 
		@gudangID, 
		@kodeCabang, 
		@namaGudang, 
		@alamat1, 
		@alamat2, 
		@alamat3, 
		@telp,
		@fax,
		@modem,
		@lastUpdatedBy,
		GETDATE()
	
END




 
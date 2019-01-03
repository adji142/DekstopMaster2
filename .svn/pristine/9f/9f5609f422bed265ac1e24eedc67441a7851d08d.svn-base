 USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Perusahaan_INSERT]') IS NOT NULL
DROP PROC [dbo].[usp_Perusahaan_INSERT] 
GO


/****** Object:  StoredProcedure [dbo].[usp_Perusahaan_INSERT]    Script Date: 01/04/2011 17:06:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 04 Jan 11
-- Description:	Insert table Perusahaan
-- =============================================
CREATE PROCEDURE [dbo].[usp_Perusahaan_INSERT] 
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
        	
	INSERT INTO dbo.Perusahaan 
	(
		RowID,
		InitPerusahaan, 
		Nama, 
		Alamat, 
		Kota, 
		Propinsi, 
		Negara, 
		KodePos, 
		Telp, 
		Fax, 
		Email, 
		Website, 
		NPWP,  
		LastUpdatedBy,
		LastUpdatedTime
	)
	SELECT 
		@rowID,
		@initPerusahaan, 
		@nama, 
		@alamat, 
		@kota, 
		@propinsi, 
		@negara, 
		@kodePos, 
		@telp, 
		@fax, 
		@email, 
		@website, 
		@npwp,  
		@lastUpdatedBy,
		GETDATE()
	
END





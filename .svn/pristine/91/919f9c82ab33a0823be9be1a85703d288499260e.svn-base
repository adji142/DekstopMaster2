USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Perusahaan_LIST]') IS NOT NULL
DROP PROC [dbo].[usp_Perusahaan_LIST] 
GO


/****** Object:  StoredProcedure [dbo].[usp_Perusahaan_LIST]    Script Date: 02/17/2011 16:30:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 04 Jan 11
-- Description:	List data on table Perusahaan
-- =============================================
ALTER PROCEDURE [dbo].[usp_Perusahaan_LIST] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
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
		TglPKP, 
		InitCabang, 
		InitGudang, 
		TipeLokasi,
		LastUpdatedBy, 
		LastUpdatedTime
	FROM dbo.Perusahaan  		
	WHERE
	(RowID = @rowID OR @rowID IS NULL)
    
END






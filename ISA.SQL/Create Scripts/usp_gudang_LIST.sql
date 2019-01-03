USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Gudang_LIST]') IS NOT NULL
DROP PROC [dbo].[usp_Gudang_LIST] 
GO


/****** Object:  StoredProcedure [dbo].[usp_Gudang_LIST]    Script Date: 01/10/2011 14:56:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		stephanie
-- Create date: 03 Jan 11
-- Description:	List data on table Gudang
-- =============================================
CREATE PROCEDURE [dbo].[usp_Gudang_LIST] 
	-- Add the parameters for the stored procedure here
	@gudangID varchar(4) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		GudangID,
		KodeCabang,
		NamaGudang,
		(Alamat1 + ' ' + Alamat2 + ' ' + Alamat3) AS Alamat,
		Telp,
		Fax,
		Modem
	FROM dbo.Gudang  		
	WHERE
	(GudangID = @gudangID OR @gudangID IS NULL)
    
END







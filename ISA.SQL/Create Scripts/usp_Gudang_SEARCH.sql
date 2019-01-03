 USE [ISAdb]
GO

/****** Object:  StoredProcedure [dbo].[usp_Gudang_SEARCH]    Script Date: 01/13/2011 16:24:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Raymon
-- Create date: 13 Jan 11
-- Description:	Search data on table Gudang
-- =============================================
CREATE PROCEDURE [dbo].[usp_Gudang_SEARCH] 
	-- Add the parameters for the stored procedure here
	@searchArg varchar(250) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		a.GudangID,
		a.KodeCabang,
		a.NamaGudang,
		(a.Alamat1 + ' ' + a.Alamat2 + ' ' + a.Alamat3) AS Alamat,
		a.Telp,
		a.Fax,
		a.Modem
	FROM dbo.Gudang a
	WHERE
		a.GudangID LIKE @searchArg + '%'
		OR a.NamaGudang LIKE '%' + @searchArg + '%'
    
END

GO



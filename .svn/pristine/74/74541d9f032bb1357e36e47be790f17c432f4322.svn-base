USE [ISAdb]

GO
IF OBJECT_ID('[dbo].[usp_kategori_LIST]') IS NOT NULL
DROP PROC [dbo].[usp_kategori_LIST]

GO
/****** Object:  StoredProcedure [dbo].[usp_Kategori_LIST]    Script Date: 02/11/2011 11:33:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Stephanie
-- Create date: 11 Feb 11
-- Description:	List data on table Kategori
-- =============================================
CREATE PROCEDURE [dbo].[usp_Kategori_LIST] 
	-- Add the parameters for the stored procedure here
	@kategori varchar(1) = NULL,
	@ket varchar(2) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    -- Insert statements for procedure here

	SELECT 
		Kategori,
		Keterangan,
		Ket
	FROM dbo.Kategori  		
	WHERE
		(Kategori = @kategori OR @kategori IS NULL)
		AND 
		(Ket = @ket OR @ket IS NULL)
	ORDER BY Kategori ASC
    
END







USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetInfoHrgJual]    Script Date: 03/25/2011 15:11:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===========================================================
-- Author:		Stephanie
-- Create date: 25 Mar 11
-- Description:	Get Info Harga Jual
-- ===========================================================
CREATE PROCEDURE [dbo].[usp_GetInfoHrgJual] 
	-- Add the parameters for the stored procedure here
	@tglDO datetime,
	@barangID varchar(23),
	@kodeToko varchar(19)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    -- Insert statements for procedure here

	SELECT 
		HrgB,
		HrgM,
		HrgK,
		HrgTerakhir,
		TglTerakhir
	FROM dbo.fnGetInfoHrgJual(@tglDO, @barangID, @kodeToko)   
END
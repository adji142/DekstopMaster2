 USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetHrgBMK]    Script Date: 01/24/2011 16:01:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===========================================================
-- Author:		Stephanie
-- Create date: 24 Jan 11
-- Description:	Get Harga BMK from Table Function fnGetHrgBMK
-- ===========================================================
CREATE PROCEDURE [dbo].[usp_GetHrgBMK] 
	-- Add the parameters for the stored procedure here
	@barangID varchar(23),
	@tglDO datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		BrgRecID,
		HargaB,
		HargaM,
		HargaK
	FROM dbo.fnGetHrgBMK(@barangID, @tglDO)   
END
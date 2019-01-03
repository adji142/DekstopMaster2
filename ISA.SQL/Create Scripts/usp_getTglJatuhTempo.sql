USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTglJatuhTempo]    Script Date: 03/02/2011 18:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ====================================================================
-- Author:		Stephanie
-- Create date: 01 03 2011
-- Description:	Get TglJatuhTempo from Function dbo.fnHitTglJatuhTempo
-- ====================================================================
ALTER PROCEDURE [dbo].[usp_GetTglJatuhTempo] 
	-- Add the parameters for the stored procedure here
	@transactionType varchar(2),
	@tglTerima datetime,
	@hariKredit int,
	@hariKirim int,
	@hariSales int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT dbo.fnHitTglJatuhTempo(@transactionType, @tglTerima, @hariKredit, @hariKirim, @hariSales)
END

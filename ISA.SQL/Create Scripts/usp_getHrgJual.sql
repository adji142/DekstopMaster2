USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetHrgJual]    Script Date: 01/24/2011 13:32:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ================================================================
-- Author:		Stephanie
-- Create date: 24 Jan 11
-- Description:	Get Harga Jual from Scalar Function fnHitungHrgJual
-- ================================================================
CREATE PROCEDURE [dbo].[usp_GetHrgJual] 
	-- Add the parameters for the stored procedure here
	@tglDO datetime,
	@barangID varchar(23),
	@qtyDO int,	
	@kodeToko varchar(19),
	@c1 varchar(2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		dbo.fnHitungHrgJual
		(
			@tglDo, 
			@barangID,
			(SELECT [Status] FROM dbo.Toko WHERE KodeToko = @kodeToko),
			@qtyDO,
			@kodeToko,
			@c1
		)AS HrgJual    
END
USE [ISAdb]

IF OBJECT_ID('[dbo].[usp_GetSisaStok]') IS NOT NULL
DROP PROC [dbo].[usp_GetSisaStok] 
GO

/****** Object:  StoredProcedure [dbo].[usp_GetSisaStok]    Script Date: 03/03/2011 16:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================================
-- Author:		Stephanie
-- Create date: 03 Mar 2011
-- Description:	Get Qty Sisa Stok from dbo.fnHitungSisaStok
-- ===============================================================
CREATE PROCEDURE [dbo].[usp_GetSisaStok] 
	-- Add the parameters for the stored procedure here
	@barangID varchar(23)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT dbo.fnHitungSisaStok(@barangID) AS QtySisa
END

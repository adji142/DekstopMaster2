USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_PT_LIST]    Script Date: 03/18/2011 13:02:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 18 Mar 11
-- Description:	List data on table PT
-- =============================================
CREATE PROCEDURE [dbo].[usp_PT_LIST] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		Nama,
		Alamat,
		TransactionType,
		NPWP,
		TglPKP,
		InitCabang
	FROM dbo.PT  		
	
END 
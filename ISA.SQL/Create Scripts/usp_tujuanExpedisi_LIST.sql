﻿USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_TujuanExpedisi_LIST]') IS NOT NULL
DROP PROC [dbo].[usp_TujuanExpedisi_LIST] 
GO

/****** Object:  StoredProcedure [dbo].[usp_TujuanExpedisi_LIST]    Script Date: 01/03/2011 16:31:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- ===============================================
-- Author:		Stephanie
-- Create date: 03 Jan 11
-- Description:	List data on table TujuanExpedisi
-- ===============================================
CREATE PROCEDURE [dbo].[usp_TujuanExpedisi_LIST] 
	-- Add the parameters for the stored procedure here
	@tujuan varchar(20) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		Tujuan,
		LastUpdatedBy,
		LastUpdatedTime
	FROM dbo.TujuanExpedisi  		
	WHERE
	(Tujuan = @tujuan OR @tujuan IS NULL)
    
END






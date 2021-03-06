USE [ISADBDepoNonRetail]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_POHeader_LIST]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_POHeader_LIST]
GO

-- ===============================================
-- Author:		csw
-- Create date: 28 jan 2013
-- Description:	List data on table hpocab
-- [usp_POHeader_LIST] '1/1/2013', '2/13/2013'
-- ===============================================
CREATE PROCEDURE [dbo].[usp_POHeader_LIST] 
	-- Add the parameters for the stored procedure here
	@fromDate  datetime = NULL
	,@toDate  datetime = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

	SELECT * FROM dbo.RefilPO 
	WHERE (tgl_po BETWEEN DATEADD(day,-1,@fromDate) AND DATEADD(day,1,@toDate)) 
	ORDER BY tgl_po DESC 
END

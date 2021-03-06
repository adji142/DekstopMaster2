USE [ISADBDepoNonRetail]
GO
-- ===============================================
-- Author:		csw
-- Create date: 28 jan 2013
-- Description:	List data on table hpocab
-- [usp_POHeader_LIST] '1/1/2013', '1/28/2013'
-- ===============================================
ALTER PROCEDURE [dbo].[usp_POHeader_LIST] 
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
	WHERE (tgl_po BETWEEN @fromDate AND @toDate)  
END

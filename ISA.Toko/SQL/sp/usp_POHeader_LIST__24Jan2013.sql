
-- ===============================================
-- Author:		csw
-- Create date: 24 jan 2013
-- Description:	List data on table hpocab
-- ===============================================
CREATE PROCEDURE [dbo].[usp_POHeader_LIST] 
	-- Add the parameters for the stored procedure here
	@KPID varchar(23) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

	SELECT * FROM dbo.hpocab 		  
END

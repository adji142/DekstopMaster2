USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_RekapKoliSubDetail_DELETE]    Script Date: 01/31/2011 12:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ====================================================
-- Author:		Stephanie
-- Create date: 31 Jan 11
-- Description:	Delete data on table RekapKoliSubDetail
-- ====================================================
ALTER PROCEDURE [dbo].[usp_RekapKoliSubDetail_DELETE] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier = NULL,
	@detailID uniqueidentifier = NULL,
	@headerID uniqueidentifier = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
           
	IF (@rowID IS NOT NULL)
	BEGIN
	DELETE RekapKoliSubDetail  		
	WHERE		
		RowID = @rowID
	END
	ELSE
	BEGIN
		IF (@detailID IS NOT NULL)
		BEGIN
		DELETE RekapKoliSubDetail
		WHERE
			HeaderID = @detailID
		END
		
		ELSE
		BEGIN
			IF (@headerID IS NOT NULL)
			BEGIN
			DELETE RekapKoliSubDetail
			WHERE 
				HeaderID IN (SELECT RowID FROM RekapKoliDetail WHERE HeaderID = @headerID)			
			END
		END
	END
    
END
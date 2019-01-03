USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_RekapKoliDetail_DELETE]    Script Date: 04/29/2011 16:34:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =================================================
-- Author:		Stephanie
-- Create date: 31 Jan 11
-- Description:	Delete data on table RekapKoliDetail
-- =================================================
CREATE PROCEDURE [dbo].[usp_RekapKoliDetail_DELETE] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier = NULL,
	@headerID uniqueidentifier = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
           
	IF (@rowID IS NOT NULL)
	BEGIN

	/* Update Nota */
	UPDATE dbo.NotaPenjualan 
	SET TglExpedisi = NULL
	FROM dbo.RekapKoliDetail r
		LEFT OUTER JOIN dbo.NotaPenjualan n ON r.NotaJualID = n.RowID
	WHERE r.RowID = @rowID

	/* Delete Rekap Koli Detail*/
	DELETE RekapKoliDetail  		
	WHERE		
		RowID = @rowID
	END

	ELSE
	BEGIN
		IF (@headerID IS NOT NULL)
		BEGIN

		/* Update Nota */
		UPDATE dbo.NotaPenjualan 
		SET TglExpedisi = NULL
		FROM dbo.RekapKoli rh
			LEFT OUTER JOIN dbo.RekapKoliDetail rd ON rh.RowID = rd.HeaderID
			LEFT OUTER JOIN dbo.NotaPenjualan n ON rd.NotaJualID = n.RowID
		WHERE rh.RowID = @headerID

		/* Delete Rekap Koli Detail*/
		DELETE RekapKoliDetail
		WHERE
			HeaderID = @headerID
		END
	END
    
END
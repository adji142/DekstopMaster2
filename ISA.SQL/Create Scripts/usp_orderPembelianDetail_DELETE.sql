USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_OrderPembelianDetail_DELETE]    Script Date: 04/08/2011 12:21:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =======================================================
-- Author:		Stephanie
-- Create date: 05 Apr 11
-- Description:	Delete data on table OrderPembelianDetail
-- =======================================================
CREATE PROCEDURE [dbo].[usp_OrderPembelianDetail_DELETE] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier = NULL,
	@headerID uniqueidentifier = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
           
	IF @rowID IS NOT NULL
	BEGIN		
		/* Update Order Penjualan detail bila BO nya pernah dibuat OrderPembelianDetail*/
		UPDATE dbo.OrderPenjualanDetail
		SET DOBeliDetailID = NULL
		WHERE DOBeliDetailID = @rowID

		DELETE dbo.OrderPembelianDetail 		
		WHERE RowID = @rowID		
	END
	
	ELSE -- IF @rowID IS NULL
	BEGIN
		IF @headerID IS NOT NULL
		BEGIN
			/* Update Order Penjualan detail bila BO nya pernah dibuat OrderPembelianDetail*/
			UPDATE dbo.OrderPenjualanDetail
			SET DOBeliDetailID = NULL
			FROM dbo.OrderPembelianDetail a 
				LEFT OUTER JOIN dbo.OrderPenjualanDetail b ON a.RowID = b.DOBeliDetailID
			WHERE a.HeaderID = @headerID

			DELETE dbo.OrderPembelianDetail 		
			WHERE HeaderID = @headerID
			
		END
	END
    
END







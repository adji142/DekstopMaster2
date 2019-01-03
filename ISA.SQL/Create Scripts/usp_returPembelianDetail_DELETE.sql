USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_ReturPembelianDetail_DELETE]    Script Date: 04/14/2011 08:50:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ======================================================
-- Author:		Stephanie
-- Create date: 13 Apr 11
-- Description:	Delete data on table ReturPembelianDetail
-- ======================================================
CREATE PROCEDURE [dbo].[usp_ReturPembelianDetail_DELETE] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier,
	@kodeRetur varchar(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	UPDATE dbo.ReturPembelian
	SET SyncFlag = 0
	FROM dbo.ReturPembelianDetail d
		LEFT OUTER JOIN dbo.ReturPembelian h ON d.HeaderID = h.RowID
	WHERE d.RowID = @rowID 

	IF @kodeRetur = '1'
	BEGIN
		DELETE ReturPembelianDetail  		
		WHERE		
			RowID = @rowID
	END

	ELSE -- IF @kodeRetur = '2'
	BEGIN
		DELETE ReturPembelianManualDetail  		
		WHERE		
			RowID = @rowID
	END
    
END
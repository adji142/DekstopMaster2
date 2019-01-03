USE [ISADBDepoNonRetail]
GO
/****** Object:  StoredProcedure [dbo].[usp_Numerator_UPDATE]    Script Date: 01/29/2013 13:59:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Gemma
-- Create date:  14 Januari 2011
-- Description:	Update table Numerator
-- =============================================
ALTER PROCEDURE [dbo].[usp_Numerator_UPDATE] 
	-- Add the parameters for the stored procedure here	
	 @doc varchar(40),
	 @depan varchar(15),
	 @belakang varchar(15),
	 @nomor int,
	 @lebar int,
	 --@nomor numeric(9,0),
	 --@lebar numeric(9,0),
	 @lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    
    UPDATE dbo.Numerator
    SET	
		Depan = @depan, 
		Belakang =  @belakang, 
		Nomor =  @nomor, 
		Lebar =  @lebar, 
		LastUpdatedBy = @lastUpdatedBy,
		LastUpdatedTime = GETDATE()
	WHERE
		Doc = @doc	
END

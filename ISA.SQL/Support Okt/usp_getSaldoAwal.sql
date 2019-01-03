USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_getSaldoAwal]    Script Date: 10/21/2011 11:13:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: Maharani
-- Create date	: 21 Okt 2011
-- Description	:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_getSaldoAwal]
	-- Add the parameters for the stored procedure here
	@TglOpname DATETIME,
	@KodeBarang VARCHAR(23),
	@KodeGudang VARCHAR(4)
AS
BEGIN

	SELECT CONVERT(BIGINT,(a.Total * dbo.fnGetHargaBeli(@KodeBarang,@TglOpname,'AVG'))) as Saldo
	from dbo.fnGetStokAwal(@TglOpname,@KodeBarang,@KodeGudang)a
	
END
 
USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Toko_LIST]') IS NOT NULL
DROP PROC [dbo].[usp_Toko_LIST] 
GO

/****** Object:  StoredProcedure [dbo].[usp_Toko_LIST]    Script Date: 01/10/2011 17:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 10 Jan 11
-- Description:	List data on table Toko
-- =============================================
CREATE PROCEDURE [dbo].[usp_Toko_LIST] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier = null,
	@namaToko varchar(31) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
		RowID, 
		TokoID, 
		NamaToko, 
		Alamat, 
		Kota, 
		Telp, 
		WilID, 
		PenanggungJawab, 
		KodeToko, 
		PiutangB, 
		PiutangJ, 
		Plafon, 
		ToJual, 
		ToRetPot, 
		JangkaWaktuKredit, 
		Cabang2, 
		Tgl1st, 
		Exist, 
		ClassID, 
		Catatan, 
		SyncFlag, 
		HariKirim, 
		KodePos, 
		Grade, 
		Plafon1st, 
		Flag, 
		Bentrok, 
		StatusAktif, 
		HariSales, 
		Daerah, 
		Propinsi, 
		AlamatRumah, 
		Pengelolah, 
		TglLahir, 
		HP, 
		Status, 
		ThnBerdiri, 
		StatusRuko, 
		JmlCabang, 
		JmlSales, 
		Kinerja, 
		BidangUsaha, 
		RefSales, 
		RefCollector, 
		RefSupervisor, 
		PlafonSurvey, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM dbo.Toko		
	WHERE
		(RowID = @rowID OR @rowID IS NULL)
		AND
		(UPPER(NamaToko) LIKE  UPPER( "%" + @namaToko + "%") OR @namaToko IS NULL)
    
END







 
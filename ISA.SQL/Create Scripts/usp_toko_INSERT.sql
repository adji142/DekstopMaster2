 USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[usp_Toko_INSERT]') IS NOT NULL
DROP PROC [dbo].[usp_Toko_INSERT] 
GO

/****** Object:  StoredProcedure [dbo].[usp_Toko_INSERT]    Script Date: 01/11/2011 10:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		Stephanie
-- Create date: 11 Jan 11
-- Description:	Insert table Toko
-- =============================================
CREATE PROCEDURE [dbo].[usp_Toko_INSERT] 
	-- Add the parameters for the stored procedure here
		@rowID uniqueidentifier, 
		@namaToko varchar(31), 
		@alamat varchar(60), 
		@kota varchar(20), 
		@telp varchar(20), 
		@wilID varchar(7), 
		@penanggungJawab varchar(20),
		@plafon money,  
		@catatan varchar(73),
		@daerah varchar(25), 
		@lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
        	
	INSERT INTO dbo.Toko
	(
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
		Pengelola, 
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
	)
	SELECT 
		@rowID, 
		NULL, 
		@namaToko, 
		@alamat, 
		@kota, 
		@telp, 
		@wilID, 
		@penanggungJawab, 
		NULL, 
		NULL, 
		NULL, 
		@plafon, 
		NULL, 
		NULL, 
		NULL,
		NULL,
		NULL, 
		NULL,
		NULL,
		@catatan, 
		NULL, 
		NULL,
		NULL,
		NULL, 
		NULL,
		NULL,
		NULL, 
		NULL,
		NULL, 
		@daerah, 
		NULL, 
		NULL,
		NULL,
		NULL, 
		NULL,
		NULL,
		NULL,
		NULL, 
		NULL,
		NULL, 
		NULL, 
		NULL,
		NULL,
		NULL, 
		NULL,
		NULL, 
		@lastUpdatedBy,
		GETDATE()
	
END







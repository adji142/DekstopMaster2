USE [ISAdb]
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetInfoHrgJual]    Script Date: 03/25/2011 13:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ========================================================
-- Author:		Stephanie
-- Create date: 25 Mar 2011
-- Description:	Get Info Harga Jual
-- ========================================================
ALTER FUNCTION [dbo].[fnGetInfoHrgJual] 
(	
	-- Add the parameters for the function here
	@tglDO datetime,
	@barangID varchar(23),
	@kodeToko varchar(19)
)
RETURNS @result 
TABLE 
(
	HrgB money,				-- Harga BMK Besar
	HrgM money,				-- Harga BMK Menengah
	HrgK money,				-- Harga BMK Kecil
	HrgTerakhir money,		-- Harga penjualan terakhir
	TglTerakhir datetime	-- Tgl penjualan terakhir
)
AS
BEGIN
	DECLARE @hrgB money
	DECLARE @hrgM money
	DECLARE @hrgK money
	DECLARE @hrgAkhir money
	DECLARE @tglAkhir datetime

	SET @hrgB = 0
	SET @hrgM = 0
	SET @hrgK = 0
	SET @hrgAkhir = 0

	DECLARE @hrgKhususB money
	DECLARE @hrgKhususM money
	DECLARE @hrgKhususK money
	DECLARE @stokID varchar(23) -- RecordID dari Tabel Stok
	
	SELECT 
		@stokID = RecordID
	FROM dbo.Stok (NOLOCK)
	WHERE BarangID = @barangID

	SELECT 
		@hrgKhususB = HrgKhususB,
		@hrgKhususM = HrgKhususM,
		@hrgKhususK = HrgKhususK
	FROM dbo.fnGetHrgKhusus(@tglDO, @stokID)
	
	IF (@hrgKhususB > 0 OR @hrgKhususM > 0)
	BEGIN
		SET @hrgB = @hrgKhususB
		SET @hrgM = @hrgKhususM
		SET @hrgK = @hrgKhususK
	END
	ELSE
	BEGIN
		SELECT
			@hrgB = HrgJualB,
			@hrgM = HrgJualM,
			@hrgK = HrgJualK
		FROM dbo.HistoryBMK (NOLOCK)
		WHERE
			StokID = @stokID
			AND Keterangan != 'K'
			AND TglAktif <= @tglDO
		ORDER BY TglAktif DESC			
	END

	SELECT TOP 1
		@hrgAkhir = b.HrgJual,
		@tglAkhir = d.TglSuratJalan
	FROM dbo.OrderPenjualan a (NOLOCK)
		LEFT OUTER JOIN dbo.OrderPenjualanDetail b (NOLOCK) ON a.RowID = b.HeaderID
		LEFT OUTER JOIN dbo.NotaPenjualanDetail c (NOLOCK) ON b.RowID = c.DODetailID
		LEFT OUTER JOIN dbo.NotaPenjualan d (NOLOCK) ON a.RowID = d.DOID
	WHERE 
		a.KodeToko = @kodeToko
		AND b.BarangID = @barangID		
	ORDER BY d.TglSuratJalan DESC

	-- Add the SELECT statement with parameter references here
	INSERT INTO @result 
	SELECT 
		@hrgB,
		@hrgM,
		@hrgK,
		@hrgAkhir,
		@tglAkhir
	RETURN
END

/*
  PARAMETERS dTgl,cId_brg
  LOCAL cRd,cIdC,cId_stok,nJual,nHK
  LOCAL nHB,nHM,nHKc,nHKB,nHKM,nHKKc
  LOCAL cLast,nLast
  *
  nLastPos = RECNO('Dhtransj')
  cRd = ' '
  cLast = ' '
  STORE 0 TO  nJual,nHK,nHB,nHM,nHKc,nHKB,nHKM,nHKKc
  *
  IF !USED('Sasstok')
     USE Sasstok IN 0
  ENDIF
  SET ORDER TO Id_brg IN Sasstok
  SEEK cId_brg IN Sasstok
  cId_stok = Sasstok.Idrec
  *
  nHK = Thisform.InfoHks(dTgl,cId_stok,@nHKB,@nHKM,@nHKKc)
  nHk = IIF(ISNULL(nHk),0,nHk)
  cRd = RdToko(Hhtransj.Tgl_do,Hhtransj.Kd_toko,Hhtransj.Cab1)
  IF nHKB > 0  OR  nHKM > 0
     nHB  = nHKB
     nHM  = nHKM
     nHKc = nHKKc
  ELSE
     cIdc = Ststoko(Hhtransj.Tgl_do,Hhtransj.Kd_toko,Hhtransj.Cab1)
     IF !USED('Hist_bmk')
        USE Hist_bmk IN 0
     ENDIF
     SET ORDER TO Id_stok IN Hist_bmk
     IF !USED('His_Bmk2')
        USE His_bmk2 IN 0
     ENDIF
     SET ORDER TO Id_stok IN His_bmk2
     IF RIGHT(cIdc,1) = '1'  && HBMK-I
        SEEK cId_stok IN Hist_bmk
        IF FOUND('Hist_bmk')
           DO WHILE Hist_bmk.Id_stok = cId_stok AND !EOF('Hist_bmk')
              IF Hist_bmk.Tmt > dTgl OR Hist_bmk.Ket = 'K'
                 SKIP IN Hist_bmk
                 LOOP
              ENDIF
              nHB = Hist_bmk.Hjual_B
              nHM = Hist_bmk.Hjual_M
              nHKc = Hist_bmk.Hjual_K
              EXIT
              SKIP IN Hist_bmk
           ENDDO
		ELSE
		   nJual = 1
		ENDIF
     ENDIF
  ENDIF
  IF !USED('Dtransj')
     USE Dtransj IN 0
  ENDIF
  SET ORDER TO Kd_toko IN Dtransj
  SEEK Hhtransj.Kd_toko+Sasstok.Nama_stok IN Dtransj
  IF FOUND('Dtransj')
     DO WHILE Dtransj.Kd_toko+Dtransj.Nama_stok = Hhtransj.Kd_toko+Sasstok.Nama_stok AND !EOF('Dtransj')
 	    nLast = Dtransj.H_jual
	    cLast = 'Penjualan terakhir Rp. '+ALLTRIM(TRANSFORM(nLast,'999,999,999'))+' Tgl. '+Date2Str(Dtransj.Tgl_Sj)
        SKIP IN Dtransj
    ENDDO
  ENDIF
  MESSAGEBOX('Harga Saat ini :'+CHR(13)+;
  'B :'+TRANSFORM(nHB,'9,999,999')+;
  '  M :'+TRANSFORM(nHM,'9,999,999')+;
  '  K :'+TRANSFORM(nHKc,'9,999,999')+CHR(13)+;
  cLast,0,'Info Harga Jual')
  SELECT Dtransj
  USE
  SELECT Hhtransj
  RETURN
*/
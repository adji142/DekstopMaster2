USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_Pembelian_AnalisaBackOrder]    Script Date: 04/20/2011 09:41:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =================================================================
-- Author:		Stephanie
-- Create date: 19 Apr 2011
-- Description:	Pembelian > Laporan > Pembelian > Analisa Back Order
-- =================================================================
CREATE PROCEDURE [dbo].[rsp_Pembelian_AnalisaBackOrder] 
	-- Add the parameters for the stored procedure here
	 @fromDate datetime,
	 @toDate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
		
    -- Insert statements for procedure here
	
	DECLARE @initPrs varchar(3)
	DECLARE @initCab varchar(2)

	SELECT 
		@initPrs = InitPerusahaan,
		@initCab = InitCabang
	FROM dbo.Perusahaan
	
	SELECT
		(SELECT TOP 1 s.NamaStok FROM dbo.Stok s WHERE x.BarangID = s.BarangID) AS NamaBarang,
		x.BarangID,
		SUM ( x.QtyDO - x.QtySuratJalan ) AS QtyBO
	FROM
	(
		SELECT
			BarangID,
			QtyDO,
			ISNULL((SELECT SUM(n.QtySuratJalan) FROM NotaPenjualanDetail n
						WHERE d.RowID = n.DODetailID), 0) AS QtySuratJalan,
			ISNULL((SELECT SUM(
				ISNULL(dbo.fnHitungNet3Disc((d.QtyDO * d.HrgJual), d.Disc1, d.Disc2, d.Disc3, d.DiscFormula), 0) 
				- (d.QtyDO * d.Pot)) FROM dbo.OrderPenjualanDetail d WHERE h.RowID = d.HeaderID), 0)
				AS  RpNet,
			ISNULL((SELECT SUM( dbo.fnHitungNet3Disc((n.QtySuratJalan * o.HrgJual), o.Disc1, o.Disc2, o.Disc3, o.DiscFormula) 
				- (n.QtySuratJalan * o.Pot)) FROM dbo.OrderPenjualanDetail o LEFT OUTER JOIN
				dbo.NotaPenjualanDetail n ON o.RowID = n.DODetailID WHERE o.HeaderID = h.RowID), 0) 
				AS RpNet2,
			h.StatusBO,
			d.DOBeliDetailID 
			
		FROM dbo.OrderPenjualan h
			LEFT OUTER JOIN dbo.OrderPenjualanDetail d ON h.RowID = d.HeaderID	
		WHERE
			(TglDO >= @fromDate AND TglDO <= @toDate)
			AND
			h.Cabang2 = @initCab
			AND
			LEFT(h.HtrID, 3) = @initPrs
			AND 
			h.StatusBO = 1
			AND 
			d.DOBeliDetailID IS NULL
	) AS x

	WHERE 
		(x.RpNet - x.RpNet2) > 0
		AND
		x.RpNet2 > 0
		AND 
		(x.QtyDo - x.QtySuratJalan) > 0

	GROUP BY x.BarangID

	ORDER BY (SELECT TOP 1 s.NamaStok FROM dbo.Stok s WHERE x.BarangID = s.BarangID)
				
END
/*
  CLOSE TABLES 
  CREATE CURSOR CursRpt ;
  (Nama_stok C(73),;
  Id_brg C(23),;
  Q_bo N(5))
  INDEX ON CursRpt.Nama_stok TAG Nama_stok
  INDEX ON CursRpt.Id_brg TAG Id_brg
  USE Hhtransj ORDER Tgl_rqbO IN 0
  USE Dhtransj ORDER IdhtrbO IN 0
  USE Tmpsheet ORDER Id_pj IN 0  
  SELECT Hhtransj
  SET KEY TO
  SET KEY TO RANGE DTOS(dTanggal1),DTOS(dTanggal2)IN Hhtransj
  GO TOP IN Hhtransj
  IF EOF('Hhtransj')
    MESSAGEBOX('Transaksi tanggal '+DTOC(dTanggal1)+' s/d '+DTOC(dTanggal2)+' tidak ada',48,'Perhatian')
    RETURN
  ENDIF
  DO WHILE !EOF('Hhtransj')
    IF Hhtransj.Cab2<>cInitCab
      SKIP IN Hhtransj
      LOOP
	ENDIF
	IF LEFT(Hhtransj.Idhtr,3)<>cInitPrs
      SKIP IN Hhtransj
      LOOP
	ENDIF
	SEEK Hhtransj.Idhtr IN Dhtransj
    WAIT WINDOW  Hhtransj.No_do NOWAIT
	IF FOUND('Dhtransj')
	  DO WHILE Dhtransj.Idhtr=Hhtransj.Idhtr AND !EOF('Dhtransj')
	    SEEK Dhtransj.Idrec IN Tmpsheet	    
   	    IF EOF('Tmpsheet')
   	      SEEK Dhtransj.Id_brg IN CursRpt
   	      IF FOUND('CursRpt')
   	        REPLACE CursRpt.Q_bo WITH CursRpt.Q_bo+Dhtransj.J_DO-Dhtransj.J_SJ IN CursRpt
   	      ELSE
   	        INSERT INTO CursRpt (Nama_stok,Id_brg,Q_bo) VALUES ;
   	        (Dhtransj.Nama_stok,Dhtransj.Id_brg,Dhtransj.J_DO-Dhtransj.J_SJ)
   	      ENDIF   	    
   	    ENDIF
   	    SKIP IN Dhtransj
   	  ENDDO 
	ENDIF  
    SKIP IN Hhtransj
  ENDDO
  WAIT CLEAR
  SET ORDER TO Nama_stok IN CursRpt
  GO TOP IN CursRpt
  RETURN
*/

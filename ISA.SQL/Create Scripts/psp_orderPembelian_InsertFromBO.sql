USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_OrderPembelian_InsertFromBO]    Script Date: 04/08/2011 08:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==============================================
-- Author:		Stephanie
-- Create date: 07 Apr 2011
-- Description:	Pembuatan Order Pembelian Detail
--				Dari BO Penjualan
-- ==============================================
ALTER PROCEDURE [dbo].[psp_OrderPembelian_InsertFromBO] 
	-- Add the parameters for the stored procedure here
	@fromDate datetime,
	@toDate datetime,
	@doBeliID uniqueidentifier,
	@initialUser varchar(3),
	@lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
			
    -- Insert statements for procedure here

	DECLARE @DOBeliRecID varchar(23)
	DECLARE @kodeGudang varchar(4)
	DECLARE @resultCount int 

	SELECT @doBeliRecID = RecordID
	FROM dbo.OrderPembelian (NOLOCK)
	WHERE RowID = @doBeliID

	SELECT TOP 1 @kodeGudang = InitGudang
	FROM dbo.Perusahaan (NOLOCK)


	/****************************************************************
	 * Mengumpulkan semua OrderPembelian ke dalam variable table @DO
	 * yang OrderPembeliannya:
	 * - TglDo nya BETWEEN @fromDate AND @toDate
	 * - StatusBO = 1 artinya belum tutup BO
	 * - RpNet2 tidak 0 artinya sudah pernah buat nota
	 * - RpNet <> RpNet2 (ada selisih antara Do dan Nota)
	 *		artinya bisa BO
	 *****************************************************************/

	DECLARE @DO TABLE 
	(RowID uniqueidentifier)

	INSERT INTO @DO
	( RowID )
	SELECT 
		x.RowID
	FROM
		(
			SELECT 
				a.RowID,
				ISNULL((SELECT SUM(
					ISNULL(dbo.fnHitungNet3Disc((d.QtyDO * d.HrgJual), d.Disc1, d.Disc2, d.Disc3, d.DiscFormula), 0) 
					- (d.QtyDO * d.Pot)) FROM dbo.OrderPenjualanDetail d WHERE a.RowID = d.HeaderID), 0)
					AS  RpNet, -- Perhitungan nilai jual untuk DO 
				ISNULL((SELECT SUM( dbo.fnHitungNet3Disc((n.QtySuratJalan * o.HrgJual), o.Disc1, o.Disc2, o.Disc3, o.DiscFormula) 
					- (n.QtySuratJalan * o.Pot)) FROM dbo.OrderPenjualanDetail o 
					LEFT OUTER JOIN dbo.NotaPenjualanDetail n ON o.RowID = n.DODetailID 
					WHERE o.HeaderID = a.RowID), 0) 
					AS RpNet2		
			FROM dbo.OrderPenjualan a (NOLOCK)
			WHERE 
				a.TglDO >= @fromDate AND a.TglDO <= @toDate
				AND StatusBO = 1
		) AS x
	WHERE 
		(x.RpNet - x.RpNet2) > 0 AND ISNULL(x.RpNet2, 0) <> 0
		

	/***************************************************************************
	 * Mengumpulkan semua OrderPembelianDetail ke dalam variable table @DODetail
	 * yang OrderPembelianDetailnya:
	 * - HeaderID nya ada di @DO 
	 *		(detail dari DO yang telak di spesifikasikan di tabel @DO)
	 * - DOBeliDetailID nya NULL artinya record detail terserbut
	 *		belum pernah diikutsertakan dalam proses pembuatan
	 *		OrderPembelianDetail dari BO
	 ***************************************************************************/

	DECLARE @DODetail TABLE 
	(
		RowID uniqueidentifier,
		BarangID varchar(23),
		QtyDO int,
		QtySuratJalan int
	)
	INSERT INTO @DODetail
	SELECT 
		b.RowID,
		b.BarangID,
		b.QtyDO,
		ISNULL((SELECT SUM(c.QtySuratJalan) FROM dbo.NotaPenjualanDetail c
			WHERE b.RowID = C.DODetailID), 0) AS QtySuratJalan
	FROM @DO a
	LEFT OUTER JOIN dbo.OrderPenjualanDetail b (NOLOCK) ON a.RowID = b.HeaderID
	WHERE 
		b.DOBeliDetailID IS NULL 
		AND	
		(b.QtyDO - ISNULL((SELECT SUM(c.QtySuratJalan) 
			FROM dbo.NotaPenjualanDetail c (NOLOCK)
			WHERE b.RowID = C.DODetailID), 0)) > 0


	/*********************************************** 
	 * Hitung jml BO yang bisa di DO.
	 * Dan proses pembuatan DO Beli akan dijalankan,
	 * jika resutnya lebih dari 0.
	 ***********************************************/

	SELECT @resultCount = COUNT(*) FROM @DODetail

	IF (@resultCount <> 0)
	BEGIN
		/********************************************************
		 * Proses Update / Insert 
		 * ke OrderPembelianDetail mengunakan Cursor DODetailCurs
		 ********************************************************/

		DECLARE @DORowID uniqueidentifier
		DECLARE @DOBarangID varchar(23)
		DECLARE @DOQtyDO int
		DECLARE @DOQtySuratJalan int

		DECLARE @DOBeliDetailID uniqueidentifier 

		DECLARE DODetailCurs CURSOR FOR 
		SELECT
			RowID,
			BarangID,
			QtyDO,
			QtySuratJalan
		FROM @DODetail

		OPEN DODetailCurs

		FETCH NEXT FROM DODetailCurs
		INTO @DORowID, @DOBarangID, @DOQtyDO, @DOQtySuratJalan

		WHILE @@FETCH_STATUS = 0
		BEGIN
			
			IF @DOBarangID IN (SELECT b.BarangID FROM dbo.OrderPembelianDetail b 
				WHERE b.HeaderID = @doBeliID) 
			/*********************************************************************
			 * Jika barang sama dengan yang ada di salah satu OrderPembelianDetail
			 * yang memiliki header @doBeliID
			 * maka record OrderPembelianDetail tersebut akan diupdate QtyBO-nya
			 *********************************************************************/
			BEGIN
				UPDATE dbo.OrderPembelianDetail
				SET
					QtyBO = QtyBO + (@DOQtyDO - @DOQtySuratJalan), 					
					LastUpdatedBy = @lastUpdatedBy, 
					LastUpdatedTime = GETDATE(),
					@DOBeliDetailID = RowID
				FROM dbo.OrderPembelianDetail (NOLOCK)
				WHERE HeaderID = @doBeliID AND BarangID = @DOBarangID
			END

			ELSE
			/***********************************************************
			 * Jika barang tidak ada di salah satu OrderPembelianDetail
			 * yang memiliki header @doBeliID,
			 * maka akan dibuatkan OrderPembelianDetail baru
			 ***********************************************************/
			BEGIN
				SET @DOBeliDetailID = NEWID()
				INSERT INTO dbo.OrderPembelianDetail
				(
					RowID, 
					HeaderID, 
					RecordID, 
					HeaderRecID, 
					BarangID, 
					QtyDO, 
					QtyBO, 
					QtyTambahan, 
					QtyJual, 
					QtyAkhir, 
					Keterangan, 
					KodeGudang, 
					Catatan, 
					SyncFlag, 
					LastUpdatedBy, 
					LastUpdatedTime
				)
				SELECT 		
					@DOBeliDetailID, 
					@doBeliID, 
					dbo.fnCreateFingerPrint(@initialUser),
					@doBeliRecID, 
					@DOBarangID, 
					0, 
					(@DOQtyDO - @DOQtySuratJalan), 
					0, 
					0, 
					0, 
					'', 
					@kodeGudang, 
					'', 
					0, 
					@lastUpdatedBy, 
					GETDATE()
			END	
			
			/***************************************************
			 * Proses menyimpan RowID dari OrderPembelianDetail 
			 * ke field DOBeliDetailID di OrderPenjualanDetail
			 * untuk menandakan telah dibuat OrderPembelian 
			 * dari record OrderPenjualanDetail ini.
			 ***************************************************/
			UPDATE dbo.OrderPenjualanDetail
			SET DOBeliDetailID = @DOBeliDetailID
			WHERE RowID = @DORowID
			
			FETCH NEXT FROM DODetailCurs
			INTO @DORowID, @DOBarangID, @DOQtyDO, @DOQtySuratJalan
		END

		CLOSE DODetailCurs
		DEALLOCATE DODetailCurs
	END

	SELECT @resultCount AS ResultCount
		
END
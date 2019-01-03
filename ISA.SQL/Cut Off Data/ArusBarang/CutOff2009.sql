USE ISAdb
GO

DECLARE @cutOffDate DATETIME
SET @cutOffDate = '2009/01/01'
-- ACC Bonus Sales

DELETE FROM dbo.ACCBonusSalesDetail
WHERE
HeaderID IN
(
	SELECT 
	RowID
	FROM dbo.ACCBonusSales a 
	WHERE
	a.TglJatuhTempo < @cutOffDate
)

DELETE FROM dbo.ACCBonusSales
WHERE
TglJatuhTempo < @cutOffDate


-- Antar Gudang
DELETE FROM dbo.AntarGudangDetail
WHERE
HeaderID IN
(
	SELECT 
	RowID
	FROM dbo.AntarGudang a 
	WHERE
	a.TglKirim < @cutOffDate
)

DELETE FROM dbo.AntarGudang
WHERE
TglKirim < @cutOffDate

-- HistoryBMK
DELETE FROM dbo.HistoryBMK
WHERE
TglAktif < @cutOffDate

-- HistoryBMK
DELETE FROM dbo.HistoryBMK2
WHERE
TglAktif < @cutOffDate

-- HistoryHPP
DELETE FROM dbo.HistoryHPP
WHERE
TglAktif < @cutOffDate

-- HistoryHPPA
DELETE FROM dbo.HistoryHPPA
WHERE
TglAktif < @cutOffDate

-- Koreksi Pembelian
DELETE FROM dbo.KoreksiPembelian
WHERE
TglKoreksi < @cutOffDate

-- Koreksi Penjualan
DELETE FROM dbo.KoreksiPenjualan
WHERE
TglKoreksi < @cutOffDate

-- Koreksi Retur Pembelian
DELETE FROM dbo.KoreksiReturPembelian
WHERE
TglKoreksi < @cutOffDate

-- Koreksi Retur Penjualan
DELETE FROM dbo.KoreksiReturPenjualan
WHERE
TglKoreksi < @cutOffDate


-- Mutasi
DELETE FROM dbo.MutasiDetail
WHERE
HeaderID IN
(
	SELECT 
	RowID
	FROM dbo.Mutasi a 
	WHERE
	a.TglMutasi < @cutOffDate
)

DELETE FROM dbo.Mutasi
WHERE
TglMutasi < @cutOffDate


-- Nota Pembelian
DELETE FROM dbo.NotaPembelianDetail
WHERE
HeaderID IN
(
	SELECT 
	RowID
	FROM dbo.NotaPembelian a 
	WHERE
	a.TglNota < @cutOffDate
)

DELETE FROM dbo.NotaPembelian
WHERE
TglNota < @cutOffDate

-- Nota Penjualan
DELETE FROM dbo.NotaPenjualanDetail
WHERE
HeaderID IN
(
	SELECT 
	RowID
	FROM dbo.NotaPenjualan a 
	WHERE
	a.TglSuratJalan < @cutOffDate
)

DELETE FROM dbo.NotaPenjualan
WHERE
TglSuratJalan < @cutOffDate


-- OpnameHistory
DELETE FROM dbo.OpnameHistory
WHERE
TglOpname < @cutOffDate

-- Order Pembelian
DELETE FROM dbo.OrderPembelianDetail
WHERE
HeaderID IN
(
	SELECT 
	RowID
	FROM dbo.OrderPembelian a 
	WHERE
	a.TglRequest < @cutOffDate
)

DELETE FROM dbo.OrderPembelian
WHERE
TglRequest < @cutOffDate


-- Order Penjualan
DELETE FROM dbo.OrderPenjualanDetail
WHERE
HeaderID IN
(
	SELECT 
	RowID
	FROM dbo.OrderPenjualan a
	WHERE
	a.TglDO < @cutOffDate
)

DELETE FROM dbo.OrderPenjualan
WHERE
TglDO < @cutOffDate

DELETE FROM dbo.OrderPenjualanPos
WHERE
TglDO < @cutOffDate


-- Peminjaman
DELETE FROM dbo.PeminjamanDetail
WHERE
HeaderID IN
(
	SELECT 
	RowID
	FROM dbo.Peminjaman a
	WHERE
	a.TglKeluar < @cutOffDate
)

DELETE FROM dbo.Peminjaman
WHERE
TglKeluar < @cutOffDate

-- Pengembalian
DELETE FROM dbo.PengembalianDetail
WHERE
HeaderID IN
(
	SELECT 
	RowID
	FROM dbo.Pengembalian a
	WHERE
	a.TglKembaliPj < @cutOffDate
)

DELETE FROM dbo.Pengembalian
WHERE
TglKembaliPj < @cutOffDate


-- Pengiriman Ekspedisi
DELETE FROM dbo.PengirimanEkspedisiDetail
WHERE
HeaderID IN
(
	SELECT 
	RowID
	FROM dbo.PengirimanEkspedisi a
	WHERE
	a.TglKirim < @cutOffDate
)

DELETE FROM dbo.PengirimanEkspedisi
WHERE
TglKirim < @cutOffDate



-- Penjualan Potongan
DELETE FROM dbo.PenjualanPotonganDetail
WHERE
HeaderID IN
(
	SELECT 
	RowID
	FROM dbo.PenjualanPotongan a
	WHERE
	a.TglPot < @cutOffDate
)

DELETE FROM dbo.PenjualanPotongan
WHERE
TglPot < @cutOffDate

--PeriodeGroup
DELETE FROM dbo.PeriodeGroup
WHERE
TglAktif < @cutOffDate

--PerolehanBonusSales
DELETE FROM dbo.PerolehanBonusSales
WHERE
Tanggal < @cutOffDate


--RekapKoli

DELETE FROM dbo.RekapKoliSubDetail
WHERE
HeaderID IN
(
	SELECT 
	b.RowID 
	FROM dbo.RekapKoliDetail b
	WHERE
	b.HeaderID IN
	(
		SELECT 
		RowID
		FROM dbo.RekapKoli a
		WHERE
		a.TglSuratJalan < @cutOffDate
)
)

DELETE FROM dbo.RekapKoliDetail
WHERE
HeaderID IN
(
	SELECT 
	RowID
	FROM dbo.RekapKoli a
	WHERE
	a.TglSuratJalan < @cutOffDate
)

DELETE FROM dbo.RekapKoli
WHERE
TglSuratJalan < @cutOffDate


-- Retur Pembelian
DELETE FROM dbo.ReturPembelianDetail
WHERE
HeaderID IN
(
	SELECT 
	RowID
	FROM dbo.ReturPembelian a
	WHERE
	a.TglRetur < @cutOffDate
)

DELETE FROM dbo.ReturPembelianManualDetail
WHERE
HeaderID IN
(
	SELECT 
	RowID
	FROM dbo.ReturPembelian a
	WHERE
	a.TglRetur < @cutOffDate
)

DELETE FROM dbo.ReturPembelian
WHERE
TglRetur < @cutOffDate


-- Retur Penjualan
DELETE FROM dbo.ReturPenjualanDetail
WHERE
HeaderID IN
(
	SELECT 
	RowID
	FROM dbo.ReturPenjualan a
	WHERE
	a.TglMPR < @cutOffDate
)

DELETE FROM dbo.ReturPenjualanTarikanDetail
WHERE
HeaderID IN
(
	SELECT 
	RowID
	FROM dbo.ReturPenjualan a
	WHERE
	a.TglMPR < @cutOffDate
)

DELETE FROM dbo.ReturPenjualan
WHERE
TglMPR < @cutOffDate

-- Selisih
DELETE FROM dbo.SelisihDetail
WHERE
HeaderID IN
(
	SELECT 
	RowID
	FROM dbo.Selisih a
	WHERE
	a.TglSelisih < @cutOffDate
)

DELETE FROM dbo.Selisih
WHERE
TglSelisih < @cutOffDate


-- Stok
DELETE FROM dbo.StokDetail
WHERE
TglAktif < @cutOffDate

DELETE FROM dbo.StokGudang
WHERE
TglAwal < @cutOffDate
USE ISAFinance
GO

TRUNCATE TABLE AccountToko

TRUNCATE TABLE BankKota
TRUNCATE TABLE BBK
TRUNCATE TABLE BBM
TRUNCATE TABLE ClosingGL
TRUNCATE TABLE DKNDetail
DELETE FROM DKN
TRUNCATE TABLE Giro
TRUNCATE TABLE GiroInternal
TRUNCATE TABLE GiroTolakDetail
DELETE FROM GiroTolak
TRUNCATE TABLE JournalDetail
DELETE FROM Journal
TRUNCATE TABLE KartuPiutangDetail
DELETE FROM KartuPiutang

TRUNCATE TABLE KasirLog
TRUNCATE TABLE Numerator
TRUNCATE TABLE PerkiraanKoneksiDetail
DELETE FROM PerkiraanKoneksi
TRUNCATE TABLE Perkiraan
DELETE FROM PinjamanPegawai
DELETE FROM TagihanSubDetail
DELETE FROM TagihanDetail
DELETE FROM Tagihan
DELETE FROM TransaksiBank
DELETE FROM TransferBankDetail
DELETE FROM TransferBank
DELETE FROM TransferG
DELETE FROM BuktiDetail
DELETE FROM Bukti
DELETE FROM VoucherJournalDetail 
DELETE FROM VoucherJournal
DELETE FROM KasBon
DELETE FROM IndenSuperDetail
DELETE FROM IndenSubDetail
DELETE FROM IndenDetail
DELETE FROM Inden
DELETE FROM BankDetail
DELETE FROM Bank
DELETE FROM PartnerDetail 
DELETE FROM [Partner]
DELETE FROM Saldo
TRUNCATE TABLE SetoranFmApi
TRUNCATE TABLE SetoranFmApiBayar 
TRUNCATE TABLE SetoranFmBank
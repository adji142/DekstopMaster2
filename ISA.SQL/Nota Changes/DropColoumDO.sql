﻿

GO
ALTER TABLE dbo.OrderPenjualanDetail
DROP COLUMN TglSuratJalan

ALTER TABLE dbo.OrderPenjualanDetail
DROP COLUMN KodeToko
GO

ALTER TABLE dbo.OrderPenjualan
DROP COLUMN Plafon

ALTER TABLE dbo.OrderPenjualan
DROP COLUMN SaldoPiutang

ALTER TABLE dbo.OrderPenjualan
DROP CONSTRAINT DF_P_OrderPenjualan_Fee1

ALTER TABLE dbo.OrderPenjualan
DROP COLUMN QtyTolak

ALTER TABLE dbo.OrderPenjualan
DROP CONSTRAINT DF_P_OrderPenjualan_Fee2

ALTER TABLE dbo.OrderPenjualan
DROP COLUMN Overdue


GO
/*View*/
vwReturPembelianDetail
vwReturPenjualanDetail

/*SP UPDATES*/
psp_POS_DOWNLOAD_OrderPenjualanDetail
psp_POS_DOWNLOAD_OrderPenjualan
psp_POS_DOWNLOAD_NotaPenjualan
psp_POS_DOWNLOAD_NotaPenjualanDetail


psp_POS_DOWNLOAD_KoreksiReturPenjualan
psp_POS_DOWNLOAD_KoreksiReturPenjualanPos
psp_POS_DOWNLOAD_ReturPembelianDetail
psp_POS_DOWNLOAD_ReturPenjualan
psp_POS_DOWNLOAD_ReturPenjualanDetail
psp_POS_DOWNLOAD_ReturPenjualanDetailPos
psp_POS_UPLOAD_ReturPembelianDetail
psp_POS_UPLOAD_ReturPenjualanDetail
psp_COCKPIT_UPLOAD_ReturPembelianDetail
usp_HistoryPenjualanForRetur_SEARCH_2
usp_KoreksiReturPenjualan_LIST
usp_KoreksiReturPembelian_LIST
usp_ReturPembelianDetail_INSERT
usp_ReturPembelianDetail_UPDATE
usp_ReturPenjualanDetail_INSERT
usp_ReturPenjualanDetail_UPDATE

/**/

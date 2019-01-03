USE ISAdb_JKT
GO
DELETE FROM ISAdb_JKT.dbo.StokGudang
GO
INSERT INTO dbo.StokGudang
(BarangID, KodeGudang, TglAwal, QtyAwal, QtyJual, 
QtyBeli, QtyOrderJual, QtyOrderBeli, QtyReturJual, 
QtyReturBeli, QtyMutasi, QtyKorJual, QtyKorBeli, 
QtyKorRetJual, QtyKorRetBeli, QtyAntarGudangKirim, 
QtyAntarGudangTerima, QtyGIT,  QtyPreOpname,
 TglGudang, LastUpdatedBy, LastUpdatedTime)
 
SELECT BarangID, KodeGudang, TglAwal, QtyAwal, QtyJual, 
QtyBeli, QtyOrderJual, QtyOrderBeli, QtyReturJual, 
QtyReturBeli, QtyMutasi, QtyKorJual, QtyKorBeli, 
QtyKorRetJual, QtyKorRetBeli, QtyAntarGudangKirim, 
QtyAntarGudangTerima, QtyGIT,  QtyPreOpname,
 TglGudang, LastUpdatedBy, LastUpdatedTime FROM ISAdb.dbo.StokGudang 
GO
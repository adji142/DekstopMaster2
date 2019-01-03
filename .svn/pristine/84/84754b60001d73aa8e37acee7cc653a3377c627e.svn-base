USE ISAdb_JKT
GO


INSERT INTO DBO.ACCBonusSalesDetail
(
RowID, HeaderID, NotaDetailID, NotaRecID, NotaDetailRecID, BarangID, QtySuratJalan, HrgNetto, NoACC, TglACC, KodeSales, KodeGudang, LastUpdatedBy, LastUpdatedTime
)

SELECT 
RowID, 
(SELECT TOP 1 RowID  FROM DBO.ACCBonusSales x WHERE x.NotaRecID = a.NotaRecID )  HeaderID, 
NotaDetailID, NotaRecID, NotaDetailRecID, BarangID, QtySuratJalan, HrgNetto, NoACC, TglACC, KodeSales, KodeGudang, LastUpdatedBy, LastUpdatedTime
FROM ISAdb.DBO.ACCBonusSalesDetail a 
WHERE NotaDetailRecID NOT IN (SELECT NotaDetailRecID FROM DBO.ACCBonusSalesDetail)

GO 
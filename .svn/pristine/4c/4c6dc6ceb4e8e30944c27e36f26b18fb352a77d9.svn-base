USE ISAFinance_JKT
GO



INSERT INTO DBO.PerkiraanKoneksiDetail
(
RowID, HeaderID, RecordID, HRecordID, NoPerkiraan, Uraian, Mdl, KodeTrn, Pasif, KodeCabang, LastUpdatedBy, LastUpdatedTime
)
SELECT 
RowID, 
(SELECT TOP 1 RowID  FROM DBO.PerkiraanKoneksi x WHERE x.RecordID = a.HRecordID) AS HeaderID, 
RecordID, HRecordID, NoPerkiraan, Uraian, Mdl, KodeTrn, Pasif, KodeCabang, LastUpdatedBy, LastUpdatedTime 
FROM ISAFinance.DBO.PerkiraanKoneksiDetail a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.PerkiraanKoneksiDetail)
GO 
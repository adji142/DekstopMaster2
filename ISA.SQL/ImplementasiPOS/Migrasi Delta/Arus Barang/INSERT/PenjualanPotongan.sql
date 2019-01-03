USE ISAdb_JKT
GO



INSERT INTO DBO.PenjualanPotongan
(
RowID, NotaPenjualanID, TrID, PotID, NoPot, TglPot, Dil, Disc, RpNet, Catatan, TglACC, DilACC, CatACC, DiscACC, SyncFlag, IdLink, StatusACC, LastUpdatedTime, LastUpdatedBy
)
SELECT RowID, 
(SELECT TOP 1 RowID FROM DBO.NotaPenjualan x WHERE x.RecordID = a.TrID) AS NotaPenjualanID, 
TrID, PotID, NoPot, TglPot, Dil, Disc, RpNet, Catatan, TglACC, DilACC, CatACC, DiscACC, SyncFlag, IdLink, StatusACC, LastUpdatedTime, LastUpdatedBy
FROM ISAdb.DBO.PenjualanPotongan a
WHERE PotID NOT IN (SELECT PotID FROM DBO.PenjualanPotongan)

GO
USE ISAdb_JKT
GO



INSERT INTO DBO.PenjualanPotonganDetail
(
RowID, HeaderID, RecordID, TrID, ID, Disc, TglPot, ACC, DIB, Catatan, DiscACC, DIBACC, CatACC, TglACC, QtyRetur, DTLink, SyncFlag, LastUpdatedBy, LastUpdatedTime
)
SELECT RowID, 
(SELECT TOP 1 RowID FROM DBO.PenjualanPotongan x WHERE x.TrID = a.TrID ) AS HeaderID, 
RecordID, TrID, ID, Disc, TglPot, ACC, DIB, Catatan, DiscACC, DIBACC, CatACC, TglACC, QtyRetur, DTLink, SyncFlag, LastUpdatedBy, LastUpdatedTime
FROM ISAdb.DBO.PenjualanPotonganDetail a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.PenjualanPotonganDetail)

GO 
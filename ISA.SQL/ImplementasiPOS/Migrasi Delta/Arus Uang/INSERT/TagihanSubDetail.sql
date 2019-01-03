USE ISAFinance_JKT
GO



INSERT INTO DBO.TagihanSubDetail
(
RowID, HeaderID, HRecordID, RecordID, TanggalKunjung, Keterangan, RpInd, SyncFlag, LastUpdatedBy, LastUpdatedTime
)
SELECT RowID, 
(SELECT  TOP  1 RowID FROM DBO.TagihanDetail x WHERE x.RecordID = a.HRecordID) AS HeaderID, 
HRecordID, RecordID, TanggalKunjung, Keterangan, RpInd, SyncFlag, LastUpdatedBy, LastUpdatedTime 
FROM ISAFinance.DBO.TagihanSubDetail a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.TagihanSubDetail)

GO 
USE ISAFinance_JKT
GO



INSERT INTO DBO.IndenSubDetail
(
RowID, HeaderID, IndenID, RecordID, HRecordID, KodeToko, NamaToko, NoReg, NoBPP, TglBPP, TglKasir, RpNominal, SyncFlag, LastUpdatedBy, LastUpdatedTime
)
SELECT a.RowID, 
(SELECT TOP 1 RowID   FROM DBO.IndenDetail x WHERE x.RecordID = a.HRecordID ) AS HeaderID, 
b.RowID AS IndenID, 
RecordID, HRecordID, KodeToko, NamaToko, NoReg, NoBPP, TglBPP, TglKasir, RpNominal, SyncFlag, LastUpdatedBy, LastUpdatedTime
FROM ISAFinance.DBO.IndenSubDetail a
OUTER APPLY
			(
			 SELECT TOP 1 x.RowID
			 FROM DBO.Inden x INNER JOIN DBO.IndenDetail y ON x.RowID = y.HeaderID
			 WHERE a.HeaderID = y.RowID
			
			)b
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.IndenSubDetail)
GO 
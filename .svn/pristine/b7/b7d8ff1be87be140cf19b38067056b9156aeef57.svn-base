USE ISAFinance_JKT
GO



INSERT INTO DBO.BuktiDetail
(
RowID, HeaderID, RecordID, HRecordID, BSRecordID, Kode, Sub, NoACC, NoPerkiraan, Uraian, Jumlah, SyncFlag, LastUpdatedBy, LastUpdatedTime
)
SELECT 
CASE WHEN a.RecordID = b.RecordID THEN b.RowID
WHEN a.RecordID = c.GiroRecID THEN c.GiroID
ELSE a.RowID END
AS RowID, 
(SELECT TOP 1 RowID FROM DBO.Bukti x WHERE x.RecordID = a.HRecordID) AS HeaderID, 
a.RecordID, HRecordID, BSRecordID, Kode, Sub, NoACC, NoPerkiraan, Uraian, Jumlah, SyncFlag, LastUpdatedBy, LastUpdatedTime
FROM ISAFinance.DBO.BuktiDetail a
OUTER APPLY
			(
			 SELECT  TOP 1 RowID,RecordID  FROM DBO.IndenDetail x
			 WHERE x.RecordID = a.RecordID
			
			)b
OUTER APPLY
			(
			 SELECT TOP 1 GiroID,GiroRecID  FROM DBO.Giro x
			 WHERE x.GiroRecID = a.RecordID
			
			)c

WHERE a.RecordID NOT IN (SELECT RecordID FROM DBO.BuktiDetail)
GO    
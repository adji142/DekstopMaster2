USE ISAFinance_JKT
GO



INSERT INTO DBO.PinjamanPegawai
(
RowID, RecordID, NIP, TglPinjam, Ref, NoRef, Uraian, KeteranganLain, Debet, Kredit, SyncFlag, LastUpdatedBy, LastUpdatedTime
)
SELECT 
CASE WHEN b.RecordID IN ('1','2','4','5') THEN b.RowID ELSE a.RowID END AS RowID, 
a.RecordID, NIP, TglPinjam, Ref, NoRef, Uraian, KeteranganLain, Debet, Kredit, SyncFlag, LastUpdatedBy, LastUpdatedTime 
FROM ISAFinance.DBO.PinjamanPegawai a
OUTER APPLY
			(
			 SELECT TOP 1 RowID,substring(RecordID,23,1) AS RecordID  FROM DBO.TransferBank x 
			 WHERE SUBSTRING(x.RecordID,1,22)  = SUBSTRING(a.RecordID,1,22) 
			 AND substring(x.RecordID,23,1) IN ('1','2','4','5')
			)b
WHERE a.RecordID NOT IN (SELECT RecordID FROM DBO.PinjamanPegawai)
GO 
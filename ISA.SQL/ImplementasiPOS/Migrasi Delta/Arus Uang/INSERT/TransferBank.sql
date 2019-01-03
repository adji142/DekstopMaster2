USE ISAFinance_JKT
GO



INSERT INTO DBO.TransferBank
(

RowID, RecordID, TglBBM, NoBBM, Src, SrcID, MK, BankID, Keterangan, Dibukukan, Diketahui, Kasir, Penyetor, NPrint, SyncFlag, LastUpdatedBy, LastUpdatedTime
)
SELECT 
CASE WHEN a.RecordID = b.RecordID THEN b.RowID 
WHEN a.RecordID = c.RecordID THEN c.RowID
ELSE a.RowID END AS RowID, 
a.RecordID, TglBBM, NoBBM, Src, 
CASE WHEN a.RecordID = b.RecordID THEN b.RowID 
WHEN a.RecordID = c.RecordID THEN c.RowID END AS SrcID, 
MK, BankID, Keterangan, Dibukukan, Diketahui, Kasir, Penyetor, NPrint, SyncFlag, LastUpdatedBy, LastUpdatedTime
FROM ISAFinance.DBO.TransferBank a
OUTER APPLY
			(
			 SELECT TOP 1  RowID, SUBSTRING(RecordID,1,22) + 'I' AS RecordID FROm DBO.Inden x
			 WHERE a.RecordID =SUBSTRING(x.RecordID,1,22) + 'I'
			
			)b
OUTER APPLY
			(
			 SELECT TOP 1 RowID,SUBSTRING(RecordID,1,22) + '8' AS RecordID  FROm DBO.KasBon x
			 WHERE a.RecordID = SUBSTRING(x.RecordID,1,22) + '8'
			
			)c

WHERE a.RecordID NOT IN (SELECT RecordID FROM DBO.TransferBank)

GO 
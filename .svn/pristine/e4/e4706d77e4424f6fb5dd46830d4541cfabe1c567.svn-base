USE ISAFinance_JKT
GO


INSERT INTO DBO.JournalDetail
(
RowID, HeaderID, RecordID, HRecordID, NoPerkiraan, Uraian, Debet, Kredit, DK, LastUpdatedBy, LastUpdatedTime, RefRowID
)
SELECT 
CASE 
WHEN LEFT(c.GiroRecID,22)  = LEFT(a.RecordID,22) AND b.Src IN ('VPG') AND b.Tanggal = c.TglGiro THEN c.GiroID
WHEN LEFT(d.GiroRecID,22)  = LEFT(a.RecordID,22) AND b.Src IN ('VTG') AND b.Tanggal = d.TglTitip THEN d.GiroID 
ELSE a.RowID END AS RowID, 
b.RowID AS HeaderID, 
RecordID, HRecordID, NoPerkiraan, Uraian, Debet, Kredit, DK, LastUpdatedBy, LastUpdatedTime, RefRowID
FROM ISAFinance.DBO.JournalDetail a
OUTER APPLY
			(
			 SELECT  TOP 1 RowID,Src,Tanggal  FROM DBO.Journal x WHERE x.RecordID = a.HRecordID 
			
			)b

OUTER APPLY
			(
			  SELECT TOP 1  GiroRecID, GiroID,TglGiro  FROM  DBO.Giro x 
			  WHERE LEFT(x.GiroRecID,22)  = LEFT(a.RecordID,22)
			  AND b.Src IN ('VPG')
			  AND x.TglGiro = b.Tanggal
			  
			)c
OUTER APPLY
			(
			  SELECT TOP 1  GiroRecID, GiroID,TglTitip  FROM  DBO.Giro x 
			  WHERE LEFT(x.GiroRecID,22)  = LEFT(a.RecordID,22)
			  AND b.Src IN ('VTG')
			  AND x.TglTitip = b.Tanggal
			  
			)d

			
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.JournalDetail)
GO 
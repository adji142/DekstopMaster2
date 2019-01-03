USE ISAFinance_JKT
GO



INSERT INTO DBO.GiroInternal
(
RowID, 
BBKID, 
GiroID, 
BBKRecID, GiroRecID, IndRecID, BankID, Kode, Sub, GC, Bank, NoGiro, TglGiro, TglJth, CairTolak, TglCair, VTA, Nominal, Kepada, Keperluan, SyncFlag, NoPerkiraan, LastUpdatedBy, LastUpdatedTime
)
SELECT a.RowID, 
CASE WHEN a.BBKRecID = c.RecordID THEN c.RowID ELSE a.BBKID END AS BBKID, 
CASE WHEN a.GiroRecID = b.RecordID THEN b.RowID ELSE a.GiroID END AS GiroID, 
BBKRecID, GiroRecID, IndRecID, BankID, Kode, Sub, GC, Bank, NoGiro, TglGiro, TglJth, CairTolak, TglCair, VTA, Nominal, Kepada, Keperluan, SyncFlag, NoPerkiraan, LastUpdatedBy, LastUpdatedTime
FROM ISAFinance.DBO.GiroInternal a
OUTER APPLY
			(
			 SELECT TOP 1 RecordID,RowID  FROM  DBO.BankDetail x
			 WHERE x.RecordID = a.GiroRecID
			
			)b
OUTER APPLY
			(
			 SELECT TOP 1 RecordID,RowID  FROM DBO.BBK x
			 WHERE x.RecordID = a.BBKRecID
			
			)c			

WHERE GiroRecID NOT IN (SELECT GiroRecID FROM DBO.GiroInternal)
GO 
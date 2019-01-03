USE ISAFinance_JKT
GO



INSERT INTO DBO.KartuPiutangDetail
(
RowID, HeaderID, RecordID, KPID, TglTransaksi, KodeTransaksi, Debet, Kredit, TglJTGiro, Uraian, SyncFlag, NoBuktiKasMasuk, NoGiro, Bank, NoACC, isClosed, LastUpdatedBy, LastUpdatedTime
)
SELECT 
CASE WHEN b.RecordID = a.RecordID AND KodeTransaksi IN ('BGC', 'KAS', 'TRN') THEN b.RowID ELSE a.RowID END AS RowID, 
(SELECT TOP 1 RowID FROM DBO.KartuPiutang x WHERE x.KPID = a.KPID) AS HeaderID, 
a.RecordID, KPID, TglTransaksi, KodeTransaksi, Debet, Kredit, TglJTGiro, Uraian, SyncFlag, NoBuktiKasMasuk, NoGiro, Bank, NoACC, isClosed, LastUpdatedBy, LastUpdatedTime 
FROM ISAFinance.DBO.KartuPiutangDetail a
OUTER APPLY
			(
			 SELECT TOP 1 RecordID, RowID FROM  DBO.IndenSubDetail x
			 WHERE x.RecordID = a.RecordID			 
			)b
WHERE (a.KPID+a.RecordID) NOT IN (SELECT (KPID+RecordID) FROM DBO.KartuPiutangDetail)
--WHERE a.RecordID NOT IN (SELECT RecordID FROM DBO.KartuPiutangDetail)
GO 
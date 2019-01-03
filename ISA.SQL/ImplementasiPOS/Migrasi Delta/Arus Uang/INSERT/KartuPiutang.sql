USE ISAFinance_JKT
GO



INSERT INTO DBO.KartuPiutang
(
RowID, KPID, KodeToko, KodeSales, TglTransaksi, TglLink, NoTransaksi, Status, JangkaWaktu, TglJatuhTempo, Uraian, TransactionType, SyncFlag, HariKirim, HariSales, KeteranganTagih, LastUpdatedBy, LastUpdatedTime
)
SELECT 
CASE WHEN b.RecordID = a.KPID THEN b.RowID ELSE  a.RowID END AS RowID, 
KPID, KodeToko, KodeSales, TglTransaksi, TglLink, NoTransaksi, Status, JangkaWaktu, TglJatuhTempo, Uraian, TransactionType, SyncFlag, HariKirim, HariSales, KeteranganTagih, LastUpdatedBy, LastUpdatedTime

FROM ISAFinance.DBO.KartuPiutang a
OUTER APPLY
			(
			 SELECT TOP 1 RowID,RecordID  FROM ISAdb.dbo.NotaPenjualan x
			 WHERE x.RecordID = a.KPID
			)b
WHERE KPID NOT IN (SELECT KPID FROM DBO.KartuPiutang)
GO
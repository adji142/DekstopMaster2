USE ISAFinance_JKT
GO



INSERT INTO DBO.Giro
(
GiroID, VoucherID, BBMID, TitipID, VoucherRecID, BBMRecID, TitipRecID, GiroRecID, KodeToko, NamaBank, Lokasi, CHBG, Nomor, TglGiro, TglJth, Nominal, CairTolak, TglCair, MainTitip, SubTitip, MainPiutang, SubPiutang, BankID, NamaBanki, NoPerkiraan, TglTitip, SyncFlag, NoACC, MainPerkiraan, LastUpdatedBy, LastUpdatedTime
)
SELECT 
CASE WHEN b.RecordID = a.GiroRecID THEN b.RowID ELSE a.GiroID END AS GiroID, 
CASE WHEN c.RecordID = a.VoucherRecID THEN c.RowID ELSE a.VoucherID END AS VoucherID, 
CASE WHEN d.RecordID = a.BBMRecID THEN d.RowID ELSE a.BBMID END AS BBMID, 
CASE WHEN e.RecordID = a.VoucherRecID AND e.Tipe = 'TT' THEN e.RowID ELSE a.TitipID END AS TitipID, 
VoucherRecID, BBMRecID, TitipRecID, GiroRecID, KodeToko, NamaBank, Lokasi, CHBG, Nomor, TglGiro, TglJth, Nominal, CairTolak, TglCair, MainTitip, SubTitip, MainPiutang, SubPiutang, BankID, NamaBanki, NoPerkiraan, TglTitip, SyncFlag, NoACC, MainPerkiraan, LastUpdatedBy, LastUpdatedTime
FROM ISAFinance.DBO.Giro a
OUTER APPLY
			(
			  SELECT TOP 1 RowID,RecordID FROM DBO.IndenDetail x
			  WHERE x.RecordID = a.GiroRecID
			
			)b
OUTER APPLY
			(
			 SELECT TOP 1 RecordID,RowID  FROM DBO.VoucherJournal x
			 WHERE x.RecordID  = a.VoucherRecID
			
			)c
OUTER APPLY
			(
			 SELECT TOP 1 RecordID,RowID  FROM DBO.BBM x
			 WHERE x.RecordID = a.BBMRecID
			)d
OUTER APPLY
			(
			 SELECT TOP 1 Tipe,RecordID,RowID  FROM DBO.VoucherJournal x
			 WHERE x.RecordID = a.VoucherRecID
			 AND x.Tipe  = 'TT'
			
			)e
			
WHERE GiroRecID NOT IN (SELECT GiroRecID FROM DBO.Giro)
GO 
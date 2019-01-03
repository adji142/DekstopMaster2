USE ISAFinance_JKT
GO



INSERT INTO DBO.TransferBankDetail
(
RowID, HeaderID, RecordID, HRecordID, KodeToko, AsalTransfer, NamaBank, Lokasi, Nomor, TglTransfer, TglBank, Nominal, MainTitip, SubTitip, MainPiut, SubPiut, BankID, NoPerkiraan, TitiPerkiraan, SyncFlag, LastUpdatedBy, LastUpdatedTime
)
SELECT 
CASE WHEN b.RecordID = a.HRecordID AND substring(b.RecordID,23,1)='8' THEN b.RowID
WHEN c.RecordID = a.RecordID THEN c.RowID ELSE a.RowID END AS RowID
, 
(SELECT TOP 1 RowID FROM DBO.TransferBank x WHERE x.RecordID = a.HRecordID) HeaderID, 
a.RecordID, HRecordID, KodeToko, AsalTransfer, NamaBank, Lokasi, Nomor, TglTransfer, TglBank, Nominal, MainTitip, SubTitip, MainPiut, SubPiut, BankID, NoPerkiraan, TitiPerkiraan, SyncFlag, LastUpdatedBy, LastUpdatedTime
FROM ISAFinance.DBO.TransferBankDetail  a
OUTER APPLY
			(
			 SELECT TOP 1 RowID, RecordID FROM DBO.TransferBank x
			 WHERE x.RecordID = a.HRecordID
			 AND substring(x.RecordID,23,1)='8'
			)b
OUTER APPLY
			(
			 SELECT TOP 1 RowID,RecordID  FROM DBO.IndenDetail x
			 WHERE x.RecordID = a.RecordID
			
			)c
WHERE a.RecordID NOT IN (SELECT RecordID FROM DBO.TransferBankDetail)

GO
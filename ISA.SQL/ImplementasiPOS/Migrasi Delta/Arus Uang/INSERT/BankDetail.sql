USE ISAFinance_JKT
GO



INSERT INTO DBO.BankDetail
(
RowID, HeaderID, RecordID, HRecordID, RegID, TglTran, NoBBK, JnsTran, NoBGCH, Keterangan, VTA, Debet, Kredit, TglBank, TglRK, Saldo, NPrint, SyncFlag, LinkRK, LinkTransferBankID, Kode, Sub, Catatan, NoPerkiraan, LastUpdatedBy, LastUpdatedTime
)
SELECT 
	RowID, 
	(SELECT TOP 1 RowID FROM dbo.Bank x WHERE x.BankID =  a.HRecordID) AS HeaderID, 
	RecordID, HRecordID, RegID, TglTran, NoBBK, JnsTran, NoBGCH, Keterangan, VTA, Debet, Kredit, TglBank, TglRK, Saldo, NPrint, SyncFlag, LinkRK, LinkTransferBankID, Kode, Sub, Catatan, NoPerkiraan, LastUpdatedBy, LastUpdatedTime
FROM ISAFinance.DBO.BankDetail a 
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.BankDetail)
GO 


DELETE from BankDetail 
where
JnsTran = 'VTG'
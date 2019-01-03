USE ISAFinance 
GO
DELETE FROM dbo.VoucherJournalDetail
GO
INSERT INTO dbo.VoucherJournalDetail
(
	RowID, 
	HeaderID, 
	RecordID, 
	HRecordID, 
	Kode, 
	Sub, 
	VoucherType, 
	VoucherNo, 
	NoPerkiraan, 
	Keterangan, 
	Debet, 
	Kredit, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	NULL,
	iddvoucher,
	idhvoucher,
	kode,
	sub,
	voutype,
	vouno,
	no_perk,
	desc1,
	debet,
	kredit,
	CASE WHEN id_match='1' THEN 1 ELSE 0 END ,
	'Import',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM dvoucher')

GO


---- DELETE DUPLICATE DVOUCHER
--SELECT 
--COUNT(*) AS Jumlah,RecordID
--INTO #TEMP_VoucherJournalDetail
--FROM DBO.VoucherJournalDetail
--GROUP BY RecordID
--HAVING COUNT(*) > 1 
--GO

--DECLARE delCursor CURSOR   
--FOR SELECT 
--RecordID
--FROM #TEMP_VoucherJournalDetail

--OPEN delCursor

--DECLARE @RecordID varchar(23)
--DECLARE @RowID UNIQUEIDENTIFIER

--FETCH NEXT FROM delCursor      
--INTO @RecordID

--WHILE @@FETCH_STATUS = 0      
--BEGIN  
--SELECT  TOP 1 @RowID=RowID FROM DBO.VoucherJournalDetail
--WHERE RecordID = @RecordID


--DELETE FROM DBO.VoucherJournalDetail WHERE RowID <> @RowID
--AND RecordID = @RecordID

--FETCH NEXT FROM delCursor      
--INTO @RecordID

--END
--CLOSE delCursor      
--DEALLOCATE delCursor  			  
--GO

--DROP TABLE #TEMP_VoucherJournalDetail
--GO


UPDATE VoucherJournalDetail SET
HeaderID=b.rowID
FROM VoucherJournalDetail a INNER JOIN VoucherJournal b ON a.hrecordid=b.recordid

GO



UPDATE VoucherJournalDetail SET
RowID=b.RowID
FROM VoucherJournalDetail a INNER JOIN IndenDetail b ON a.RecordID=b.RecordID

GO

  
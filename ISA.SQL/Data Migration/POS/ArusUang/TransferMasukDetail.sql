 USE ISAFinance 
GO
DELETE FROM dbo.TransferBankDetail
GO
INSERT INTO dbo.TransferBankDetail
(
	RowID, 
	HeaderID, 
	RecordID, 
	HRecordID, 
	KodeToko, 
	AsalTransfer, 
	NamaBank, 
	Lokasi, 
	Nomor, 
	TglTransfer, 
	--TglBank, --> baca ke tabel TransferBank.TglBBM
	Nominal, 
	MainTitip, 
	SubTitip, 
	MainPiut, 
	SubPiut, 
	BankID, 
	NoPerkiraan, 
	TitiPerkiraan, 
	SyncFlag, 	
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	NULL,
	idtrm,
	idbbm,
	kd_toko,
	asaltrf,
	namabank,
	lokasi,
	nomor,
	tgl_trf,
	--tgl_bank,
	nominal,
	maintitip,
	subtitip,
	mainpiut,
	subpiut,
	idbank,
	no_perk,
	titiperk,
	id_match,	
	'DELTA CRB',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM TRMTRF')

GO
UPDATE DBO.TransferBankDetail
SET 
RowID = b.RowID,
HeaderID = b.HeaderID

FROM DBO.TransferBankDetail a INNER JOIN ISAFinance_JKT.DBO.TransferBankDetail b ON a.RecordID =  b.RecordID


GO 

---- DELETE DUPLICATE DATA TRMTRF
--SELECT COUNT(*) AS jumlah,RecordID
--INTO #TEMP_TransferBankDetail
--FROM DBO.TransferBank
--GROUP BY RecordID
--HAVING COUNT(*) > 1

--DECLARE delCursor CURSOR   
--FOR SELECT 
--RecordID
--FROM #TEMP_TransferBankDetail

--OPEN delCursor

--DECLARE @RecordID varchar(23)
--DECLARE @RowID UNIQUEIDENTIFIER

--FETCH NEXT FROM delCursor      
--INTO @RecordID

--WHILE @@FETCH_STATUS = 0      
--BEGIN  
--SELECT  TOP 1 @RowID=RowID FROM DBO.TransferBankDetail
--WHERE RecordID = @RecordID


--DELETE FROM DBO.TransferBankDetail WHERE RowID <> @RowID
--AND RecordID = @RecordID

--FETCH NEXT FROM delCursor      
--INTO @RecordID

--END
--CLOSE delCursor      
--DEALLOCATE delCursor  			  
--GO

--DROP TABLE #TEMP_TransferBankDetail
--GO


UPDATE TransferBankDetail SET
HeaderID=b.rowID
FROM TransferBankDetail a INNER JOIN TransferBank b ON a.hrecordid=b.recordid

GO

UPDATE TransferBankDetail SET
RowID=b.rowID
FROM TransferBankDetail a INNER JOIN TransferBank b ON a.hrecordid=b.recordid 
where substring(b.recordid,23,1)='8'
AND b.RecordID NOT IN (
'C092011072808:38:08KSM8',
'C092002111313:01:44KSM8'
)

GO

UPDATE TransferBankDetail SET
RowID=b.RowID
FROM TransferBankDetail a INNER JOIN IndenDetail b ON a.RecordID=b.RecordID


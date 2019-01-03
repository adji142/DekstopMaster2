 USE ISAFinance 
GO
DELETE FROM dbo.TransferBank
GO

INSERT INTO dbo.TransferBank
(
	RowID, 
	RecordID, 
	TglBBM, 
	NoBBM, 
	MK, 
	Keterangan, 	
	Dibukukan, 
	Diketahui, 
	Kasir, 
	Penyetor, 
	NPrint, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	idbbm,
	tgl_bbm,
	no_bbm,
	mk,
	nm_bank,
	dibukuan,
	diketahui,
	kasir,
	penyetor,
	nprint,
	id_match,	
	'Import',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM HTRF')

GO


---- DELETE DUPLICATE DATA HTRF
--SELECT COUNT(*) AS jumlah,RecordID
--INTO #TEMP_TransferBank
--FROM DBO.TransferBank
--GROUP BY RecordID
--HAVING COUNT(*) > 1

--DECLARE delCursor CURSOR   
--FOR SELECT 
--RecordID
--FROM #TEMP_TransferBank

--OPEN delCursor

--DECLARE @RecordID varchar(23)
--DECLARE @RowID UNIQUEIDENTIFIER

--FETCH NEXT FROM delCursor      
--INTO @RecordID

--WHILE @@FETCH_STATUS = 0      
--BEGIN  
--SELECT  TOP 1 @RowID=RowID FROM DBO.TransferBank
--WHERE RecordID = @RecordID


--DELETE FROM DBO.TransferBank WHERE RowID <> @RowID
--AND RecordID = @RecordID

--FETCH NEXT FROM delCursor      
--INTO @RecordID

--END
--CLOSE delCursor      
--DEALLOCATE delCursor  			  
--GO

--DROP TABLE #TEMP_TransferBank
--GO

UPDATE TransferBank SET
SrcID = b.RowID,
RowID=b.RowID
FROM TransferBank a INNER JOIN Inden b ON a.RecordID =SUBSTRING(b.RecordID,1,22) + 'I'
GO

UPDATE TransferBank SET
SrcID = b.RowID,
RowID=b.RowID
FROM TransferBank a INNER JOIN KasBon b ON a.RecordID = SUBSTRING(b.RecordID,1,22) + '8'
GO

update transferbank
set src='BSL'
where substring(recordid,23,1)='8'

GO

update transferbank
set src='PKK',
	SrcID = RowID
where substring(recordid,23,1)='1'

GO

update transferbank
set src='PKM',
	SrcID = RowID
where substring(recordid,23,1)='2'

GO

update transferbank
set src='IND'
where substring(recordid,23,1)='I'

GO

update transferbank
set src='OUT'
where substring(recordid,23,1)='4'
USE ISAFinance 
GO
DELETE FROM dbo.BuktiDetail
GO
INSERT INTO dbo.BuktiDetail
(
	RowID, 
	HeaderID, 
	RecordID, 
	HRecordID, 
	BSRecordID, 
	Kode, 
	Sub, 
	NoACC, 
	NoPerkiraan, 
	Uraian, 
	Jumlah, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	NULL,
	idrec,
	idtr,
	idbs,
	kode,
	sub,
	'',
	no_perk,
	uraian,
	jumlah,
	1,	
	'DELTA CRB',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM dbukti')

GO


----- Bersih Duplikasi Data DBukti FOXPRO

--SELECT COUNT(*) AS Jumlah, 
--RecordID
--INTO #TEMP_BUKTI_DETAIL
--FROM dbo.BuktiDetail
--GROUP BY RecordID 
--HAVING COUNT(*) > 1

--GO
			
--DECLARE delCursor CURSOR   
--FOR SELECT 
--RecordID
--FROM #TEMP_BUKTI_DETAIL

--OPEN delCursor

--DECLARE @RecordID varchar(23)
--DECLARE @RowID UNIQUEIDENTIFIER

--FETCH NEXT FROM delCursor      
--INTO @RecordID

--WHILE @@FETCH_STATUS = 0      
--BEGIN  
--SELECT  TOP 1 @RowID=RowID FROM DBO.BuktiDetail
--WHERE RecordID = @RecordID


--DELETE FROM DBO.BuktiDetail WHERE RowID <> @RowID
--AND RecordID = @RecordID

--FETCH NEXT FROM delCursor      
--INTO @RecordID

--END
--CLOSE delCursor      
--DEALLOCATE delCursor  			  

--GO

--DROP TABLE #TEMP_BUKTI_DETAIL
--GO

--DELETE FROM DBO.BuktiDetail WHERE RecordID = ''  
--GO

UPDATE DBO.BuktiDetail
SET RowID = b.RowID,
HeaderID = b.HeaderID

FROM DBO.BuktiDetail a INNER JOIN ISAFinance_JKT.DBO.BuktiDetail b ON a.RecordID =  b.RecordID


GO 

update buktidetail set 
rowid=b.rowid
from buktidetail a inner join indendetail b on a.recordid=b.recordid

GO



UPDATE DBO.BuktiDetail
SET RowID = b.GiroID
FROM DBO.BuktiDetail a INNER JOIN DBO.Giro b ON a.RecordID = b.GiroRecID
GO

UPDATE dbo.BuktiDetail
SET
	HeaderID = (SELECT TOP 1 RowID FROM dbo.Bukti b WHERE b.RecordID = a.HRecordID)
FROM dbo.BuktiDetail a

GO 

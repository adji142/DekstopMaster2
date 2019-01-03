USE ISAFinance 
GO
DELETE FROM dbo.Bukti
GO

INSERT INTO dbo.Bukti
(
	RowID, 
	RecordID, 
	MK, 
	JenisBukti, 
	NoBukti, 
	TglBukti, 
	Kepada, 
	Pembukuan, 
	NoACC, 
	Kasir, 
	Penerima, 
	NPrint, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),	
	RTRIM(Idtr),
	MK,
	RTRIM(Jns_bukti),
	RTRIM(No_bukti),
	RTRIM(Tgl_Bukti),
	RTRIM(Kepada),
	RTRIM(Pembukuan),
	RTRIM(Acc),
	Kasir,
	Penerima,
	NPrint,
	id_match,
	'DELTA CRB',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM hbukti')

GO

UPDATE DBO.Bukti
SET RowID = b.RowID,
SrcID = b.SrcID

FROM DBO.Bukti a INNER JOIN ISAFinance_JKT.DBO.Bukti b ON a.RecordID =  b.RecordID


GO 
----- Bersih Duplikasi Data HBukti FOXPRO

--SELECT COUNT(*) AS Jumlah, 
--RecordID
--INTO #TEMP_BUKTI
--FROM dbo.Bukti
--GROUP BY RecordID 
--HAVING COUNT(*) > 1

--GO
			
--DECLARE delCursor CURSOR   
--FOR SELECT 
--RecordID
--FROM #TEMP_BUKTI

--OPEN delCursor

--DECLARE @RecordID varchar(23)
--DECLARE @RowID UNIQUEIDENTIFIER

--FETCH NEXT FROM delCursor      
--INTO @RecordID

--WHILE @@FETCH_STATUS = 0      
--BEGIN  
--SELECT  TOP 1 @RowID=RowID FROM DBO.Bukti
--WHERE RecordID = @RecordID


--DELETE FROM DBO.Bukti WHERE RowID <> @RowID
--AND RecordID = @RecordID

--FETCH NEXT FROM delCursor      
--INTO @RecordID

--END
--CLOSE delCursor      
--DEALLOCATE delCursor  			  

--GO

--DROP TABLE #TEMP_BUKTI
--GO

--DELETE FROM DBO.Bukti WHERE RecordID = ''  
--GO

--UPDATE SRC
update bukti set 
src = 'IND'
where substring(recordid,23,1)='I'
GO

update bukti set 
Src = 'BSA' 
WHERE SUBSTRING(RecordID,23,1) = '1'
GO

update bukti set 
Src = 'BSK'
WHERE SUBSTRING(RecordID,23,1) = '2'
GO

update bukti set 
Src = 'BSL'
WHERE SUBSTRING(RecordID,23,1) = '3'
GO

update bukti set 
Src = 'BNK'
WHERE SUBSTRING(RecordID,23,1) = 'B'
GO

update bukti set 
Src = 'PIK',
SrcID=RowID
WHERE (SUBSTRING(RecordID,23,1) = '4' OR SUBSTRING(RecordID,23,1) = '5')
GO

update bukti set 
Src = 'OUT'
WHERE SUBSTRING(RecordID,23,1) = '6'
GO

update bukti set 
Src = 'IN'
WHERE SUBSTRING(RecordID,23,1) = '7'
GO

update bukti set 
Src = 'PJT'
WHERE SUBSTRING(RecordID,23,1) = 'T'
GO

update bukti set 
Src = 'SLP'
WHERE SUBSTRING(RecordID,23,1) = 'S'
GO

--UPDATE SRCID
update bukti set 
--rowid=b.rowid,
SrcID=b.rowid
from bukti a inner join inden b on a.recordid=rtrim(b.recordid)+'I'
GO

update bukti set 
SrcID=b.rowid
from bukti a inner join KasBon b on SUBSTRING(a.RecordID,1,22) = SUBSTRING(b.RecordID,1,22)

GO

update bukti set 
--rowid=b.rowid,
SrcID=b.rowid
from bukti a inner join BankDetail b on SUBSTRING(a.RecordID,1,22) = SUBSTRING(b.RecordID,1,22)
WHERE SUBSTRING(a.RecordID,23,1)='B'
GO 



UPDATE DBO.Bukti
SET --RowID = b.RowID,
SrcID=b.rowid
FROM DBO.Bukti a INNER JOIN dbo.KartuPiutang b ON SUBSTRING(a.RecordID,1,22) = SUBSTRING(b.KPID,1,22)
WHERE SUBSTRING(a.RecordID,23,1) = 'T' AND LEFT(b.TransactionType,1) = 'T'
GO


UPDATE DBO.Bukti
SET --RowID = b.RowID,
SrcID=b.rowid
FROM DBO.Bukti a INNER JOIN DBO.VoucherJournal b ON a.RecordID = SUBSTRING(b.RecordID,1,22) + 'S'
WHERE b.Tipe = 'TT'
GO




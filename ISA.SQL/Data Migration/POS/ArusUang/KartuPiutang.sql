 USE ISAFinance 
GO
DELETE FROM dbo.KartuPiutang
GO
INSERT INTO dbo.KartuPiutang 
(
	RowID,
	KPID, 
	KodeToko, 
	KodeSales, 
	TglTransaksi, 
	NoTransaksi, 
	JangkaWaktu, 
	TglJatuhTempo, 
	Uraian,  
	TransactionType, 
	SyncFlag, 
	HariKirim, 
	HariSales, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
    NEWID(),
	RTRIM(id_kp),
	RTRIM(kd_toko),
	RTRIM(kd_sales),
	tgl_tr,
	RTRIM(no_tr),
	jk_waktu,
	tgl_jt,
	RTRIM(uraian),
	RTRIM(id_tr),
	CASE WHEN id_match = '0' THEN '0' WHEN id_match = '1' THEN '1' ELSE '1' END AS id_match,
	hari_krm,
	hari_sls,
	'DELTA CRB',
	GETDATE()	
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM kpiutang')

GO

--SELECT COUNT(*) AS Jumlah, 
--KPID
--INTO #TEMP_KartuPiutang
--FROM dbo.KartuPiutang
--GROUP BY KPID 
--HAVING COUNT(*) > 1

--GO
			
--DECLARE delCursor CURSOR   
--FOR SELECT 
--KPID
--FROM #TEMP_KartuPiutang

--OPEN delCursor

--DECLARE @RecordID varchar(23)
--DECLARE @RowID UNIQUEIDENTIFIER

--FETCH NEXT FROM delCursor      
--INTO @RecordID

--WHILE @@FETCH_STATUS = 0      
--BEGIN  
--SELECT  TOP 1 @RowID=RowID FROM DBO.KartuPiutang
--WHERE KPID = @RecordID


--DELETE FROM DBO.KartuPiutang WHERE RowID <> @RowID
--AND KPID = @RecordID

--FETCH NEXT FROM delCursor      
--INTO @RecordID

--END
--CLOSE delCursor      
--DEALLOCATE delCursor  			  

--GO

--DROP TABLE #TEMP_KartuPiutang

--GO

UPDATE DBO.KartuPiutang
SET 
RowID = b.RowID

FROM DBO.KartuPiutang a INNER JOIN ISAFinance_JKT.DBO.KartuPiutang b ON a.KPID =  b.KPID


GO 
UPDATE dbo.KartuPiutang
SET
	RowID =  b.RowID
FROM dbo.KartuPiutang a
INNER JOIN ISAdb.dbo.NotaPenjualan b ON a.KPID = b.RecordID 

--- tes ali
GO


GO


USE ISAFinance 
GO
DELETE FROM dbo.PinjamanPegawai
GO

INSERT INTO dbo.PinjamanPegawai
(
	RowID, 
	RecordID, 
	NIP, 
	TglPinjam, 
	Ref, 
	NoRef, 
	Uraian, 
	KeteranganLain, 
	Debet, 
	Kredit, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	iddpinj,
	nip,
	tgl,
	ref,
	no_ref,
	uraian,
	ket_lain2,
	debet,
	kredit,
	id_match,
	'Import',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM dpinjpgw')

GO


UPDATE DBO.PinjamanPegawai
SET RowID = tb.RowID
FROM DBO.PinjamanPegawai pp  INNER JOIN DBO.TransferBank tb ON SUBSTRING(tb.RecordID,1,22)  = SUBSTRING(pp.RecordID,1,22) 
WHERE substring(tb.RecordID,23,1) = '2' 

GO

UPDATE DBO.PinjamanPegawai
SET RowID = tb.RowID
FROM DBO.PinjamanPegawai pp INNER JOIN DBO.TransferBank tb ON SUBSTRING(tb.RecordID,1,22)  = SUBSTRING(pp.RecordID,1,22) 
WHERE substring(tb.RecordID,23,1) = '1' 

GO

UPDATE DBO.PinjamanPegawai 
SET RowID = pp.RowID
FROM DBO.PinjamanPegawai b INNER JOIN DBO.Bukti pp ON SUBSTRING(b.RecordID,1,22) = SUBSTRING(pp.RecordID,1,22)
WHERE (SUBSTRING(pp.RecordID,23,1) = '4' or SUBSTRING(pp.RecordID,23,1) = '5')
GO
--- Bersih Duplikasi Data HBukti FOXPRO

--SELECT COUNT(*) AS Jumlah, 
--RecordID
--INTO #TEMP_PINJAMAN_PEGAWAI
--FROM dbo.PinjamanPegawai
--GROUP BY RecordID 
--HAVING COUNT(*) > 1

--GO
			
--DECLARE delCursor CURSOR   
--FOR SELECT 
--RecordID
--FROM #TEMP_PINJAMAN_PEGAWAI

--OPEN delCursor

--DECLARE @RecordID varchar(23)
--DECLARE @RowID UNIQUEIDENTIFIER

--FETCH NEXT FROM delCursor      
--INTO @RecordID

--WHILE @@FETCH_STATUS = 0      
--BEGIN  
--SELECT  TOP 1 @RowID=RowID FROM DBO.PinjamanPegawai
--WHERE RecordID = @RecordID


--DELETE FROM DBO.PinjamanPegawai WHERE RowID <> @RowID
--AND RecordID = @RecordID

--FETCH NEXT FROM delCursor      
--INTO @RecordID

--END
--CLOSE delCursor      
--DEALLOCATE delCursor  			  

--GO

--DROP TABLE #TEMP_PINJAMAN_PEGAWAI
--GO

 

GO

  
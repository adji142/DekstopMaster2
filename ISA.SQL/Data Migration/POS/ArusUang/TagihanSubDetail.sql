USE ISAFinance

TRUNCATE TABLE dbo.TagihanSubDetail
GO


SELECT 
NEWID() AS RowID,
iddrec RecorID,
LEFT(idrec,23 ) HrecordID,
CASE WHEN YEAR(tanggal) < 1900 THEN NULL ELSE tanggal END AS tanggal,
ket,
rp_ind,
1 SYnflag,
'DELTA CRB' audit,GETDATE() tgl
INTO #TEMP
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM DKUNJUNG')

INSERT INTO dbo.TagihanSubDetail(HeaderID,RowID,  RecordID, HRecordID, 
TanggalKunjung, Keterangan, RpInd, SyncFlag, LastUpdatedBy, LastUpdatedTime)
SELECT i.RowID, t.*
FROM #TEMP t
CROSS APPLY (SELECT TOP 1 RowID FROM dbo.TagihanDetail i WHERE i.RecordID = t.HrecordID )i
GO


--UPDATE dbo.TagihanSubDetail
--	SET HeaderID = a.RowID
--	FROM dbo.TagihanSubDetail b
--	INNER JOIN dbo.TagihanDetail a ON a.RecordID=b.HRecordID
GO

UPDATE DBO.TagihanSubDetail
SET 
RowID = b.RowID,
HeaderID = b.HeaderID

FROM DBO.TagihanSubDetail a INNER JOIN ISAFinance_JKT.DBO.TagihanSubDetail b ON a.RecordID =  b.RecordID


GO 
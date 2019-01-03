 USE ISAdb 
GO
DELETE FROM dbo.[PenjualanPotonganDetail]
GO

SELECT 
	NEWID() AS RowID, 
	RTRIM(a.idrec) AS RecID,
	RTRIM(a.idtr) AS TrID, 
	RTRIM(a.id) AS ID,
 	CONVERT(datetime , CASE LEFT(a.tgl_pot,2) WHEN '  ' THEN NULL ELSE RTRIM(a.tgl_pot) END ) AS TglPot, 
	a.disc AS Disc, 
	dib AS dib, 
	RTRIM(a.catatan) AS Catatan,
	CASE WHEN RTRIM(a.acc)<> '' THEN 1 ELSE 0 END AS StatusACC,
	CONVERT(datetime , CASE LEFT(a.tgl_acc,2) WHEN '  ' THEN NULL ELSE RTRIM(a.tgl_acc) END ) AS TglACC, 
	a.dib_acc AS DibACC,
	RTRIM(a.cat_acc) AS CatACC, 
	a.disc_acc AS DiscACC,
    a.j_retur as QtyRetur,
	RTRIM(a.id_match) AS SyncFlag, 
	RTRIM(a.dt_link) AS dtLink	
INTO #PenjualanPotonganDetailTemp
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ','SELECT * FROM dpotj') a 

INSERT INTO [ISAdb].[dbo].[PenjualanPotonganDetail]
	([RowID]
	,[RecordID]
	,[TrID]
	,[ID]
	,[Disc]
	,[TglPot]
	,[ACC]
	,[DIB]
	,[Catatan]
	,[DiscACC]
	,[DIBACC]
	,[CatACC]
	,[TglACC]
	,[QtyRetur]
	,[DTLink]
	,[SyncFlag]
	,[LastUpdatedBy]
	,[LastUpdatedTime])
SELECT 
	RowID, 
	RecID,
	TrID, 
	ID, 
	Disc, 
 	TglPot,
	StatusACC,
	dib, 
	Catatan,
	DiscACC,
	DibACC,
	CatACC,
	TglACC, 
	QtyRetur,
	dtLink,
	SyncFlag, 
	'System' as LastUpdatedBy,
	getdate() as LastUpdatedTime
from #PenjualanPotonganDetailTemp

UPDATE dbo.PenjualanPotonganDetail
SET [HeaderID] = b.RowID
FROM dbo.PenjualanPotonganDetail a LEFT OUTER JOIN dbo.PenjualanPotongan b
ON a.trID = b.trID

GO
DROP TABLE #PenjualanPotonganDetailTemp
GO
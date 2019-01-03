 USE ISAdb 
GO
DELETE FROM ISAdb.dbo.[BarangBonusDetail]
GO

INSERT INTO [ISAdb].[dbo].[BarangBonusDetail]
           ([RowId]
           ,[TrId]
           ,[RecordId]
           ,[BarangId]
           ,[Qty]
           ,[SyncFlag]
           ,[LastUpdatedBy]
           ,[LastUpdatedTime])
SELECT 
	newid() as RowID,
	RTRIM(idtr) as TrID,
	RTRIM(idrec) as RecordID,
	RTRIM(id_brg) as BarangID,
	qty as Qty,
	RTRIM(a.id_match) AS SyncFlag,
	'DELTA CRB',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 
'SELECT *
FROM DBABON') AS a

UPDATE dbo.BarangBonusDetail
SET [HeaderID] = b.RowID
FROM dbo.BarangBonusDetail a LEFT OUTER JOIN dbo.BarangBonus b
ON a.trID = b.trID 
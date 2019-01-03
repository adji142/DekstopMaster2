 USE ISAdb 
GO
DELETE FROM ISAdb.dbo.[BarangBonus]
GO

INSERT INTO [ISAdb].[dbo].[BarangBonus]
	([RowID]
	,[TrID]
	,[TrIDhtj]
	,[Tanggal]
	,[KodeToko]
	,[SyncFlag]
	,[KodeToko1]
	,[LastUpdatedBy]
	,[LastUpdatedTime])
SELECT
	newid() as RowID,
	RTRIM(idtr) as TrID,
	RTRIM(idtrhtj) as TrIDhtj,
	CONVERT(datetime , CASE LEFT(a.tanggal,2) WHEN '  ' THEN NULL ELSE RTRIM(a.tanggal) END ) as tanggal,
	RTRIM(Kd_toko) as kodetoko,
	RTRIM(a.id_match) AS SyncFlag,
	RTRIM(Kd_toko) as kodetoko1,
	'Admin',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 
'SELECT *
FROM HBABON') AS a 
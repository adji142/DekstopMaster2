 USE ISAdb 
GO
DELETE FROM ISAdb.dbo.ReIDWil
GO
INSERT INTO ISAdb.dbo.ReIDWil
(
	RowID, 
	RecID, 
	TokoID,
	KodeToko, 
	Tanggal, 
	WilID, 
	WilIDOld, 
	Keterangan, 
	LRefresh, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	newid(),
	RTRIM(a.idrec), 
	b.RowID,
	a.kd_toko,
	a.tanggal, 
	RTRIM(a.idwil), 
	RTRIM(a.oldwil),
	RTRIM(a.keterangan),
	RTRIM(a.lrefresh), 
	a.id_match,
	'Admin',
	getdate()  
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM Reidwil') a LEFT OUTER JOIN dbo.Toko b
ON a.kd_toko=b.KodeToko

GO

--SELECT * FROM Checker 
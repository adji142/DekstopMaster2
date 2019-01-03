USE ISAdb 

GO
DELETE FROM ISAdb.dbo.KoliTone

GO
INSERT INTO ISAdb.dbo.KoliTone
(
	RowID, 
	RecID, 
	BarangID, 
	Pcs, 
	Koli, 
	QPoint, 
	Jenis, 
	ItemCode, 
	NPoint, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(), 
	RTRIM(a.idrec), 
	RTRIM(a.id_brg), 
	a.pcs,
	a.koli,
	a.q_point,
	RTRIM(a.jenis),
	RTRIM(a.item_code),
	a.n_point,
	'Admin',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM Kolitone') a 

GO
--SELECT * FROM KoliTone
  
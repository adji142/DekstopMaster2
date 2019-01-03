USE ISAdb
GO

DELETE FROM dbo.StandarStokHistory
GO
INSERT INTO	dbo.StandarStokHistory
(
	RowID,
	KodeBarang,
	TglProses,
	TglLink	,
	QtyMaximum,
	QtyMinimum,
	QtyAkhir,
	QtyOrder,
	LinkID,
	Flag,
	LastUpdatedBy,
	LastUpdatedTime	
)
SELECT
	NEWID(),
	RTRIM(id_brg),
	tgl_pros,
	tgl_link,
	q_max,
	q_min,
	q_akhir,
	q_order,
	RTRIM(id_link),
	flag,
	'Admin',
	GETDATE()

FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM hist_std')
GO
UPDATE dbo.StandarStokHistory SET
	TglLink=NULL
WHERE  YEAR(TglLink)=1899
GO
--SELECT * FROM  dbo.StandarStokHistory
GO

	
